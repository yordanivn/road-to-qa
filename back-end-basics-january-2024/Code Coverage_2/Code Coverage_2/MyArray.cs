using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Coverage_2
{
    public class MyArray
    {
        private readonly int[] _myArray;
        public int[] Array=> _myArray;
        public MyArray(int size)
        {
            _myArray=Enumerable.Range(0, size).ToArray();
        }
    public bool Replace(int position, int newValue)
        {
            if(position<0)
                throw new ArgumentException("Position must not be less than zero");
            if(position>=_myArray.Length)
            {
                throw new ArgumentException("Position must be valid");
            }
            _myArray[position] = newValue;
            return true;
        }
    }
}
