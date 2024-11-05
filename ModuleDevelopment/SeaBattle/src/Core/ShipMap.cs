using System.Runtime.ConstrainedExecution;

namespace SeaBattle.Core;

public class ShipMap{
    private const int LINES = 10;
    private const int COLUMNS = 10; 

    private int[,] map = new int[LINES,COLUMNS];

    public ShipMap(){
        for (int i = 0; i < LINES; i++){
            for (int j = 0; j < COLUMNS; j++){
                map[i,j] = 0;
            }
        }
    }

    public void Write(int mark, int line, int column){
        map[line, column] = mark;
    }

    public int Read(int line, int column){
        return map[line, column];
    }
}