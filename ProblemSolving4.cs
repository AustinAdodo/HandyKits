using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HandyKits
{
    internal class ProblemSolving4
    {
        //class Program
        //{
        //    static void Main(string[] args)
        //    {
        //        BinarySearchTree tree = new BinarySearchTree();
        //        tree.root = new Node(10);
        //        tree.root.left = new Node(5);
        //        tree.root.right = new Node(15);

        //        int value = 5;
        //        if (tree.Contains(value))
        //        {
        //            Console.WriteLine("The tree contains the value " + value);
        //        }
        //        else
        //        {
        //            Console.WriteLine("The tree does not contain the value " + value);
        //        }

        //        value = 20;
        //        if (tree.Contains(value))
        //        {
        //            Console.WriteLine("The tree contains the value " + value);
        //        }
        //        else
        //        {
        //            Console.WriteLine("The tree does not contain the value " + value);
        //        }
        //    }
        //}

        public static string[] UniqueNames(string[] names1, string[] names2)
        {
            string[] newArray = new string[names1.Length + names2.Length];
            Array.Copy(names1, newArray, names1.Length);
            Array.Copy(names2, 0, newArray, names1.Length, names2.Length);
            return newArray.ToList().Distinct().ToArray();
        }
        //full counting sort
        public static void countSort(List<List<string>> arr)
        {
            int mid = (int)Math.Ceiling((decimal)arr.Count / 2m);
            List<List<string>> sorted = new List<List<string>>();

            for (int i = 0; i < arr.Count; i++)
            {
                int val = int.Parse(arr[i][0]);
                while ((sorted.Count - 1) < val) sorted.Add(new List<string>());
                if (i < mid) sorted[val].Add("-");
                else sorted[val].Add(arr[i][1]);
            }

            string result = string.Empty;
            for (int n = 0; n < sorted.Count; n++) result += string.Join(" ", sorted[n]) + " ";
            Console.Write(result.Trim());
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

        //Picking Numbers
        public static int pickingNumbers(List<int> a)
        {
            a.OrderBy(a => a);
            List<List<int>> subArrays = new();
            for (int i = 0; i < a.Count; i++)
            {
                int r = a[i];
                int rplus = r + 1;
                List<int> arr = new();
                arr.Add(r);
                for (int j = i + 1; j < a.Count; ++j)
                {
                    if (a[j] == r || a[j] == rplus)
                    {
                        arr.Add(a[j]);
                    }
                }
                subArrays.Add(arr);
            }
            int max = subArrays[0].Count;
            foreach (List<int> ar in subArrays)
            {
                if (ar.Count > max)
                {
                    max = ar.Count;
                }
            }
            return max;
        }
    }

    //public Node(int value)
    //{
    //    this.value = value;
    //}


    //class BinarySearchTree
    //{
    //    public Node root;

    //    public bool Contains(int value)
    //    {
    //        Node current = root;
    //        while (current != null)
    //        {
    //            if (value < current.value)
    //            {
    //                current = current.left;
    //            }
    //            else if (value > current.value)
    //            {
    //                current = current.right;
    //            }
    //            else
    //            {
    //                return true;
    //            }
    //        }
    //        return false;
    //    }
    //}
}
