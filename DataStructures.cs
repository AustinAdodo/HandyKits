using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyKits
{
    internal class DataStructures
    {
        public static List<int> matchingStrings(List<string> stringList, List<string> queries)
        {
            //1 <= n <= 1000;
            //1 <= q <= 1000;|| str.Contains(queries[i])
            int[] result = new int[queries.Count];
            foreach (string str in stringList)
            {
                for (int i = 0; i < queries.Count; ++i)
                {
                    if (str == queries[i]) { result[i]++; }
                }
            }
            return result.ToList();
        }
    }
}
