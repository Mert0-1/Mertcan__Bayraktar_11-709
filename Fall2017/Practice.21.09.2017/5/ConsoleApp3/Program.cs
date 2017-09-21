using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Sayı Giriniz *****");
            
            int sayi = Convert.ToInt32(Console.ReadLine());

            for (int i = 2; i <= sayi; i++)
            {
                
                int kalan = sayi % i;

                if (kalan == 0)
                {

                    Console.WriteLine(sayi + " Not A Prime Number");

                    break;

                }

                if (i == sayi - 1)
                {

                    Console.WriteLine(sayi + " Prime number");

                    break;

                }

            }

            Console.ReadLine();


        }

    }
}





