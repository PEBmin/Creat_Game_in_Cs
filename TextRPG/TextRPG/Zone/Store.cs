using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Store
{
    
    public static Info.STARTSELECT InStore(Player NewPlayer)
    {
        while (true)
        {
            NPC NewNPC = new NPC("상점 주인");
            Info.SelectInfo(Info.NOWMODE.STOREMODE);
            NewPlayer.StutueRender(Info.NOWMODE.STOREMODE);

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    NewPlayer.Talk(NewNPC);
                    Console.ReadKey();
                    break;
                case ConsoleKey.D2:
                    ShopOpen(NewPlayer, NewNPC);
                    Console.ReadKey();
                    break;
                case ConsoleKey.D3:
                    NewNPC.ShowItem(NewPlayer);
                    Console.ReadKey();
                    break;
                case ConsoleKey.D4:
                    Console.WriteLine("");
                    Console.WriteLine("마을에서 떠납니다.");
                    return Info.STARTSELECT.NONSELECT;
            }
        }
    }

    public static void ShopOpen(Player NewPlayer, NPC NewNPC)
    {
        ConsoleKey SelectKey = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("인벤토리에서 나가려면 1번을 누르세요.");
            NewNPC.InvenRender(SelectKey);
            NewPlayer.InvenRender(SelectKey);
            SelectKey = Console.ReadKey().Key;
            if (SelectKey == ConsoleKey.D1)
                return;
        }
    }


}

