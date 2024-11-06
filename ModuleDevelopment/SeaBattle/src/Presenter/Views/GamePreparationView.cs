namespace SeaBattle.Presenter.Views;

using SeaBattle.Core;
using SeaBattle.Core.UseCase;

public class GamePreparationView : IView{
    private readonly int PointMultiplier;
    
    private readonly UserPoint[,] BattleMapPoints;

    private readonly Dictionary<UserPoint, Action> ExecutableBattleMapPoints;

    private readonly MapEditor MapUseCase;
    
    public GamePreparationView(
        UserPoint[,] battleMapPoints,
        Action[,] battleMapActions,
        int battleMapPointMultiplier,
        MapEditor mapUseCase
    ){
        PointMultiplier = battleMapPointMultiplier;
        BattleMapPoints = battleMapPoints;
        ExecutableBattleMapPoints = new Dictionary<UserPoint, Action>();
        MapUseCase = mapUseCase;

        for (int i = 0; i < PointMultiplier; i++){
            for (int j = 0; j < PointMultiplier; j++){
                ExecutableBattleMapPoints.Add(BattleMapPoints[i,j], battleMapActions[i,j]);
            }
        }
    }
    
    public RequestFromView Launch(){
        Tuple<int, int> specifyPoint = new Tuple<int, int>(4, 4);
        Tuple<int, int>[] staticSpecifyPoints = { new Tuple<int, int>(1,2) };

        SideDirection currentSideDirection;
        
        while (true){
            Console.Clear();

            ConsolePrinter.Print(
                BattleMapPoints,
                PointMultiplier,
                specifyPoint,
                staticSpecifyPoints,
                ConsoleColor.Gray,
                ConsoleColor.Yellow,
                ConsoleColor.Green
            );

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            
            switch (keyInfo.Key){
                case ConsoleKey.UpArrow:
                    specifyPoint = MapUseCase.ShiftPointToSide(specifyPoint, SideDirection.Up);
                break;
                case ConsoleKey.DownArrow:
                    specifyPoint = MapUseCase.ShiftPointToSide(specifyPoint, SideDirection.Down);
                break;
                case ConsoleKey.LeftArrow:
                    specifyPoint = MapUseCase.ShiftPointToSide(specifyPoint, SideDirection.Left);
                break;
                case ConsoleKey.RightArrow:
                    specifyPoint = MapUseCase.ShiftPointToSide(specifyPoint, SideDirection.Right);
                break;
            }
        }
    }
}