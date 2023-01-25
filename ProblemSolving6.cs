using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;

using System.Threading.Tasks;

namespace HandyKits
{
    //create software called bubbles to prevent plaigarisation
    internal class ProblemSolving6
    {
        //    Write a function that takes 
        //    a string as an argument and 
        //    returns the string with the first letter of each word capitalized.Words are separated by spaces.
        //    Test Cases
        //1. welcome to andela => Welcome To Andela
        //2. how are you doing today => How Are You Doing Today
        public static string capitalize(string s)
        {
            char[] wordarr = s.ToCharArray();
            char[] chararr2 = new char[s.Length];
            string result = string.Empty;
            for (int i = 0; i < wordarr.Length; i++)
            {
                if (i == 0) { result += wordarr[i].ToString().ToUpper(); i++; }
                if (wordarr[i].ToString() == " ") { result += " " + wordarr[i + 1].ToString().ToUpper(); i++; }
                else { result += wordarr[i]; }
            }
            return result;
        }
        public static string MaxMin(string s)
        {
            string[] s1 = s.Split(" ");
            int b;
            List<string> resultarr = Array.ConvertAll(s1, a => a.ToString()).ToList();
            List<int> resultarr1 = Array.ConvertAll(resultarr.ToArray(), a => int.Parse(a)).ToList();

            string ans = (resultarr1.Max()).ToString() + " " + (resultarr1.Min()).ToString();
            return ans;
        }
        private static void GetCombinations(List<int> listinit, int startSum, int n, int max)
        {
            for (int i = 1; i <= max; i++)
            {
                string list = listinit.Count > 0 ? listinit + " + " + i.ToString() : i.ToString();
                int sum = startSum + i;
                if (sum == n)
                {
                    Console.WriteLine(list);
                }
                else if (sum < n)
                {
                    GetCombinations(listinit, sum, n, i);
                }
            }
        }

        //Combinations
        private static int[][] Solutions(int value, int startWith = -1)
        {
            if (value <= 0)
                return new int[][] { new int[0] };

            if (startWith < 0)
                startWith = value - 1;

            List<int[]> solutions = new List<int[]>();

            for (int i = Math.Min(value, startWith); i >= 1; --i)
                foreach (int[] solution in Solutions(value - i, i))
                {
                    int[] next = new int[solution.Length + 1];

                    Array.Copy(solution, 0, next, 1, solution.Length);
                    next[0] = i;

                    solutions.Add(next);
                }

            // Or just (if we are allow a bit of Linq)
            //   return solutions.ToArray();
            int[][] answer = new int[solutions.Count][];

            for (int i = 0; i < solutions.Count; ++i)
                answer[i] = solutions[i];

            return answer;
        }
        public static void CrazyBrackets(int n)
        {
            // the numbers to use to generate the combinations
            int[] numbers = new int[] { 1, 2, 3 };

            // create a list to store the combinations
            List<List<int>> combinations = new List<List<int>>();
            //output 3 -> [((())),(()()), (())(), ()(()),()()() ]
            string[] t = new string[] {"()","(())","((()))","(((())))","((((()))))","(((((())))))","((((((()))))))",
            "(((((((())))))))"};
        }
        //Making Anagrams
        //remove similar characters, then count remaining characters
        public static int makingAnagrams(string s1, string s2)
        {
            int i = 0;
            while (i < s1.Length)
            {
                if (string.IsNullOrEmpty(s2)) break;
                if (s2.Contains(s1[i]))
                {
                    s2 = s2.Remove(s2.IndexOf(s1[i]), 1);
                    s1 = s1.Remove(i, 1);
                }
                else i++;
            }
            return s1.Length + s2.Length;
        }

        //Maximum Pallindromes
        private static int M = 1000000007;
        private static List<BigInteger> F = new List<BigInteger>();
        private static List<BigInteger> I = new List<BigInteger>();
        private static List<int[]> chars = new List<int[]>();
        public static void initialize(string s)
        {
            F.Add(1);
            I.Add(1);
            for (var i = 1; i < s.Length; ++i)
            {
                F.Add(F[i - 1] * i % M);
                I.Add(BigInteger.ModPow(F[i], M - 2, M));
            }
            var arrA = new int[26];
            chars.Add(new int[26]);
            for (var i = 0; i < s.Length; ++i)
            {
                ++arrA[s[i] - 'a'];
                var arrB = new int[26];
                Array.Copy(arrA, arrB, 26);
                chars.Add(arrB);
            }
        }
        public static int answerQuery(int l, int r)
        {
            // Return the answer for this query modulo 1000000007.
            var array = new int[26];
            for (var i = 0; i < 26; ++i)
            {
                array[i] = chars[r][i] - chars[l - 1][i];
            }
            var odd = 0;
            var sum = 0;
            var divider = F[0];
            foreach (var a in array)
            {
                if (a % 2 != 0)
                {
                    ++odd;
                }
                sum += a / 2;
                divider *= I[a / 2];
                divider %= M;
            }
            odd = odd > 0 ? odd : 1;
            var result = F[sum] * divider * odd;
            return (int)(result % M);
        }

        //Morgan and String
        public string morganAndString(string a, string b)
        {
            string result = String.Empty;
            return result;
        }

        //GameOfThrones
        public static string gameOfThrones(string s)
        {
            // only possible to make palindrome if only a single character is repeated an odd number of times
            Dictionary<char, int> chars = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (chars.ContainsKey(s[i])) chars[s[i]]++;
                else chars.Add(s[i], 1);
            }

            int odds = 0;

            foreach (char k in chars.Keys)
            {
                if (chars[k] % 2 == 1) odds++;
                if (odds > 1) return "NO";
            }
            return "YES";
        }

        //String Simiarity
        public static int stringSimilarity(string s)
        {
            int ans = s.Length;
            char[] p = s.ToCharArray();

            int length = p.Length;

            for (int i = 1; i < p.Length; i++)
            {
                int buffer_index = 0;
                while (buffer_index + i < length && p[buffer_index] == p[buffer_index + i])
                {
                    buffer_index++;
                }
                ans += buffer_index;
            }
            return ans;
        }

        //Intro Turotials
        public static int introTutorial(int V, List<int> arr)
        {
            int answer = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] == V)
                {
                    answer = i;
                }
            }
            return answer;
        }

        //Closest Numbers
        public static List<int> closestNumbers(List<int> arr)
        {
            arr.Sort();
            int min = arr[arr.Count - 1];
            List<int> result = new List<int>();

            for (int i = 0; i < (arr.Count - 1); i++)
            {
                int diff = Math.Abs(arr[i] - arr[i + 1]);
                if (diff < min)
                {
                    min = diff;
                    result.Clear();
                    result.Add(arr[i]); result.Add(arr[i + 1]);
                }
                else if (diff == min)
                {
                    result.Add(arr[i]);
                    result.Add(arr[i + 1]);
                }
            }
            return result;
        }

        //Sherlock
        public static string isValid(string s)
        {
            Dictionary<char, int> freq = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (freq.ContainsKey(s[i])) freq[s[i]]++;
                else freq.Add(s[i], 1);
            }

            int badChars = 0;
            List<int> vals = freq.Values.ToList();
            int mode = vals.GroupBy(x => x).
                                    OrderByDescending(g => g.Count()).
                                    First().
                                    Key;

            for (int j = 0; j < vals.Count; j++)
            {
                if (vals[j] != mode) badChars += Math.Min(vals[j], Math.Abs(vals[j] - mode));
                if (badChars > 1) return "NO";
            }
            return "YES";
        }
    }
}
