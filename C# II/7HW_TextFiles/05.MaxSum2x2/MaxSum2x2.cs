using System;
using System.IO;


class MaxSum2x2
{
    public static int[,] GetArray()
    {
        StreamReader reader = default(StreamReader);
        try
        {
            reader = new StreamReader(@"..\..\inputfile.txt");
            Console.WriteLine("File successfully opened.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
        int[,] resArr;
        using (reader)
        {
            string line = reader.ReadLine();
            int n = 0;
            try
            {
                n = Convert.ToInt32(line);
            }
            catch (FormatException)
            {
                Console.WriteLine("Wrong input!");
            }
            resArr = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                line = reader.ReadLine();
                string[] tokens = line.Split(' ');
                for (int j = 0; j < tokens.Length; j++)
                {
                    resArr[i, j] = int.Parse(tokens[j]);
                }
            }
        }
        return resArr;
    }

    public static int GetMaxSum(int[,] arr)
    {
        int result = arr[0,0] + arr[0,1] + arr[1,0] + arr[1,1];
        for (int i = 0; i < arr.GetLength(0) - 1; i++)
        {
            int temp;
            for (int j = 0; j < arr.GetLength(1) - 1; j++)
            {
                temp = arr[i, j] + arr[i + 1, j] + arr[i, j + 1] + arr[i + 1, j + 1];
                if (temp > result)
                {
                    result = temp;
                }
            }
        }
        return result;
    }

    static void Main()
    {
        int[,] arr = GetArray();
        int res = GetMaxSum(arr);
        string outputPath = "../../output.txt";
        Console.WriteLine("The result is in the output file.");
        using (StreamWriter output = new StreamWriter(outputPath)) 
        {
            output.WriteLine("The max sum from sqaure 2x2 is {0}", res);
        }

    }
}
