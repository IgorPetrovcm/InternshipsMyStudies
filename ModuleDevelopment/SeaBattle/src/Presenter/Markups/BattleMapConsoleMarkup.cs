namespace SeaBattle.Presenter.Markups;

public class BattleMapConsoleMarkup : IConsoleMarkup{

    private int _currentLeft = Console.CursorLeft + 4;

    private int _currentTop = Console.CursorTop + 1;

    private int _iteratorCount;

    public BattleMapConsoleMarkup(int iteratorCount){
        _iteratorCount = iteratorCount;
    }  

    public UserPoint InsertPoint(string title){
        UserPoint userPoint = new UserPoint();

        userPoint.Title = title;

        userPoint.Left = _currentLeft + (_iteratorCount * 8);

        userPoint.Top = _currentTop;

        if (_iteratorCount == 9){
            userPoint.Top += 4;

            _iteratorCount = 0;
        }

        _iteratorCount++;

        return userPoint;
    }
}