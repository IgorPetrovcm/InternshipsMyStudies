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
}