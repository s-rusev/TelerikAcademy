using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace PokerTest
{
    [TestClass]
    public class HandTest
    {
        [TestMethod]
        public void HandToStringTest()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            string actual = hand.ToString();
            string expected = "Seven Clubs Eight Clubs Nine Clubs Ten Clubs Jack Clubs";

            Assert.AreEqual(expected, actual, "Hand.ToString() method doesn't work correctly!");
        }
    }
}
