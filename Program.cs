using HandyKits;
using System.Collections.Generic;
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
        //List<int> arr = new() { 3, 8, 15, 11, 14 ,1 ,9 ,2, 24 ,31 };
        //int k= 5; int n = 10; 
        //ProblemSolving2.workbook(n,k,arr);
        List < List<int> > obstacles = new();
        int r_q = 4; int c_q = 4;
        ProblemSolving2.queensAttack(4,0,4,4,obstacles);
        //        List<int> a = new() { 35,65,69,28,12,69,37,80,80,50,80,50,15,57,79,69,57,
        //65,15,69,57,50,65,2,14,64,15,65,65,5,15,64,57,37,50,12,64,37,28,20,80,80,50};
        //        ProblemSolving.equalizeArray(a);
        //List<int> a = new() { 2, 4 };
        //List<int> b = new() { 16, 32, 96 };
        //ProblemSolving.getTotalX(a, b);
        //List<int> s = new() { 4,97,5,97,97,4,97,4,97,97,97,97,4,4,5,5,97,5,97,99,4,
        //       97,5,97,97,97,5,5,97,4,5,97,97,5,97,4,97,5,4,4,97,5,5,5,4,97,97,4,97,
        //       5,4,4,97,97,97,5,5,97,4,97,97,5,4,97,97,4,97,97,97,5,4,4,97,4,4,97,5,97,
        //                 97,97,97,4,97,5,97,5,4,97,4,5,97,97,5,97,5,97,5,97,97,97 };
        //ProblemSolving.pickingNumbers(s);

        //List<int> s = new() {14,18,17,10,9,20,4,13,19,19,8,15,15,17,6,5,15,12,18,2,18,7,20,8,
        //2,8,11,2,16,2,12,9,3,6,9,9,13,7,4,6,19,7,2,4,3,4,14,3,4,9,17,9,4,20,10,16,
        //12,1,16,4,15,15,9,13,6,3,8,4,7,14,16,18,20,11,20,14,20,12,15,4,5,10,10,20,11,
        //18,5,20,13,4,18,1,14,3,20,19,14,2,5,13 };
        //ProblemSolving.pickingNumbers(s);
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