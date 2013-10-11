namespace Cooking
{
    using System;

    public class Chef
    {
        private string name;
        private static readonly Random randomVegetableGetter = new Random();

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public Chef(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// The cook takes an empty bowl, takes random vegetables - potatos and carrots
        /// (either rotten or not, but both are not peeled), and puts the not-rotten ones
        /// in the bowl.After that he peels, cuts and cooks them.
        /// </summary>
        public void Cook()
        {
            Console.WriteLine("Chef " + this.Name + " is cooking!");
            Bowl bowl = GetBowl();
            Console.WriteLine(bowl.ToString()); //an empty bowl

            byte numberOfProducts = 5;
            for (int i = 0; i < numberOfProducts; i++)
            {
                Potato potato = (Potato)GetVegetable("potato");
                bowl.Add(potato);
                //potato.Cook(); // potatos cannot be cooked because they are either rotten or not peeled
                Carrot carrot = (Carrot)GetVegetable("carrot");
                bowl.Add(carrot);
                //carrot.Cook(); // carrots cannot be cooked because they are either rotten or not peeled
            }

            Console.WriteLine(bowl.ToString()); //listing the present products now
            Console.WriteLine("Peeling, cutting and cooking products:");
            //doing some more cooking
            foreach (var product in bowl.BowlItems)
            {
                Peel(product);
                Cut(product);
                product.Cook();
            }
        }

        private Bowl GetBowl()
        {
            return new Bowl();
        }

        /// <summary>
        /// Returns a random Potato or Carrot object - either rotten or not, but not peeled
        /// </summary>
        private Vegetable GetVegetable(string vegetableType)
        {
            int randomNumberForRotten = randomVegetableGetter.Next(10000);
            bool isRotten = false;

            if (randomNumberForRotten % 2 == 0)
            {
                isRotten = true;
            }
            else
            {
                isRotten = false;
            }

            bool isPeeled = false;
            Vegetable randomVegetable;

            if (vegetableType == "potato")
            {
                randomVegetable = new Potato(isPeeled, isRotten);
                return randomVegetable;
            }

            if (vegetableType == "carrot")
            {
                randomVegetable = new Carrot(isPeeled, isRotten);
                return randomVegetable;
            }

            return null;
        }

        private void Cut(Vegetable vegetable)
        {
            Console.WriteLine(vegetable.GetType().Name + " cut!");
        }

        private void Peel(Vegetable product)
        {
            product.IsPeeled = true;
        }

    }
}
