using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitArray64
{
    public class Program
    {
        static void Main()
        {
            //ToString()
            int num = 1111;
            Console.WriteLine(num.ToString().PadLeft(64, '0'));
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            //Print some number in binary representation just to compare with it
            Console.WriteLine(Convert.ToString(num, 2).PadLeft(64, '0'));
            //Making the BitArray64 with the same number but from ulong type
            ulong number = 1111;
            BitArray64 bits = new BitArray64(number);
            //Test foreach
            foreach (var bit in bits)
            {
                Console.Write(bit);
            }
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------");
            //Making new BitArray64 and compare it with the old one
            BitArray64 bits2 = new BitArray64((ulong)8766);
            Console.WriteLine(bits.Equals(bits2));
            Console.WriteLine(bits == bits2);
            Console.WriteLine(bits != bits2);
            Console.WriteLine("-----------------------------------------------------------------");
            //Test ToString() method
            Console.WriteLine(bits);
            //Test overriten operator[]
            Console.WriteLine(bits[0]);
        }
    }
}
