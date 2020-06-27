using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Program
    {

        static void Main(string[] args)
        {
            string name;

            Console.WriteLine("사용하실 플레이어의 이름을 지정하세요.");
            Console.Write("이름: ");

            name = Console.ReadLine();

            Player NewPlayer = new Player(name);

            Zone.StartSelect(NewPlayer);
        }

    }
}
