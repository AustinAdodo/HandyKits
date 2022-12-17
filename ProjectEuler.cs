using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HandyKits
{
    internal class ProjectEuler
    {
        //BigInteger n = BigInteger.Parse(Console.ReadLine());
        //multiples of 3 and 5
        public static void Multiples(BigInteger n)
        {
            List<BigInteger> list = new List<BigInteger>();
            for (BigInteger i = 0; i < n; i++)
            {
                if (n == 0) { list.Add(0); break; }
                if (i % 3 == 0 || i % 5 == 0) list.Add(i);
            }
            if (list.Count == 0) { list.Add(0); }
            Console.WriteLine(list.Aggregate(func: (a, b) => a + b));
        }
    }
}
