using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop4_4
{
    class Program
    {
        static void Main()
        {
            var str = Console.ReadLine();
            var length = str.Length;
            if (length == 0)
            {
                Console.WriteLine("Mistake!");
                return;
            }
            var a = 0;
            var count = 0;
            var list = new List<int>();
            for (var i = 0; i < length; i++)
            {
                if (str[i] == '(')
                    a++;
                else if (str[i] == ')')
                {
                    if (i != length - 1 && str[i + 1] != '(')
                        count++;
                    a--;
                }
                if (a == 0)
                {
                    list.Add(count);
                    count = 0;
                }
            }
            list.Sort();
            if (a == 0)
                Console.WriteLine(list[list.Count - 1] + 1);
            else Console.WriteLine("Mistake!");
        }
    }
}

