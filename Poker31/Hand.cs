﻿using System.Collections.Generic;

namespace Poker31
{
    public class Hand
    {
        private readonly List<Card> _cards = new List<Card>();

        public void AddCard(Card card)
        {
            _cards.Add(card);
        }

        public IEnumerable<Card> GetCards()
        {
            return _cards;
        }
    }
}