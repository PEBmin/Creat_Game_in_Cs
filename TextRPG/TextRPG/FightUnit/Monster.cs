using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Monster : FightUnit
{
    public Monster(int num)
    {
        name = "오크" + num.ToString();
        HP = 60;
        AT = 15;
    }
}
