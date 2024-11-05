namespace SeaBattle.Presenter.Markups;

public class BattleMapConsoleMarkup : IConsoleMarkup{

    private int _currentLeft = Console.CursorLeft + 4;

    private int _currentTop = Console.CursorTop + 1;

    private int _iteratorCount;

    private int _fixedIteratorCount;

    public BattleMapConsoleMarkup(int iteratorCount){
        _fixedIteratorCount = iteratorCount;
        _iteratorCount = iteratorCount;
    }  

    public UserPoint InsertPoint(string title){
        UserPoint userPoint = new UserPoint();

        userPoint.Title = title;

        userPoint.Left = _currentLeft + (Math.Abs(_iteratorCount - _fixedIteratorCount) * 8);

        userPoint.Top = _currentTop;

        if (_iteratorCount == 0){
            userPoint.Top += 4;

            _currentTop += 4;

            _iteratorCount = _fixedIteratorCount;
        }
    
        _iteratorCount--;

        return userPoint;
    }
}