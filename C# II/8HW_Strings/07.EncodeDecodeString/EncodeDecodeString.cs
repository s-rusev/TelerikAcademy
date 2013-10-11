using System;
using System.Linq;
using System.Text;

class EncodeDecodeString
{

    public static string Encode(string input, string key)
    {
        StringBuilder encodedStr = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            encodedStr.Append((char)(input[i] ^ (key[i % key.Length])));
        }

        return encodedStr.ToString();
    }

    public static string Decode(string input, string key)
    {

        StringBuilder decodedStr = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            decodedStr.Append((char)(input[i] ^ (key[i % key.Length])));
        }

        return decodedStr.ToString();
    }

    static void Main()
    {
        Console.WriteLine("Enter message to encode:");
        string input = Console.ReadLine();
        Console.WriteLine("Enter key for the cypher:");
        string key = Console.ReadLine();

        string encodedString = Encode(input, key);
        Console.WriteLine("Encoded string (some symblos may encode as sound) is: {0}", encodedString);
        string decodedString = Decode(encodedString, key);
        Console.WriteLine("And the decoded string(obtained from the encoded) is:{0}", decodedString);
    }



}
