using HandyKits;
using System.Drawing;

internal class Program
{
    private static void Main(string[] args)
    {
        List<List<int>> queries = new();
        queries.Add(new List<int> { 1, 5, 3 });
        queries.Add(new List<int> { 4, 8, 7 });
        queries.Add(new List<int> { 6, 9, 1 });
        long result = Arrays.ArrayComplexManipulation3(10, queries);
        Console.WriteLine(result);
        //Random rd = new Random(Guid.NewGuid().GetHashCode());
        //int det = rd.Next(1, 100);
        //int a = 1 * det; int b = 10 * det; int ThreeDdet = 3 * det;
        //int Randomer1 = rd.Next(a, b);
        //int Randomer2 = rd.Next(Randomer1, b);
        //int Randomer3 = rd.Next(a, b);

        //List<List<int>> queries = new();
        //for (int i = 0; i < ThreeDdet; ++i)
        //{
        //    queries.Add(new List<int> { Randomer1, Randomer2, Randomer3 });
        //}
        //long result = Arrays.ArrayComplexManipulation2(10, queries);
        //Console.WriteLine(result);

        //case 2
        //int[] arr = { 7, 1, 3, 2, 4, 5, 6 };
        //int[] arr = { 2,3,4,1,5 };
        //int[] arr = { 3 ,7, 6 ,9, 1, 8 ,10, 4 ,2 ,5 };
        //int[] arr = { 4,3,1,2 };
        //Console.WriteLine(Arrays.ArraySwaps(arr));

        //case 3
        //List<int> q = new List<int> {1,2,3,5,4,6,7,8 };
        //iList<int> q = new List<int> {4,1,2,3};
        //List<int> q = new List<int> { 2,1,5,3,4};
        //List<int> q = new List<int> { 5,1,2,3,7,8,6,4};
        //List<int> q = new List<int>  { 1,2,5,3,7,8,6,4};
        //List<int> q = new List<int> { 1, 2, 5,3,4,7,8,6 };
        //Arrays.NYChaos(q);

        //case4
        //List<int> l = new List<int> { 1,2,3,4,5};
        //Arrays.CounterClockwise(l, 4);
        //...............................................SORTING

        //    List<int> list = new List<int> { 7,5,3,1 };
        //    Sorting.InversionsAggregate(list);

        //............................................. GREEDYMAN
        //string s = "daba";
        //GreedyMan.Reverse(s);
    }
}