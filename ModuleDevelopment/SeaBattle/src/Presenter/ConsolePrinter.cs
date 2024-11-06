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
                UserPoint point = twoDimensionalPoints[i, j];
                
                Console.SetCursorPosition(
                    point.Left,
                    point.Top
                );
                Console.Write(point.Title);

                Console.SetCursorPosition(
                    point.Left - 1,
                    point.Top + 1
                );
                Console.Write(String.Concat(Enumerable.Repeat(point.Title, 3)));

                Console.SetCursorPosition(
                    point.Left,
                    point.Top + 2
                );
                Console.Write(point.Title);
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
        Console.ForegroundColor = defaultColor;

        for (int i = 0; i < pointMultiplier; i++){
            for (int j = 0; j < pointMultiplier; j++){
                UserPoint point = twoDimensionalPoints[i, j];

                
            }
        }
    }
}