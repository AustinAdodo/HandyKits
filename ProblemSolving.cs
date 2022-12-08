using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyKits
{
    internal class ProblemSolving
    {
        //is divisible
        public static int divisibleSumPairs(int n, int k, List<int> ar)
        {
            int result = 0;
            return result;
        }

        //birds migratory algorithm optimized.
        public static int migratoryBirds(List<int> arr)
        {
            List<int> distinctBirdType = arr.Distinct().ToList();
            int result = 0; int[,] birdArr = new int[distinctBirdType.Count, 2];
            int t = 0;
            List<List<int>> birdArrFinal = new List<List<int>>();
            List<int> trimmed = new();
            for (int i = 0; i < distinctBirdType.Count; i++)
            {
                birdArr[i, 0] = distinctBirdType[i];
            }
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = 0; j < distinctBirdType.Count; ++j)
                {
                    if (birdArr[j, 0] == arr[i])
                    {
                        birdArr[j, 1]++;
                    }
                }
            }
            //sorted arr
            birdArrFinal= birdArr.Cast<int>()
                 .Select((x, i) => new { x, index = i / birdArr.GetLength(1) })
                 .GroupBy(x => x.index)
                 .Select(x => x.Select(s => s.x).ToList())
                 .ToList();
            birdArrFinal.Sort((x, y) => x[1].CompareTo(y[1]));
            birdArrFinal.Reverse();
            for (int i = 0; i <birdArrFinal.Count; i++)
            {
                trimmed.Add(birdArrFinal[i][1]);
            }
            t = birdArrFinal.Where(s => s[1] == trimmed.Max()).Min(p => p[0]);     
            result = t;
            return result;
        }

        //Largest SubArray with absolute difference == 1
        public static int pickingNumbers(List<int> a)
        {
            int result = 0; List<int> b = new();
            int l = 0; int finalLength = 0;
            int count= 0;   
            for (int i = 0; i < a.Count; i++)
            {
                b.Add(a[i]);
                for (int j = i; j < a.Count; ++j)
                {
                    if (j < a.Count - 1 && Math.Abs(a[j+1] - b[b.Count - 1]) <= 1)
                    {
                        b.Add(a[j+1]);
                    }
                    if (b.Count > 1 && Math.Abs(b[0]- b[1]) <= 1)
                    {
                        l = b.Count;
                        finalLength =  (l > finalLength) ? l:finalLength;
                        count++;
                    }
                    result = finalLength;
                }
                //b.RemoveRange(0, b.Count);
            }
            return result;
        }

        //apples and Oranges
        public static void countApplesAndOranges(int s, int t, int a, int b, List<int> apples, List<int> oranges)
        {
            int applecount = 0; int orangecount = 0;
            for (int i = 0; i < apples.Count; i++)
            {
                apples[i] += a;
                if (s <= apples[i] && apples[i] <= t)
                {
                    applecount++;
                }
            }
            for (int i = 0; i < oranges.Count; i++)
            {
                oranges[i] += b;
                if (s <= oranges[i] && oranges[i] <= t)
                {
                    orangecount++;
                }
            }
            Console.WriteLine(applecount + "\n");
            Console.WriteLine(orangecount);
        }

        //kangaroo pace
        public static string kangaroo(int x1, int v1, int x2, int v2)
        {
            return (v1 <= v2) ? "NO" : (((x2 - x1) % (v1 - v2) == 0) ? "YES" : "NO");
        }

        //majic 3X3 matrix //extend study
        public static int formingMagicSquare(List<List<int>> s)
        {
            // Write your code here
            string[] allComb = { "618753294", "816357492", "834159672", "438951276", "672159834", "276951438", "294753618", "492357816" };
            int min = 100;
            string mat = "";
            for (int i = 0; i < s.Count; i++)
            {
                mat += string.Join("", s[i]);
            }
            // console.log(mat);
            for (int i = 0; i < allComb.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < mat.Length; j++)
                {
                    if (mat[j] != allComb[i][j])
                    {
                        count += Math.Abs(mat[j] - allComb[i][j]);
                    }
                }
                // console.log(count);
                if (min > count) min = count;
            }
            return min;
        }

        //sockMerchant
        public static int sockMerchant(int n, List<int> ar)
        {
            int result = 0; decimal a = 0; int b = 0;
            List<int> distinct = ar.Distinct().ToList();
            List<int> resultArr = new();
            int[,] arrComparer = new int[distinct.Count, 2];
            for (int i = 0; i < distinct.Count; i++)
            {
                arrComparer[i, 0] = distinct[i];
            }
            for (int i = 0; i < ar.Count; i++)
            {
                for (int j = 0; j < distinct.Count; ++j)
                {
                    if (arrComparer[j, 0] == ar[i])
                    {
                        arrComparer[j, 1]++;
                    }
                }
            }
            for (int i = 0; i < distinct.Count; i++)
            {
                a = arrComparer[i, 1] / 2;
                a = Math.Floor(a); b = (a >= 1) ? (int)a : 0;
                resultArr.Add(b);
            }
            result += resultArr.Aggregate(func: (res, ele) => (res + ele));
            return result;
        }

        //split bills.
        public static void bonAppetit(List<int> bill, int k, int b)
        {
            int AnnaBill = 0; int a = 0; string result = String.Empty;
            int briansBill = 0;
            bill.RemoveAt(k);
            a += bill.Aggregate(func: (res, ele) => (res + ele)); AnnaBill = a / 2;
            briansBill += AnnaBill + k;
            result = (AnnaBill == b) ? "Bon Appetit" : (b - AnnaBill).ToString();
            Console.WriteLine(result);
        }

        //julian and Gregorian Calender Comparism
        public static string dayOfProgrammer(int year)
        {
            string result = String.Empty;
            return result;
        }

        //pages and books
        public static int pageCount(int n, int p)
        {
            //page 0=>1
            return (int)Math.Min(p == 1 ? 0 : Math.Floor((decimal)p / 2), (Math.Floor((decimal)n / 2) - Math.Floor((decimal)p / 2)));
        }

        //prisoner
        public static int saveThePrisoner(int n, int m, int s)
        {
            return _ = ((m + s - 1) % n == 0) ? n : (m + s - 1) % n;
        }

        //The length of the segment matches Ron's birth month
        //chocolate
        public static int birthday(List<int> s, int d, int m)
        {
            int result = 0; int n;
            List<int> chocoRange = new();
            for (int i = 0; i < s.Count; i++)
            {
                for (int j = i; j < s.Count; ++j)
                {
                    n = 0;
                    chocoRange.Add(s[j]);
                    n += chocoRange.Aggregate(func: (res, ele) => (res + ele));
                    if (chocoRange.Count == m && n == d)
                    {
                        result++;
                    }
                }
                chocoRange.RemoveRange(0, chocoRange.Count);
            }
            return result;
        }
    }
}

//string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
//int n = Convert.ToInt32(firstMultipleInput[0]);
//int k = Convert.ToInt32(firstMultipleInput[1]);

