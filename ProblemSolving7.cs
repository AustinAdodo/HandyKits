﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyKits
{
    class TreeNode
    {
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
    }
    internal class ProblemSolving7
    {
        //longest path on left
        public int FindLeftLongestPath(TreeNode root)
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
    }
    internal class Difficult
    {
        //Crazy Brackets Problem.
        private static int[][] GetCombination2(int value, int startWith = -1)
        {
            if (value <= 0)
                return new int[][] { new int[0] };

            if (startWith < 0)
                startWith = value - 1;

            List<int[]> solutions = new List<int[]>();

            for (int i = Math.Min(value, startWith); i >= 1; --i)
                foreach (int[] solution in GetCombination2(value - i, i))
                {
                    int[] next = new int[solution.Length + 1];

                    Array.Copy(solution, 0, next, 1, solution.Length);
                    next[0] = i;

                    solutions.Add(next);
                }

            // Or just (if we are allow a bit of Linq)
            //   return solutions.ToArray();
            int[][] answer = new int[solutions.Count][];

            for (int i = 0; i < solutions.Count; ++i) answer[i] = solutions[i];

            return answer;
            //string report = string.Join(Environment.NewLine, result
            //.Select(solution => string.Join(" + ", solution)));
        }
        public static void CrazyBrackets(int n) //output 3 -> [((())), (()()), (())(), ()(()), ()()() ]
        {
            List<List<int>> combinations = new List<List<int>>();
            string[] t = new string[] {"()","(())","((()))","(((())))","((((()))))","(((((())))))","((((((()))))))",
            "(((((((())))))))"};
            string[] tjagged = new string[] {"(()())","(()()())","(()()()())","(()()()()())","(()()()()()())",
            "(()()()()()()())"};
        }

        //Crazy Triangle
        //Area A = [ x1(y2 – y3) + x2(y3 – y1) + x3(y1-y2)]/2 
        //s=(A+B+C)/2  -> Math.Pow((S*(S-a)*(S-b)*(S-c)),0.5)
        //for An Arbitrary point P , in Triangle ABC PAB+PAC+PBC must be = ABC
        public static bool DoTheyBelong(string[] args)
        {
            return false;
        }
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

        public static int pointsBelong(int x1, int y1, int x2, int y2, int x3, int y3, int xp, int yp, int xq, int yq)
        {
            int result = 0;
            double abcArea = 0.5 * Math.Abs((x1 * (y2 - y3)) + (x2 * (y1 - y3)) + (x3 * (y1 - y2)));

            //for point p
            double abPArea = 0.5 * Math.Abs(xp * (y2 - y3) + (2 * (yp - y3)) + (x3 * (yp - y2)));
            double bcPArea = 0.5 * Math.Abs(x1 * (yp - y3) + xp * (y1 - y3) + x3 * (y1 - yp));
            double PabArea = 0.5 * Math.Abs((x1 * (y2 - yp) + x2 * (y1 - yp) + xp * (y1 - y2)));
            // for Q
            double abQArea = 0.5 * Math.Abs(xq * (y2 - y3) + (x2 * (yq - y3)) + (x3 * (yq - y2)));
            double bcQArea = 0.5 * Math.Abs(x1 * (yq - y3) + (xq * (y1 - y3)) + (x3 * (y1 - yq)));
            double QabArea = 0.5 * Math.Abs(x1 * (y2 - yq) + (x2 * (y1 - yq)) + (xq * (y1 - y2)));

            double resQ = abcArea + bcQArea + QabArea;
            double resP = abPArea + bcPArea + PabArea;

            if (Math.Abs(x1 - x2) + Math.Abs(x2 - x3) > Math.Abs(x3 - x2)
            && Math.Abs(x2 - x3) + Math.Abs(x3 - x2) > Math.Abs(x1 - x2)
            && Math.Abs(x3 - x2) + Math.Abs(x1 - x2) > Math.Abs(x2 - x3)
            ) { return 0; }

            if (resQ == abcArea && resP != abcArea) result = 2;//q
            if (resQ != abcArea && resP == abcArea) result = 1;//p
            if (resQ != abcArea && resP != abcArea) result = 4;
            if (resQ == abcArea && resP == abcArea) result = 3;
            if (abcArea == 0) result = 4;

            return result;

        }

        public static List<string> getPasswordStrength(List<string> passwords, List<string> common_words)
        {
            List<string> result = new List<string>();
            var vowels = new string[] { "a", "e", "i", "o", "u" };
            int b = 0;
            for (int i = 0; i < passwords.Count; i++)
            {
                //substring is english.
                for (int j = 0; j < passwords[i].Length; j++)//correct this
                {
                    if (j <= passwords[i].Length && common_words.Any(a => a == passwords[i].Substring(j, passwords[i].Length))) result.Add("weak");
                }
            }
            for (int i = 0; i < passwords.Count; i++)
            {
                // is english
                if (common_words.Any(a => a == passwords[i])) { result.Add("weak"); }
                if (string.Join("", passwords).Length < 6) { result.Add("weak"); }
                if (passwords[i].All(a => char.IsLower(a))) { result.Add("weak"); } //check for equivalent extension methods in python.
                if (passwords[i].All(a => char.IsUpper(a))) { result.Add("weak"); }
                if (passwords[i].All(a => int.TryParse(a.ToString(), out b) == true)) { result.Add("weak"); }
                if (passwords[i].All(a => a.ToString() is string)) { result.Add("weak"); }
                else { result.Add("strong"); }
            }
            return result;
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
            bool result = false; string res = String.Empty;
            if (subs == 0 && isPalindrome(s)) result = true;
            while (count > 0)
            {
                res = s.Replace(s[i], s[j]);
                if (isPalindrome(res)) { return true; }
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

    }

}