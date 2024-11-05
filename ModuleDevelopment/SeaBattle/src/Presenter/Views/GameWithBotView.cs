namespace SeaBattle.Presenter.Views;

public class GameWithBotView : IView{
    public RequestFromView Launch(){
        return new RequestFromView(null);
    }
}