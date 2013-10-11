namespace Cooking
{
    using System;

    public abstract class Vegetable : ICookable
    {

        public Vegetable(bool isPeeled, bool isRotten)
        {
            this.IsPeeled = isPeeled;
            this.IsRotten = isRotten;
        }

        public bool IsPeeled
        {
            get;
            set;
        }

        public bool IsRotten
        {
            get;
            set;
        }

        public void Cook()
        {
            if (this.IsPeeled && !this.IsRotten)
            {
                Console.WriteLine("Cooked!");
            }
            else
            {
                Console.WriteLine("Can't be cooked!");
            }
        }
    }
}
