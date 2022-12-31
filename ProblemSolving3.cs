using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace HandyKits
{
    internal class ProblemSolving3
    {
        //Bookings
        public static int Bookings(int N, string S)
        {
            decimal result = 0;
            decimal temp = 0;
            int overflow = 0;
            string d = String.Empty;
            int b; string a;
            string[] strArr = S.Split(" ").ToArray();
            string[] code = { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K" };
            List<int> codeEq = new List<int>();
            if (string.IsNullOrEmpty(S) || S.Length < 1)
            {
                result = (Math.Floor((decimal)code.Length / 4)) * N;
            }
            else
            {
                for (int i = 0; i < N; i++)
                {
                    codeEq.Clear();
                    for (int j = 0; j < code.Length; j++)
                    {
                        a = ((i + 1) + code[j]).Trim();
                        if (strArr.Contains(a)) codeEq.Add(j);

                        //overflow plus empty sits before first booked space on a new row
                        temp = (codeEq.Count > 0) ? Math.Floor((decimal)(codeEq.First() + 1 + overflow) / 4) : overflow;
                        if (codeEq.Count == 1 && j == codeEq.First() && codeEq.First() + 1 + overflow >= 4) result += temp;

                        //space between booked sits
                        if (codeEq.Count > 1 && (codeEq[codeEq.Count - 1] - codeEq[codeEq.Count - 2]) >= 4) result += Math.Floor((decimal)(codeEq[i] - codeEq[i - 1]) / 4);

                        //last booked space to the end.
                        if (codeEq.Count > 0 && j == code.Length - 1 && (code.Length - 1) - codeEq.Last() >= 4)
                        {
                            result += Math.Floor((decimal)(code.Length - 1 - codeEq.Last()) / 4);
                            overflow = (code.Length - 1 - codeEq.Last()) % 4;
                        }

                        //completely Empty row
                        if (j == code.Length - 1 && codeEq.Count == 0)
                        {
                            result += Math.Floor((decimal)(codeEq.Count) / 4);
                            overflow = (codeEq.Count) % 4;
                        }
                    }
                }
            }
            return (int)result;
        }//(22, '1A 3C 2B 20G 5A')

        //bannana Problem
        public int solution(string S)
        {
            decimal result = 0;
            int[] arrCounter = new int[3];
            int Acount = S.Split('A').Length - 1;
            int Bcount = S.Split('B').Length - 1;
            int Ncount = S.Split('N').Length - 1;
            if (Acount < 3 || Bcount < 1 || Ncount < 2) result = 0;
            else
            {
                for (int i = 0; i < S.Length; i++)
                {
                    result = Math.Floor((decimal)((Acount + Bcount + Ncount) / 6.0));
                }
            }
            return (int)result;
        }

        //countries Problem
        public static int Countries(int[][] A)
        {
            int CountriesCount = 0; List<int> colorCheck = new List<int>();
            for (int i = 0; i < A[i].Length; i++)
            {
                for (int j = 0; j < A[j].Length; j++)
                {
                    if (!colorCheck.Contains(A[i][j])) colorCheck.Add(A[i][j]);
                    if (j > 0 && A[i][j] == A[i][j - 1]) CountriesCount += 0; //left
                    if (i > 0 && i <= A[i].Length && A[i][j] == A[i + 1][j]) CountriesCount += 0; //down
                    if (i > 0 && A[i][j] == A[i - 1][j]) CountriesCount += 0; //up
                    if (j + 1 <= A[j].Length - 1 && A[i][j] == A[i + 1][j + 1]) CountriesCount += 0; //right
                    else CountriesCount++;
                }
            }
            CountriesCount += colorCheck.Count;
            return CountriesCount;
        }

        //TreeLongestZigZag
        static void TreeLongestZigZag(string[] args)
        {
            //NB Post order Treversal
        }
        static bool PrimeNumbers(int n)
        {
            //We know 1 is not a prime number
            bool result = false;
            int i = 2;
            if (n == 1) return result;
            //This will loop from 2 to int(sqrt(x))
            while (i * i <= n)
            {
                //Check if i divides x without leaving a remainder
                if (n % i == 0) return result;
                //This means that n has a factor in between 2 and sqrt(n)
                //So it is not a prime number
                i += 1;
                // If we did not find any factor in the above loop, then n is a prime number
            }
            result = true;
            return result;
        }

        //binary gap 
        public static int BinaryGap(int N)
        {
            string binaryString = Convert.ToString(N, 2);
            int result = 0;
            int count = 0;
            List<int> resultArr = new();
            if (binaryString.Split('0').Length - 1 > 0)
            {
                for (int i = 0; i < binaryString.Length; i++)
                {
                    if (binaryString[i] == '0') count++;
                    if (binaryString[i] != '0')
                    {
                        resultArr.Add(count);
                        count = 0;
                    }
                }
            }
            result = (binaryString.Split('0').Length - 1 == 0) ? 0 : resultArr.Max();
            return result;
        }

        //miniOperations
        public static int minOperations(List<int> arr, int threshold, int d) //12345 = 2 t=3 d=2
        {
            //64 30 25 33 2 2 = 3 // 1 2 3 4 t=4 d=3 = 6
            int count = 0; int min = arr.Min();
            count++;
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr.Contains(d) && Math.Floor((double)arr[i] / d) == d) count++;
                if (!arr.Contains(d) && Math.Floor((double)arr[i] / d) == min) count++;
                if (count == threshold) break;
            }
            return count;
        }

        //bitiwse AND count operation
        //10,7,2,8,3
        //a & (a - 1); for Ulong
        public static long countPairs(List<int> arr)//6
        {
            int result = 0;
            var a = 10;
            bool b = false;
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = i; j < arr.Count; j++)
                {
                    a = arr[i] & arr[j];
                    b = Math.Ceiling(Math.Log(a) / Math.Log(2)) == Math.Floor(Math.Log(a) / Math.Log(2));
                    if (b) result++;
                }
            }
            return result;
        }

        //download speed calculation
        public static void CalculateSpeedDownload(Stream b)
        {
            // Set the URL of the file you want to download
            string url = "http://example.com/somefile.zip";

            // Set the size of the buffer (in bytes)
            int bufferSize = 1024;

            // Create a Stopwatch to measure the download time
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Open a Stream to the file
            using (Stream stream = File.OpenRead(url))
            {
                // Create a buffer to hold the data
                byte[] buffer = new byte[bufferSize];

                // Read the data from the stream and store it in the buffer
                int bytesRead = stream.Read(buffer, 0, bufferSize);

                // Keep track of the total number of bytes read
                long totalBytesRead = bytesRead;

                // Continue reading until the end of the stream is reached
                while (bytesRead > 0)
                {
                    bytesRead = stream.Read(buffer, 0, bufferSize);
                    totalBytesRead += bytesRead;
                }

                // Stop the Stopwatch
                stopwatch.Stop();

                // Calculate the download speed (in bytes per second)
                double downloadSpeed = totalBytesRead / stopwatch.Elapsed.TotalSeconds;

                // Print the download speed
                Console.WriteLine("Download speed: {0} bytes/second", downloadSpeed);
            }
        }

        static List<String> romanizer(List<int> numbers)
        {
            List<String> ans = new List<String>();
            List<int> num = new List<int> { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
            List<String> sym = new List<String> { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
            foreach (int number in numbers)
            {// traverse right to left
                int i = 12;
                string str = "";
                while (number > 0)
                {
                    int div = number;
                    // and the remainder after they are handled
                    // number = number % num[i];// get symbol occurrences (integer floor division)// num[i]
                    while (div > 0)
                    {
                        str += sym[i];
                        div--;
                        i--;
                        ans.Add(str);// handle occurrences of the symbol
                    }
                }
            }
            return ans;
        }

        //illgal legal
        public static int maxCost(List<int> cost, List<string> labels, int dailyCount)
        {
            int count = 0; int total = 0; int adder = 0;
            for (int i = 0; i < cost.Count; i++)
            {
                if (labels[i] == "legal" && count < dailyCount) { count++; }
                if (count == dailyCount) { adder = cost.Where(a => a <= i).Sum(); total += adder; count = 0; adder = 0; }
            }
            return total;
        }

        //manual labour
        public static long getMinCost(List<int> crew_id, List<int> job_id)
        {
            int result = 0; string s = "abc";
            string[] strArr = Array.ConvertAll(s.ToCharArray(), item => item.ToString());
            for (int i = 0; i < crew_id.Count; i++)
            {
                result += (job_id[i] - crew_id[i]);
            }
            return result;
        }

        //time in words
        public static string timeInWords(int h, int m)
        {
            string s = "";
            string[] wordArray = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine","ten",
                "eleven", "twelve", "thirteen", "fourteen", "quarter", "sixteen", "seventeen","eighteen", "nineteen","twenty",
                "twenty one","twenty two","twenty three","twenty four","twenty five","twenty six","twenty six","twenty seven","twenty nine","half" };
            s = (m > 1 && m < 30 && m != 15) ? wordArray[m - 1] + " minutes past " + wordArray[h - 1]
                : (m == 1) ? wordArray[m - 1] + " minute past " + wordArray[h - 1]
                : (m == 15 || m == 30) ? wordArray[m - 1] + " past " + wordArray[h - 1]
                : (m > 30 && (60 - (m + 1)) > 0 && m != 45) ? wordArray[60 - (m + 1)] + " minutes to " + wordArray[h]
                : (m > 30 && (60 - (m + 1)) == 0) ? wordArray[60 - (m + 1)] + " minute to " + wordArray[h]
                : (m == 45) ? wordArray[60 - (m + 1)] + " to " + wordArray[h]
                : wordArray[h - 1] + " o' clock";
            return s;
        }

        //Fair Rations
        public static string fairRations(List<int> B)
        {
            int answer = 0; int a = B.Count;
            for (int i = 0; i < B.Count - 1; i++)
            {
                if (B[i] % 2 == 1)
                {
                    B[i]++;
                    B[i + 1]++;
                    answer += 2;
                }
            }
            return (B[a - 1] % 2 == 1) ? "NO" : answer.ToString();
        }

        /// <summary>
        /// BitWise Sparse Binary Decomposition.
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public static int SparseBinaryDecomposition(int N)
        {
            int result = 0;
            //int j = 1; int Sparsej = Convert.ToString(j, 2).Split("00").Length - 1;
            for (int k = 1; k <= N; k++)
            {
                if (Convert.ToString(k, 2).Split("00").Length - 1 > 0 && Convert.ToString(N - k, 2).Split("00").Length - 1 > 0) result = k;
            }
            result = (result > 0) ? result : -1;
            return result;
        }
    }
}
