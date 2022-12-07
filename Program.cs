using HandyKits;
using System.Drawing;

internal class Program
{
    private static void Main(string[] args)
    {
        //List<List<int>> queries = new();
        //queries.Add(new List<int> { 1, 2, 100 });
        //queries.Add(new List<int> { 2, 5, 100 });
        //queries.Add(new List<int> { 3, 4, 100 });
        //long result = Arrays.arrayManipulation(5, queries);
        //Console.WriteLine(result);
        List<int> s = new() {1,2,1,2,1,3,2 };
        ProblemSolving.sockMerchant(7,s);
        //Random rd = new Random(Guid.NewGuid().GetHashCode());
        //int det = rd.Next(1, 100);
        //int a = 1 * det; int b = 10 * det; int ThreeDdet = 3 * det;
        //int Randomer1 = rd.Next(a, b);
        //int Randomer2 = rd.Next(Randomer1, b);
        //int Randomer3 = rd.Next(a, b);
        //Console.WriteLine(result);
        //List<List<int>> queries = new();
        //for (int i = 0; i < ThreeDdet; ++i)
        //{
        //    queries.Add(new List<int> { Randomer1, Randomer2, Randomer3 });
        //}
        //long result = Arrays.ArrayComplexManipulation2(10, queries);
        //Console.WriteLine(result);
        //...............................................SORTING

        //    List<int> list = new List<int> { 7,5,3,1 };
        //    Sorting.InversionsAggregate(list);

        //............................................. GREEDYMAN
        //string s = "daba";
        //GreedyMan.Reverse(s);
        //............................................. DATASTRUCTURES
        //List<List<int>> queries = new();
        //queries.Add(new List<int> { 11, 2, 4 });
        //queries.Add(new List<int> { 4, 5, 6 });
        //queries.Add(new List<int> { 10, 8, -12 });
        //DataStructures.diagonalDifference(queries);
        //DataStructures.staircase(6);
    }
}