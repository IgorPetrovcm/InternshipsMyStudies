namespace SeaBattle.Presenter;

public class RequestFromView{
    public readonly Type Redirect;

    public RequestFromView(){

    }
    
    public RequestFromView(Type redirect){
        Redirect = redirect;
    }
}