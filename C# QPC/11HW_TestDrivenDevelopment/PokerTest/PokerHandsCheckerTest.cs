using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace PokerTest
{
    [TestClass]
    public class PokerHandsCheckerTest
    {
        [TestMethod]
        public void ValidHandDifferentFaceDifferentSuitTest()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            Hand hand = new Hand(cards);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isValidExpected = true;
            bool isValidActual = handChecker.IsValidHand(hand);

            Assert.AreEqual(
                isValidExpected,
                isValidActual,
                "Hand cheker doesn't work correctly for different face, different suit!"
            );
        }

        [TestMethod]
        public void ValidHandDifferentFaceSameSuitTest()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            Hand hand = new Hand(cards);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isValidExpected = true;
            bool isValidActual = handChecker.IsValidHand(hand);

            Assert.AreEqual(
                isValidExpected,
                isValidActual,
                "Hand cheker doesn't work correctly for different face, same suit!"
            );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidHandSameFaceRepeatingSuitTest()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            Hand hand = new Hand(cards);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isValidActual = handChecker.IsValidHand(hand);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ValidHandSameFaceSameSuitTest()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            Hand hand = new Hand(cards);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isValidActual = handChecker.IsValidHand(hand);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DifferentThanFiveCardsInHandTest()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            Hand hand = new Hand(cards);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isValidHand = handChecker.IsValidHand(hand);
        }

        [TestMethod]
        public void IsFlushTest()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            Hand hand = new Hand(cards);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isFlushActual = handChecker.IsFlush(hand);
            bool isFlushExpected = true;

            Assert.AreEqual(
                isFlushExpected,
                isFlushActual,
                "Flush checker doesn't work correctly!"
            );
        }

        [TestMethod]
        public void IsFourOfAKindTest()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            Hand hand = new Hand(cards);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            bool isFourOfAKind = handChecker.IsFourOfAKind(hand);
            bool isFourOfAKindExpected = true;

            Assert.AreEqual(
                isFourOfAKindExpected,
                isFourOfAKind,
                "Four of a kind checker doesn't work correctly!"
            );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsFourOfAKindSameSuitTest()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            Hand hand = new Hand(cards);

            PokerHandsChecker handChecker = new PokerHandsChecker();
            //this brakes because hand is invalid
            bool isFourOfAKind = handChecker.IsFourOfAKind(hand);
            bool isFourOfAKindExpected = true;

            Assert.AreEqual(
                isFourOfAKindExpected,
                isFourOfAKind,
                "Four of a kind checker doesn't work correctly!"
            );
        }
    }
}
