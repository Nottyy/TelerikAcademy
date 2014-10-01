﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodDesignPattern
{
    public class Program
    {
        static void Main()
        {
            for (int i = 0; i <= 3; i++)
            {
                var type = Factory.Get(i);
                if (type != null)
                {
                    Console.WriteLine("This is Product : " + type.Functionality());
                }
            }
        }
    }
}
