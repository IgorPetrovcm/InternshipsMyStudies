namespace SeaBattle.Presenter.Context;

using SeaBattle.Presenter.Views;

public class ViewsContext{

    private readonly IEnumerable<IView> _views;

    public ViewsContext(IEnumerable<IView> views){
        _views = views;
    }

    public void View(Type viewType){
        _views
            .Where(x => x.GetType() == viewType)
            .First()
            .Launch();
    }
}