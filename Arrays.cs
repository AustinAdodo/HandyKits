using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HandyKits
{
    public class Arrays
    {
        //Complex Manipulation
        public static long ArrayComplexManipulation1(int n, List<List<int>> queries)
        {
            int[,] IndexArr = new int[n, 2];
            List<int> ResultArr = new();
            int count = queries.Count;
            if (n >= 3 && queries != null && n <= Math.Pow(10, 7))
            {
                for (int i = 0; i < n; i++)
                {
                    IndexArr[i, 0] = i + 1; //indices
                    IndexArr[i, 1] = 0; //zeros
                    for (int j = 0; j < count; j++)//optimize loop introduce aggregates
                    {
                        bool condition = Enumerable.Range(queries[j][0], queries[j][1]).Contains(IndexArr[i, 0]); //bool Array
                        while (condition)
                        {
                            IndexArr[i, 1] += queries[j][2];
                            break;
                        }
                        if (ResultArr.Count == 0)
                        {
                            ResultArr.Add(IndexArr[i, 1]);
                        }
                        if (ResultArr.Count > 0 && IndexArr[i, 1] > ResultArr[0])
                        {
                            ResultArr.RemoveAt(0);
                            ResultArr.Add(IndexArr[i, 1]);
                        }
                    }
                }
            }
            return ResultArr[0];
        }
        public static long ArrayComplexManipulation2(int n, List<List<int>> queries)
        {
            int[,] IndexArr = new int[n, 2];
            List<int> ResultArr = new();
            int count = queries.Count;
            //sample queries -> //;a b k
            //1 5 3
            //4 8 7
            //6 9 1
            if (n >= 3 && queries != null && n <= Math.Pow(10, 7))
            {
                for (int i = 0; i < n; i++)
                {
                    IndexArr[i, 0] = i + 1; //indices
                    IndexArr[i, 1] = 0; //zeros
                    for (int j = 0; j < count; j++)//optimize loop
                    {
                        bool condition = queries[j][0] <= IndexArr[i, 0] && IndexArr[i, 0] <= queries[j][1]; //(Enumerable.Range(1,100).Contains(x))
                        IndexArr[i, 1] += (condition) ? queries[j][2] : 0;
                    }
                    if (ResultArr.Count == 0)
                    {
                        ResultArr.Add(IndexArr[i, 1]);
                    }
                    if (ResultArr.Count > 0 && IndexArr[i, 1] > ResultArr[0])
                    {
                        ResultArr.RemoveAt(0);
                        ResultArr.Add(IndexArr[i, 1]);
                    }
                }
            }
            return ResultArr[0];
        }
        public static long ArrayComplexManipulation3(int n, List<List<int>> queries)
        {
            long result = 0;
            return result;
        }
        public static long ArrayComplexManipulation4(int n, List<List<int>> queries)
        {
            int[,] IndexArr = new int[n, 2];
            List<int> ResultArr = new();
            int count = queries.Count;
            if (n >= 3 && queries != null && n <= Math.Pow(10, 7))
            {
                for (int i = 0; i < n; i++)
                {
                    IndexArr[i, 0] = i + 1; //indices
                    IndexArr[i, 1] = 0; //zeros
                    Parallel.For(0, count, j =>
                    {
                        bool condition = queries[j][0] <= IndexArr[i, 0] && IndexArr[i, 0] <= queries[j][1]; //(Enumerable.Range(1,100).Contains(x))
                        IndexArr[i, 1] += (condition) ? queries[j][2] : 0;
                    });

                    if (ResultArr.Count == 0)
                    {
                        ResultArr.Add(IndexArr[i, 1]);
                    }
                    if (ResultArr.Count > 0 && IndexArr[i, 1] > ResultArr[0])
                    {
                        ResultArr.RemoveAt(0);
                        ResultArr.Add(IndexArr[i, 1]);
                    }
                }
            }
            return ResultArr[0];
        }

        //inline swaps minimum req swaps.
        public static int ArraySwaps(int[] arr)
        {
            int a = 0; int b = 0; int count = 0; int LengthEvenCheck = arr.Length % 2;
            int[] ProperArr = arr.ToList().OrderBy(s => s).ToArray();
            int maxi = ProperArr.ToList().Max();
            int IndexOfMaxElement = arr.ToList().IndexOf(maxi);
            int central = (int)Math.Floor(arr.Length * 0.5) + 1;
            int CentralElement = arr[central];
            //place Max
            if (IndexOfMaxElement < central)
            {
                a = maxi; int aIndex = arr.ToList().IndexOf(a);
                b = (LengthEvenCheck == 0) ? arr[(arr.Length / 2) - 1] : arr[((arr.Length - 1) / 2)];
                b = (arr[arr.ToList().IndexOf(b)] > arr[arr.ToList().IndexOf(b) + 1]) ? arr[arr.ToList().IndexOf(b) + 1] : b;
                b = CentralElement;
                int bIndex = arr.ToList().IndexOf(b);
                arr[aIndex] = b; arr[bIndex] = a;
                count++;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (i + 1 <= arr.Length - 1 && arr[i] > arr[i + 1]) //concurrent swap
                {
                    a = arr[i];
                    b = arr[i + 1];
                    arr[i + 1] = a; arr[i] = b;
                    count++;
                }
                if (i >= 2 && i <= arr.Length - 1 && arr[i - 1] < arr[i - 2])
                {
                    a = arr[i - 1];
                    b = arr[i - 2];
                    arr[i - 2] = a; arr[i - 1] = b;
                    count++;
                }
            }
            for (int j = arr.Length; j-- > 0;)
            {
                if (j - 1 >= 0 && arr[j] < arr[j - 1]) //backward check
                {
                    a = arr[j];
                    b = arr[j - 1];
                    arr[j - 1] = a; arr[j] = b;
                    count++;
                }
                if (j <= arr.Length - 3 && j <= 0 && arr[j + 1] > arr[j + 2])
                {
                    a = arr[j + 1];
                    b = arr[j + 2];
                    arr[j + 2] = a; arr[j + 2] = b;
                    count++;
                }
            }
            return count;
        }
        public static int ArraySwaps2(int[] arr)
        {
            int a = 0; int b = 0; int count = 0; int LengthEvenCheck = arr.Length % 2;
            int[] ProperArr = arr.ToList().OrderBy(s => s).ToArray();
            int maxi = ProperArr.ToList().Max();
            int IndexOfMaxElement = arr.ToList().IndexOf(maxi);
            int central = (int)Math.Floor(arr.Length * 0.5) + 1;
            int CentralElement = arr[central];
            //Divide and sort.
            //place Max 
            if (IndexOfMaxElement < central)
            {
                a = maxi; int aIndex = arr.ToList().IndexOf(a);
                b = (LengthEvenCheck == 0) ? arr[(arr.Length / 2) - 1] : arr[((arr.Length - 1) / 2)];
                b = (arr[arr.ToList().IndexOf(b)] > arr[arr.ToList().IndexOf(b) + 1]) ? arr[arr.ToList().IndexOf(b) + 1] : b;
                b = CentralElement;
                int bIndex = arr.ToList().IndexOf(b);
                arr[aIndex] = b; arr[bIndex] = a;
                count++;
            }
            return count;
        }
        //New Year Chaos..Bribes
        public static void NYChaos(List<int> q)
        {
            string result = ""; int count = 0;
            int size = q.Count;
            List<int> properlist = q.OrderBy(s => s).ToList();
            for (int i = 0; i < q.Count; i++)
            {
                int shift = properlist.IndexOf(q[i]) - q.IndexOf(q[i]);
                switch (i == 0)//shift cannot be <= 0
                {
                    case true:
                        if (shift == 1)
                        {
                            count++;
                            result = count.ToString();
                        }
                        if (shift == 2)
                        {
                            count += 2;
                            result = count.ToString();
                        }
                        if (shift > 2 && q[i] > q[i + 1])
                        {
                            result = "Too chaotic";
                            Console.WriteLine(result);
                            return;
                        }

                        break;
                }
                switch (i > 0)
                {

                    case true:
                        if (shift < 0 && i < size - 1 && q[i] > q[i + 1]) //position goes lower
                        {
                            count++;
                            result = count.ToString();
                        }
                        if (shift == 0 && q[i] < q[i - 1])//position unchanged
                        {
                            count++;
                            result = count.ToString();
                        }
                        if (shift == 1)//position goes higher
                        {
                            count++;
                            result = count.ToString();
                        }
                        if (shift == 2)//bribe limit reached
                        {
                            count += 2;
                            result = count.ToString();
                        }
                        if (shift > 2 && q[i] > q[i - 1])
                        {
                            result = "Too chaotic";
                            Console.WriteLine(result);
                            return;
                        }
                        break;
                }
            }
            Console.WriteLine(result);
        }

        //Left Shift
        public static List<int> CounterClockwise(List<int> a, int d)
        {
            List<int> cut = new List<int>();
            for (int i = 0; i < d; i++)
            {
                cut.Add(a[i]);
            }
            a.RemoveRange(0, d);
            a.AddRange(cut);
            return a;
        }

        //to Refactor
        static void ToRefactor(String[] args)//Main
        {
            int NoOfPeopleInQueue = Convert.ToInt32(Console.ReadLine());
            var ArrTemp1 = new int[NoOfPeopleInQueue][]; //jagged
            for (int i = 0; i < NoOfPeopleInQueue; i++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                string[] q_temp = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                int[] MainList = Array.ConvertAll(q_temp, Int32.Parse);
                ArrTemp1[i] = MainList;
            }

            for (var j = 0; j < NoOfPeopleInQueue; ++j)
            {
                var ArrTemp2 = ArrTemp1[j];
                var ParallelShiftCheck = 0;

                for (var k = 0; k < ArrTemp2.Length; ++k)
                {
                    --ArrTemp2[k];
                }

                for (var i = ArrTemp2.Length - 1; i >= 0; --i)
                {
                    if (i >= ArrTemp2[i])
                    {
                        continue;
                    }

                    if (2 + i < ArrTemp2[i])
                    {
                        ParallelShiftCheck = -1;
                        break;
                    }

                    ParallelShiftCheck += (1 + i == ArrTemp2[i]) ? 1 : 2;
                }

                if (ParallelShiftCheck != -1)
                {
                    ParallelShiftCheck = (int)CountShifts(ArrTemp2, new int[ArrTemp2.Length]);
                }

                Console.WriteLine((ParallelShiftCheck == -1) ? "Too chaotic" : ParallelShiftCheck.ToString());
            }
        }

        //Count Shifts..
        static long CountShifts(int[] arr1, int[] arr2)
        {
            var s_n = 0L;

            if (arr1.Length < 2)
            {
                return s_n;
            }

            var ac_n = arr1.Length;
            var ab_i = 0;
            var ae_i = ac_n;
            var ss_iu = arr1;
            var dd_iu = arr2;

            for (var n = 1; n < ac_n; n *= 2)
            {
                var db_i = (dd_iu == arr2) ? 0 : ab_i;
                var lb_i = db_i ^ ab_i;
                var le_i = lb_i + n;
                var rb_i = le_i;
                var re_i = rb_i + n;
                var se_i = lb_i + ac_n;

                while (lb_i < se_i)
                {
                    if (le_i > se_i)
                    {
                        le_i = se_i;
                    }

                    if (rb_i > se_i)
                    {
                        rb_i = se_i;
                    }

                    if (re_i > se_i)
                    {
                        re_i = se_i;
                    }

                    while (true)
                    {
                        if (lb_i == le_i)
                        {
                            while (rb_i < re_i)
                            {
                                dd_iu[db_i++] = ss_iu[rb_i++];
                            }

                            break;
                        }

                        if (rb_i == re_i)
                        {
                            while (lb_i < le_i)
                            {
                                dd_iu[db_i++] = ss_iu[lb_i++];
                            }

                            break;
                        }

                        if (ss_iu[lb_i] <= ss_iu[rb_i])
                        {
                            dd_iu[db_i++] = ss_iu[lb_i++];
                        }
                        else
                        {
                            s_n += le_i - lb_i;
                            dd_iu[db_i++] = ss_iu[rb_i++];
                        }
                    }

                    lb_i = re_i;
                    le_i = lb_i + n;
                    rb_i = le_i;
                    re_i = rb_i + n;
                }

                var iu = ss_iu;
                ss_iu = dd_iu;
                dd_iu = iu;
            }

            return s_n;
        }
    }
}

