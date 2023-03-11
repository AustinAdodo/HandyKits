using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HandyKits
{
    internal class ProblemSolving
    {
        //archade Game, Dense Ranking System
        public static List<int> climbingLeaderboard1(List<int> ranked, List<int> player)
        {
            List<int> result = new(); int a = 0; int k = 0;
            while (k < player.Count)
            {
                ranked.Add(player[k]);
                IEnumerable<int> distinct = ranked.Distinct();
                distinct = distinct.OrderByDescending(x => x >= player[k]);
                a = distinct.ToList().IndexOf(player[k]);
                result.Add(a + 1);
                ranked.RemoveAt(ranked.IndexOf(player[k]));
                ++k;
            }
            return result;
        }
        /// <summary>
        /// Large Loop Optimization successful
        /// </summary>
        public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)//newRank = a + 1 - count;
        {
            List<int> result = new(); int position, a;
            List<int> distinct = new();
            distinct = ranked.Distinct().ToList();
            int max = distinct.Max();
            int min = distinct.Min();
            position = distinct.Count - 1; a = distinct.Count - 1;
            switch (distinct.Count == 1)
            {
                case true:
                    for (int i = 0; i < player.Count; ++i)
                    {
                        position = (player[i] == distinct[0]) ? 1 : 2;
                        result.Add(position);
                    }
                    break;
                case false:
                    for (int i = 0; i < player.Count; ++i)
                    {
                        while (position >= 0 && player[i] >= distinct[position])
                        {
                            --position;
                            if (player[i] == max) position = -1;
                            if (position == -1) break;
                        }
                        if (player[i] < min) position = a;
                        if (position == -1) position = -1;
                        result.Add(position + 2);
                        //if (i <= player.Count - 2 && player[i] == player[i + 1])
                        //{ position = result[result.Count - 1]; result.Add(position); ++i; }
                    }
                    break;
            }
            return result;
        }

        //equal Divisors
        public static int findDigits(int n)
        {
            int result = 0;
            string s = n.ToString();
            for (int i = 0; i < s.Length; i++)
            {
                result += (s[i].ToString() != "0" && (n % int.Parse(s[i].ToString())) == 0) ? 1 : 0;
            }
            return result;
        }

        //square Integers
        public static int squares(int a, int b)
        {
            int total = 0;
            int i = (int)Math.Ceiling(Math.Sqrt((double)a));
            while (i * i <= b)
            {
                total++;
                i++;
            }
            return total;
        }

        //minimum number of deletions
        public static int equalizeArray(List<int> arr)
        {
            int[] distinctArr = arr.Distinct().ToArray();
            int[] resultArr = new int[distinctArr.Length];
            List<int> maxarr = new();
            int[,] arr1 = new int[distinctArr.Length, 2];
            int result = 0; int result1 = 0;
            for (int i = 0; i < distinctArr.Length; i++)
            {
                arr1[i, 0] = distinctArr[i];
            }
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = 0; j < distinctArr.Count(); j++)
                {
                    arr1[j, 1] += (arr1[j, 0] == arr[i]) ? 1 : 0;
                }
            }
            for (int i = 0; i < distinctArr.Length; i++)
            {
                resultArr[i] = arr1[i, 1];
            }
            bool check = resultArr.All(s => resultArr[0] == s);
            switch (check)
            {
                case true:
                    result = resultArr.Count() - 1;
                    break;
                case false:
                    maxarr = resultArr.Where(s => s == resultArr.Max()).ToList();
                    maxarr.RemoveAt(0);
                    result1 = (maxarr.Count > 0) ? maxarr.Aggregate(func: (res, ele) => (res + ele)) : 0;
                    if (resultArr.Count() == 1) result = 0;
                    else { result = result1 + resultArr.Where(s => s != resultArr.Max()).Aggregate(func: (res, ele) => (res + ele)); }
                    break;
            }
            return result;
        }

        //append and delete //c
        public static String appendAndDelete(string s, string t, int k)
        {
            // Write your code here
            int n = s.Length, m = t.Length;
            if (n + m <= k) return "Yes";
            int z = 0;
            while (z < Math.Min(n, m) && s[z] == t[z])
            {
                z++;
            }
            int res = (n - z) + (m - z);
            if (res < k)
            {
                while (res < k)
                {
                    res += 2;
                }
                if (res == k)
                {
                    return "Yes";
                }
                return "No";
            }
            else if (res == k)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }
        static int reverseInt(int a)
        {
            string result = String.Empty;
            string s = a.ToString();
            for (int i = s.Length; i-- > 0;) result += s[i];
            return int.Parse(result);
        }
        //beautiful Days
        public static int beautifulDays(int i, int j, int k)
        {
            int count = 0;
            List<int> NumberList = new();
            for (int m = i; m <= j; ++m)
            {
                NumberList.Add(m);
            }
            for (int m = 0; m < NumberList.Count; ++m)
            {
                if ((NumberList[m] - reverseInt(NumberList[m])) % k == 0) count++;
            }
            return count;
        }

        //Angry Professor
        public static string angryProfessor(int k, List<int> a)
        {
            string s = String.Empty; int result = 0;
            //thresshold = k
            result = a.Where(s => s <= 0).Count();
            s = (result >= k) ? "NO" : "YES";
            return s;
        }

        //hurdles
        public static int hurdleRace(int k, List<int> height)
        {
            int result = 0;
            result = height.Max() - k;
            result = (result < 1) ? 0 : result;
            return result;
        }

        //is divisible
        public static int divisibleSumPairs(int n, int k, List<int> ar)
        {
            int result = 0;
            for (int i = 0; i < ar.Count; i++)
            {
                for (int j = i; j < ar.Count; ++j)
                {
                    if (i < j && (ar[i] + ar[j]) % k == 0) result++;
                }
            }
            return result;
        }

        //PDF Viewer Design
        public static int designerPdfViewer(List<int> h, string word)
        {
            int result = 0;
            int[] arr = new int[word.Length];
            string[] reference = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            for (int i = 0; i < word.Length; i++)
            {
                arr[i] = reference.ToList().IndexOf(word[i].ToString());
                arr[i] = h[arr[i]];
            }
            result = arr.Max() * word.Length;
            return result;
        }

        //budjeting
        static int getMoneySpent(int[] keyboards, int[] drives, int b)
        {
            var max = -1;
            if (keyboards.Min() + drives.Min() > b)
                return max;
            foreach (var k in keyboards)
            {
                var possibleDrives = drives.Where(x => (x <= b - k));
                foreach (var d in possibleDrives)
                {
                    var total = k + d;
                    if (total >= max && total <= b)
                        max = total;
                    if (max == b) break;
                }
                if (max == b) break;
            }
            return max;
        }

        //cats and mouse 
        static string catAndMouse(int x, int y, int z)
        {
            string s = String.Empty;
            s = (Math.Abs(x - z) < Math.Abs(y - z)) ? "Cat A" : (Math.Abs(x - z) > Math.Abs(y - z)) ? "Cat B" : "Mouse C";
            return s;
        }

        //factoring determiner
        public static int getTotalX(List<int> a, List<int> b)
        {
            List<int> resultArr = new();
            int start = a.Min();
            bool allClear = false; bool allClearstep1 = false;
            for (int i = start; i <= b.Max(); ++i)
            {
                allClearstep1 = a.All(s => i % s == 0);
                allClear = b.All(s => s % i == 0);
                if (allClearstep1 == true && allClear == true)
                {
                    resultArr.Add(i);
                }
            }
            return resultArr.Count;
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
            birdArrFinal = birdArr.Cast<int>()
                 .Select((x, i) => new { x, index = i / birdArr.GetLength(1) })
                 .GroupBy(x => x.index)
                 .Select(x => x.Select(s => s.x).ToList())
                 .ToList();
            birdArrFinal.Sort((x, y) => x[1].CompareTo(y[1]));
            birdArrFinal.Reverse();
            for (int i = 0; i < birdArrFinal.Count; i++)
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
            int sizeMax = 0; int j = 0; int suite = 0;
            int k = 0;
            a.Sort((res, ele) => res - ele);
            for (int i = 0; i < a.Count; i += k)
            {
                j = i;
                while (a[j] - a[i] <= 1)
                {
                    suite++;
                    j++;
                }
                if (suite > sizeMax) sizeMax = suite;
                k = (suite == 0) ? 1 : suite;
            }
            return sizeMax;
        }

        //repeted string //c
        public static long repeatedString(string s, long n)
        {
            if (s.Length > n)
            {
                return s.Substring(0, (int)n).Count(x => x == 'a');
            }
            var divisor = ((long)n / s.Length) + 1;
            var count = s.Count(x => x == 'a') * (divisor - 1);
            var remaining = s.Substring(0, (int)Math.Abs((s.Length * (divisor - 1)) - n)).Count(x => x == 'a');
            return count + remaining;
        }

        //mountains and Valleys
        public static int countingValleys(int steps, string path)
        {
            int result = 0; int altitude = 0;
            for (int i = 0; i < steps; i++)
            {
                if (path[i].ToString() == "U") { altitude++; } else { altitude--; }
                if (path[i].ToString() == "U" && altitude == 0) { result++; }
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

        //pages and books //c
        public static int pageCount(int n, int p)
        {
            //page 0=>1
            return (int)Math.Min(p == 1 ? 0 : Math.Floor((decimal)p / 2), (Math.Floor((decimal)n / 2) - Math.Floor((decimal)p / 2)));
        }

        //prisoner //c
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

