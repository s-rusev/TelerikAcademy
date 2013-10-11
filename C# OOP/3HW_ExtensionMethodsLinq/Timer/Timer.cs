using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timer
{
    class Timer
    {
        private Thread workerThread;
        public delegate void DoWorkDelegte();
        public DoWorkDelegte DoWork { get; set; }
        public uint TimeOut { get; set; }

        public Timer(uint timeOut)
        {
            this.TimeOut = timeOut;
        }

        public void Start()
        {
            workerThread = new Thread(()=>
            {
                while (true)
                {
                    DoWork();
                    Thread.Sleep((int)this.TimeOut);
                }
            }
            );
            workerThread.Start();
        }
        public void Stop()
        {
            if (this.workerThread != null)
            {
                workerThread.Abort();
            }
        }
    }
}