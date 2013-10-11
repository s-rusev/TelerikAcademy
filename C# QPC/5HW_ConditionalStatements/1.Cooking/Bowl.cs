namespace Cooking
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Bowl
    {
        private List<Vegetable> bowlItems = new List<Vegetable>();

        public Bowl()
        {
        }

        public List<Vegetable> BowlItems
        {
            get
            {
                return this.bowlItems;
            }
            set
            {
                this.bowlItems = value;
            }
        }

        public void Add(Vegetable vegetable)
        {
            if (vegetable == null)
            {
                throw new ArgumentNullException("Vegetable doesn't exist!");
            }

            if (vegetable.IsRotten)
            {
                Console.WriteLine("The " + vegetable.GetType().Name + " is rotten!");
            }
            else
            {
                Console.WriteLine("Product " + vegetable.GetType().Name + " added!");
                this.bowlItems.Add(vegetable);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            if (this.bowlItems.Count == 0)
            {
                result.Append("There are no products in the bowl!");
            }
            else
            {
                result.Append("The producst in the bowl are:\n");
                bool first = true;
                foreach (var product in this.bowlItems)
                {
                    if (!first)
                    {
                        result.Append("\n");
                    }
                    result.Append(product.GetType().Name);
                    first = false;
                }
            }

            return result.ToString();
        }

    }
}
