using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace HandyKits
{
    // A binary tree node
    //Array(len).fill(val) is similar to Enumerable.Repeat(val, len).
    public class BinaryTree
    {
        static Node head;

        /* Given a binary search tree and a number,
           inserts a new node with the given number in
           the correct place in the tree. Returns the new
           root pointer which the caller should then use
           (the standard trick to avoid using reference
           parameters). */

        Node insert(Node node, int data)
        {

            /* 1. If the tree is empty, return a new,    
                 single node */
            if (node == null)
            {
                return new Node(data);
            }
            else
            {
                Node? temp = null;
                /* 2. Otherwise, recur down the tree */
                if (data <= node.data)
                {
                    temp = insert(node.left, data);
                    node.left = temp;
                    temp.parent = node;
                }
                else
                {
                    temp = insert(node.right, data);
                    node.right = temp;
                    temp.parent = node;
                }

                /* return the (unchanged) node pointer */
                return node;
            }
        }

        Node inOrderSuccessor(Node? root, Node n)
        {

            // step 1 of the above algorithm
            if (n.right != null)
            {
                return minValue(n.right);
            }

            // step 2 of the above algorithm
            Node p = n.parent;
            while (p != null && n == p.right)
            {
                n = p;
                p = p.parent;
            }
            return p;
        }

        static void findPreSuc(Node root, int key)
        {

            // Base case
            if (root == null)
                return;

            // If key is present at root
            if (root.data == key)
            {
                // The maximum value in left
                // subtree is predecessor
                if (root.left != null)
                {
                    Node tmp = root.left;
                    while (tmp.right != null)
                        tmp = tmp.right;

                    var pre = tmp;
                }

                // The minimum value in
                // right subtree is successor
                if (root.right != null)
                {
                    Node tmp = root.right;

                    while (tmp.left != null)
                        tmp = tmp.left;

                    var suc = tmp;
                }
                return;
            }

            // If key is smaller than
            // root's key, go to left subtree
            if (root.data > key)
            {
                var suc = root;
                findPreSuc(root.left, key);
            }

            // Go to right subtree
            else
            {
                var pre = root;
                findPreSuc(root.right, key);
            }
        }

        /* Given a non-empty binary search  tree, return the minimum data value found in that tree. Note that the entire tree does not need
         to be searched. */

        Node minValue(Node node)
        {
            Node current = node;

            /* loop down to find the leftmost leaf */
            while (current.left != null)
            {
                current = current.left;
            }
            return current;
        }
    }

    internal class ProblemSolving7
    {

        // Create a function that takes a single integer parameter, n, 
        //and returns the first n elements of the Fibonacci sequence.
        // Rabin-Karp and Knuth-Morris-Pratt
        //        g(1) = [ 0 ]
        //        g(2) = [ 0, 1 ]
        //        g(3) = [ 0, 1, 1 ]
        //        g(4) = [ 0, 1, 1, 2 ]
        //        g(5) = [ 0, 1, 1, 2, 3 ]

        //longest path on left
        public int FindLeftLongestPath(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            int left = FindLeftLongestPath(root.left);
            int right = FindLeftLongestPath(root.right);
            return Math.Max(left, right) + 1;
        }
        //longest path on right
        // BST sucessor search
        //BST predecessor search

        //public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        //{
        //    List<T> lis = iterable.ToList<T>();
        //    return lis.Cast<T>().Select((x, i) => (i != iterable.Count() - 1) ? x + "," : x);
        //}

        //bool areEqual = brr.SequenceEqual(arr,comparer);

        static void Temperature(string[] args)
        {
            List<int> posi = new List<int>();
            List<int> nega = new List<int>();
            string[] emptyArr = { "0" };
            int N = int.Parse(Console.ReadLine());
            string[] inputs = Console.ReadLine().Split(' ');
            if (N == 0 || inputs.Length == 0 || inputs == null)
            {
                Console.Write(0);
            }
            else
            {
                for (int i = 0; i < N; i++)
                {
                    int t = int.Parse(inputs[i]);
                    if (Math.Sign(t) == 1) posi.Add(t);
                }
                posi.Sort((a, b) => a - b);
                nega.Sort((a, b) => b - a);
                if (posi.Count == 0) Console.Write(nega[0]);
                if (nega.Count == 0) Console.Write(posi[0]);
                Console.Write(Math.Min(posi[0] - 0, 0 - nega[0]));
            }
        }
    }

    internal class Difficult
    {
        //Crazy Triangle
        //Area A = [ x1(y2 – y3) + x2(y3 – y1) + x3(y1-y2)]/2 
        //s=(A+B+C)/2  -> Math.Pow((S*(S-a)*(S-b)*(S-c)),0.5)
        //for An Arbitrary point P , in Triangle ABC PAB+PAC+PBC must be = ABC
        public const int MAX = 256;

        // This function returns true if
        // contents of arr1[] and arr2[]
        // are same, otherwise false.
        public static bool compare(char[] arr1, char[] arr2)
        {
            for (int i = 0; i < MAX; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    return false;
                }
            }
            return true;
        }
        // This function search for all
        // permutations of pat[] in txt[]
        public static void search(string pat, string txt)
        {
            int M = pat.Length;
            int N = txt.Length;

            // countP[]: Store count of all
            // characters of pattern
            // countTW[]: Store count of current
            // window of text
            char[] countP = new char[MAX];
            char[] countTW = new char[MAX];
            for (int i = 0; i < M; i++)
            {
                (countP[pat[i]])++;
                (countTW[txt[i]])++;
            }

            // Traverse through remaining
            // characters of pattern
            for (int i = M; i < N; i++)
            {
                // Compare counts of current window
                // of text with counts of pattern[]
                if (compare(countP, countTW))
                {
                    Console.WriteLine("Found at Index " + (i - M));
                }

                // Add current character to
                // current window
                (countTW[txt[i]])++;

                // Remove the first character of
                // previous window
                countTW[txt[i - M]]--;
            }

            // Check for the last window in text
            if (compare(countP, countTW))
            {
                Console.WriteLine("Found at Index " + (N - M));
            }
        }

        // Driver Code
        //public static void Main(string[] args)
        //{
        //    string txt = "BACDGABCDA";
        //    string pat = "ABCD";
        //    search(pat, txt);
        //}

        public static int Permute(int num)
        {
            //recursive
            if (num == 0)
            {
                return 1;
            }
            return num * Permute(num - 1);
        }
        public static long maxSubarrayValue(List<int> arr)
        {
            //n! / (r! * (n - r)!)
            double maxcount = 0; double count = 0;
            List<double> result = new List<double>();
            List<double> evenresult = new List<double>();
            List<double> oddresult = new List<double>();
            if (arr.Count < 2) return 0;
            if (arr.Count == 2) return (long)(Math.Pow(arr.First(), 2) - arr.Last());
            for (int i = 0; i < arr.Count; ++i)
            {
                if (i % 2 == 0) evenresult.Add(Math.Pow(arr[i], 2));
                if (i % 2 != 0) oddresult.Add(arr[i]);
            }
            for (int i = 0; i < evenresult.Count; i++)
            {
                for (int j = 0; j < oddresult.Count; j++)
                {
                    count = Math.Pow(evenresult[i], 2) - oddresult[j];
                    if (count > maxcount) { maxcount = count; result.Clear(); result.Add(Math.Pow(evenresult[i], 2) - oddresult[j]); }
                }
                count = 0;
            }
            return (long)result.First();

        }

        public static bool con(string s1, string s2)
        {
            string[] arr = Array.ConvertAll(s1.ToCharArray(), a => a.ToString());
            for (int i = 0; i < s2.Length; i++)
            {
                if (!arr.ToList().Contains(s2[i].ToString())) return false;
            }
            return true;
        }
        public static int renameFile(string newName, string oldName)
        {
            int similarCount = 0;
            //for (int i = 0; i < oldName.Length; i++)
            //{
            //    similarCount += oldName.Split(oldName[i]).Length - 1;
            //}
            List<string> s33 = Array.ConvertAll(oldName.ToCharArray(), a => a.ToString()).Distinct().ToList();
            int s3 = string.Join("", s33).Length;

            int s2 = newName.Length;
            int s1 = oldName.Length;
            if (s2 > s1) return 0;
            if (!con(oldName, newName)) return 0;
            long a = Permute(s3);
            long b = Permute(s2);
            int c = Permute(s3 - s2);
            return (int)(a / b * c);
        }

        static double CalculateTriangleArea(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            return 0.5 * (Math.Abs((x1 * (y2 - y3)) + (x2 * (y3 - y1)) + (x3 * (y1 - y2))));
        }
        public static double DistanceBetweenPoints(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
        }
        static double CalculateEucledianistance(int x1, int y1, int x2, int y2)
        { return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)); }
        public static int pointsBelong(int x1, int y1, int x2, int y2, int x3, int y3, int xp, int yp, int xq, int yq)
        {
            int result = 0;
            double abcArea = CalculateTriangleArea(x1, y1, x2, y2, x3, y3);
            //Eucledian
            double AB = CalculateEucledianistance(x1, y1, x2, y2);
            double BC = CalculateEucledianistance(x2, y2, x3, y3);
            double AC = CalculateEucledianistance(x1, y1, x3, y3);
            //for point p
            double abPArea = CalculateTriangleArea(xp, yp, x2, y2, x3, y3);
            double bcPArea = CalculateTriangleArea(x1, y1, xp, yp, x3, y3);
            double PabArea = CalculateTriangleArea(x1, y1, x2, y2, xp, yp);
            // for Q
            double abQArea = CalculateTriangleArea(xq, yq, x2, y2, x3, y3);
            double bcQArea = CalculateTriangleArea(x1, y1, xq, yq, x3, y3);
            double QabArea = CalculateTriangleArea(x1, y1, x2, y2, xq, yq);

            double resQ = abQArea + bcQArea + QabArea;
            double resP = abPArea + bcPArea + PabArea;

            if (AB + BC <= AC && AC + BC <= AB && AB + AC <= BC) { return 0; }
            if (resQ != abcArea && resP == abcArea) result = 1;//p
            if (resQ == abcArea && resP != abcArea) result = 2;//q
            if (resQ == abcArea && resP == abcArea) result = 3;
            if (resQ != abcArea && resP != abcArea) result = 4;
            if (abcArea == 0) result = 4;

            return result;
        }

        public static bool SubstringIsCommonWord(string password, string common_word)
        {
            bool result = false;
            var vowels = new string[] { "a", "e", "i", "o", "u" };
            string lowerCase = "abcdefghijklmnopqrstuvwxyz";
            //substring is english.
            if (password.Length > common_word.Length && password.Split(common_word).Length - 1 > 1) result = true;
            return result;
        }

        public static List<string> getPasswordStrength(List<string> passwords, List<string> common_words)
        {
            //|| passwords[i].All(a => lower_Case.Contains(a.ToString().ToLower()))
            string[] result = new string[passwords.Count];
            var lower_Case = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z " };
            int b = 0;
            int[] nums = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < passwords.Count; i++)
            {
                // is english
                if (common_words.Any(a => a == passwords[i])
                || common_words.Any(a => passwords[i].Split(a).Length - 1 > 0)
                || (passwords[i].Length < 6)
                || (passwords[i].All(a => char.IsLower(a)))  //check for equivalent extension methods in python.
                || (passwords[i].All(a => char.IsUpper(a)))
                || (passwords[i].All(a => nums.Contains(a)))
                ) { result[i] = ("weak"); }
                else { result[i] = "strong"; }
            }
            return result.ToList();
        }

        //IS Pallindrome
        public static bool isPalindrome(string s)
        {
            var ch = s.ToCharArray();
            Array.Reverse(ch);
            return s.Equals(new string(ch));
        }

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

        //Equip With Substitutions
        public static bool IsValidSubstitutions(string s, int subs)
        {
            int count = subs; int i = 0; int j = s.Length - 1;
            bool result = false; string res;
            if (string.IsNullOrEmpty(s)) return false;
            if (subs == 0 && isPalindrome(s)) return true;
            while (count > 0)
            {
                res = s.Replace(s[i], s[j]);
                if (isPalindrome(res)) { return true; }
                count--; i++; j--;
            }
            return result;
        }

        //Can you detec a pallindrome.. Andela
        static string palindromeChecker(string s, List<int> startIndex, List<int> endIndex, List<int> Subs)
        {
            string result = String.Empty; string test = "";
            if (string.IsNullOrEmpty(s)) return "";
            for (int i = 0; i < startIndex.Count; i++)
            {
                if (endIndex[i] + 1 > s.Length || startIndex[i] < 0) return result += "0";
                if (i <= endIndex[i])
                {
                    test = s.Substring(startIndex[i], endIndex[i] - startIndex[i] + 1);
                }
                if (IsValidSubstitutions(s, Subs[i]) && isPalindrome(test)) result += "1";
                else { result += "0"; }
            }
            return result;
        }

        //minimum absolute difference........Andela
        public static void closestNumbers(List<int> numbers)
        {
            List<string> row = new List<string>();
            List<List<int>> results = new List<List<int>>();
            if (numbers.Count == 0) Console.WriteLine("Invalid");
            //save the first indexes of operands with each difference 
            numbers = numbers.OrderBy(a => a).ToList();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i > 0) results.Add(new List<int> { (numbers[i] - numbers[i - 1]), numbers[i - 1], numbers[i] });
            }
            //sort
            results.Sort((x, y) => x[0].CompareTo(y[0]));
            //results.Reverse();
            for (int i = 0; i < results.Count; i++)
            {
                Console.WriteLine("{0} {1} {2}", results[i][0], results[i][1].ToString(), results[i][2].ToString());
            }
        }

        //Covert 2D Array to Jagged Array
        public static int[][] Convert2DArrayToJaggedArray(int[,] twoDArray)
        {
            int rows = twoDArray.GetLength(0);
            int columns = twoDArray.GetLength(1);

            int[][] jaggedArray = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                jaggedArray[i] = new int[columns];

                for (int j = 0; j < columns; j++)
                {
                    jaggedArray[i][j] = twoDArray[i, j];
                }
            }

            return jaggedArray;
        }


        public static int fibb(int n)
        {
            if (n < 2) return n;
            else
            {
                return fibb(n - 1) + fibb(n - 2);
            }
        }

        public static List<int> Task(int n)
        {
            List<int> result = new();
            for (int i = 0; i < n; i++)
            {
                result.Add(fibb(i));
            }
            return result;
        }
        //coding Game
        static void UserName(string[] args)
        {
            Regex check = new Regex(@"^[0-9a-zA-Z]+$");
            string u = Console.ReadLine();
            bool res = false;
            if (string.IsNullOrEmpty(u)) { Console.WriteLine(res); }
            if (u.Length < 3 || u.Length > 20) { Console.WriteLine(res); }
            if (check.IsMatch(u)) { Console.WriteLine(res); }


            Console.WriteLine("answer");
        }
        static void RequestedOrder(string[] args)//ABCD 4321
        {
            string line = Console.ReadLine();
            string[] inputs = Console.ReadLine().Split(' ');
            int n = int.Parse(Console.ReadLine());
            int[] numorder = line.Split(' ').Select(a => int.Parse(a)).ToArray();
            string[] alphaarr = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q",
                "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            string resul = string.Empty;
            string space = " ";
            try
            {
                inputs = Console.ReadLine().Split(' ');
            }
            catch (Exception e)
            {

                //Console.WriteLine("Empty");
            }
            for (int i = 0; i < n; i++)
            {
                int index = int.Parse(inputs[i]);
                resul += $"{alphaarr.ToList().IndexOf(numorder[i].ToString())}{space}";
            }

            //Console.WriteLine(resul);
        }
        static StringBuilder Encode(string[] a, int length)
        {
            //string result = "";
            string hash = "#";
            string space = " ";
            string hashN = "#\n";
            string spaceN = " " + "\n";
            string hashN1 = "#" + " " + "\n";
            string spaceN1 = " " + " " + "\n";
            int b = 0;
            StringBuilder hashbuild = new StringBuilder();
            string res = String.Empty;
            List<List<string>> ans = new List<List<string>>();
            if (length == 1)
            {
                string resolve = string.Empty;
                for (int i = 0; i < a.Length; i += 5)
                {
                    if (a[i] == " ") ++i;
                    List<string> row = new List<string>();
                    for (int j = i; j < i + 5 && j < a.Length; ++j)
                    {
                        row.Add(a[j]);
                    }
                    ans.Add(row);
                }
                foreach (List<string> item in ans)
                {
                    for (int i = 0; i < item.Count; ++i)
                    {
                        if (i < item.Count - 1 && (item[i] == "0" || item[i] == " ")) resolve += space;
                        if (i < item.Count - 1 && item[i] == "1") resolve += hash;
                        if (i == item.Count - 1 && (item[i] == "0" || item[i] == " ")) resolve += spaceN1;
                        if (i == item.Count - 1 && item[i] == "1") resolve += hashN1;
                        //resolve.Trim();
                    }
                }
                hashbuild.Append(resolve);
            }
            return hashbuild;
        }
        public static string HollowSquare(string s)
        {
            string[] arr = Array.ConvertAll(s.ToCharArray(), a => a.ToString());
            StringBuilder result = new StringBuilder();
            result.Append(Encode(arr, 1));
            return result.ToString();
        }

    }
}
