using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyKits
{
    internal class ProblemSolving2
    {
        public static int utopianTree(int n)
        {
            int result = 0; int a;
            List<int> cyclesList = new();
            List<int> ValuesList = new();
            cyclesList.Add(0);
            ValuesList.Add(1);
            for (int i = 1; i <= n; ++i)
            {
                cyclesList.Add(i);
                ValuesList.Add(_ = (i > 0 && i % 2 != 0) ? ValuesList[i - 1] * 2 : ValuesList[i - 1] + 1);
            }
            result = ValuesList[ValuesList.Count - 1];
            return result;
        }

        //strange viral Advertising Strategy // an = arn - 1 (or) an = r an - 1
        public static int viralAdvertising(int n)
        {
            int result = 0;
            return result;
        }

        //julian and Gregorian Calender Comparism
        //Time Machine.
        public static string dayOfProgrammer(int year)
        {
            string result = String.Empty;
            return result;
        }
        //the QUEEN
        public static int queensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
        {
            int result = 0;
            return result;
        }

        //game console purchase
        //a +(n-1)d a==p
        public static int howManyGames(int p, int d, int m, int s)
        {
            int result = p; List<int> SeriesList = new(); int n = 2; int a = 0; int z = 0;
            if (p > s)
            {
                return 0;
            }
            else
            {
                SeriesList.Add(p);
                a = SeriesList.Aggregate(func: (res, ele) => (res + ele));
                while (result >= m)
                {
                    result = p + ((n - 1) * -d);
                    if (result >= m && a + m <= s) SeriesList.Add(result); ++n;
                }
                a = SeriesList.Aggregate(func: (res, ele) => (res + ele));
                if (a < s)
                {
                    while (a + m <= s) { SeriesList.Add(m); a += m; }
                }
                else
                {
                    z = SeriesList.Count - 1;
                    while (a > s)
                    {
                        SeriesList.Remove(SeriesList[z]); --z;
                        a = SeriesList.Aggregate(func: (res, ele) => (res + ele));
                    }
                }
                return SeriesList.Count;
            }
        }
    }
}
