using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Info
{
    static public void SelectInfo(Enum state)
    {
        Console.Clear();

        switch (state)
        {
            case NOWMODE.STARTMODE:
                Console.WriteLine("어떤 것을 선택하시겠습니까?");
                Console.WriteLine("1. 마을");
                Console.WriteLine("2. 싸움터");
                Console.WriteLine("3. 상점");
                break;
            case NOWMODE.TOWNMODE:
                Console.WriteLine("마을에서 무슨 일을 하시겠습니까?");
                Console.WriteLine("1. 체력 회복");
                Console.WriteLine("2. 무기 강화");
                Console.WriteLine("3. NPC한테 말을 건다");
                Console.WriteLine("4. 마을을 나간다.");
                break;
            case NOWMODE.BATTLEMODE:
                Console.WriteLine("싸움터에 도착하셨습니다. 무엇을 하시겠습니까?");
                Console.WriteLine("1. 오크 생성");
                Console.WriteLine("2. 오크와 싸움");
                Console.WriteLine("3. 싸움터를 나간다.");
                break;
            case NOWMODE.STOREMODE:
                Console.WriteLine("상점에서 무슨 일을 하시겠습니까?");
                Console.WriteLine("1. NPC에게 말걸기");
                Console.WriteLine("2. 인벤토리 확인");
                Console.WriteLine("3. 물건 사기");
                Console.WriteLine("4. 상점을 나간다.");
                break;
        }
    }

    public enum STARTSELECT
    {
        TOWNSELECT,
        BATTLESELECT,
        STORESELECT,
        NONSELECT,
    }

    public enum NOWMODE
    {
        STARTMODE,
        TOWNMODE,
        BATTLEMODE,
        STOREMODE,
    }

}
