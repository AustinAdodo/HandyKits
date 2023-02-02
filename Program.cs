using HandyKits;
using System.Collections.Generic;
using System.Drawing;

internal class Program
{
    //Wollow
    //SAML -> Security Assertion Mark-up Language. 

    private static void Main(string[] args)
    {
        //Console.WriteLine(ProblemSolving6.capitalize("How Are You Doing Today"));
        //Challenger.findSubstring("azerdii",5);
        //for (int i = 0; i < 3; i++)
        //{
        // Console.WriteLine(Difficult.GetCombination2(3));
        //}
        List<string> common_words = new List<string>() {"International","Pannational","intercontinental","Continental","National"};
        List<string> passwords = new List<string>() {"11258","lobo","Allintercontinenetal","International","$@shape1$@" };
        Difficult.getPasswordStrength(passwords,common_words);
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