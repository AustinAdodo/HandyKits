using HandyKits;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json.Serialization;

internal class Program
{
    //Wollow
    //SAML -> Security Assertion Mark-up Language. 

    private static void Main(string[] args)
    {

        //List<int> t = Difficult.Task(10);
        //Console.Write(String.Join(",", t));
        //int[] firstArray = { 11, 4, 11, 7, 3, 7, 10, 13, 4, 8, 12, 11, 10, 14, 12 };
        //int[] secondArray = { 11, 4, 11, 7, 13, 4, 12, 11, 10, 14 };
        int[] firstArray = {7,7,7,7,7 };
        int[] secondArray = { 7,7}; 
        Console.Write(String.Join(",", ProblemSolving7.missingNumbers(secondArray.ToList(),firstArray.ToList())));


        //Console.WriteLine(ProblemSolving6.capitalize("How Are You Doing Today"));
        //Challenger.findSubstring("azerdii",5);
        //for (int i = 0; i < 3; i++)
        //{
        // Console.WriteLine(Difficult.GetCombination2(3));
        //}
        //List<int> list = new List<int>() {945,44,173 };
        //var res = ProblemSolving3.romanizer(list);
        //for (int i = 0; i < 3; i++)
        //{
        //    Console.WriteLine(res[i]);
        //}
        //    string s="><<><";
        //    string s1 = "<";
        //    string s2 = ">";
        //    ProblemSolving6.Solutionx(s);
        //queries.Add(new List<int> { 2, 3, 603 });
        //queries.Add(new List<int> { 1 ,1, 286 });
        //queries.Add(new List<int> { 4 ,4, 882 });
        //Arrays.arrayManipulation1(4,queries);
        //ProblemSolving3.SparseBinaryDecomposition(4);
        //ProblemSolving4.CountConformingBitmasks(1073741727, 1073741631, 1073741679);
        //ProblemSolving4.tester(819399173, 9843471);
    }
}