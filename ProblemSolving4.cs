using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HandyKits
{
    internal class ProblemSolving4
    {
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

        //do they belong Andela
        static bool DoTheyBelong(int AB, int AC, int BC)
        {
            return true;
        }
        //IS Pallindrome
        public static bool isPalindrome(string s)
        {
            var ch = s.ToCharArray();
            Array.Reverse(ch);
            return s.Equals(new string(ch));
        }

        //Equip With Substitutions
        public static bool IsValidSubstitutions(string s, int subs)
        {
            int count = subs; int i = 0; int j = s.Length - 1;
            bool result = false;
            if (subs == 0 && isPalindrome(s)) result = true;
            while (count > 0)
            {
                s.Replace(s[i], s[j]);
                if (isPalindrome(s)) { return true; }
                count--; i++; j--;
            }
            return result;
        }

        //Can you detec a pallindrome.. Andela
        static string CanYouMAkeaPallndrom(string s, List<int> startIndex, List<int> endIndex, List<int> Subs)
        {
            string result = String.Empty;
            for (int i = 0; i < startIndex.Count; i++)
            {
                string test = s.Substring(startIndex[i], endIndex[i] + 1);
                if (ProblemSolving4.IsValidSubstitutions(s, Subs[i]) && isPalindrome(test)) result += "1";
                else { result += "0"; }   
            }
            return result;
        }

        //minimum absolute difference........Andela
        public static void closestNumbers(List<int> numbers)
        {
            List<string> row = new List<string>();
            List<List<int>> results = new List<List<int>>();
            int temp = 0;
            //save the first indexes of operands with each difference 
            numbers = numbers.OrderBy(a => a).ToList();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i > 0) results.Add(new List<int> { (numbers[i] - numbers[i - 1]), numbers[i - 1], numbers[i] });
            }
            //sort
            results.Sort((x, y) => x[1].CompareTo(y[1]));
            results.Reverse();
            for (int i = 0; i < results.Count; i++)
            {
                Console.WriteLine("{0} {1}", results[i][1].ToString(), results[i][2].ToString());
            }
        }

        //create Pallindrome
        //reversed is O(1) only when the collection conforms to RandomAccessCollection (which String does not!)
        public static int palindromeIndex(string s)
        {
            if (isPalindrome(s))
                return -1;
            else
            {
                var len = s.Length;
                for (int i = 0; i < len / 2; ++i)
                {
                    var left = s[i];
                    var right = s[len - 1 - i];

                    if (left != right)
                    {
                        var sub = s.Substring(i, len - i * 2);
                        var sublen = sub.Length;
                        if (isPalindrome(sub.Substring(0, sublen - 1)))
                        {
                            return i + sublen - 1;
                        }
                        else if (isPalindrome(sub.Substring(1, sublen - 1)))
                        {
                            return i;
                        }
                    }
                }
            }

            return -1;
        }

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
    }
    //Inorder Node is one which contains the smallest value but > value of the current Node after traversing the whole node 
    class Node
    {
        public int value { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }
        public Node(int value, Node left, Node right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }
    }

    class BinarySearchTree
    {
        public Node root;
        public bool Contains(int value)
        {
            Node current = root;
            while (current != null)
            {
                if (value < current.value)
                {
                    current = current.left;
                }
                else if (value > current.value)
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
