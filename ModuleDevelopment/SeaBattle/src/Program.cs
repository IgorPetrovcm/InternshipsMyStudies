namespace SeaBattle;

using SeaBattle.Presenter;
using SeaBattle.Presenter.Views;
using SeaBattle.Presenter.Markups;
using SeaBattle.Context;
using System.Reflection;
using SeaBattle.Context;
using SeaBattle.Presenter.Context;

public class Program{

    public static void Main(){

        SeaBattleApplication battleApplication = new SeaBattleApplication(typeof(ViewsConfiguration));

        ViewsContext viewsContext = new ViewsContext(battleApplication.Supply<IView>());

        viewsContext.View(typeof(MainMenuView));
    //     IConsoleMarkup markup = new MenuConsoleMarkup();

    //     List<UserPoint> userPoints = new List<UserPoint>(){
    //         markup.InsertPoint("Start game with Bot"),
    //         markup.InsertPoint("Exit")
    //     };

    //     LinkedList<UserPoint> linkedUserPoints = new LinkedList<UserPoint>(userPoints);

    //     Console.Clear();

    //     MainMenuView menu = new MainMenuView(markup, linkedUserPoints);

    //     menu.Launch();

        
    
    }
}
