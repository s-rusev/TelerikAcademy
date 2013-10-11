using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class AllCards
{
    static void Main()
    {
        string[] cards = new string[13] { "Ace", "Deuce", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
        string[] suits = new string[4] { "Spades", "Diamonds", "Hearts" , "Clubs" };
        foreach (string suit in suits)
        {

            for (int card = 1; card < 14; card++)
            {
                switch (card)
                {
                    case 1:
                        Console.WriteLine("{0} of {1}", cards[card - 1], suit); break;
                    case 2:
                        Console.WriteLine("{0} of {1}", cards[card - 1], suit); break;
                    case 3:
                        Console.WriteLine("{0} of {1}", cards[card - 1], suit); break;
                    case 4:
                        Console.WriteLine("{0} of {1}", cards[card - 1], suit); break;
                    case 5:
                        Console.WriteLine("{0} of {1}", cards[card - 1], suit); break;
                    case 6:
                        Console.WriteLine("{0} of {1}", cards[card - 1], suit); break;
                    case 7:
                        Console.WriteLine("{0} of {1}", cards[card - 1], suit); break;
                    case 8:
                        Console.WriteLine("{0} of {1}", cards[card - 1], suit); break;
                    case 9:
                        Console.WriteLine("{0} of {1}", cards[card - 1], suit); break;
                    case 10:
                        Console.WriteLine("{0} of {1}", cards[card - 1], suit); break;
                    case 11:
                        Console.WriteLine("{0} of {1}", cards[card - 1], suit); break;
                    case 12:
                        Console.WriteLine("{0} of {1}", cards[card - 1], suit); break;
                    case 13:
                        Console.WriteLine("{0} of {1}", cards[card - 1], suit); break;
                }
            }
        }
    }
}
