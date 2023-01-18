using HandyKits;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyKits
{
    internal class Ps5
    {
        //minimum absolute difference
        public static void closestNumbers(List<int> numbers)
        {
            List<string>row = new List<string>(); 
            List<int>results = new List<int>();
            int temp = 0;
            
            numbers = numbers.OrderByDescending(a=>a).ToList();
            temp = numbers[0] - numbers[1];
            for (int i = 1; i < numbers.Count; i++)
            {
                if (temp < (numbers[i] - numbers[i - 1])) { temp = (numbers[i] - numbers[i - 1]); }
            }
    }
        /// <summary>
        /// Advanced Insertion Sort Ananlysis
        /// </summary>
        public static long Merge(List<int> arr, int l, int m, int r)
        {
            int lLength = m - l + 1;
            int rLength = r - m;

            int[] tempLeft = new int[lLength];
            int[] tempRight = new int[rLength];

            long shifts = 0;

            int i = 0, j = 0;
            for (i = 0; i < lLength; i++) tempLeft[i] = arr[l + i];
            for (j = 0; j < rLength; j++) tempRight[j] = arr[m + j + 1];

            i = 0;
            j = 0;
            int k = l;

            while (i < lLength && j < rLength)
            {
                if (tempLeft[i] <= tempRight[j]) arr[k++] = tempLeft[i++];
                else
                {
                    arr[k++] = tempRight[j++];
                    shifts += (long)(lLength - i);
                }
            }

            while (i < lLength) arr[k++] = tempLeft[i++];
            while (j < rLength) arr[k++] = tempRight[j++];

            return shifts;
        }
        public static long Sort(List<int> arr, int l, int r)
        {
            if (l >= r) return 0;
            int mid = l + (r - l) / 2;
            long shifts = 0;

            shifts += Sort(arr, l, mid);
            shifts += Sort(arr, (mid + 1), r);
            shifts += Merge(arr, l, mid, r);

            return shifts;
        }
        public static long insertionSort(List<int> arr)
        {
            return Ps5.Sort(arr, 0, (arr.Count - 1));
        }

        //Matrix layer rotation..
        public static void matrixRotation(List<List<int>> matrix, int r)
        {
            int[,] result = new int[matrix.Count, matrix[0].Count];

            for (int i = 0; i < Math.Min(matrix.Count / 2, matrix[0].Count / 2); i++)
            {
                int columnSize = matrix.Count - (i * 2); // row boundary
                int rowSize = matrix[0].Count - (i * 2); // column boundary

                // linearize each layer
                int index = 0;
                List<int> lin = new List<int>();
                int j = i;
                int k = (i + 1);
                while (j < (i + columnSize)) lin.Add(matrix[j++][i]); // left column
                j--;
                while (k < (i + rowSize)) lin.Add(matrix[j][k++]); // bottom row
                k--;
                j--;
                while (j >= i) lin.Add(matrix[j--][k]); // right column
                j++;
                k--;
                while (k > i) lin.Add(matrix[j][k--]); // top row

                // rotate the linearized inner layer
                int[] rotated = new int[lin.Count];
                for (int l = 0; l < lin.Count; l++) rotated[l] = lin[(rotated.Length - (r % rotated.Length) + l) % rotated.Length];

                // insert back into original matrix
                j = i;
                k = (i + 1);
                index = 0;
                while (j < (i + columnSize)) matrix[j++][i] = rotated[index++]; // left column
                j--;
                while (k < (i + rowSize)) matrix[j][k++] = rotated[index++]; // bottom row
                k--;
                j--;
                while (j >= i) matrix[j--][k] = rotated[index++];// right column
                j++;
                k--;
                while (k > i) matrix[j][k--] = rotated[index++]; // top row
            }
            foreach (List<int> row in matrix) Console.WriteLine(string.Join(" ", row));
        }

        //private static HashSet<string> hasher = new HashSet<string>();
        //the QUEEN.(Chess game Algorithm optimized) AGzion.
        private static HashSet<string> obstacleHash = new HashSet<string>(); //string interpolation
        public static int MoveLeft(int qRow, int qCol, int count)
        {
            if (qCol < 1 || obstacleHash.Contains($"{qRow}_{qCol}")) return count - 1;
            return MoveLeft(qRow, (qCol - 1), (count + 1));
        }

        public static int MoveLeftDown(int qRow, int qCol, int count)
        {
            if (qCol < 1 || qRow < 1 || obstacleHash.Contains($"{qRow}_{qCol}")) return count - 1;
            return MoveLeftDown((qRow - 1), (qCol - 1), (count + 1));
        }

        public static int MoveDown(int qRow, int qCol, int count)
        {
            if (qRow < 1 || obstacleHash.Contains($"{qRow}_{qCol}")) return count - 1;
            return MoveDown((qRow - 1), qCol, (count + 1));
        }
                         
        public static int MoveRightDown(int qRow, int qCol, int length, int count)
        {
            if (qRow < 1 || qCol > length || obstacleHash.Contains($"{qRow}_{qCol}")) return count - 1;
            return MoveRightDown((qRow - 1), (qCol + 1), length, (count + 1));
        }

        public static int MoveRight(int qRow, int qCol, int length, int count)
        {
            if (qCol > length || obstacleHash.Contains($"{qRow}_{qCol}")) return count - 1;
            return MoveRight(qRow, (qCol + 1), length, (count + 1));
        }

        public static int MoveRightUp(int qRow, int qCol, int length, int count)
        {
            if (qRow > length || qCol > length || obstacleHash.Contains($"{qRow}_{qCol}")) return count - 1;
            return MoveRightUp((qRow + 1), (qCol + 1), length, (count + 1));
        }

        public static int MoveUp(int qRow, int qCol, int length, int count)
        {
            if (qRow > length || obstacleHash.Contains($"{qRow}_{qCol}")) return count - 1;
            return MoveUp((qRow + 1), qCol, length, (count + 1));
        }

        public static int MoveLeftUp(int qRow, int qCol, int length, int count)
        {
            if (qRow > length || qCol < 1 || obstacleHash.Contains($"{qRow}_{qCol}")) return count - 1;
            return MoveLeftUp((qRow + 1), (qCol - 1), length, (count + 1));
        }

        public static int queensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
        {
            foreach (List<int> ob in obstacles)
            {
                obstacleHash.Add($"{ob[0]}_{ob[1]}");
            }
            int count = 0;
            count += MoveLeft(r_q, c_q, 0);
            count += MoveLeftDown(r_q, c_q, 0);
            count += MoveDown(r_q, c_q, 0);
            count += MoveRightDown(r_q, c_q, n, 0);
            count += MoveRight(r_q, c_q, n, 0);
            count += MoveRightUp(r_q, c_q, n, 0);
            count += MoveUp(r_q, c_q, n, 0);
            count += MoveLeftUp(r_q, c_q, n, 0);

            return count;
        }
    }

    /// <summary>
    /// Sample
    /// </summary>
    public interface IAlertDAO
    {
        public Guid AddAlert(DateTime time);

        public DateTime GetAlert(Guid id);
    }

    public class AlertService
    {
        private readonly AlertDAO storage = new AlertDAO();
        private readonly IAlertDAO _IAlertDAO;

        public AlertService(IAlertDAO iAlertDAO)
        {
            _IAlertDAO = iAlertDAO;
        }
        public Guid RaiseAlert()
        {
            return _IAlertDAO.AddAlert(DateTime.Now);
        }

        public DateTime GetAlertTime(Guid id)
        {
            return _IAlertDAO.GetAlert(id);
        }
    }

    public class AlertDAO : IAlertDAO
    {
        private readonly Dictionary<Guid, DateTime> alerts = new Dictionary<Guid, DateTime>();

        public Guid AddAlert(DateTime time)
        {
            Guid id = Guid.NewGuid();
            this.alerts.Add(id, time);
            return id;
        }

        public DateTime GetAlert(Guid id)
        {
            return this.alerts[id];
        }
    }

    public class Song
    {
        private string name { get; set; }
        public Song NextSong { get; set; }

        private static Song instance = null;
        public Song(string name)
        {
            this.name = name;
        }

        public bool IsInRepeatingPlaylist()
        {
            //if (this.NextSong != null && this. ) return true;
            return false;
        }
    }
    public static class solution
    {
        public static void x()
        {
            List<Song> songs = new List<Song>();
            Song first = new Song("Hello");
            Song second = new Song("Eye of the tiger");
            first.NextSong = second;
            second.NextSong = first;
            Console.WriteLine(first.IsInRepeatingPlaylist());
        }
    }

    public class TextInput
    {
        public string val { get; set; }
        public virtual void Add(char value) { this.val += value.ToString(); }
        public string GetValue() { return this.val.ToString(); }
    }

    public class NumericInput : TextInput
    {
        int a = 0;
        public string tin { get; set; }
        public override void Add(char value)
        {
            if (int.TryParse(value.ToString(), out a))
            {
                this.tin += a;
            }
            this.val = this.tin;
        }
    }
}


