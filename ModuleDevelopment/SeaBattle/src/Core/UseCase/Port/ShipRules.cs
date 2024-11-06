using System.Security.Cryptography.X509Certificates;

namespace SeaBattle.Core.UseCase.Port;

public class ShipRules{
    private readonly ShipMap Map;

    private Dictionary<SideDirection, Func<Tuple<int,int>, Tuple<int,int>>> sideShiftFuncs = 
        new Dictionary<SideDirection, Func<Tuple<int, int>, Tuple<int, int>>>{
            { SideDirection.Down, (x) => {
                return Tuple.Create(x.Item1 + 1, x.Item2);
            }},
            { SideDirection.Up, (x) => {
                return Tuple.Create(x.Item1 - 1, x.Item2);
            }},
            { SideDirection.Left, (x) => {
                return Tuple.Create(x.Item1, x.Item2 - 1);
            }},
            { SideDirection.Right, (x) => {
                return Tuple.Create(x.Item1, x.Item2 + 1);
            }}
        };

    public ShipRules(ShipMap map){
        Map = map;
    }

    public Func<Tuple<int,int>, Tuple<int,int>> FactoryOfSideShiftFuncs(SideDirection sideDirection){
        return sideShiftFuncs[sideDirection];
    }

    public bool IsInsert(int line, int column){

        if (Map.Read(line, column) == 2){
            if (column == 0){
                return InsertAlgh(3, 2, 1, line, column, true);
            }
            else if (column == 9){
                return InsertAlgh(3, 2, -1, line, column, true);
            }
            else if (line == 0){
                return InsertAlgh(3, 1, 1, line, column, true);
            }
            else if (line == 9){
                return InsertAlgh(3, 1, -1, line, column, true);
            }
        }
        else if (Map.Read(line, column) == 4){
            if (column == 0 && line == 0){
                return InsertAlgh(2, 1, 1, line, column, false);
            }
            if (column == 9 && line == 0){
                return InsertAlgh(2, 1, 1, line, column, true);
            }
            if (column == 0 && line == 9){
                return InsertAlgh(2, 1, -1, line, column, true);
            }
            if (column == 9 && line == 9){
                return InsertAlgh(2, 1, -1, line, column, false);
            }
        }
        else {
            return InsertAlgh(4, 2, 1, line, column, true);
        }

        return true;
    }

    private bool InsertAlgh(
        int numberOfSide,
        int columnCheckingCount,
        int sign,
        int line, int column,
        bool isSignEditing
    ){
        int pointSet = 0;

        for (int i = 0; i < numberOfSide; i++){
            if (i > columnCheckingCount - 1){
                pointSet = Map.Read(line, column + sign);
            }

            else {
                pointSet = Map.Read(line + sign, column);
            }

            if (pointSet != 0 && pointSet != 2 && pointSet != 4){
                return false;
            }

            if (isSignEditing){
                sign *= -1;
            }
        }
        
        return true;
    }

    public void RecognizePoints(
        int line,
        int column,
        SideDirection direction,
        int numberOfDecks
    ){
        
    }


    // public bool isInsert(Tuple<int, int>[] points){
    //     for (int i = 0; i < points.Length; i++){
    //         int line = points[i].Item1;
    //         int column = points[i].Item2;
            
    //         if ((line != 0 || line != 9) && (column != 0 || column != 9)){

    //         }
    //     }

    //     return false;
    // }
}