using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyKits
{
    internal class DataStructures
    {
        public static List<int> matchingStrings(List<string> stringList, List<string> queries)
        {
            //1 <= n <= 1000;
            //1 <= q <= 1000;|| str.Contains(queries[i])
            int[] result = new int[queries.Count];
            foreach (string str in stringList)
            {
                for (int i = 0; i < queries.Count; ++i)
                {
                    if (str == queries[i]) { result[i]++; }
                }
            }
            return result.ToList();
        }
        public static int[] ReturnPrimaryDiagonal(List<List<int>> arr)
        {
            int[] result = new int[arr.Count];
            for (int i = 0; i < arr.Count; i++)
            {
                result[i] = arr[i][i];
            }
            return result;
        }
        public static int[] ReturnSecondaryDiagonal(List<List<int>> arr)
        {
            int[] result = new int[arr.Count];
            int i = 0;
            for (int j = arr.Count; j-- > 0;)
            {
                result[i] = (arr[i][j]);
                i++;
            }
            return result;
        }
        public static int diagonalDifference(List<List<int>> arr)
        {
            int result = 0;
            //diagonal differnce 
            int a = DataStructures.ReturnPrimaryDiagonal(arr).Aggregate((ele, res) => ele + res);
            int b = DataStructures.ReturnSecondaryDiagonal(arr).Aggregate((ele, res) => ele + res);
            result = (a - b > 0) ? a - b : -1 * (a - b);
            return result;
        }
        public static void plusMinus(List<int> arr)
        {
            int n = arr.Count; decimal Positives = 0;
            decimal a, b, c;
            decimal Negatives = 0; decimal zeros = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] > 0)
                {
                    Positives++;
                }
                if (arr[i] < 0)
                {
                    Negatives++;
                }
                if (arr[i] == 0)
                {
                    zeros++;
                }
            }
            a = Positives / n; b = Negatives / n; c = zeros / n;
            Console.WriteLine(string.Format("{0:N6}", a));//must be 6 decimal places.
            Console.WriteLine(string.Format("{0:N6}", b));
            Console.WriteLine(string.Format("{0:N6}", c));
        }

        //stairCase.
        public static void staircase(int n)
        {
            string a = ""; string b = "";
            string[] jagged = new string[n];
            string[] empty = new string[n];
            //#
            //##
            //###
            //####
            //#####
            //######
            for (int j = n - 1; j-- > 0;)
            {
                b += " ";
                empty[j] = b;
            }
            for (int i = 0; i < n; i++)
            {
                a += "#";
                jagged[i] = empty[i] + a;
            }
            for (int j = 0; j < jagged.Length; j++)
            {
                Console.WriteLine(jagged[j]);
            }
        }
    }
}
