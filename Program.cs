using HandyKits;

internal class Program
{
    private static void Main(string[] args)
    {
        //List<List<int>> queries = new();
        //queries.Add(new List<int> { 1, 5, 3 });
        //queries.Add(new List<int> { 4, 8, 7 });
        //queries.Add(new List<int> { 6, 9, 1 });
        //long result = Arrays.ArrayComplexManipulation(10, queries);
        //Console.WriteLine(result);

        //case 2
        //int[] arr = { 7, 1, 3, 2, 4, 5, 6 };
        //int[] arr = { 2,3,4,1,5 };
        //int[] arr = { 4,3,1,2 };
        //Console.WriteLine(Arrays.ArraySwaps(arr));

        //case 3
        //List<int> q = new List<int> {1,2,3,5,4,6,7,8 };
        //iList<int> q = new List<int> {4,1,2,3};
        //List<int> q = new List<int> { 2,1,5,3,4};
        //List<int> q = new List<int> { 5,1,2,3,7,8,6,4};
        //List<int> q = new List<int>  { 1,2,5,3,7,8,6,4};
        //List<int> q = new List<int> { 1, 2, 5,3,4,7,8,6 };
        //Arrays.NYChaos(q);

        //case4
        List<int> l = new List<int> { 1,2,3,4,5};
        Arrays.CounterClockwise(l, 4);
    }
}