using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HandyKits
{
    public class Arrays
    {
        //Complex Manipulation
        public static long ArrayComplexManipulation(int n, List<List<int>> queries)
        {
            int[,] IndexArr = new int[n, 2];
            List<int> ResultArr = new();
            int count = queries.Count;
            //samplequeries -> //a b k
            //1 5 3
            //4 8 7
            //6 9 1
            if (n >= 3 && queries != null && n <= Math.Pow(10, 7))
            {
                for (int i = 0; i < n; i++)
                {
                    IndexArr[i, 0] = i + 1; //indices
                    IndexArr[i, 1] = 0; //zeros
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < count; j++)//optimize loopintroduce aggregates
                    {
                        IndexArr[i, 1] = (IndexArr[i, 0] >= queries[j][0] && IndexArr[i, 0] <= queries[j][1]) ? IndexArr[i, 1] + queries[j][2] :
                            IndexArr[i, 1] + 0;
                    }
                    ResultArr.Add(IndexArr[i, 1]);
                }
            }
            return ResultArr.Max();
        }

        //inline swaps minimum req swaps.
        public static int ArraySwaps(int[] arr)
        {

            int a = 0; int b = 0; int count = 0; int LengthEvenCheck = arr.Length % 2;
            int[] ProperArr = arr.ToList().OrderBy(s => s).ToArray();
            int maxi = ProperArr.ToList().Max();
            if (arr.ToList().IndexOf(maxi) < arr.Length / 2) //binary log sort
            {
                a = maxi; int aIndex = arr.ToList().IndexOf(a);
                b = (LengthEvenCheck == 0) ? arr[((arr.Length) / 2) - 1] : arr[((arr.Length - 1) / 2)];
                b = (arr[arr.ToList().IndexOf(b)] > arr[arr.ToList().IndexOf(b) + 1]) ? arr[arr.ToList().IndexOf(b) + 1] : b;
                int bIndex = arr.ToList().IndexOf(b);
                arr[aIndex] = b; arr[bIndex] = a;
                count++;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (i + 1 <= arr.Length - 1 && arr[i] > arr[i + 1]) //concurrent swap
                {
                    a = arr[i];
                    b = arr[i + 1];
                    arr[i + 1] = a; arr[i] = b;
                    count++;
                }
            }
            for (int j = arr.Length; j-- > 0;)
            {
                if (j - 1 >= 0 && arr[j] < arr[j - 1]) //concurrent swap backward check
                {
                    a = arr[j];
                    b = arr[j - 1];
                    arr[j - 1] = a; arr[j] = b;
                    count++;
                }
            }
            return count;
        }

        //New Year Chaos..Bribes
        public static void NYChaos(List<int> q)
        {
            string result = ""; int count = 0;
            int size = q.Count;
            List<int> properlist = q.OrderBy(s => s).ToList();
            for (int i = 0; i < q.Count; i++)
            {
                int shift = properlist.IndexOf(q[i]) - q.IndexOf(q[i]);
                switch (i == 0)
                {
                    case true:
                        if (shift < 2 && q[i] > q[i + 1])
                        {
                            count++;
                            result = count.ToString();
                        }
                        else if (shift == 2 && q[i] > q[i + 1])
                        {
                            count += 2;
                            result = count.ToString();
                        }
                        else if (shift > 2 && q[i] > q[i + 1])
                        {
                            result = "Too chaotic";
                            Console.WriteLine(result);
                            return;
                        }

                        break;
                }
                switch (i > 0)
                {

                    case true:
                        if (shift < 0 && i < size - 1 && q[i] > q[i + 1])
                        {
                            count++;
                            result = count.ToString();
                        }
                        if (shift > 0 && shift < 2 && q[i] > q[i - 1])
                        {
                            count++;
                            result = count.ToString();
                        }
                        if (shift == 2 && q[i] > q[i - 1])
                        {
                            count += 2;
                            result = count.ToString();
                        }
                        if (shift == 0 && q[i] < q[i - 1])
                        {
                            count++;
                            result = count.ToString();
                        }
                        if (shift == 0 && q[i] > q[i + 1])
                        {
                            count++;
                            result = count.ToString();
                        }
                        if (shift > 2 && q[i] > q[i - 1])
                        {
                            result = "Too chaotic";
                            Console.WriteLine(result);
                            return;
                        }
                        break;
                }
            }
            Console.WriteLine(result);
        }

        //Left Shift
        public static List<int> CounterClockwise(List<int> a, int d)
        {
            List<int> cut = new List<int>();
            for (int i = 0; i < d; i++)
            {
                cut.Add(a[i]);
                
            }
            a.RemoveRange(0, d);
            a.AddRange(cut);
            return a;
        }
    }
}
