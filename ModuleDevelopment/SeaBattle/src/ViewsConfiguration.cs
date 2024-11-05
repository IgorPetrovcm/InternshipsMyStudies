namespace SeaBattle;

using SeaBattle.Context;
using SeaBattle.Presenter.Views;
using SeaBattle.Presenter.Markups;
using SeaBattle.Presenter;

[ViewConfigurationContext]
public class ViewsConfiguration{

    [ContextComponent(typeof(MainMenuView))]
    public IView supplyMainMenu(){
        IConsoleMarkup markup = new MenuConsoleMarkup();

        List<UserPoint> userPoints = new List<UserPoint>(){
            markup.InsertPoint("Start game with Bot"),
            markup.InsertPoint("Exit")
        };

        LinkedList<UserPoint> points = new LinkedList<UserPoint>(userPoints);

        List<Action> actions = new List<Action>(2){
            () => new RequestFromView(null),
            () => System.Environment.Exit(0)
        };

        return new MainMenuView(
            points: points,
            actions: actions
        );
    }

    [ContextComponent(typeof(GamePreparationView))]
    public IView supplyGamePreparation(){
        const int pointMultiplier = 10;

        IConsoleMarkup markup = new BattleMapConsoleMarkup(10);
        
        UserPoint[,] battleMap = new UserPoint[pointMultiplier, pointMultiplier];
        Action[,] battleMapActions = new Action[pointMultiplier, pointMultiplier];

        for (int i = 0; i < pointMultiplier; i++){
            for (int j = 0; j < pointMultiplier; j++){
                battleMapActions[i, j] = () => {}; 
                battleMap[i, j] = markup.InsertPoint("E");
            }
        }

        return new GamePreparationView(
            battleMap,
            battleMapActions,
            pointMultiplier
        );
    }
}