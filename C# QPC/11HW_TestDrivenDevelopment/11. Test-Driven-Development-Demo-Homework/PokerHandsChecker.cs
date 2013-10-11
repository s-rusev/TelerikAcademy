using System;
using System.Linq;
namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {

        public bool IsValidHand(IHand hand)
        {
            var distinctCardNumber = hand.Cards.Select(
                card => new { suit = card.Suit, face = card.Face }).Distinct().Count();

            if (distinctCardNumber != 5)
            {
                throw new ArgumentException("Cards must be exactly 5 and distinct!");
            }

            bool isValid = true;
            return isValid;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            IsValidHand(hand);

            var fourOfAKind = (from card in hand.Cards
                               group card by card.Face into cardGroup
                               where cardGroup.Count() == 4
                               select cardGroup).Count();

            bool isFourOfAKind = false;
            if (fourOfAKind != 0)
            {
                isFourOfAKind = true;
            }

            return isFourOfAKind;
        }

        public bool IsFullHouse(IHand hand)
        {
            IsValidHand(hand);

            var dist = (from card in hand.Cards
                        group card by card.Face into cardGroup
                        select cardGroup).ToArray();

            var count1 = dist[0].Count();
            var count2 = dist[1].Count();

            bool isFullHouse = false;
            if ((count1 == 2 && count2 == 3) || (count1 == 3 && count2 == 2))
            {
                isFullHouse = true;
            }

            return isFullHouse;
        }

        public bool IsFlush(IHand hand)
        {
            IsValidHand(hand);

            var distinctCardSuit = hand.Cards.Select(
                card => new { suit = card.Suit }).Distinct().Count();

            bool isStraightFlush = false;
            if (distinctCardSuit == 1)
            {
                isStraightFlush = true;
            }

            return isStraightFlush;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
