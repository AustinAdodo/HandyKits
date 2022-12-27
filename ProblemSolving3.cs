using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyKits
{
    internal class ProblemSolving3
    {
        static List<String> romanizer(List<int> numbers)
        {
            List<String> result = new List<String>();
            return result;
        }

        //illgal legal
        public static int maxCost(List<int> cost, List<string> labels, int dailyCount)
        {
            int count = 0; int total = 0; int adder = 0;
            for (int i = 0; i < cost.Count; i++)
            {
                if (labels[i] == "legal" && count < dailyCount) { count++; }
                if (count == dailyCount) {adder = cost.Sum(a => a); total += adder; count = 0; adder = 0; }
            }
            return total;
        }
        //manual labour
        public static long getMinCost(List<int> crew_id, List<int> job_id)
        {
            int result = 0;
            for (int i = 0; i < crew_id.Count; i++)
            {
                result += (job_id[i] - crew_id[i]);
            }
            return result;
        }
    }
}
