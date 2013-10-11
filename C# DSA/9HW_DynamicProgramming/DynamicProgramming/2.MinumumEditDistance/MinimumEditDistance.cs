namespace _2.MinumumEditDistance
{
    using System;

    public class MinimumEditDistance
    {
        const decimal PriceInserion = 0.8m;
        const decimal PriceDeletion = 0.9m;
        const decimal PriceSubstitution = 1m;

        static void Main()
        {
            //http://en.wikipedia.org/wiki/Levenshtein_distance
            Console.WriteLine("Enter two words to compute their minimum edit distance:");
            string firstWord = Console.ReadLine();
            string secondWord = Console.ReadLine();

            //the matrix used for dynamice programming
            decimal[,] editDistance = new decimal[firstWord.Length + 1, secondWord.Length + 1];

            editDistance[0, 0] = 0;

            for (int i = 1; i < editDistance.GetLength(0); i++)
            {
                editDistance[i, 0] = editDistance[i - 1, 0] + PriceDeletion;
            }

            for (int i = 1; i < editDistance.GetLength(1); i++)
            {
                editDistance[0, i] = editDistance[0, i - 1] + PriceInserion;
            }

            for (int i = 1; i < editDistance.GetLength(0); i++)
            {
                for (int j = 1; j < editDistance.GetLength(1); j++)
                {
                    decimal insertion = editDistance[i, j - 1] + PriceInserion;
                    decimal deletion = editDistance[i - 1, j] + PriceDeletion;
                    decimal substitution = editDistance[i - 1, j - 1];

                    if (firstWord[i - 1] != secondWord[j - 1])
                    {
                        substitution += PriceSubstitution;
                    }

                    editDistance[i, j] = insertion;
                    if (deletion < editDistance[i, j])
                    {
                        editDistance[i, j] = deletion;
                    }
                    if (substitution < editDistance[i, j])
                    {
                        editDistance[i, j] = substitution;
                    }
                }
            }

            Console.WriteLine("Minimum edit distance between these words is: " 
                + editDistance[firstWord.Length, secondWord.Length]);
        }
    }
}
