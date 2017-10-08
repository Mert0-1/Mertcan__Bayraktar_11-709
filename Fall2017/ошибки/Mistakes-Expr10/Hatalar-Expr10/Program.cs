using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatalar_Expr10
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            i = 0;
                for (i=0; i < 1000; i++)
            {
                if (i % 5 == 0 || i%3==0)
                {
                    Console.WriteLine(i);
                }
                
            }
            Console.ReadLine();
        }
    }
}
