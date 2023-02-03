using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HandyKits
{
    internal class ProblemSolving4
    {
        //Two Strings
        public static int alternate(string s)
        {
            var permArray = (from item1 in s.Distinct().ToArray()
                             from item2 in s.Distinct().ToArray()
                             where item1 > item2
                             select new[] { item1, item2 }).ToList();
            int returnLength = 0;

            if (Regex.IsMatch(s, "^([a-z])(?!\\1)([a-z])(?:\\1\\2)*\\1?$"))
            {
                return s.Length;
            }
            else
            {
                for (int i = 0; i < permArray.Count; i++)
                {
                    var charList = new string(s.Distinct().ToArray());
                    String chars = "[" + String.Concat(permArray[i]) + "]";
                    var charArray = Regex.Replace(charList, chars, String.Empty).ToCharArray();
                    String chars2 = "[" + String.Concat(charArray) + "]";
                    string result = Regex.Replace(s, chars2, String.Empty);

                    if (Regex.IsMatch(result, "^([a-z])(?!\\1)([a-z])(?:\\1\\2)*\\1?$") && result.Length > returnLength)
                    {
                        returnLength = result.Length;
                    }
                }
            }
            return returnLength;
        }

        //ABsolute Permutation
        public static List<int> absolutePermutation(int n, int k)
        {
            if (k == 0) return Enumerable.Range(1, n).ToList();

            HashSet<int> result = new();

            for (int i = 1; i <= n; i++)
            {
                var permutationElement = i > k ? i - k : i + k;
                if (permutationElement > n || result.Contains(permutationElement))
                {
                    permutationElement = i < k ? i - k : i + k;
                    if (permutationElement > n || result.Contains(permutationElement))
                    {
                        return new List<int> { -1 };
                    }
                }
                result.Add(permutationElement);
            }
            return result.ToList();
        }

        //CavityMap
        public static List<string> cavityMap(List<string> grid)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < grid.Count; i++)
            {
                string row = string.Empty;
                for (int j = 0; j < grid.Count; j++)
                {
                    if (i.Equals(0) || i.Equals(grid.Count - 1) ||
                        j.Equals(0) || j.Equals(grid.Count - 1))
                    {
                        row += grid[i][j];
                    }
                    else if (grid[i][j] > grid[i - 1][j] &&
                     grid[i][j] > grid[i + 1][j] &&
                     grid[i][j] > grid[i][j - 1] &&
                     grid[i][j] > grid[i][j + 1])
                    {
                        row += 'X';
                    }
                    else row += grid[i][j];
                }
                result.Add(row);
            }
            return result;
        }
 
        //Viral Advertising
        public static int viralAdvertising(int n)
        {
            if (n == 1) return 5 / 2;

            int shares = 5;
            int likes = 5 / 2;
            int cumulativeLikes = 5 / 2;
            for (int i = 2; i <= n; i++)
            {
                shares = likes * 3;
                likes = shares / 2;
                cumulativeLikes += likes;
            }

            return cumulativeLikes;
        }

        //Grid Search
        public static string gridSearch(List<string> G, List<string> P)
        {
            int len = P.Count;
            int horizontal = P[0].Length;
            for (int i = 0; i <= G.Count - len; i++)
            {
                string s1 = "";
                for (int y = 0; y <= G[0].Length - horizontal; y++)
                {
                    string s2 = G[i];
                    s1 = s2.Substring(y, horizontal);
                    int a = i + 1;
                    int b = 1;
                    if (s1 == P[0])
                    {
                        while (b <= P.Count - 1)
                        {
                            s2 = G[a];
                            s1 = s2.Substring(y, horizontal);
                            if (s1 != P[b])
                                break;
                            else
                            {
                                b++;
                                a++;
                            }
                        }
                    }
                    if (b == P.Count)
                        return "YES";
                }
            }
            return "NO";
        }

        //create Pallindrome
        //reversed is O(1) only when the collection conforms to RandomAccessCollection (which String does not!)
        

        //Two Pluses Two Crosses
        private static int[,] mtx;
        private static void initMtx(List<string> grid)
        {
            int rowIdx = 0;
            mtx = grid.Aggregate(new int[grid[0].Length, grid.Count], (m, s) =>
            {
                s.Aggregate(0, (idx, c) =>
                {
                    m[idx, rowIdx] = c.ToString().ToUpper() == "G" ? 1 : 0;
                    return ++idx;
                });
                rowIdx++;
                return m;
            });

        }
        private static int getSingleProd(int k1, int[] coord1, int k2, int[] coord2)
        {
            if (k1 == 3 && coord1[0] == 9 && coord1[1] == 4 && k2 == 6 && coord2[0] == 5 && coord2[1] == 7)
            { }
            int dx = Math.Abs(coord1[0] - coord2[0]), dy = Math.Abs(coord1[1] - coord2[1]);
            if (dx > dy) { dx ^= dy; dy ^= dx; dx ^= dy; } // i.e. make dx <= dy
            if (k1 > k2) { k1 ^= k2; k2 ^= k1; k1 ^= k2; } // i.e. make k1 <= k2


            while (dx == 0 && k2 + k1 > dy + 1)
            {
                if (k2 > k1) k2--; else k1--;
            }
            if (dx > 0 && dy < k1) // i.e. dx < k1 && dx < k2 - 2 intersections
            {
                if ((1 + 4 * (dy - 1)) * (1 + 4 * (dy - 1)) > (1 + 4 * (dx - 1)) * (1 + 4 * (k2 - 1))) { k1 = dy; k2 = dy; } else { k1 = dx; }
            }
            else if (dx > 0 && dx < k1 && dy < k2) // 1 intersection
            {
                if ((1 + 4 * (dx - 1)) * (1 + 4 * (k2 - 1)) > (1 + 4 * (k1 - 1)) * (1 + 4 * (dy - 1))) k1 = dx; else k2 = dy;
            }
            return (1 + 4 * (k1 - 1)) * (1 + 4 * (k2 - 1));
        }
        private static int getMaxProdSameKey(int k, IEnumerable<int[]> lstCoords) // , ref int max, ref int min
        {
            int[] coords1 = lstCoords.ElementAt(0);

            return Math.Max(lstCoords.Skip(1).Aggregate(0, (prod, cur) => Math.Max(prod, getSingleProd(k, cur, k, coords1))),
                lstCoords.Count() > 1 ? getMaxProdSameKey(k, lstCoords.Skip(1)) : 0);
        }
        private static int getMaxProd2Lists(int k1, IEnumerable<int[]> lstCoordsLo, int k2, IEnumerable<int[]> lstCoordsHi) // , ref int max, ref int min
        {
            return lstCoordsHi.Aggregate(0, (prod, curHi) => Math.Max(prod, lstCoordsLo.Aggregate(prod, (prd, curLo) => Math.Max(prd, getSingleProd(k1, curLo, k2, curHi)))));
        }
        public static int twoPluses(List<string> grid)
        {
            initMtx(grid);
            int max = 0, totCnt = 0;
            var dict = new Dictionary<int, List<int[]>>();
            for (int j = 0; j < mtx.GetLength(1); j++) // cols-loop
                for (int i = 0; i < mtx.GetLength(0); i++) // rows-loop
                {
                    if (mtx[i, j] == 0) continue;
                    int k = 1;
                    while (i - k >= 0 && i + k < mtx.GetLength(0) && j - k >= 0 && j + k < mtx.GetLength(1)
                    && mtx[i - k, j] * mtx[i + k, j] * mtx[i, j - k] * mtx[i, j + k] == 1) k++;
                    max = Math.Max(max, k);
                    totCnt++;
                    if (dict.ContainsKey(k)) dict[k].Add(new int[] { i, j });
                    else dict[k] = new List<int[]> { new int[] { i, j } };
                }
            if (totCnt < 2) return 0;
            if (max == 1) return 1;
            int idx = 0;
            var ordKeys = dict.Keys.OrderByDescending(k => k);
            return ordKeys.Aggregate(0, (prod, k) =>
            {
                if (prod < (1 + 4 * (k - 1)) * (1 + 4 * (k - 1)))
                {
                    prod = Math.Max(prod, getMaxProdSameKey(k, dict[k]));
                    if (idx++ < dict.Keys.Count)
                        prod = Math.Max(prod, ordKeys.Skip(idx).Aggregate(prod, (p, kk) => p < (1 + 4 * (k - 1)) * (1 + 4 * (kk - 1)) ? Math.Max(p, getMaxProd2Lists(kk, dict[kk], k, dict[k])) : p));
                }
                return prod;
            });
        }

        //ACMTeam
        public static List<int> acmTeam(List<string> topic)
        {
            List<int> ints = new List<int>();
            List<int> results = new List<int>();
            int max = 0;
            for (int i = 0; i < topic.Count - 1; i++)
            {
                for (int y = i + 1; y < topic.Count; y++)
                {
                    int syc = 0;
                    for (int z = 0; z < topic[i].Length; z++)
                    {
                        if (topic[i][z] == '1' || topic[y][z] == '1')
                        {
                            syc++;
                        }
                    }
                    results.Add(syc);
                    if (syc > max)
                        max = syc;
                }
            }
            ints.Add(max);
            int syac = 0;
            for (int i = 0; i < results.Count; i++)
            {
                if (results[i] == max)
                    syac++;
            }
            ints.Add(syac);
            return ints;
        }

        //Unique Names
        public static string[] UniqueNames(string[] names1, string[] names2)
        {
            string[] newArray = new string[names1.Length + names2.Length];
            Array.Copy(names1, newArray, names1.Length);
            Array.Copy(names2, 0, newArray, names1.Length, names2.Length);
            return newArray.ToList().Distinct().ToArray();
        }

        //full counting sort
        public static void countSort(List<List<string>> arr)
        {
            int mid = (int)Math.Ceiling((decimal)arr.Count / 2m);
            List<List<string>> sorted = new List<List<string>>();

            for (int i = 0; i < arr.Count; i++)
            {
                int val = int.Parse(arr[i][0]);
                while ((sorted.Count - 1) < val) sorted.Add(new List<string>());
                if (i < mid) sorted[val].Add("-");
                else sorted[val].Add(arr[i][1]);
            }

            string result = string.Empty;
            for (int n = 0; n < sorted.Count; n++) result += string.Join(" ", sorted[n]) + " ";
            Console.Write(result.Trim());
        }

        //bomberman
        public static List<string> bomberMan(int n, List<string> grid)
        {
            int[,] bombermanPosition = new int[1, 1];
            List<int> BombLocations = new List<int>();
            List<string> result = new List<string>();
            for (int i = 0; i < grid.Count; i++)
            {
                for (int j = 0; j < grid.LongCount(); j++)
                {

                }
            }
            return result;
        }
        public static bool tester(int A, int B)
        {
            string Aa = Convert.ToString(A, 2);
            string Bb = Convert.ToString(B, 2);
            string test = Convert.ToString(A ^ B, 2); ;
            //the number of zeros that dont match
            bool result = Aa.Remove(0, (Aa.Length - Bb.Length)).Split('0').Length
                          == (Convert.ToString(A ^ B, 2).Remove(0, (Aa.Length - Bb.Length)).Split('1').Length + 1);
            return result;
        }
        static bool CheckPracticalConformance(int A, int Query)
        {
            bool result = true;
            string QueryStr = Convert.ToString(Query, 2);
            if (QueryStr.Length == 30)
            {
                string strRep = Convert.ToString(A, 2);
                //List<string> QueryArr = Array.ConvertAll(QueryStr.ToCharArray(), a => a.ToString()).ToList();
                //List<string> strRepArr = Array.ConvertAll(strRep.ToCharArray(), a => a.ToString()).ToList();
                //result = QueryArr.All(t => t == "1"# && strRepArr[QueryArr.IndexOf(t)] == "1");
                result = strRep.Except(QueryStr).Contains('0');
            }
            return result;
        }
        public static int CountConformingBitmasks(int A, int B, int C)//(1073741727, 1073741631, 1073741679)
        {
            int result = 0;
            List<int> nums = new List<int>();
            List<int> nums2 = new List<int>();
            nums.Add(A); nums.Add(B); nums.Add(C);
            for (int i = 0; i <= nums.Max(); i++)
            {
                if (Convert.ToString(i, 2).Length == 30) nums2.Add(i);
            }
            for (int i = 0; i < nums2.Count; ++i)
            {
                result += (CheckPracticalConformance(A, nums2[i]) || CheckPracticalConformance(B, nums2[i]) || CheckPracticalConformance(C, nums2[i])) ? 1 : 0;
            }
            return result;
        }

        //Picking Numbers
        public static int pickingNumbers(List<int> a)
        {
            a.OrderBy(a => a);
            List<List<int>> subArrays = new();
            for (int i = 0; i < a.Count; i++)
            {
                int r = a[i];
                int rplus = r + 1;
                List<int> arr = new();
                arr.Add(r);
                for (int j = i + 1; j < a.Count; ++j)
                {
                    if (a[j] == r || a[j] == rplus)
                    {
                        arr.Add(a[j]);
                    }
                }
                subArrays.Add(arr);
            }
            int max = subArrays[0].Count;
            foreach (List<int> ar in subArrays)
            {
                if (ar.Count > max)
                {
                    max = ar.Count;
                }
            }
            return max;
        }

        //Manasa Stones
        public static List<int> stones(int n, int a, int b)
        {
            n -= 1;
            List<int> result = new List<int>();
            result.Add(a * n);
            result.Add(b * n);
            for (int i = 1; i <= (n / 2); i++)
            {
                result.Add((a * i) + (b * (n - i)));
                result.Add((b * i) + (a * (n - i)));
            }
            result.Sort();
            return result.Distinct().ToList();
        }

        //public static int populateNode()
        //{
        //    int result = 0;
        //    Node root = new Node(1, new Node(2, new Node(4), new Node(5))
        //        , new Node(3, new Node(6), new Node(7)));
        //    return result;
        //}
    }
    //Inorder Node is one which contains the smallest value but > value of the current Node after traversing the whole node 
    class Node
    {
        public int data { get; set; }
        public Node? left { get; set; }
        public Node? right { get; set; }
        public Node? parent { get; set; }
        public Node(int value)
        {
            this.data = value;
        }
    }

    class BinarySearchTree
    {
        public Node? root;
        public bool Contains(int value)
        {
            Node? current = root;
            while (current != null)
            {   
                if (value < current.data)
                {
                    current = current.left;
                }
                else if (value > current.data)
                {
                    current = current.right;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
