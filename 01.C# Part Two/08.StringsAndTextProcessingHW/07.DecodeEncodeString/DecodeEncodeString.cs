//Write a program that encodes and decodes a string using given encryption key (cipher). The key consists of a sequence of characters. The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key, the second – with the second, etc. When the last key character is reached, the next is the first.

using System;
using System.Text;
class DecodeEncodeString
{
    static void Main()
    {
        string str = "Write a program that encodes and decodes a string using given encryption key";
        string cipher = "123124324";

        string resultEncoded = EncodeDecode(str, cipher);
        Console.WriteLine(resultEncoded);

        string resultDecoded = EncodeDecode(resultEncoded, cipher);
        Console.WriteLine(resultDecoded);

    }

    static string EncodeDecode(string str, string cipher)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < str.Length; i+= cipher.Length)
        {
            for (int j = 0; j < cipher.Length; j++)
            {
                if (i + j > str.Length - 1)
                {
                    break;
                }
                char temp = (char)(str[i + j] ^ cipher[j]);
                sb.Append(temp);
            }
        }
        return sb.ToString();
    }
}

