namespace SeaBattle.Core.UseCase.Port;

public class ShipRules{
    private readonly ShipMap Map;

    public ShipRules(ShipMap map){
        Map = map;
    }

    public bool IsInsert(int line, int column){
        int sign = 1;

        int pointSet = 0;

        for (int i = 0; i < 4; i++){
            if (i > 1){
                pointSet = Map.Read(line, column + sign);
            }
            else {
                pointSet = Map.Read(line + sign, column);
            }

            if (pointSet != 0){
                return false;
            }

            sign *= -1;
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