namespace SeaBattle.Presenter.Views;

public class MainMenuView : IView{
    private readonly LinkedList<UserPoint> points;

    private Dictionary<LinkedListNode<UserPoint>, Action> _executablePoints;

    public MainMenuView(LinkedList<UserPoint> points, IEnumerable<Action> actions){
        if (points.Count != actions.Count()){
            throw new ArgumentException("The number of points and number of actions must match");
        }
        
        this.points = points;

        List<Action> actionsArr = actions.ToList();

        _executablePoints = new Dictionary<LinkedListNode<UserPoint>, Action>();

        LinkedListNode<UserPoint>? point = points.First;

        for (int i = 0; point != null; i++){
            _executablePoints.Add(point, actionsArr[i]);

            point = point.Next;
        }
    }

    public RequestFromView Launch(){
        LinkedListNode<UserPoint>? selectedPoint = points.First;
        
        while (true){
            Console.Clear();

            ConsolePrinter.Print(
                linkedPoints: points,
                specifyPoint: selectedPoint,
                specifyColor: ConsoleColor.Gray,
                defaultColor: ConsoleColor.Yellow
            );

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key) {
                case ConsoleKey.UpArrow:
                    selectedPoint = selectedPoint?.Previous ?? selectedPoint;
                break;
                
                case ConsoleKey.DownArrow:
                    selectedPoint = selectedPoint?.Next ?? selectedPoint;
                break;

                case ConsoleKey.Enter:
                    _executablePoints[selectedPoint].Invoke();
                    return new RequestFromView(null);

                default:
                break;
            }
        }

    }
}