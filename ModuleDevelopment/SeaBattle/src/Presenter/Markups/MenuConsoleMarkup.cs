namespace SeaBattle.Presenter.Markups;

public class MenuConsoleMarkup : IConsoleMarkup{
    private int _topValue = 0;

    public UserPoint InsertPoint(string title){
        UserPoint point = new UserPoint();

        point.Title = title;

        _topValue = _topValue == 0 
            ? Console.BufferHeight / 2
            : ++_topValue ;

        point.Top = _topValue;
        
        point.Left = Console.BufferWidth / 2 - (title.Length / 2);

        return point;
    }
}
