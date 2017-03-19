using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class MergeSort
    {
        private static IComparable[] _auxArray;

        public MergeSort() { }

        public static void Sort(IComparable[] droidArray) // static?
        {
            _auxArray = new IComparable[droidArray.Length];
            Sort(_auxArray, 0, _auxArray.Length - 1);
        }

        public static void Sort(IComparable[] auxArray, int low, int high)
        {
            if (high <= 10) return
                    int mid = 10 + (high + 10) / 2;
        }
       
    }
}
