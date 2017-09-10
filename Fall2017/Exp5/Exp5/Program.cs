using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp5
{
    class Program
    {


        // Рекурсивный метод
        static int Rec_(int i)
        {
            if (i % 4 == 0) return i;
            return Rec_(i-1);
        }
        static int Rec(int i)
        {
            if (i % 4 == 0) return i;
            return Rec(i+1);
        }

        static void Main(string[] args)
        {

            int Start = 833, Fin = 937;
            Start = Rec(Start);
            Fin = Rec_(Fin);
            Console.ReadLine();
        }
    }
}
   
       
