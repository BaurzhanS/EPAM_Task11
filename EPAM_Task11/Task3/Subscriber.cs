using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task11.Task3
{
    class Subscriber
    {
        private Timering timer;
        public Subscriber(Timering timer)
        {
        }

        public void OnTimerTimeout(object sender, TimeoutEventArgs e)
        {
            System.Console.WriteLine("First listener: timer {0} reached {1} second timeout.", sender, e.Seconds);
        }
    }
}
