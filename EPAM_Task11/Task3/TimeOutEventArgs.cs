using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task11.Task3
{
    public class TimeoutEventArgs : EventArgs
    {
        public int Seconds { get; set; }
        public TimeoutEventArgs(int seconds) : base()
        {
            Seconds = seconds;
        }
    }
}
