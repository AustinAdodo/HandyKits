using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyKits
{
    internal class ProblemSolving4
    {
        public static string[] UniqueNames(string[] names1, string[] names2)
        {
            names1.ToList().AddRange(names2.ToList());
            string[] newArray = new string[names1.Length + names2.Length];
            Array.Copy(names1, newArray, names1.Length);
            Array.Copy(names2, 0, newArray, names1.Length, names2.Length);
            return newArray.ToList().Distinct().ToArray();
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
    }
}
