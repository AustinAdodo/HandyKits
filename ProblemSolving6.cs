using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HandyKits
{
    internal class ProblemSolving6
    {
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
