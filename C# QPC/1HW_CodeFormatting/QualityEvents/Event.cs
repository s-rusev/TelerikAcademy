using System;
using System.Text;

namespace QualityEvents
{
    public class Event : IComparable
    {
        private DateTime date;
        private String title;
        private String location;

        public Event(DateTime date, String title, String location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
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

        public String Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }

        public String Location
        {
            get
            {
                return this.location;
            }
            set
            {
                this.location = value;
            }
        }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;
            int byDate = this.date.CompareTo(other.date);
            int byTitle = this.title.CompareTo(other.title);
            int byLocation = this.location.CompareTo(other.location);

            if (byDate == 0)
            {
                if (byTitle == 0)
                {
                    return byLocation;
                }
                else
                {
                    return byTitle;
                }
            }
            else
            {
                return byDate;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(date.ToString("yyyy-MM-ddTHH:mm:ss")); 
            result.Append(" | " + title);
            if (location != null && location != "")
            {
                result.Append(" | " + location);
            }
            return result.ToString();
        }
    }
}