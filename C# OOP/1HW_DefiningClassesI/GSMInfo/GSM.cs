using System;
using System.Collections.Generic;
using System.Text;

namespace GSMInfo
{
    //class containing model, manufacturer, price, owner, battery characteristics 
    //(model, hours idle and hours talk) and display characteristics (size and number of colors). 
    class GSM
    {
        private string model;
        private string manifacturer;
        private decimal price;
        private string owner;
        private Battery batery;
        private Display display;
        private List<Call> callHistory;
        private static readonly string IPhone4SInfo = "Iphone is a telephone.";

        public decimal CalculateTotalPriceCalls(decimal price) 
        {
            return this.callHistory.Count * price;
        }
        public void AddCall(Call call)
        {
            if (call != null)
            {
                this.callHistory.Add(call);
            }
            else
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }
        }
        public void RemoveCall(Call call)
        {

            if (this.callHistory.Count != 0)
            {
                this.callHistory.Remove(call);
            }
            else
            {
                throw new IndexOutOfRangeException("No elements in call history!");
            }
        }
        public void ClearHistory()
        {
            this.callHistory.Clear();
        }

        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
            set
            {
                this.callHistory = value;
            }
        }

        public static string PIPhone4SInfo
        {
            get
            {
                return IPhone4SInfo;
            }
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid model!");
                }
                this.model = value;
            }
        }

        public string Manifacturer
        {
            get { return this.manifacturer; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid manifacturer!");
                }
                this.manifacturer = value;
            }
        }
        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (price < 0)
                {
                    throw new ArgumentException("Invalid price!");
                }
                this.price = value;
            }
        }
        public string Owner
        {
            get { return this.owner; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid owner!");
                }
                this.owner = value;
            }
        }
        public Battery Batery
        {
            get { return this.batery; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Invalid batery!");
                }
                this.batery = value;
            }
        }
        public Display Display
        {
            get { return this.display; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Invalid display!");
                }
                this.display = value;
            }
        }
        public GSM()
            : this("Nokia 3310", "Nokia", 0.0m, "No owner", new Battery("No model"), new Display(), new List<Call>())
        {
        }
        public GSM(string model, string manifacturer, decimal price, string owner, Battery batery, Display display, List<Call> callHistory)
        {
            this.Model = model;
            this.Manifacturer = manifacturer;
            this.Price = price;
            this.Owner = owner;
            this.Batery = batery;
            this.Display = display;
            this.CallHistory = callHistory;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Model- " + this.model).Append("; ").Append("Manifacturer- " + this.manifacturer).Append("; ");
            sb.Append("Price- " + this.price).Append("; ").Append("Owner- " + this.owner).Append("; \n");
            sb.Append("Batery info: " + this.batery.ToString()).Append("; \n").Append("Display info: " + this.display.ToString()).Append(".");

            return sb.ToString();
        }

    }

}
