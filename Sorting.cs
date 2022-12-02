using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyKits
{
    internal class Sorting
    {
        //i<j...if arr[i]>arr[j]...out of order
        public static long InversionsAggregate(List<int> arr)
        {
            int count = 0;
            int a = 0; int b = 0; int LengthEvenCheck = arr.Count % 2;
            int[] ProperArr = arr.ToList().OrderBy(s => s).ToArray();
            int maxi = ProperArr.ToList().Max();
            for (int i = 0; i < arr.Count; i++)
            {
                if (i + 1 <= arr.Count - 1 && arr[i] > arr[i + 1]) //concurrent inversions
                {
                    a = arr[i];
                    b = arr[i + 1];
                    arr[i + 1] = a; arr[i] = b;
                    count++;
                }
                if (i >= 2 && i <= arr.Count - 1 && arr[i - 1] < arr[i - 2])
                {
                    a = arr[i - 1];
                    b = arr[i - 2];
                    arr[i - 2] = a; arr[i - 1] = b;
                    count++;
                }
            }
            for (int j = arr.Count - 1; j-- > 0;)
            {
                if (j - 1 >= 0 && arr[j] < arr[j - 1]) //concurrent inversion backward check
                {
                    a = arr[j];
                    b = arr[j - 1];
                    arr[j - 1] = a; arr[j] = b;
                    count++;
                }
                if (j <= arr.Count - 3 && j <= 0 && arr[j + 1] > arr[j + 2])
                {
                    a = arr[j + 1];
                    b = arr[j + 2];
                    arr[j + 2] = a; arr[j + 2] = b;
                    count++;
                }
            }
            return count;
        }
    }
}
