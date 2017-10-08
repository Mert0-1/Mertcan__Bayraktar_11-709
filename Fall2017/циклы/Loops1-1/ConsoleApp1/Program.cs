using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int nLength = Length(N);
            int tenPower = (int)Math.Pow(10, nLength - 1);

            int result = 0;
            while (N > 0)
            {
                int digit = N % 10;
                N /= 10;

                result += digit * tenPower;
                tenPower /= 10;
            }

            Console.WriteLine(result);
            Console.ReadLine();
        }
       
        static int Length(int number) { return (int)Math.Floor(Math.Log10(number)) + 1; }

    }
}

