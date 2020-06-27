using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NPC : FightUnit, QuestUnit
{
    string[] item = { "무기", "갑옷", "투구", "바지", "포션", "신발" };
    int[] gold = { 1000, 500, 500, 50, 100 };

    Item[] NPCitem = new Item[5];

    Inven NPCInven = new Inven(5, 3);

    public NPC(string _name)
    {
        name = _name;
        for (int i = 0; i < NPCitem.Length; i++)
        {
            NPCitem[i] = new Item(item[i], gold[i]);
            NPCInven.GetItem(NPCitem[i]);
        }
    }

    public void InvenRender(ConsoleKey SelectKey)
    {
        NPCInven.Render();

        SelectByKey(SelectKey);
    }

    public void Talk(FightUnit Otherunit)
    {
        Console.WriteLine(name + "이 " + Otherunit.Getname() + "에게 말을 걸었습니다.");
    }

    public void ShowItem(Player Newplayer)
    {
        while(true)
        {
            Console.Clear();
            Console.WriteLine("무슨 아이템을 구입하시겠습니까?");
            Console.WriteLine(" ");

            for (int i = 0; i < NPCitem.Length; i++)
            {
                Console.Write(i + "." + NPCitem[i].Name +" - "+ NPCitem[i].Gold + " Gold");
                Console.WriteLine("");
            }
            Console.WriteLine(NPCitem.Length + ".아무것도 사지 않는다.");
            Console.WriteLine("");

            string InItemNumber = Console.ReadLine();
            try { 
                int Index = Convert.ToInt32(InItemNumber);
                if (Index == NPCitem.Length)
                    return;

                if(Newplayer.GetItem(NPCitem[Index]))
                    Console.WriteLine(Newplayer.Getname() + "가 " + NPCitem[Index].Name + "를 " +NPCitem[Index].Gold+ "에 구매 했습니다.");
                Console.WriteLine("");
                Console.WriteLine("현재 남아 있는 돈은 " + Newplayer.GetGold() + "원 입니다.");
                Console.ReadKey();
            }

            catch { 
                Console.WriteLine("입력한 값이 범위에서 벗어납니다.");
                Console.ReadKey();
                continue; 
            }

            
        }
    }

    public void SelectByKey(ConsoleKey Key)
    {
        switch (Key)
        {
            case ConsoleKey.UpArrow:
                NPCInven.SelectMove(-NPCInven.GetxLen());
                break;
            case ConsoleKey.DownArrow:
                NPCInven.SelectMove(NPCInven.GetxLen());
                break;
            case ConsoleKey.RightArrow:
                NPCInven.SelectMove(1);
                break;
            case ConsoleKey.LeftArrow:
                NPCInven.SelectMove(-1);
                break;
            default:
                Console.WriteLine("방향키만 가능합니다.");
                break;
        }
    }
}

