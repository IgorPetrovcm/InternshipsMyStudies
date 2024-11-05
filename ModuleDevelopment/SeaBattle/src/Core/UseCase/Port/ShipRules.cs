namespace SeaBattle.Core.UseCase.Port;

public class ShipRules{
    private readonly ShipMap Map;

    public ShipRules(ShipMap map){
        Map = map;
    }

    public bool isInsert(Tuple<int, int>[] points){
        for (int i = 0; i < points.Length; i++){
            int line = points[i].Item1;
            int column = points[i].Item2;
            
            if ((line != 0 || line != 9) && (column != 0 || column != 9)){

            }
        }

        return false;
    }
}