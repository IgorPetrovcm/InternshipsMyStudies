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

        SeaBattleApplication battleApplication = new SeaBattleApplication(typeof(ViewsConfiguration));

        ViewsContext viewsContext = new ViewsContext(battleApplication.Supply<IView>());

        viewsContext.View(typeof(GamePreparationView));
        
        // Console.Clear();
        
        // int[,] battleMap = new int[10,10];

        // int currentLeft = Console.CursorLeft + 4;
        // int currentTop = Console.CursorTop + 1;

        // for (int i = 0; i < 10; i++){
        //     int tempLeft = currentLeft;
        //     int tempTop = currentTop;
            
        //     for (int j = 0; j < 10; j++){
        //         Console.SetCursorPosition(tempLeft, tempTop);

        //         battleMap[i,j] = 0;

        //         if (i == 5 && j == 5){
        //             Console.ForegroundColor = ConsoleColor.Green;
        //         }

        //         Console.Write("E");
        //         Console.SetCursorPosition(tempLeft - 1, tempTop + 1);
        //         Console.Write("EEE");
        //         Console.SetCursorPosition(tempLeft, tempTop + 2);
        //         Console.Write("E");

        //         Console.ResetColor();

        //         tempLeft += 8;
        //     }

        //     currentTop += 4;
        // }

        // while (true){
        //     ConsoleKeyInfo keyInfo = Console.ReadKey();

        //     switch (keyInfo.Key){
        //         case ConsoleKey.UpArrow:
                    
        //     }
        // }
        
    }
}
