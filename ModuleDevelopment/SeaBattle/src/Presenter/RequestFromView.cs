namespace SeaBattle.Presenter;

public class RequestFromView{
    public Type Redirect {
        get => Redirect;
        init => Redirect = value;
    }

    public bool Refresh {
        get => Refresh;
        init => Refresh = value;
    }

    public Object Body {
        get => Body;
        init => Body = value;
    }

    public RequestFromView(){

    }
    
    public RequestFromView(Type redirect){
        Redirect = redirect;
    }

    public RequestFromView(Type redirect, Object body){
        Redirect = redirect;
        Body = body;
    }

    public RequestFromView(Type redirect, Object body, bool refresh){
        Redirect = redirect;
        Body = body;
        Refresh = refresh;
    }
}