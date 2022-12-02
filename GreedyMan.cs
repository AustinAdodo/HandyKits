using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyKits
{
    internal class GreedyMan
    {
        public static int Permute(int num)
        {
            //recursive
            if (num == 0)
            {
                return 1;
            }
            return num * GreedyMan.Permute(num - 1);
        }
        public static string Permutestring(string st)
        {
            string rand = new string(st.OrderBy(x => Guid.NewGuid()).ToArray());
            return rand;
        }
        public static string Reverse(string s)
        {
            string result = "";
            for (int  i = s.Length;i--> 0;)
            {
                result += s[i];
            }
            return result;
        }
        public static List<string> ProvideAllRandoms(string s)
        {
            int permutationResult = GreedyMan.Permute(s.Length);
            string[] Result = new string[permutationResult];
            Result[0] = s;
            for (int i = 1; i < Result.Length; i++)
            {
                string rand = GreedyMan.Permutestring(s);
                if (!Result.Contains(rand))
                {
                    Result[i] = rand;
                }
                else
                {
                    i--;
                }
            }
            return Result.ToList();
        }
        /// <summary>
        /// Conduct Reverse Shuffle Merge.... lexicographically ∉
        /// </summary>
        public static string RSMerge(string s)
        {
            //s ∈ merge(reverse(A), shuffle(A)) -> abab = ab
            string Result = String.Empty;
            string[] sSplit = new string[2];
            if (s.Length % 2 == 0)
            {

            }
            else if (s.Length % 2 != 0) //odd
            { 
            //sSplit = s.Substring(); 
            }  
            return Result;     
        }
    }
}
