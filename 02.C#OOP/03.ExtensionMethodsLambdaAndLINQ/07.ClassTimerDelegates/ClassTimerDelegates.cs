////Using delegates write a class Timer that 
//can execute certain method at each t seconds.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTimerDelegates
{
    class ClassTimerDelegates
    {
        public static void DateAndTime()
        {
            Console.WriteLine(DateTime.Now);
        }

        static void Main()
        {
            Timer timer = new Timer();
            timer.method = DateAndTime;
            timer.Start(1, 10);
        }
    }
}
