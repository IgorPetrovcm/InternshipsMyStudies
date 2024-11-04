namespace SeaBattle;

using SeaBattle.Presenter;
using SeaBattle.Presenter.Views;
using SeaBattle.Presenter.Markups;

public class Program{

    public static void Main(){
        IConsoleMarkup markup = new MenuConsoleMarkup();

        List<UserPoint> userPoints = new List<UserPoint>(){
            markup.InsertPoint("Start game with Bot"),
            markup.InsertPoint("Exit")
        };

        LinkedList<UserPoint> linkedUserPoints = new LinkedList<UserPoint>(userPoints);

        Console.Clear();

        MainMenuView menu = new MainMenuView(markup, linkedUserPoints);

        menu.Launch();
    }
}
