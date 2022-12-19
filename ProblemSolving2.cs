using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HandyKits
{
    internal class ProblemSolving2
    {
        //rotating Array
        public static void matrixRotation(List<List<int>> matrix, int r)
        {

        }
        // flatlandSpaceStations.
        public static int flatlandSpaceStations(int n, int[] c)
        {
            int maxDistance = 0;
            c = c.OrderBy(x => x).ToArray();
            // two cases:       
            if (c.Length == 1)
            {
                return Math.Max(c[0], n - c[0] - 1);
            }
            else
            {
                for (int i = 0; i < c.Length; i++)
                {
                    int nearestStation = 0;
                    if (i.Equals(0))
                    {
                        int nextCity = (int)Math.Floor((decimal)((decimal)c[i + 1] - (decimal)c[i]) / (decimal)2);
                        nearestStation = Math.Max(c[i], nextCity);
                    }
                    else if (i.Equals(c.Length - 1))
                    {
                        int previousCity = (int)Math.Floor((decimal)((decimal)c[i] - (decimal)c[i - 1]) / (decimal)2);
                        nearestStation = Math.Max((n - 1 - c[i]), previousCity);
                    }
                    else
                    {
                        int nextCity = (int)Math.Floor((decimal)((decimal)c[i + 1] - (decimal)c[i]) / (decimal)2);
                        int previousCity = (int)Math.Floor((decimal)((decimal)c[i] - (decimal)c[i - 1]) / (decimal)2);
                        nearestStation = Math.Max(nextCity, previousCity);
                    }
                    if (nearestStation > maxDistance) maxDistance = nearestStation;
                }
            }
            return maxDistance;
        }

        //GoToMars
        public static int marsExploration(string s)
        {
            int count = 0; string FixedS = "";
            for (int i = 0; i < s.Length; i += 3)
            {
                FixedS += "SOS";
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].ToString() != FixedS[i].ToString()) { count++; }
            }
            return count;
        }

        //camelcase
        public static int camelcase(string s)
        {
            int count = 1; string l = s.ToLower();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].ToString() == l[i].ToString().ToUpper()) count++;
            }
            return count;
        }
        //sticks
        public static List<int> cutTheSticks(List<int> arr)
        {
            List<int> result = new(); int a;
            result.Add(arr.Count);
            a = arr.Min();
            arr.RemoveAll(s => s == a);
            while (arr.Count > 0)
            {
                if (arr.Count == 2 && arr[0] == arr[1]) { result.Add(arr.Count); break; }
                if (arr.Count == 1) { result.Add(arr.Count); break; }
                for (int i = 0; i < arr.Count; i++) { arr[i] -= a; }
                a = arr.Min(); result.Add(arr.Count);
                arr.RemoveAll(s => s == a);
            }
            return result;
        }

        //unique Permutation
        public static List<int> permutationEquation(List<int> p)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < p.Count; i++)
            {
                int index = p.IndexOf(i + 1) + 1;
                index = p.IndexOf(index) + 1;
                result.Add(index);
            }
            return result;
        }

        //Lisa's Notebook
        public static int workbook(int n, int k, List<int> arr)
        {
            int[,] counter = new int[1, 2];
            int result; int pageCount = 1;
            int count = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                counter[0, 0] = 1; counter[0, 1] = k;
                if (arr[i] < k && arr.IndexOf(arr[i]) == 0) { count++; i++; }
                result = arr[i];
                while (result > k)
                {
                    pageCount++; counter[0, 0] += k; counter[0, 1] += k;
                    result += -k;
                    if (counter[0, 0] >= pageCount && pageCount <= counter[0, 1]) count++;
                }
                pageCount++; counter[0, 0] += k; counter[0, 1] += k;
                if (result > 0 && result < k && pageCount >= counter[0, 0] && pageCount <= counter[0, 1]) count++;
            }
            return count;
        }

        //pangram
        public static string pangrams(string s)
        {
            int count = 0; string result = "";
            string[] arr = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            for (int i = 0; i < arr.Length; i++)
            {
                if (s.Trim().Contains(arr[i].ToString(), StringComparison.CurrentCultureIgnoreCase)) count++;
            }
            result = (count == 26) ? "pangram" : "not pangram";
            return result;
        }
        public static int utopianTree(int n)
        {
            int result = 0; int a;
            List<int> cyclesList = new();
            List<int> ValuesList = new();
            cyclesList.Add(0);
            ValuesList.Add(1);
            for (int i = 1; i <= n; ++i)
            {
                cyclesList.Add(i);
                ValuesList.Add(_ = (i > 0 && i % 2 != 0) ? ValuesList[i - 1] * 2 : ValuesList[i - 1] + 1);
            }
            result = ValuesList[ValuesList.Count - 1];
            return result;
        }

        //beautiful triplets
        public static int beautifulTriplets(int d, List<int> arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Count - 2; i++)
            {
                count += (arr[i + 2] - arr[i + 1] == arr[i + 1] - arr[i]) ? 1 : 0;
            }
            return count;
        }

        //detect Kaprekar
        public static bool DetectKaprekar(int num)
        {
            long square = (long)num * (long)num;

            int digits = num.ToString().Length;
            long divisor = (long)Math.Pow((double)10, (double)digits);

            int x = (int)(square % divisor);
            square /= divisor;

            int y = (int)square;

            if ((x + y) == num) return true;

            return false;
        }

        //Karprekar
        public static void kaprekarNumbers(int p, int q)
        {
            int count = 0;
            while (p <= q)
            {
                if (DetectKaprekar(p))
                {
                    Console.Write($"{p} ");
                    count++;
                }
                p++;
            }
            if (count.Equals(0)) Console.Write("INVALID RANGE");
        }

        //module factorial
        public static BigInteger Factorials(int n)
        {
            BigInteger result;
            if (n == 0) result = 1;
            else result = n * ProblemSolving2.Factorials(n - 1);
            return result;
        }
        //xtra Long Factorials
        public static void extraLongFactorials(int n)
        {
            Console.WriteLine(ProblemSolving2.Factorials(n));
        }

        //strange viral Advertising Strategy // an = arn - 1 (or) an = r an - 1
        public static int viralAdvertising(int n)
        {
            int result = 0;
            return result;
        }

        //julian and Gregorian Calender Comparism
        //Time Machine.
        public static string dayOfProgrammer(int year)
        {
            string result = String.Empty;
            return result;
        }
        //private static HashSet<string> hasher = new HashSet<string>();

        //the QUEEN.(Chess game Algorithm optimized) AGzion.
        public static int queensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
        {
            int result = 0; int y = 0;
            c_q = c_q - 1; r_q = r_q - 1;
            string[,] ChessBoard = new string[n, n];
            List<int> zeroIndexed = new();
            List<int> oneIndexed = new();
            if (obstacles.Count != 0)
            {
                for (int i = 0; i < obstacles.Count; i++)
                {
                    zeroIndexed[i] = obstacles[i][0] - 1;
                    oneIndexed[i] = obstacles[i][1] - 1;
                }
            }

            //provide identity to each square
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    ChessBoard[i, j] = i + "" + j;
                }
            }

            //lower left to right diagonal count
            y = (r_q - c_q + 1);
            for (int x = c_q - Math.Abs(r_q - c_q); x <= c_q + Math.Abs(c_q - r_q); ++x)
            {
                if (zeroIndexed.Contains(x) && oneIndexed.Contains(y) && zeroIndexed.IndexOf(x) == oneIndexed.IndexOf(y) && x < r_q) result -= r_q;
                if (zeroIndexed.Contains(x) && oneIndexed.Contains(y) && zeroIndexed.IndexOf(x) == oneIndexed.IndexOf(y) && x > r_q) break;
                if (ChessBoard[x, y] == r_q + "" + c_q) result += 0;
                else { result++; }
                y++;
            }

            //lower right to left diagonal count.
            y = (c_q - r_q - 1);                     //y component increases, x decease.
            for (int x = Math.Abs(r_q + c_q - 1); x-- > (n - r_q - 1);)
            {
                if (zeroIndexed.Contains(x) && oneIndexed.Contains(y) && zeroIndexed.IndexOf(x) == oneIndexed.IndexOf(y) && x > r_q) result -= r_q;
                if (zeroIndexed.Contains(x) && oneIndexed.Contains(y) && zeroIndexed.IndexOf(x) == oneIndexed.IndexOf(y) && x < r_q) break;
                if (ChessBoard[x, y] == (r_q) + "" + (c_q)) result += 0;
                else { result++; }
                y++;
            }

            //left to right
            for (int i = 0; i < n; i++)
            {
                if (zeroIndexed.Contains(r_q) && oneIndexed.Contains(i) && zeroIndexed.IndexOf(r_q) == oneIndexed.IndexOf(i) && i < r_q) result -= r_q;
                if (zeroIndexed.Contains(r_q) && oneIndexed.Contains(i) && zeroIndexed.IndexOf(r_q) == oneIndexed.IndexOf(i) && i > r_q) break;
                if (ChessBoard[r_q, i] == r_q + "" + c_q) result += 0;
                else { result++; }
            }

            //down to up
            for (int i = 0; i < n; i++)
            {
                if (zeroIndexed.Contains(i) && oneIndexed.Contains(c_q) && zeroIndexed.IndexOf(i) == oneIndexed.IndexOf(c_q) && i < r_q) result -= r_q;
                if (zeroIndexed.Contains(i) && oneIndexed.Contains(c_q) && zeroIndexed.IndexOf(i) == oneIndexed.IndexOf(c_q) && i > r_q) break;
                if (ChessBoard[i, c_q] == r_q + "" + c_q) result += 0;
                else { result++; }
            }
            return result;
        }
        //jumping clouds
        public static int jumpingOnClouds(List<int> c)
        {
            int result = 0; int count = 0;//cloud count before first thunder cloud.
            for (int i = 0; i < c.Count; i++)
            {
                switch (i + 2 <= c.Count - 1 && c[i + 2] == 0)
                {
                    case true:
                        count++; i += 1;
                        break;
                    case false:
                        if (i + 2 <= c.Count - 1 && c[i + 2] == 1 && c[i + 1] == 0) { count++; }
                        if (i + 1 == c.Count - 1 && c[i + 1] == 0) { count++; }
                        break;
                }
            }
            result = count;
            return result;
        }

        // jumpingOnClouds Revisited. ((i + k) % c.Length == 0)
        public static int jumpingOnClouds(int[] c, int k)
        {
            int Currentenergy = 100; int n = c.Length;
            int tc = 3; int nc = 1; int loss = 0; int i = 0;
            while (true)
            {
                i += k;
                if (i >= n) i = i % n;
                loss = (c[i] == 1) ? tc : nc;
                Currentenergy -= loss;
                if (i == 0) break;
            }
            return Currentenergy;
        }
        //Library fine
        public static int libraryFine(int d1, int m1, int y1, int d2, int m2, int y2)
        {
            int result = 0;
            int[] MonthsDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (d1 < d2 && m1 == m2 && y1 == y2) result = 0;
            if (d1 > d2 && m1 == m2 && y1 == y2) result = 15 * (d1 - d2);
            if (m1 > m2 && y1 == y2) result = 500 * (m1 - m2);
            if (y1 > y2) result = 10000;
            return result;
        }

        //game console purchase
        //a +(n-1)d a==p
        public static int howManyGames(int p, int d, int m, int s)
        {
            int result = p; List<int> SeriesList = new(); int n = 2; int a = 0; int z = 0;
            if (p > s)
            {
                return 0;
            }
            else
            {
                SeriesList.Add(p);
                a = SeriesList.Aggregate(func: (res, ele) => (res + ele));
                while (result >= m)
                {
                    result = p + ((n - 1) * -d);
                    if (result >= m && a + m <= s) SeriesList.Add(result); ++n;
                }
                a = SeriesList.Aggregate(func: (res, ele) => (res + ele));
                if (a < s)
                {
                    while (a + m <= s) { SeriesList.Add(m); a += m; }
                }
                else
                {
                    z = SeriesList.Count - 1;
                    while (a > s)
                    {
                        SeriesList.Remove(SeriesList[z]); --z;
                        a = SeriesList.Aggregate(func: (res, ele) => (res + ele));
                    }
                }
                return SeriesList.Count;
            }
        }

        //breaking records
        public static List<int> breakingRecords(List<int> scores)
        {
            int[] result = new int[2]; int h; int l;
            h = scores[0]; l = scores[0];
            for (int i = 1; i < scores.Count; i++)
            {
                if (scores[i] < l) { result[1]++; l = scores[i]; }
                if (scores[i] > h) { result[0]++; h = scores[i]; }
            }
            return result.ToList();
        }

        //super reduced string
        public static string superReducedString(string s)
        {
            string superR = s; string a = String.Empty; int n = s.Length;
            for (int i = 0; i < n; i++)
            {
                if (i + 1 <= superR.Length - 1 && superR[i] == superR[i + 1])
                {
                    a = superR[i].ToString();
                    superR = superR.Remove(i, 2);
                    i = -1; n = superR.Length;
                }
            }
            superR = (superR == String.Empty) ? "Empty String" : superR;
            return superR.Trim();
        }

        /// <summary>
        /// Password Recommendation
        /// </summary>
        public static int minimumNumber(int n, string password)
        {
            int result = 0;
            string numbers = "0123456789";
            string lower_case = "abcdefghijklmnopqrstuvwxyz";
            string upper_case = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string special_characters = "!@#$%^&*()-+";
            return result;
        }
        //bigger is greater
        public static string biggerIsGreater(string w)
        {
            string result = String.Empty;
            string[] swap = new string[2]; string[] splitter = new string[2];
            string lower_case = "abcdefghijklmnopqrstuvwxyz";
            if (w.Length == 2 && w[0] != w[1])
            {
                swap[0] = w[0].ToString(); swap[1] = w[1].ToString();
                swap.Reverse();
            }
            if (w.Length == 1 || w.Length == 2 && w[0] == w[1]) result = "no answer";
            else
            {
                for (int i = w.Length; i-- > 0;)
                {
                    if (i - 1 >= 0 && lower_case.IndexOf(w[i].ToString()) > lower_case.IndexOf(w[i - 1].ToString()))
                    {
                        swap[0] = w[i].ToString(); swap[1] = w[i - 1].ToString();
                        swap.Reverse();
                        splitter[0] = w.Substring(0, i - 1);
                        splitter[1] = (i == w.Length - 1) ? "" : w.Substring(i + 1, (w.Length - 1) - i);
                        break;
                    }
                }
            }
            result = (string.IsNullOrEmpty(swap[0])) ? "no answer" : (splitter[0] + swap[0] + swap[1] + splitter[1]).Trim();
            return result;
        }

        ///Little Bobby
        public static int chocolateFeast(int n, int c, int m)
        {
            decimal chocolates = Math.Floor((decimal)(n / c));
            decimal wrappings = chocolates;
            while (wrappings >= m)
            {
                chocolates += Math.Floor((decimal)wrappings / m);
                wrappings = Math.Floor((decimal)wrappings / m) + (wrappings % m);
            }
            return (int)chocolates;
        }
    }
}
