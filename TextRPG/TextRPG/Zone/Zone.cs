using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Zone
{
    string zonename;
    List<Zone> LinkZone = new List<Zone>();

    public Zone(string _zonename)
    {
        zonename = _zonename;
    }

    public Zone Update()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("이 곳은 " + zonename + "입니다.");

            Console.WriteLine("다음으로 이동할 수 있는 곳의 리스트입니다.");
            for (int i = 0; i < LinkZone.Count; i++)
            {
                Console.WriteLine((i + 1).ToString() + ". " + LinkZone[i].zonename);
            }

            int Number = (int)Console.ReadKey().Key;
            Number -= 49;
            if (Number > LinkZone.Count)
            {
                Console.WriteLine("허용되지 않는 값입니다.");
                Console.ReadKey();
                return this;
            }
            return LinkZone[Number];
        }

    }
    public static void StartSelect(Player NewPlayer)
    {
        Zone StartZone = new Zone("태초마을");
        Zone TownZone = new Zone("마을");
        Zone BattleZone = new Zone("사냥터");
        Zone StoreZone = new Zone("상점");

        StartZone.LinkZone.Add(TownZone);
        StartZone.LinkZone.Add(BattleZone);
        StartZone.LinkZone.Add(StoreZone);

        TownZone.LinkZone.Add(StartZone);
        TownZone.LinkZone.Add(BattleZone);
        TownZone.LinkZone.Add(StoreZone);

        BattleZone.LinkZone.Add(StartZone);
        BattleZone.LinkZone.Add(TownZone);
        BattleZone.LinkZone.Add(StoreZone);

        StoreZone.LinkZone.Add(StartZone);
        StoreZone.LinkZone.Add(TownZone);
        StoreZone.LinkZone.Add(BattleZone);

        Zone Nowzone = StartZone;
        while (true)
        {
            Nowzone = Nowzone.Update();
            switch (Nowzone.zonename)
            {
                case "태초마을":
                    StartSelect(NewPlayer);
                    break;
                case "마을":
                    Town.InTown(NewPlayer);
                    break;
                case "사냥터":
                    Battle.InBattle(NewPlayer);
                    break;
                case "상점":
                    Store.InStore(NewPlayer);
                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }
    }
}
    
