namespace SeaBattle.Core.UseCase;

using System.Dynamic;
using SeaBattle.Core;
using SeaBattle.Core.UseCase.Port;

public class MapEditor{
    private readonly ShipMap Map;

    private readonly ShipRules Rules;

    public MapEditor(ShipMap map, ShipRules rules){
        Map = map;
        Rules = rules;
    }

    public Tuple<int, int> ShiftPointToSide(
        Tuple<int, int> point,
        SideDirection sideDirection
    ){
        return Rules.FactoryOfSideShiftFuncs(sideDirection).Invoke(point);
    }

    public Tuple<int, int> ShiftPointToSide(
        Tuple<int, int> point,
        int numberOfDeck,
        SideDirection sourceSideDirection,
        SideDirection targetSideDirection
    ){
        Tuple<int, int> result = Tuple.Create(0,0);
        
        int iterationDirection = numberOfDeck - 1;

        int sign = 2;

        if (sourceSideDirection != (SideDirection)1 && sourceSideDirection != (SideDirection)2){
            sign *= -1;
        }
        
        SideDirection alternativeTargerSideDirection = (SideDirection)((int)sourceSideDirection + sign);

        for (int i = 0; i < numberOfDeck; i++){
            result = Rules.FactoryOfSideShiftFuncs(targetSideDirection).Invoke(point);
        }

        for (int i = 0; i < numberOfDeck; i++){
            result = Rules.FactoryOfSideShiftFuncs(alternativeTargerSideDirection).Invoke(result);
        }

        return result;
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