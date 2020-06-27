using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Battle
{
    public static Info.STARTSELECT InBattle(Player player)
    {
        Monster monster = new Monster(1);
        while (true)
        {
            int num = 0;
            Info.SelectInfo(Info.NOWMODE.BATTLEMODE);
            Console.WriteLine("");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    num = Console.Read();
                    MonsterPlus(num);
                    Console.ReadKey();
                    break;
                case ConsoleKey.D2:
                    BattleStart(player, monster);
                    Console.WriteLine("마을로 귀환합니다.");
                    Console.ReadKey();
                    return Info.STARTSELECT.TOWNSELECT;
                case ConsoleKey.D3:
                    Console.WriteLine("");
                    Console.WriteLine("싸움터에서 떠납니다.");
                    return Info.STARTSELECT.NONSELECT;
            }
        }
    }

    static void BattleStart(Player NewPlayer, Monster NewMonster)
    {

        while (NewMonster.UserHealth() && NewPlayer.UserHealth())
        {
            Console.Clear();
            NewPlayer.StutueRender();
            NewMonster.StutueRender();

            FightUnit.Battle(NewPlayer, NewMonster);
            Console.ReadKey();
        }
        Console.WriteLine("싸움이 결판이 났습니다.");
        Console.WriteLine("");
        if (NewMonster.UserHealth())
            Console.WriteLine("몬스터에 의해 죽었습니다..");
        else
            Console.WriteLine("게임에서 승리했습니다!!");
        Console.ReadKey();
    }

    static void MonsterPlus(int num)
    {
        for (int i = 0; i < num; i++)
        {
            Monster monster = new Monster(i);
        }
    }
}

