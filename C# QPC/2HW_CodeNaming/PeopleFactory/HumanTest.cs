using System;

namespace PeopleFactory
{
    public class HumanTest
    {
        public static void Main()
        {
            // Test the Human Class
            Random randomNumberGenerator = new Random();
            int randomNumber = randomNumberGenerator.Next(100);
            Human randomHuman = CreateHuman(randomNumber);
            Console.WriteLine(randomHuman.ToString());
            randomNumber = randomNumberGenerator.Next(100);
            randomHuman = CreateHuman(randomNumber);
            Console.WriteLine(randomHuman.ToString());
        }

        private static Human CreateHuman(int numberToDetermineSex)
        {
            Human newHuman = new Human();
            newHuman.Age = numberToDetermineSex;
            if (numberToDetermineSex % 2 == 0)
            {
                newHuman.FullName = "MaleName";
                newHuman.Sex = Sex.Male;
            }
            else
            {
                newHuman.FullName = "FemaleName";
                newHuman.Sex = Sex.Female;
            }

            return newHuman;
        }

        
    }
}