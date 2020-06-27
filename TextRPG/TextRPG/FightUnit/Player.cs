using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Player : FightUnit, QuestUnit
{
    const int HealHP = 10;
    const int EnAT = 50;

    int HaveGold;

    Inven NewInven = new Inven(5, 3);

    public Player(string _name)
    {
        name = _name;
        HaveGold = 5000;
    }

    public int GetGold()
    {
        return HaveGold;
    }
    public void Enhance()
    {
        Console.WriteLine("");
        if (AT >= MAXAT)
            Console.WriteLine("더이상 무기를 강화할 수 없습니다.");
        else
        {
            Console.WriteLine("무기를 " + EnAT + " 만큼 강화했습니다.");
            AT += EnAT;
        }

    }
    public void Recovery()
    {
        Console.WriteLine("");
        if (HP >= MAXHP)
            Console.WriteLine("더이상 회복할 수 없습니다.");
        else
        {
            Console.WriteLine("체력이 " + HealHP + " 만큼 증가합니다.");
            HP += HealHP;
        }
    }

    public void Talk(FightUnit Otherunit)
    {
        Console.WriteLine(name + "이 " + Otherunit.Getname() + "에게 말을 걸었습니다.");
    }

    public void InvenRender(ConsoleKey SelectKey)
    {
        NewInven.Render();

        SelectByKey(SelectKey);
    }
    public bool GetItem(Item _item)
    {
        if (_item.Gold > HaveGold)
        {
            Console.WriteLine("현재 가지고 있는 돈이 부족합니다.");
            return false;
        }
        NewInven.GetItem(_item);
        HaveGold -= _item.Gold;
        return true;
    }

    public void StutueRender(Info.NOWMODE nowMode)
    {

        if (nowMode == Info.NOWMODE.STOREMODE)
        {
            Console.WriteLine("");
            Console.WriteLine("현재" + name + "의 상태");
            Console.WriteLine("----------------------------");
            Console.WriteLine("인벤토리 공간: " + NewInven.GetItem() + " / " + NewInven.Ivensize());
            Console.WriteLine("사용가능 골드: " + HaveGold);
            Console.WriteLine("----------------------------");
        }
    }

    public void SelectByKey(ConsoleKey Key)
    {
        switch (Key)
        {
            case ConsoleKey.UpArrow:
                NewInven.SelectMove(-NewInven.GetxLen());
                break;
            case ConsoleKey.DownArrow:
                NewInven.SelectMove(NewInven.GetxLen());
                break;
            case ConsoleKey.RightArrow:
                NewInven.SelectMove(1);
                break;
            case ConsoleKey.LeftArrow:
                NewInven.SelectMove(-1);
                break;
            default:
                Console.WriteLine("방향키만 가능합니다.");
                break;
        }
    }
}
