using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyKits
{
    internal class ProblemSolving4
    {
        static bool CheckPracticalConformance(int A, int Query)
        {
            bool result = false;
            string strRep = Convert.ToString(A, 2);
            string QueryStr = Convert.ToString(Query, 2);
            if (strRep.Length != QueryStr.Length) return result;
            List<string> QueryArr = Array.ConvertAll(QueryStr.ToCharArray(), a => a.ToString()).ToList();
            List<string> strRepArr = Array.ConvertAll(strRep.ToCharArray(), a => a.ToString()).ToList();
            result = QueryArr.All(t => t == "1" && strRepArr[QueryArr.IndexOf(t)] == "1");
            //for (int i = 0; i < strRep.Length; ++i)
            //{
            //    if (strRep.Length != QueryStr.Length) break;
            //    if (QueryStr[i] == '1' && strRep[i] != '1') break;
            //    //if (i == QueryStr.Length - 1 && QueryStr[i] == '1' && strRep[i] == '1') result = true;
            //    //result = QueryArr.All(t => t == "1" && strRep[i] == '1');
            //    result = QueryArr.All(t => t == "1" && strRep[i] =='1');
            //}
            return result;
        }
        static int CountConformingBitmasks(int A, int B, int C)//(1073741727, 1073741631, 1073741679)
        {
            int result = 0;
            for (int i = 0; i <= 1073741823; ++i)
            {
                result += (CheckPracticalConformance(A, i) || CheckPracticalConformance(B, i) || CheckPracticalConformance(C, i)) ? 1 : 0;
            }
            return result;
        }
    }
}
