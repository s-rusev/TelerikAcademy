using System;
using System.Linq;


namespace GSMInfo
{
    // class Call to hold a call performed through a GSM. It should contain date, time, dialed phone number and duration (in seconds).
    class Call
    {
        private DateTime date;
        private DateTime time;
        private string number;
        private int durationInSeconds;

        public Call()
            : this(new DateTime(2000, 1, 1), new DateTime(2000, 1, 1 , 0 , 0, 0) , "no number" , 0)
        {
        }
        public Call(DateTime date, DateTime time, string number , int duration) 
        {
            this.Date = date;
            this.Time = time;
            this.Number = number;
            this.DurationInSeconds = duration;
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public DateTime Time
        {
            get
            {
                return this.time;
            }
            set
            {
                this.time = value;
            }
        }

        public string Number
        {
            get
            {
                return this.number;
            }
            set
            {
                this.number = value;
            }
        }

        public int DurationInSeconds
        {
            get
            {
                return this.durationInSeconds;
            }
            set
            {
                this.durationInSeconds = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "date:year {0} month {1} day {2}\ntime:hour {3} minute {4} second {5}\nnumber:{2}\ndurationInSeconds: {3}\n ",
                Date.Year, Date.Month, Date.Day, time.Hour, time.Minute, time.Second, number, durationInSeconds);
            
        }
    }
}
