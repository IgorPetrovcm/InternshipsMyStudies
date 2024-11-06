namespace SeaBattle.Core.UseCase;

using SeaBattle.Core;
using SeaBattle.Core.UseCase.Port;

public class MapEditor{
    private readonly ShipMap Map;

    private readonly ShipRules Rules;

    public MapEditor(ShipMap map, ShipRules rules){
        Map = map;
        Rules = rules;
    }

    public Tuple<int, int>? ShiftPointToSide(
        Tuple<int, int> point,
        SideDirection sideDirection
    ){    
        Tuple<int, int> result = Rules.FactoryOfSideShiftFuncs(sideDirection).Invoke(point);     
        
        if (!Rules.IsInsert(result.Item1, result.Item2)){
            return null;
        } 

        return result;
    }

    public Tuple<int, int>? ShiftPointToSide(
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

        if (!Rules.IsInsert(result.Item1, result.Item2)){
            return null;
        }

        return result;
    }

    public void WritePoints(Tuple<int, int> point){
        Map.Write(1, point.Item1, point.Item2);
    }

    public void RecognizePoints(
        int line,
        int column,
        SideDirection direction,
        int numberOfDecks
    ){
        
    }
}