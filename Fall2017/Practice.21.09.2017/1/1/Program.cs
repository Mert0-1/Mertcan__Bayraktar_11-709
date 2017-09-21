using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            int x;
            int y;
            int toplam;
            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            toplam = Convert.ToInt32(x + (2 * x) * (134 * y) - x + y);
            Console.WriteLine("Toplam" + toplam);
            Console.ReadLine();

        }
    }
}
