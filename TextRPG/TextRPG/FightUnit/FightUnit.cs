using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FightUnit
{
    protected string name = "none";
    protected int AT = 10;
    protected int HP = 50;
    protected int MAXAT = 1000;
    protected int MAXHP = 100;

    public int GetAT() { return AT; }
    public int GetHP() { return HP; }

    public string Getname() { return name; }
    public void StutueRender()
    {
        Console.WriteLine("");
        Console.WriteLine("현재" + name + "의 상태");
        Console.WriteLine("----------------------------");
        Console.WriteLine("공격력: " + AT);
        Console.WriteLine("체력: " + HP + "/" + MAXHP);
        Console.WriteLine("----------------------------");
    }

    public bool UserHealth()
    {
        if (HP <= 0)
            HP = 0;
        return !(HP <= 0);
    }

    public void Suffer(FightUnit fightUnit)
    {
        Console.WriteLine(fightUnit.name + "가 " + name + "을 공격합니다.");
        HP -= fightUnit.AT;
        Console.WriteLine(name + "의 체력이 " + HP + "가 되었습니다....");
        Console.WriteLine("");
    }

    static public void Battle(Player NewPlayer, Monster NewMonster)
    {
        Random random = new Random();

        string[] str = { "MonsterSuffer", "PlayerSuffer" };
        int selectA = random.Next(str.Length);

        if (str[selectA] == "PlayerSuffer")
        {

            NewPlayer.Suffer(NewMonster);

            if (NewPlayer.UserHealth())
            {
                NewMonster.Suffer(NewPlayer);
            }
        }
        else if (str[selectA] == "MonsterSuffer")
        {
            NewMonster.Suffer(NewPlayer);

            if (NewPlayer.UserHealth())
            {
                NewPlayer.Suffer(NewMonster);
            }
        }
    }
}
