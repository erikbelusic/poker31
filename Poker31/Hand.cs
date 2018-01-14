using System.Collections.Generic;

namespace Poker31
{
    public class Hand
    {
        private List<Card> _cards = new List<Card>();

        public void AddCard(Card card)
        {
            _cards.Add(card);
        }

        public List<Card> GetCards()
        {
            return _cards;
        }
    }
}