using System.Security.Cryptography.X509Certificates;

namespace SeaBattle.Presenter;

public static class ConsolePrinter{
    public static void Print(LinkedList<UserPoint> linkedPoints){
        LinkedListNode<UserPoint>? pointNode = linkedPoints.First;

        if (pointNode is null){
            throw new NullReferenceException();
        }

        while (pointNode != null){
            UserPoint point = pointNode.Value;

            Console.SetCursorPosition(point.Left, point.Top);
            Console.WriteLine(point.Title);

            pointNode = pointNode.Next;
        }
    }

    public static void Print(
        LinkedList<UserPoint> linkedPoints,
        LinkedListNode<UserPoint>? specifyPoint,
        ConsoleColor specifyColor
    ){
        LinkedListNode<UserPoint>? pointNode = linkedPoints.First;

        if (pointNode is null){
            throw new NullReferenceException();
        }

        while (pointNode != null){
            UserPoint point = pointNode.Value;

            Console.SetCursorPosition(point.Left, point.Top);
            
            if (pointNode == specifyPoint){
                Console.BackgroundColor = specifyColor;

                Console.WriteLine(point.Title);

                Console.ResetColor();
            }
            else {
                Console.WriteLine(point.Title);
            }

            pointNode = pointNode.Next;
        }
    }

    public static void Print(
        LinkedList<UserPoint> linkedPoints,
        LinkedListNode<UserPoint>? specifyPoint,
        ConsoleColor defaultColor,
        ConsoleColor specifyColor
    ){
        LinkedListNode<UserPoint>? pointNode = linkedPoints.First;

        if (pointNode is null){
            throw new NullReferenceException();
        }

        while (pointNode != null){
            UserPoint point = pointNode.Value;

            Console.SetCursorPosition(point.Left, point.Top);

            Console.ForegroundColor = defaultColor;
            
            if (pointNode == specifyPoint){
                ConsoleColor defaultBackgroundColor = Console.BackgroundColor;
                Console.BackgroundColor = specifyColor;

                Console.WriteLine(point.Title);

                Console.BackgroundColor = defaultBackgroundColor;
            }
            else {
                Console.WriteLine(point.Title);
            }

            pointNode = pointNode.Next;
        }

        Console.ResetColor();
    }

    public static void Print(
        UserPoint[,] twoDimensionalPoints,
        int pointMultiplier,
        ConsoleColor defaultColor
    ){
        Console.ForegroundColor = defaultColor;

        for (int i = 0; i < pointMultiplier; i++){
            for (int j = 0; j < pointMultiplier; j++){
                PrintBattleMap(twoDimensionalPoints[i, j]);
            }
        }

        Console.ResetColor();
    }

    public static void Print(
        UserPoint[,] twoDimensionalPoints,
        int pointMultiplier,
        Tuple<int, int>[] specifyPoints,
        ConsoleColor defaultColor,
        ConsoleColor specifyColor
    ){
        Console.ForegroundColor = specifyColor;

        for (int i = 0; i < specifyPoints.Length; i++){
            Tuple<int, int> specifyPointTuple = specifyPoints[i];

            PrintBattleMap(
                twoDimensionalPoints[specifyPointTuple.Item1, specifyPointTuple.Item2]);
        }

        Console.ForegroundColor = defaultColor;

        int[] iSpecify = specifyPoints.Select(x => x.Item1).ToArray();
        int[] jSpecify = specifyPoints.Select(x => x.Item2).ToArray();

        for (int i = 0; i < pointMultiplier; i++){
            for (int j = 0; j < pointMultiplier; j++){
                if (iSpecify.Contains(i) && jSpecify.Contains(j))
                    continue;
                
                PrintBattleMap(twoDimensionalPoints[i, j]);
            }
        }

        Console.ResetColor();
    }

    public static void Print(
        UserPoint[,] twoDimensionalPoints,
        int pointMultiplier,
        Tuple<int, int> specifyPoint,
        Tuple<int, int>[] staticSpecifyPoints,
        ConsoleColor defaultColor,
        ConsoleColor staticSpecifyColor,
        ConsoleColor specifyColor
    ){
        Console.ForegroundColor = staticSpecifyColor;

        for (int i = 0; i < staticSpecifyPoints.Length; i++){
            Tuple<int, int> staticSpecifyPointTuple = staticSpecifyPoints[i];

            PrintBattleMap(
                twoDimensionalPoints[staticSpecifyPointTuple.Item1, staticSpecifyPointTuple.Item2]);
        }

        Console.ForegroundColor = specifyColor;

        List<Tuple<int, int>> excludingFromDefaultPoints = staticSpecifyPoints
            .Append(specifyPoint)
            .ToList();

        PrintBattleMap(
            twoDimensionalPoints[specifyPoint.Item1, specifyPoint.Item2]);

        Console.ForegroundColor = defaultColor;

        int[] iSpecify = excludingFromDefaultPoints.Select(x => x.Item1).ToArray();
        int[] jSpecify = excludingFromDefaultPoints.Select(x => x.Item2).ToArray();

        for (int i = 0; i < pointMultiplier; i++){
            for (int j = 0; j < pointMultiplier; j++){
                if (excludingFromDefaultPoints.Contains(Tuple.Create(i, j)))
                    continue;
                
                PrintBattleMap(twoDimensionalPoints[i, j]);
            }
        }

        Console.ResetColor();
    }
    
    private static void PrintBattleMap(UserPoint point){
        Console.SetCursorPosition(
            point.Left,
            point.Top
        );

        Console.Write(point.Title);
    }
}