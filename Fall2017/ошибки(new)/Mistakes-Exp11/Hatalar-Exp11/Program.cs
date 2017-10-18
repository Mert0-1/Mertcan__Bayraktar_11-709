using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatalar_Exp11
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int hours;
                do
                {
                    Console.Write("Enter hours (0 to 23) : ");
                    hours = int.Parse(Console.ReadLine());
                }
                while (hours < 0 || hours > 23);
                if (hours > 11) hours -= 12;
                int mins;
                do
                {
                    Console.Write("Enter minutes (0 to 59) : ");
                    mins = int.Parse(Console.ReadLine());
                }
                while (mins < 0 || mins > 59);
                double hDegrees = (hours * 30) + (mins * 30.0 / 60);
                double mDegrees = mins * 6;
                double diff = Math.Abs(hDegrees - mDegrees);
                if (diff > 180) diff = 360 - diff;
                Console.WriteLine("The angle between the hands is {0} degrees", diff);
                Console.Write("Do another y/n : ");
                string yn = Console.ReadLine();
                if (yn == "n") return;
                Console.WriteLine();
            }
        }
    }

}
    
