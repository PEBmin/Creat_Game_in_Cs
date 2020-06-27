using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisTest
{
    enum TBlock
    {
        VOID,
        WALL,
    }
    static class Constants
    {
        public const int ScreenWidth = 5;
        public const int ScreenHeight = 10;
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

        public void SetBlock(int _x, int _y, TBlock block)
        {
            BlockList[_y][_x] = block;
        }
        public bool Tetris_Shift(ref BlockPoint block, int direc)
        {
            BlockPoint next = new BlockPoint();
            next.x += direc;
            if (direc == 0)
                next.y += 1;

            block = next;
            return true;
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
                    }
                }
                Console.WriteLine();
            }
        }
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
        }
    }

    class TetrisMove
    {
    }

}
