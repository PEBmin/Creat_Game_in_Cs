using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TetrisGame
{
    class Program
    {
        static void Main(string[] args)
        {
            TetrisScreen NewSC = new TetrisScreen(10, 20);
            //TetrisScreen DrawSC = NewSC;
            Block NewBlock = new Block(NewSC);
            NewBlock.TetrisReset();
            while (true)
            {
                Thread.Sleep(5);
                NewSC.DrawScreen();
                NewSC.CheckBingo();
                NewSC.Init();
                NewBlock.Move();
            }
        }
    }
}