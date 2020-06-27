using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum TBlock
{
    VOID,
    WALL,
    BLOCK, // TBlock
}
class TetrisScreen
{
    List<List<TBlock>> BlockList = new List<List<TBlock>>();

    int X_Len;
    public int X_len()
    {
        { return X_Len; }
    }
    int Y_Len;


    public TetrisScreen(int Size_x, int Size_y)
    {
        for (int y = 0; y < Size_y; ++y)
        {
            BlockList.Add(new List<TBlock>());
            for (int x = 0; x < Size_x; ++x)
            {
                BlockList[y].Add(0);
            }
        }
        
        X_Len = Size_x;
        Y_Len = Size_y;
    }

    public void SetBlock(int _X, int _Y, TBlock _block)
    {
        BlockList[_Y][_X] = _block;
    }
    public void DrawScreen()
    {
        Console.Clear();
        for (int y = 0; y < BlockList.Count; ++y)
        {
            for (int x = 0; x < BlockList[y].Count; ++x)
            {
                switch (BlockList[y][x])
                {
                    case TBlock.VOID:
                        Console.Write("□");
                        break;
                    case TBlock.WALL:
                        Console.Write("■");
                        break;
                    case TBlock.BLOCK:
                        Console.Write("▣");
                        break;
                }
            }
            Console.WriteLine();
        }
    }
   
    public void Init()
    {
        for (int y = 0; y < Y_Len - 1; ++y)
        {
            for (int x = 0; x < X_Len; ++x)
            {
                if (BlockList[y][x] == TBlock.WALL)
                    continue;
                BlockList[y][x] = TBlock.VOID;
            }
        }

        for(int x = 0; x < X_Len; ++x)
        {
            BlockList[Y_Len-1][x] = TBlock.WALL;
        }
    }
    public bool Over(int nextX, int nextY)
    {
        if (nextX < 0 || nextY < 0 || nextY > BlockList.Count - 1 || nextX > BlockList[nextY].Count - 1)
        {
            return true;
        }
        return false;

    }
    public TBlock GetBlock(int x, int y)
    {
        return BlockList[y][x];
    }

    public void CheckBingo()
    {
        bool[] BingoIndex = new bool[20];

        for (int y = 0; y < Y_Len - 1; ++y)
        {
            BingoIndex[y] = false;
            int BlockCount = 0;

            for (int x = 0; x < X_Len; ++x)
            {
                if (BlockList[y][x] == TBlock.VOID)
                    break;
                else
                    BlockCount++;
            }
            if (BlockCount == 10)
            {
                BingoIndex[y] = true;
            }
        }
        List<TBlock> NewLine = new List<TBlock>();
        for(int i = 0; i < X_Len; i++)
        {
            NewLine.Add(TBlock.VOID);
        }

        for(int i = 0; i< BingoIndex.Length; i++)
        {
            if(BingoIndex[i] == true)
            {
                BlockList.RemoveAt(i);
                BlockList.Insert(0, NewLine);
            }
        }
    }
}

