using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rec1
{
    class Program
    {
        public static int PowerBySquaring(int baseNumber, int exponent)
        {
            int result = 1;
            while (exponent != 0)
            {
                if ((exponent & 1) == 1)
                {
                    result *= baseNumber;
                }
                exponent >>= 1;
                baseNumber *= baseNumber;
            }

            return result;
        }
    }
    }




