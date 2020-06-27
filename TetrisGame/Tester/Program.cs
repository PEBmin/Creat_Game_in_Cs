using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Tester
{
    enum TBlock
    {
        VOID,
        WALL,
        TEST,//
    }
    class BlockPoint
    {
        public int x;
        public int y;
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
    class TetrisScreen
    {
        List<List<TBlock>> BlockList = new List<List<TBlock>>();
        int X_len;
        int Y_len;

        public TetrisScreen(int _x, int _y)
        {
            for (int y = 0; y < _y; ++y)
            {
                BlockList.Add(new List<TBlock>());
                for (int x = 0; x < _x; ++x)
                {
                    BlockList[y].Add(0);
                }
            }

             X_len = _x;
             Y_len = _y;
        }
        public void SetBlock(int _x, int _y, TBlock block)
        {
            BlockList[_y][_x] = block;
        }

        public void Render()
        {
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
                        case TBlock.TEST:
                            Console.Write("▣");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        public bool OverCheck(List<List<TBlock>> CheckBlock)
        {
            if (CheckBlock.Count > BlockList.Count)
            {
                return true;
            }
            return false;
        }

        public void MoveBlock(int index_y, int index_x)
        {
            TBlock nextblock = BlockList[index_y][index_x];
            if(index_x > X_len || index_y>Y_len || index_y < 0 || index_x <0)
            {
                BlockList[index_y][index_x] = nextblock;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TetrisScreen tetrisScreen = new TetrisScreen(10, 20);
            tetrisScreen.Render();
        }
    }
}

