using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
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
        //hour Glass
        public static int hourglassSum(List<List<int>> arr)
        {
            List<List<int>> GlassArr = new(); int a = 0;
            List<int> ResultArr = new();
            for (int i = 0; i < arr.Count - 2; i++)
            {
                for (int j = 0; j < arr.LongCount() - 2; j++)
                {
                    GlassArr.Add(new List<int> { arr[i][j], arr[i][j + 1], arr[i][j + 2], arr[i + 1][j + 1],
                        arr[i + 2][j], arr[i + 2][j + 1], arr[i + 2][j + 2] });
                }
            }
            for (int i = 0; i < GlassArr.Count; i++)
            {
                a += GlassArr[i].Aggregate(func: (result, item) => result + item);
                ResultArr.Add(a);
                a = 0;
            }
            return ResultArr.Max();
        }

        //dynamic XOR Arrays Manipulation.
        public static List<int> dynamicArray(int n, List<List<int>> queries)
        {
            int lastAnswer = 0; n = queries.Count;
            int[,] arrPlus = new int[n, n];
            List<int> answers = new List<int>();
            return answers;
        }
        //Complex Manipulation
        public static long arrayManipulation1(int n, List<List<int>> queries)
        {
            int[] arr = new int[n]; int a, b, k;
            long result = 0;
            long temp = 0;
            List<List<int>> arr1 = new();
            arr1.Add(new List<int> { 0, 0, 0 });
            foreach (List<int> query in queries)
            {
                arr1[0] = query;
                a = arr1[0][0]; b = arr1[0][1]; k = arr1[0][2];
                if (a <= n - 1) arr[a] += k;
                if (b < (n - 1)) arr[b + 1] -= k;
            }
            foreach (int agg in arr)
            {
                temp += agg;
                result = (temp > result) ? temp : result;
            }
            return result;
        }
        //var queriesLookup = queries.ToLookup(x => x[2]);
        //queries.ForEach(num => order.OrderItems = orderItemLookup[order.OrderIncidentName]);

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

        //Left Rotation.
        //Left Shift
        public static List<int> CounterClockwise(List<int> arr, int d)
        {
            List<int> cut = new List<int>();
            for (int i = 0; i < d; i++)
            {
                cut.Add(arr[i]);
            }
            arr.RemoveRange(0, d);
            arr.AddRange(cut);
            return arr;
        }

        //grades
        public static List<int> gradingStudents(List<int> grades)
        {
            List<int> resultarr = new List<int>();
            int result = 0;
            for (int i = 0; i < grades.Count; i++)
            {
                if (grades[i] > 40 && (grades[i] % 5) >= 3)
                {
                    result = grades[i] + (5 - (grades[i] % 5));
                    resultarr.Add(result);
                }
                if (grades[i] >= 40 && (grades[i] % 5) < 3)
                {
                    result = grades[i];
                    resultarr.Add(result);
                }
                if (grades[i] < 40 && grades[i] > 37)
                {
                    result = grades[i] + (5 - (grades[i] % 5));
                    resultarr.Add(result);
                }
                if (grades[i] < 40 && grades[i] <= 37)
                {
                    result = grades[i];
                    resultarr.Add(result);
                }
            }
            return resultarr;
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

