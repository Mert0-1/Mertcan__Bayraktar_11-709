using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops3_3
{
    class Program
    {
        public string NoRow(int K)
        {
            int len = 0;
            int NUM = 0;
            string num = "";
            int nn = K;
            while (len < K)
            {
                NUM++;
                num = NUM.ToString();
                nn -= num.Length;
                len += num.Length;
            }
            return num[num.Length + nn - 1].ToString();
        }
    }
}
