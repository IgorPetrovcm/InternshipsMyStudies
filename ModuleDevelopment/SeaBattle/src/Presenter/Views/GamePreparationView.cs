namespace SeaBattle.Presenter.Views;

public class GamePreparationView : IView{
    private readonly int PointMultiplier;
    
    private readonly UserPoint[,] BattleMapPoints;

    private readonly Dictionary<UserPoint, Action> ExecutableBattleMapPoints;
    
    public GamePreparationView(
        UserPoint[,] battleMapPoints,
        Action[,] battleMapActions,
        int battleMapPointMultiplier
    ){
        PointMultiplier = battleMapPointMultiplier;
        BattleMapPoints = battleMapPoints;
        ExecutableBattleMapPoints = new Dictionary<UserPoint, Action>();

        for (int i = 0; i < PointMultiplier; i++){
            for (int j = 0; j < PointMultiplier; j++){
                ExecutableBattleMapPoints.Add(BattleMapPoints[i,j], battleMapActions[i,j]);
            }
        }
    }
    
    public RequestFromView Launch(){
        Console.Clear();

        ConsolePrinter.Print(
            BattleMapPoints,
            PointMultiplier,
            ConsoleColor.Gray
        );

        while (true);

        return new RequestFromView(null);
    }
}