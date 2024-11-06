namespace SeaBattle;

using SeaBattle.Presenter;
using SeaBattle.Presenter.Views;
using SeaBattle.Presenter.Markups;
using SeaBattle.Context;
using System.Reflection;
using SeaBattle.Context;
using SeaBattle.Presenter.Context;
using System.Data;

public class Program{

    public static void Main(){

        Console.Clear();

        SeaBattleApplication battleApplication = new SeaBattleApplication(typeof(ViewsConfiguration));

        ViewsContext viewsContext = new ViewsContext(battleApplication.Supply<IView>());

        viewsContext.View(typeof(GamePreparationView));
    }
}
