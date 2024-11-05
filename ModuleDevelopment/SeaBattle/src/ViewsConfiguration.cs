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
            () => new RequestFromView(typeof(GameWithBotView)),
            () => System.Environment.Exit(0)
        };

        return new MainMenuView(
            markup: markup,
            points: points,
            actions: actions
        );
    }
}