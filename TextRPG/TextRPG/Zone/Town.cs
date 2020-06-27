using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Town
{
    public static void InTown(Player player)
    {
        NPC NewNPC = new NPC("마을 주민");
        while (true)
        {
            Info.SelectInfo(Info.NOWMODE.TOWNMODE);
            Console.WriteLine("");
            player.StutueRender();

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    player.Recovery();
                    Console.ReadKey();
                    break;
                case ConsoleKey.D2:
                    player.Enhance();
                    Console.ReadKey();
                    break;
                case ConsoleKey.D3:
                    player.Talk(NewNPC);
                    Console.ReadKey();
                    break;
                case ConsoleKey.D4:
                    Console.WriteLine("");
                    Console.WriteLine("마을에서 떠납니다.");
                    return;
            }
        }
    }
}

