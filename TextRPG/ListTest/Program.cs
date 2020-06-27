using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTest
{
    class Zone
    {
        public string name = "None";
        public List<Zone> LinkZone = new List<Zone>();

        public Zone(string _name)
        {
            name = _name;
        }

        public Zone Update()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("이곳은 " + name + "입니다.");
                Console.WriteLine("이곳에서 이동할 수 있는 리스트.");
                for(int i =0; i< LinkZone.Count; i++)
                {
                    Console.WriteLine((i + 1).ToString() + ". " + LinkZone[i].name);
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            Zone NewZone0 = new Zone("태초마을");
            Zone NewZone1 = new Zone("초보사냥터");
            Zone NewZone2 = new Zone("중급사냥터");
            Zone NewZone3 = new Zone("중급마을");
            Zone NewZone4 = new Zone("고급사냥터");

            NewZone0.LinkZone.Add(NewZone1);
            NewZone0.LinkZone.Add(NewZone2);

            NewZone1.LinkZone.Add(NewZone3);
            NewZone1.LinkZone.Add(NewZone0);

            NewZone2.LinkZone.Add(NewZone3);
            NewZone2.LinkZone.Add(NewZone0);

            NewZone3.LinkZone.Add(NewZone4);
            NewZone3.LinkZone.Add(NewZone2);

            Zone startzone = NewZone0;
            while(true)
            {
                startzone = startzone.Update();
            }
        }
    }
}
