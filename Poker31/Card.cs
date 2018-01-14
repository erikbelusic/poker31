using System;
using System.ComponentModel;

namespace Poker31
{
    public class Card : IComparable<Card>
    {
        public enum Suit
        {
            Diamonds = 1,
            Hearts = 2,
            Clubs = 3,
            Spades = 4
        }
        
        public enum Rank
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13,
            Ace = 14
        }
        
        private readonly Rank _rank;
        private readonly Suit _suit;
        
        public Card(Rank rank, Suit suit)
        {
            if (!Enum.IsDefined(typeof(Rank), rank))
            {
                throw new InvalidEnumArgumentException();
            }
            
            if (!Enum.IsDefined(typeof(Suit), suit))
            {
                throw new InvalidEnumArgumentException();
            }
            
            _rank = rank;
            _suit = suit;
        }

        public Rank GetRank()
        {
            return _rank;
        }
        
        public Suit GetSuit()
        {
            return _suit;
        }

        public int GetValue()
        {
            return (int) _rank;
        }

        public int CompareTo(Card other)
        {
            return GetValue().CompareTo(other.GetValue());
        }

        public string ToString()
        {
            return _rank + " of " + _suit;
        }
    }
}