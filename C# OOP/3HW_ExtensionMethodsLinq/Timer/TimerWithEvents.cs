using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Timer
{
    class TimerWithEvents
    {
        private Thread workerThread;
        public delegate void Tick(object sender, EventArgs data);
        public event Tick TimerTick;
        public uint TimeOut { get; set; }

        public TimerWithEvents(uint timeOut)
        {
            this.TimeOut = timeOut;
        }

        public void Start()
        {
            workerThread = new Thread(()=>
            {
                while (true)
                {
                    OnTick(this, new EventArgs());
                    Thread.Sleep((int)this.TimeOut);
                }
            }
            );
            workerThread.Start();
        }

        //public void Stop()
        //{
        //    if (this.workerThread != null)
        //    {
        //        workerThread.Abort();
        //    }
        //}
        protected void OnTick(object sender, EventArgs data)
        {
            // Check if there are any Subscribers
            if (TimerTick != null)
            {
                // Call the Event
                TimerTick(this, data);
            }
        }
    }
}