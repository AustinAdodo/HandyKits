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

        //List<int> a = new() { 4 ,6 ,5 ,3 ,3 ,1 };
        List<int> ranked = new() { 295,294,291,287,287,285,285,284,283,279,277,274,274,271,270,268,268,268,
264,260,259,258,257,255,252,250,244,241,240,237,236,236,231,227,227,227,
226,225,224,223,216,212,200,197,196,194,193,189,188,187,183,182,178,177,173,
171,169,165,143,140,137,135,133,130,130,130,128,127,122,120,116,114,113,109,106,
103,99,92,85,81,69,68,63,63,63,61,57,51,47,46,38,30,28,25,22,15,14,12,6,4};
        List<int> player = new() {5,5,6,14,19,20,23,25,29,29,30,30,32,37,38,38,38,41,41,44,45,45,47,59,59,
62,63,65,67,69,70,72,72,76,79,82,83,90,91,92,93,98,98,100,100,102,103,105,106,
107,109,112,115,118,118,121,122,122,123,125,125,125,127,128,131,131,133,134,139,
140,141,143,144,144,144,144,147,150,152,155,156,160,164,164,165,165,166,168,169,170,
171,172,173,174,174,180,184,187,187,188,194,197,197,197,198,201,202,202,207,208,211,
212,212,214,217,219,219,220,220,223,225,227,228,229,229,233,235,235,236,242,242,245,
246,252,253,253,257,257,260,261,266,266,268,269,271,271,275,276,281,282,283,284,285,
287,289,289,295,296,298,300,300,301,304,306,308,309,310,316,318,318,324,326,329,329,
329,330,330,332,337,337,341,341,349,351,351,354,356,357,366,369,377,379,380,382,391,391,394,396,396,400};
        ProblemSolving.climbingLeaderboard(ranked,player);
        //ProblemSolving.pickingNumbers(a);
        //string s = "zzzzz";
        //string t = "zzzzzzz";
        //ProblemSolving.appendAndDelete(s, t, 4);
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