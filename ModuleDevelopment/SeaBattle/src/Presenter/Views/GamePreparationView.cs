namespace SeaBattle.Presenter.Views;

public class GamePreparationView : IView{
    public RequestFromView Launch(){
        return new RequestFromView(null);
    }
}