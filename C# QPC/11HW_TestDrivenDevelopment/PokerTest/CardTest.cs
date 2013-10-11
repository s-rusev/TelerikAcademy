using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTest
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void CardHeartsToStringTest()
        {
            Card card = new Card(CardFace.Eight, CardSuit.Hearts);
            string actual = card.ToString();
            string expected = "Eight Hearts";

            Assert.AreEqual(expected, actual, "Card.ToString() method doesn't work correctly for hearts!");
        }

        [TestMethod]
        public void CardSpadesToStringTest()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Spades);
            string actual = card.ToString();
            string expected = "Ace Spades";

            Assert.AreEqual(expected, actual, "Card.ToString() method doesn't work correctly for spades!");
        }

        [TestMethod]
        public void CardClubsToStringTest()
        {
            Card card = new Card(CardFace.Jack, CardSuit.Clubs);
            string actual = card.ToString();
            string expected = "Jack Clubs";

            Assert.AreEqual(expected, actual, "Card.ToString() method doesn't work correctly for clubs!");
        }

        [TestMethod]
        public void CardDiamondsToStringTest()
        {
            Card card = new Card(CardFace.King, CardSuit.Diamonds);
            string actual = card.ToString();
            string expected = "King Diamonds";

            Assert.AreEqual(expected, actual, "Card.ToString() method doesn't work correctly for diamonds!");
        }
    }
}
