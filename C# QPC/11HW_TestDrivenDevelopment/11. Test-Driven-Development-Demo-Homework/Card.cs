using System;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Face, Suit);
        }

        public static bool operator ==(Card a, Card b)
        {
            return (a.Face == b.Face && a.Suit == b.Suit);
        }

        public static bool operator !=(Card a, Card b)
        {
            return (a.Face != b.Face && a.Suit != b.Suit);
        }
    }
}
