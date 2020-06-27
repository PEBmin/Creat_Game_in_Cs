using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace TetrisTest
{
    class Form
    {
        public static string inp_buf_queue;
        public static int inp_head;
        public static int inp_tail;
    }
    class Tetris
    {
        public BlockPoint blockPoint = new BlockPoint();

        public void Tetris_init()
        {
            blockPoint.x = 0;
            blockPoint.y = 0;
        }
    }

    class Entry
    {
        static void Main(string[] args)
        {
            TetrisScreen tYpeScreen = new TetrisScreen(Constants.ScreenWidth, Constants.ScreenHeight);
            Tetris tetris = new Tetris();
            tetris.Tetris_init();

            for (; ; )
            {
                
                switch (pad.Key)
                {
                    case ConsoleKey.UpArrow:
                        break;

                    case ConsoleKey.DownArrow:
                        tYpeScreen.Tetris_Shift(ref tetris.blockPoint, 0);
                        break;

                    case ConsoleKey.RightArrow:
                        tYpeScreen.Tetris_Shift(ref tetris.blockPoint, 1);
                        break;

                    case ConsoleKey.LeftArrow:
                        tYpeScreen.Tetris_Shift(ref tetris.blockPoint, -1);
                        break;
                }
                tYpeScreen.SetBlock(tetris.blockPoint.x, tetris.blockPoint.y, TBlock.WALL);
                tYpeScreen.Render();
            }

            void input_thread()
            {
                for(; ; ) 
                {
                    string ch = Console.ReadLine();
                    Form.inp_buf_queue = ch;
                }
            }

            char input_next()
            {
                string[]
            }
        }
    }
}
