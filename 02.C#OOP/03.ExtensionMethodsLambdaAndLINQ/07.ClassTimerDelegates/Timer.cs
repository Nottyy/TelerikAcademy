using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ClassTimerDelegates
{
    class Timer
    {
        public delegate void MethodToExecute();

        public MethodToExecute method;

        public void Start(int intervalInSeconds, int totalTimeInSeconds)
        {
            DateTime start = DateTime.Now;
            DateTime end = start.AddSeconds(totalTimeInSeconds);
            while (start <= end)
            {

                method();
                Thread.Sleep(intervalInSeconds * 1000);
                start = DateTime.Now;
            }

        }
    }
}
