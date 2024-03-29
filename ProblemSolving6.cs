﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;

using System.Threading.Tasks;

namespace HandyKits
{
    //create software called bubbles to prevent plaigarisation
    internal class ProblemSolving6
    {
        public static string Solutionx(string angles)
        {
            //""><<>< ->    "<><<><>>"
            string[] angles1 = Array.ConvertAll(angles.ToArray(), a => a.ToString()).ToArray();
            int a1 = angles.Split(">").Length - 1;
            int a2 = angles.Split("<").Length - 1;
            string res = "";
            if (angles == "<" || angles == ">") return "<>";

            string[] result = new string[angles.Length];
            for (int i = 0; i < angles.Length; i++)
            {
                if (i + 1 <= angles.Length - 1 && angles[i].ToString() == "<" && angles[i + 1].ToString() != "<") { res += "<>"; i++; }
                if (i - 1 >= 0 && angles1[i].ToString() == ">"
                   && angles1[i - 2].ToString() != ">") { res += "<>"; i++; }
                else { res += angles[i].ToString(); }
            }
            if (res.Split("<").Length - 1 % 2 != 0) res += ">";
            if (res.Split(">").Length - 1 % 2 != 0) res = "<" + res;
            return res;
        }
        public static long Challenge(long[] prices)
        {
            long[] purchases = prices.Where(a => prices.ToList().IndexOf(a) % 2 != 0).ToArray();
            long[] sales = prices.Where(a => prices.ToList().IndexOf(a) % 2 == 0).ToArray();
            return purchases.Max() - sales.Min();
        }
        //Node arr
        public static string getLong(long[] arr)
        {
            long a = 0;
            long b = 0;
            arr.ToList().Remove(-1);
            arr.ToList().Remove(0);
            if (arr.Length <= 1)
            {
                return "";
            }
            a += arr[0];
            b += arr[0];
            for (int i = 1; i < arr.Length; i += 2)
            {
                if (arr[i] == -1 && i + 2 <= arr.Length - 1) i += 2;
                a += arr[i];
            }
            for (int i = 2; i < arr.Length; i += 2)
            {
                if (arr[i] == -1 && i + 2 <= arr.Length - 1) i += 2;
                b += arr[i];
            }
            if (a > b) return "Left";
            if (a == b) return "";
            return "Right";
        }
        public static long getLong1(long[] arr)
        {

            arr.ToList().RemoveAll(a => a == -1);
            if (arr.Length < 1)
            {
                return 0;
            }
            if (arr.Length == 1)
            {
                return arr[0];
            }
            long[] l = arr.Where(a => arr.ToList().IndexOf(a) == 0 && arr.ToList().IndexOf(a) % 2 == 0).ToArray();
            long[] r = arr.Where(a => arr.ToList().IndexOf(a) == 0 && arr.ToList().IndexOf(a) % 2 != 0).ToArray();
            return Math.Max(l.Length, r.Length);
        }
        public static bool Solution(long[][] maze, long n)
        {
            int i = 0;
            string res = "";
            foreach (long[] row in maze)
            {
                if (i == 0 && row.Contains(1) && row[0] == 1) res += 1;
                if (1 - i >= 0 && row[i - 1] == 1 && row[i] == 1) res += 1;
                //if (i + 1 <= maze.Length - 1 && maze[i + 1][j] == 1 && maze[i][j] == 1) res += 1;
                else { res += 0; }
                i++;
            }
            if (res.Split("0").Length - 1 == 0) return true;
            return false;
        }

        //    Write a function that takes 
        //    a string as an argument and 
        //    returns the string with the first letter of each word capitalized.Words are separated by spaces.
        //    Test Cases
        //    1. welcome to andela => Welcome To Andela
        //    2. how are you doing today => How Are You Doing Today
        public static string capitalize(string s)
        {
            string[] arr = Array.ConvertAll(s.ToCharArray(), a => a.ToString());
            string res = string.Join("", arr.ToList().Select((x, i) => (i == 0 || arr[i - 1].ToString() == " ")
            ? x.ToUpper() : x).ToList());
            return res;
        }
        public static string MaxMin(string s)
        {
            List<string> resultarr = Array.ConvertAll(s.Split(" "), a => a.ToString()).ToList();
            List<int> resultarr1 = Array.ConvertAll(resultarr.ToArray(), a => int.Parse(a)).ToList();
            return $"{resultarr1.Max()} {resultarr1.Min()}";
        }

        //Combinations
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
                i++;
            }
            return s1.Length + s2.Length;
        }

        public static BigInteger Factorials(int n)
        {
            BigInteger result;
            if (n == 0) result = 1;
            else result = n * ProblemSolving2.Factorials(n - 1);
            return result;
        }

        public static int comb(string s)
        {
            int result = s.Length;
            return result;
        }
        public static string[] ListAllAnangrams(string s)
        {
            List<string> result = new List<string>();
            if (s.Length == 1) { result.Add(s); return result.ToArray(); }
            string p = new string(s.ToCharArray().OrderBy(x => Guid.NewGuid()).ToArray());
            if (p.Length == 0) { result.Add(p); }
            if (!result.Contains(p)) { result.Add(p); }
            return result.ToArray();
        }

        public static List<int> stringAnagram(List<string> dictionary, List<string> query)
        {
            int count = 0;
            List<int> result = new List<int>();
            for (int i = 0; i < dictionary.Count; i++)
            {
                for (int j = 0; j < query.Count; j++)
                {
                    if (ListAllAnangrams(dictionary[i]).Contains(query[j])) count++;
                }
                result.Add(count);
            }
            return result;
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

    public class Challenger
    {
        //vowels:substring with highest occuring vowels.
        public static string findSubstring(string s, int k)
        {
            List<string> result = new(); string test = "";
            if (s.Length < k) return "";
            string[] query = { "a", "e", "i", "o", "u" };
            int count = 0; int maxcount = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (k <= s.Length - i) test = s.Substring(i, k);
                count += test.Split("a").Length - 1;
                count += test.Split("e").Length - 1;
                count += test.Split("i").Length - 1;
                count += test.Split("o").Length - 1;
                count += test.Split("u").Length - 1;
                if (count > maxcount) { maxcount = count; result.Clear(); result.Add(test); }
            }
            result.OrderBy(a => a).ToList();
            return result.First();
        }
        public static bool isPrime(long n)
        {
            //We know 1 is not a prime number
            bool result = false;
            int i = 2;
            if (n == 1) return result;
            while (i * i <= n)
            {
                if (n % i == 0) return result;
                ++i;
            }
            result = true;
            return result;
        }

        public static long fibonacci(long x)
        {
            long a = 0;
            if (x < 2) { return x;}
            else { a += fibonacci(x - 1) + fibonacci(x - 2); }
            return a;
        }
        public static long[] f(long x)
        {
            long b = 0;
            List<long> arr2 = new List<long>();
            List<long> ans = new List<long>();
            for (int i = 1; i <= x; i++)
            {
                b = fibonacci(i);
                if (isPrime(b)) arr2.Add(b);
            }
            return arr2.ToArray();
        }

        public static long[] Solution(long n)
        {
            long[] arr = f(n);
            int count = arr.Length;
            return arr;
        }

    }

}
