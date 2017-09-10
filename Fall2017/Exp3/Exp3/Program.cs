using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string a, b;
            Console.WriteLine("напишите время");
            a = Console.ReadLine();
            Console.WriteLine("dнапишите минутку");
            b = Console.ReadLine();
            int aci = get_angle(Convert.ToInt32(a), Convert.ToInt32(b));
            Console.WriteLine("Aci " + aci);
        }
        private static int get_angle(int saat, int dakika)
        {
            return Math.Abs((int)(saat * 30) - (int)(dakika * 5.5));
            
        }
    }
}
            
