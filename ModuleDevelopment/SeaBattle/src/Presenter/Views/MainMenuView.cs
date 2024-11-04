namespace SeaBattle.Presenter.Views;

using SeaBattle.Presenter.Markups;

public class MainMenuView{
    private readonly IConsoleMarkup markup;

    private readonly LinkedList<UserPoint> points;

    private Dictionary<LinkedListNode<UserPoint>, Action> _executablePoints;

    public MainMenuView(IConsoleMarkup markup, LinkedList<UserPoint> points){
        this.markup = markup;

        this.points = points;

        _executablePoints = new Dictionary<LinkedListNode<UserPoint>, Action>();

        LinkedListNode<UserPoint> point = points.First;

        while (point != null){
            _executablePoints.Add(point, () => {
                System.Environment.Exit(-1);
            });

            point = point.Next;
        }
    }

    public void Launch(){
        LinkedListNode<UserPoint> selectedPoint = points.First;
        
        while (true){
            ConsolePrinter.Print(
                linkedPoints: points,
                specifyPoint: selectedPoint,
                specifyColor: ConsoleColor.Gray,
                defaultColor: ConsoleColor.Yellow
            );

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key) {
                case ConsoleKey.UpArrow:
                    selectedPoint = selectedPoint.Previous ?? selectedPoint;
                break;
                
                case ConsoleKey.DownArrow:
                    selectedPoint = selectedPoint.Next ?? selectedPoint;
                break;

                case ConsoleKey.Enter:
                    _executablePoints[selectedPoint].Invoke();
                break;

                default:
                break;
            }
        }
    }
}