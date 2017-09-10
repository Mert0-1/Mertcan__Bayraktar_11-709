using System;

namespace Test
{
    class Program
    {
        public static bool IsPrime(int num)
        {
            for (int i = 2; i * i <= num; i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.Write("N=");
            int n = int.Parse(Console.ReadLine());
            Console.Write("X=");
            int x = int.Parse(Console.ReadLine());
            if (!IsPrime(x))
            {
                Console.WriteLine("X is not prime number");
                Console.ReadKey(true);
                return;
            }
            Console.Write("Y=");
            int y = int.Parse(Console.ReadLine());
            if (!IsPrime(y))
            {
                Console.WriteLine("Y is not prime number");
                Console.ReadKey(true);
                return;
            }
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (i % x == 0 || i % y == 0) count++;
            }
            Console.WriteLine($"{count} numbers total");
            Console.ReadKey(true);
        }
    }
}