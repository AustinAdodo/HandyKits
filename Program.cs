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
        //ProblemSolving3.SparseBinaryDecomposition(4);
        //ProblemSolving4.CountConformingBitmasks(1073741727, 1073741631, 1073741679);
        //ProblemSolving4.tester(819399173, 9843471);
        TextInput input = new NumericInput();
        input.Add('1');
        input.Add('a');
        input.Add('0');
        Console.WriteLine(input.GetValue());
    }
}