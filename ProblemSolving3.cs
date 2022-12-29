using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HandyKits
{
    internal class ProblemSolving3
    {
        static List<String> romanizer(List<int> numbers)
        {
            List<String> ans = new List<String>();
            List<int> num = new List<int> { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
            List<String> sym = new List<String> { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
            foreach (int number in numbers)
            {// traverse right to left
                int i = 12;
                string str = "";
                while (number > 0)
                {
                    int div = number;
                    // and the remainder after they are handled
                    // number = number % num[i];// get symbol occurrences (integer floor division)// num[i]
                    while (div > 0)
                    {
                        str += sym[i];
                        div--;
                        i--;
                        ans.Add(str);// handle occurrences of the symbol
                    }
                }
            }
            return ans;
        }

        //illgal legal
        public static int maxCost(List<int> cost, List<string> labels, int dailyCount)
        {
            int count = 0; int total = 0; int adder = 0;
            for (int i = 0; i < cost.Count; i++)
            {
                if (labels[i] == "legal" && count < dailyCount) { count++; }
                if (count == dailyCount) { adder = cost.Where(a => a <= i).Sum(); total += adder; count = 0; adder = 0; }
            }
            return total;
        }

        //manual labour
        public static long getMinCost(List<int> crew_id, List<int> job_id)
        {
            int result = 0; string s = "abc";
            string[] strArr = Array.ConvertAll(s.ToCharArray(), item => item.ToString());
            for (int i = 0; i < crew_id.Count; i++)
            {
                result += (job_id[i] - crew_id[i]);
            }
            return result;
        }

        //time in words
        public static string timeInWords(int h, int m)
        {
            string s = "";
            string[] wordArray = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine","ten",
                "eleven", "twelve", "thirteen", "fourteen", "quarter", "sixteen", "seventeen","eighteen", "nineteen","twenty",
                "twenty one","twenty two","twenty three","twenty four","twenty five","twenty six","twenty six","twenty seven","twenty nine","half" };
            s = (m > 1 && m < 30 && m != 15) ? wordArray[m - 1] + " minutes past " + wordArray[h - 1]
                : (m == 1) ? wordArray[m - 1] + " minute past " + wordArray[h - 1]
                : (m == 15 || m == 30) ? wordArray[m - 1] + " past " + wordArray[h - 1]
                : (m > 30 && (60 - (m + 1)) > 0 && m != 45) ? wordArray[60 - (m + 1)] + " minutes to " + wordArray[h]
                : (m > 30 && (60 - (m + 1)) == 0) ? wordArray[60 - (m + 1)] + " minute to " + wordArray[h]
                : (m == 45) ? wordArray[60 - (m + 1)] + " to " + wordArray[h]
                : wordArray[h - 1] + " o' clock";
            return s;
        }

        /// <summary>
        /// BitWise SparseBinary Decomposition.
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public int solution(int N) 
        {
            int result = 0;
            return result;
        } 
    }
}
