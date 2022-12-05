using HandyKits;
using System.Drawing;

internal class Program
{
    private static void Main(string[] args)
    {
        //List<List<int>> queries = new();
        //queries.Add(new List<int> { 1, 5, 3 });
        //queries.Add(new List<int> { 4, 8, 7 });
        //queries.Add(new List<int> { 6, 9, 1 });
        //long result = Arrays.ArrayComplexManipulation1(10, queries);
        //Console.WriteLine(result);
        //Random rd = new Random(Guid.NewGuid().GetHashCode());
        //int det = rd.Next(1, 100);
        //int a = 1 * det; int b = 10 * det; int ThreeDdet = 3 * det;
        //int Randomer1 = rd.Next(a, b);
        //int Randomer2 = rd.Next(Randomer1, b);
        //int Randomer3 = rd.Next(a, b);
        List<List<int>> queries = new();
        queries.Add(new List<int> { -9 ,- 9 ,- 9 , 1, 1, 1 });
        queries.Add(new List<int> { 0 ,- 9 , 0 , 4, 3, 2, });
        queries.Add(new List<int> { -9 ,- 9 ,- 9 , 1, 2,3 });
        queries.Add(new List<int> { 0  ,0 , 8 , 6, 6,0 });
        queries.Add(new List<int> { 0 , 0, 0 ,- 2 ,0 ,0 });
        queries.Add(new List<int> { 0,  0 , 1 , 2, 4,0 });
        long result = Arrays.hourglassSum(queries);
        Console.WriteLine(result);
       
 


 
 

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