using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Server
{
    public  class Sort
    {
        public  List<int> lists = new List<int>();        
        public List<int> fibonacci = new List<int> { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 };
       public List<int> listlast = new List<int>();
        
    }
    
    public class Pars
    {
        
        public int Average { get; set; }
        public int MyInteger { get; set; }
        private void integer(int _myinteger)
        {
            MyInteger = _myinteger;
        }
        private void average(int average)
        {
            Average = average;
        }
        
        
    }
}
     
    












