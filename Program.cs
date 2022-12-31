using HandyKits;
using System.Collections.Generic;
using System.Drawing;

internal class Program
{
    private static void Main(string[] args)
    {
        //List<List<int>> queries = new();
        //queries.Add(new List<int> { 2, 3, 603 });
        //queries.Add(new List<int> { 1 ,1, 286 });
        //queries.Add(new List<int> { 4 ,4, 882 });
        //Arrays.arrayManipulation1(4,queries);
        string s = "1B 1E 2E";
        ProblemSolving3.Bookings(2, s);
        //ProblemSolving3.SparseBinaryDecomposition(26);
    }
}