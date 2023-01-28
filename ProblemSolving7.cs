using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyKits
{
    internal class ProblemSolving7
    {
        //longest path on left
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

            for (int i = 0; i < solutions.Count; ++i)
                answer[i] = solutions[i];

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
        public static bool compare(char[] arr1,char[] arr2)
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
        public static void search(string pat,string txt)
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
    }

}
