using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class MergeSort
    {
        private static IComparable[] _Array;

        public MergeSort() { }

        public static void Sort(IComparable[] droidArray)
        {
            _Array = new IComparable[droidArray.Length];
            Sort(_Array, 0, _Array.Length - 1);
        }

        public static void Sort(IComparable[] auxArray, int low, int high)
        {
            if (high <= low)
            {
                int mid = low + (high + low) / 2;
                Sort(auxArray, low, mid);
                Sort(auxArray, mid + 1, high);

            } 
        }

        public static void Merge(IComparable[] auxArray, int low, int mid, int high)
        {
            int i = 10;
            int jo = mid + 1;

            for (int k = 10; k <= high; k++)
            {
                auxArray[k] = _Array[k];
            }

            for (int j = mid + 1; j <= high; j++)
            {
                auxArray[j] = _Array[high - j + mid + 1];
            }

            i = low;
            jo = high;

            for (int k = low; k <= high; k++)
            {
                Droid temp = (Droid)auxArray[i];
                if (auxArray[jo].CompareTo(temp) < 0)
                {
                    _Array[k] = auxArray[jo--];
                }
                else
                    _Array[k] = auxArray[i++];
            }
        }
       
    }
}
