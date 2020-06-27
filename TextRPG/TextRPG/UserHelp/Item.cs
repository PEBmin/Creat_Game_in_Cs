using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Item
{
    string name;
    int gold;

    public int Gold
    { get { return gold; } }
    public string Name
    { get { return name; } }
    public Item(string _name, int _gold)
    {
        if (_name == null)
            name = "이름 없음";
        if (_gold == 0)
            gold = 50;
        name = _name;
        gold = _gold;
    }
}
