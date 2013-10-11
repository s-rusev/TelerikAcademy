using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var card in Cards)
            {
                result.Append(card.ToString() + " ");       
            }

            return result.ToString().TrimEnd();
        }
    }
}
