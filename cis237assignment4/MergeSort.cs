using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    // Takes an IComparable array, performs
    // a mergesort to sort droids in terms
    // of their total cost
    class MergeSort
    {
        // 
        private static IComparable<IDroid>[] _Array;

        public MergeSort() { }

        public static void Sort(IComparable<IDroid>[] droidArray)
        {
            _Array = new IComparable<IDroid>[droidArray.Length];
            Sort(droidArray, 0, _Array.Length - 1);

            int counter = 0;
            
            foreach (IDroid droid in _Array)
            {
                if (droid != null)
                {
                    Console.WriteLine(droid.TotalCost.ToString("C"));
                    counter++;
                }
                    
            }
            Console.WriteLine(counter);
                
        }

        public static void Sort(IComparable<IDroid>[] droidArr, int low, int high)
        {
            if ((high - low) >= 1)
            {
                int mid = (high + low) / 2;
                int mid2 = mid + 1;
                Sort(droidArr, low, mid);
                Sort(droidArr, mid + 1, high);
                Merge(droidArr, low, mid, mid2, high);
            } 
        }

        public static void Merge(IComparable<IDroid>[] droidArr, int left, int mid, int mid2, int right)
        {
            int leftIndex = left;
            int rightIndex = mid2;
            int compbinedIndex = left;

            // Copy elements into aux array
            for (int k = left; k <= right; k++)
            {
                _Array[k] = droidArr[k];
            }

            while (leftIndex <= mid && rightIndex <= right)
            {
                if (droidArr[leftIndex].CompareTo(_Array[rightIndex])
                {

                }
            }


            for (int k = left; k <= right; k++)
            {
                IDroid temp = (IDroid)droidArr[k];

                if (j > mid)
                    droidArr[k] = _Array[j++];
                else if (j > right)
                    droidArr[k] = _Array[j++];
                else if (droidArr[k].CompareTo(temp) > 0)
                    droidArr[k] = _Array[j++];
                else
                    droidArr[k] = _Array[j++];
            }


            /*
            for (int k = low; k <= high; k++)
            {
                droidArr[k] = _Array[k];
            }

            for (int j = mid + 1; j <= high; j++)
            {
                droidArr[j] = _Array[high - j + mid + 1];
            }



            i = low;
            jo = high;

            for (int k = low; k <= high; k++)
            {
                IDroid temp = (IDroid)droidArr[i];
                if (droidArr[jo].CompareTo((Droid)temp) < 0)
                {
                    _Array[k] = (Droid)droidArr[jo--];
                }
                else
                    _Array[k] = (Droid)droidArr[i++];
            }
            */
        }
       
    }
}
