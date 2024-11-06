namespace SeaBattle.Core.UseCase;

using SeaBattle.Core;

public class MapEditor{
    private readonly ShipMap Map;

    public MapEditor(ShipMap map){
        Map = map;
    }

    public void RecognizePoints(
        int line,
        int column,
        SideDirection direction,
        int numberOfDecks
    ){
        
    }

    // public void AddShip(int length, SideDirection direction, int line, int column){
        
    // }

}