public class PointCalclator
{
    public int MaxInARow
    {
        get; private set;
    }

    public int MaxRowNum
    {
        get; private set;
    }

    public int Shanten{
        get{return BingoCard.Data.SheetSize.x - MaxInARow;}
    }




    public void Calclator(Number[,] numbers)
    {
        GameData data = BingoCard.Data;
        int[] scanner = new int[data.SheetSize.x + data.SheetSize.y];
        int Count = 0;

        for (int x = 0; x < data.SheetSize.x; x++)
        {
            scanner[Count] = 0;
            for (int y = 0; y < data.SheetSize.y; y++)
            {
                if (numbers[x, y].IsOpen)
                {
                    scanner[Count]++;
                }
            }
            Count++;
        }

        for (int y = 0; y < data.SheetSize.y; y++)
        {
            scanner[Count] = 0;
            for (int x = 0; x < data.SheetSize.x; x++)
            {
                if (numbers[x, y].IsOpen)
                {
                    scanner[Count]++;
                }
            }
            Count++;
        }
        Calclate(scanner);
    }

    void Calclate(int[] scanner){
        MaxInARow = 0;
        MaxRowNum = 0;
        foreach(int num in scanner){
            if(num > MaxInARow){
                MaxInARow = num;
                MaxRowNum = 1;
            }
            else if(num == MaxInARow){
                MaxRowNum++;
            }

        }
    }
}
