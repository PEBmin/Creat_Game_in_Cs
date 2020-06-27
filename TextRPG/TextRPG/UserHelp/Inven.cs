using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Inven
{
    Item[] ArrItem;
    int xLen;
    int X;
    int Y;
    int SelectIndex;
    int InvenSize;

    public int Ivensize()
    { { return InvenSize; } }

    public Inven(int _X, int _Y)
    {
        X = _X;
        Y = _Y;
        InvenSize = X * Y;

        if (X < 0)
            X = 1;
        if (Y < 0)
            Y = 1;

        ArrItem = new Item[X * Y];
        xLen = X;
    }
    public void Render()
    {
        for (int i = 0; i< ArrItem.Length; i++)
        {
            if ((i % xLen) == 0)
                Console.WriteLine("");

            if (i == SelectIndex)
                Console.Write("▣");
            else if (ArrItem[i] == null)
                Console.Write("□");
            else
                Console.Write("■");
        }

        Console.WriteLine("");
        if (ArrItem[SelectIndex] == null)
        {
            Console.WriteLine("");
            Console.WriteLine("해당칸은 비어 있습니다.");
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("현재 선택된 아이템");
            Console.WriteLine("이름: " + ArrItem[SelectIndex].Name);
            Console.WriteLine("가격: " + ArrItem[SelectIndex].Gold);
        }
    }

    public void GetItem(Item _item)
    {
        int Index = 0;
        for (int i = 0; i < ArrItem.Length; i++)
        {
            if (ArrItem[Index] == null)
            { 
                ArrItem[i] = _item; 
                return; 
            }
            else
            { 
                Index++; 
                continue; 
            }
        }
    }

    public int GetItem()
    {
        int Index = 0;

        for (int i = 0; i < ArrItem.Length; i++)
        {
            if (ArrItem[Index] == null)
            {  }
            else
            { Index++; continue; }
        }
        return Index;
    }


    public bool OverCheck(int ChecIndex)
    {
        if (ChecIndex < 0 || ChecIndex > InvenSize - 1)
        {
            return true;
        }
        return false;
    }

    public void SelectMove(int Select)
    {
        int CheckIndex = SelectIndex;
        CheckIndex += Select;

        if (true == OverCheck(CheckIndex))
        {
            return;
        }

        SelectIndex += Select;
    }
    public int GetxLen()
    {
        return xLen;
    }
}
