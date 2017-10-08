using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int b, c, count, i, j, num, p;
            string s, a, d, f;
            byte res;
            try
            {
                Console.Write("num:=");
                a = Console.ReadLine();
                num = Convert.ToInt32(a);
                Console.Write("b:=");
                d = Console.ReadLine();
                b = Convert.ToInt32(d);
                Console.Write("c:=");
                f = Console.ReadLine();
                c = Convert.ToInt32(f);
                p = num % 10;
                if (p % 2 == 0)
                {
                    Console.WriteLine("Even");
                }
                else
                {
                    Console.WriteLine("Uneven");
                }
                if (b > 27)
                {
                    Console.WriteLine("Dont Have Such Numbers");

                }
                if (b >= c)
                {
                    Console.WriteLine("B Cant Be Bigger than C ");

                }
                s = Convert.ToString(num);
                res = Convert.ToByte(s.Length);
                Console.WriteLine("The Number Of Digits:= {0,0}", res);
                for (i = 0; i < 9; i++)
                    for (j = 0; j < 9; j++)
                       
                        Console.ReadKey();




            }

            catch
            {
                Console.WriteLine("Write");
                

            }
        }
    }
}
    

