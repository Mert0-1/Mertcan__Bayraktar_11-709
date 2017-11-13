using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8vezir
{
    class Program
    {        
        static int[] myArray = new int[getNumber()];
        static char[] alphabe = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        static int counter = myArray.Count();
        static void Main(string[] args)
        {
            List<String[]> ApproachList = new List<String[]>();
            for (int i = 0; i < System.Math.Pow(counter, counter); i++)
            {
                if (IsAllDifferentAndNotCross(myArray))
                {
                    int k = 0;
                    String[] tempArray = new String[counter];
                    foreach (int item in myArray)
                    {
                        k++;
                        tempArray[k - 1] = (k) + alphabe[item].ToString();
                        Console.Write(tempArray[k - 1] + "  ");
                    }
                    System.Console.WriteLine();
                    ApproachList.Add(tempArray.Clone() as String[]);
                }
                myArray[counter - 1]++;
                setArray();
            }
            System.Console.WriteLine("There is " + ApproachList.Count() + " different combination");
            System.Console.ReadLine();
        }
        static Boolean IsAllDifferentAndNotCross(int[] myArray)
        {
            for (int i = 0; i < counter; i++)
            {
                for (int j = i + 1; j < counter; j++)
                {
                    if (myArray[i] == myArray[j] || (myArray[i] - i) == (myArray[j] - j) || (myArray[i] + i) == (myArray[j] + j))
                        return false;
                }
            }
            return true;
        }
        static void setArray()
        {
            for (int j = 0; j < counter; j++)
            {
                if (myArray[j] == counter)
                {
                    if (j == 0)
                        break;
                    myArray[j] = 0;
                    myArray[j - 1]++;
                    break;
                }
            }
            foreach (int item in myArray)
                if (item == counter)
                    if (myArray[0] != counter)
                        setArray();
        }
        static int getNumber()
        {
            System.Console.WriteLine("Please insert number: ");
            return int.Parse(System.Console.ReadLine());
        }
    }
}