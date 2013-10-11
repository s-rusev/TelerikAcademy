using System;
using System.Text;

namespace GSMInfo
{
    //containg (model, hours idle and hours talk)
    
    class Battery
    {
        private string batteryModel;
        private uint hoursIdle;
        private uint hoursTalk;
        public string BatteryModel 
        {
            get { return this.batteryModel; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid battery model!");
                }
                this.batteryModel = value;
            }
        }
        public uint HoursIdle 
        {
            get { return this.hoursIdle; }
            set
            {
                if (value < 0 )
                {
                    throw new ArgumentException("Invalid hours idle!");    
                }
                this.hoursIdle = value;
            }
        }
        public uint HoursTalk
        {
            get { return this.hoursTalk; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid hours talk!");
                }
                this.hoursTalk = value;
            }
        }

        public Battery(string model = "No model", uint hoursIdle = 10, uint hoursTalk = 5 ) 
        {
            this.BatteryModel = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Model- " + this.batteryModel).Append("; ").Append("Hours idle- " + this.hoursIdle).Append("; ").Append("Hours talk-" + this.hoursTalk);
            return sb.ToString();
        }
    }
}
