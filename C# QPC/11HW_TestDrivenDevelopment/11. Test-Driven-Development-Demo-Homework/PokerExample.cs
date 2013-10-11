using System;
using System.Collections.Generic;

namespace Poker
{
    class PokerExample
    {
        static void Main()
        {
            ICard card = new Card(CardFace.Ace, CardSuit.Clubs);
            Console.WriteLine(card);

            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });
            Console.WriteLine(hand);

            IHand flushHand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
            });

            IHand fourOfAKindHand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Clubs),
            });

            IHand fullHouseHand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Clubs),
            });

            IPokerHandsChecker checker = new PokerHandsChecker();
            checker.IsValidHand(hand);
            checker.IsValidHand(flushHand);
            checker.IsValidHand(fourOfAKindHand);
            checker.IsValidHand(fullHouseHand);

            Console.WriteLine(checker.IsFlush(flushHand));
            Console.WriteLine(checker.IsFourOfAKind(fourOfAKindHand));
            Console.WriteLine(checker.IsFourOfAKind(fullHouseHand));
            Console.WriteLine(checker.IsFullHouse(fullHouseHand));

            //Console.WriteLine(checker.IsOnePair(hand));
            //Console.WriteLine(checker.IsTwoPair(hand));
        }
    }
}
