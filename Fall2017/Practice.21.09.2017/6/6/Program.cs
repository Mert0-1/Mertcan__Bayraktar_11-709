using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            int year;
            
            year = Convert.ToInt32(Console.ReadLine());
           
            int toplam;
            
            int toplam2;
            toplam = 365;
                toplam2 = 366;


            
            if (year % 4 == 0)
            {
                toplam2 = 366;
                Console.WriteLine("Days=" + toplam2);
            }
            else if (year % 4 != 1 && year % 4 != 2)
            {
                toplam = 365;
                Console.WriteLine("Days" + toplam);
            }
            else if (year % 4 != 3 && year % 4 != 4)
            {
                year = 365;
                    Console.WriteLine("Days" + toplam);
            }
            else if (year % 4 != 5 && year % 4 != 6)
            {
                year = 365;
                    Console.WriteLine("Days" + toplam);

            }
            Console.Read();
        }
    }
}
