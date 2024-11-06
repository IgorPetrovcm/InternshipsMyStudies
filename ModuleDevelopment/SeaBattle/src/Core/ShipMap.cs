using System.Runtime.ConstrainedExecution;

namespace SeaBattle.Core;

public class ShipMap{
    private const int LINES = 10;
    private const int COLUMNS = 10; 

    private int[,] map = new int[LINES,COLUMNS];

    public ShipMap(){
        for (int i = 0; i < LINES; i++){
            for (int j = 0; j < COLUMNS; j++){
                if ((i == 0 || i == 9) && (j == 0 || j == 9)){
                    map[i,j] = 4;

                    continue;
                }
                if (i == 0 || i == 9 || j == 0 || j == 9){
                    map[i,j] = 2;

                    continue;
                }
                
                map[i,j] = 0;
            }
        }
    }

    public void Write(int mark, int line, int column){
        map[line, column] = mark;
    }

    public int Read(int line, int column){
        if (line < 0 || line > 9){
            return -1;
        }

        if (column < 0 || column > 9){
            return -1;
        }
        
        return map[line, column];
    }
}