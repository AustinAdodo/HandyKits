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
        //string[] labels = { "legal","legal","illegal","legal","legal"};
        string s = "1A 3C 2B 20G 5A";
        ProblemSolving3.Bookings(22, s);
    }
}