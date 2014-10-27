using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Tubes
{
    static void Main(string[] args)
    {
        int tubes = int.Parse(Console.ReadLine());
        int friends = int.Parse(Console.ReadLine());

        long[] tubesSizes = new long[tubes];
        long maxTube = 0;
        for (int i = 0; i < tubesSizes.Length; i++)
        {
            tubesSizes[i] = int.Parse(Console.ReadLine());
            if (tubesSizes[i] > maxTube)
            {
                maxTube = tubesSizes[i];
            }
        }

        long left = 1;
        long right = maxTube;
        long middle;
        long finalResult = 0;

        while (left <= right)
        {
            long maxDelitel = 0;
            middle = (left + right) / 2;
            for (int j = 0; j < tubesSizes.Length; j++)
            {
                maxDelitel += tubesSizes[j] / middle;

            }
            if (maxDelitel < friends)
            {
                right = middle - 1;
            }
            else if (maxDelitel >= friends)
            {
                left = middle + 1;
                finalResult = middle;
            }
        }
        Console.WriteLine(finalResult);

        //long maxDelitel = 0;

        //for (long i = maxTube; i >= 1; i--)
        //{
        //    for (int j = 0; j < tubesSizes.Length; j++)
        //    {
        //        maxDelitel += tubesSizes[j] / i;
        //    }
        //    if (maxDelitel >= friends)
        //    {
        //        maxDelitel = i;
        //        break;
        //    }
        //    maxDelitel = 0;
        //}
        //Console.WriteLine(maxDelitel);
    }
}
