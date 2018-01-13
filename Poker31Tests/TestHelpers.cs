using System.Collections.Generic;
using Poker31;

namespace Poker31Tests
{
    public static class TestHelpers
    {
        private static readonly Dictionary<char, Card.Suit> suitDictionary = new Dictionary<char, Card.Suit>()
        {
            {'C', Card.Suit.Clubs},
            {'D', Card.Suit.Diamonds},
            {'H', Card.Suit.Hearts},
            {'S', Card.Suit.Spades}
        };
        
        private static readonly Dictionary<char, Card.Rank> rankDictionary = new Dictionary<char, Card.Rank>()
        {
            {'2', Card.Rank.Two},
            {'3', Card.Rank.Three},
            {'4', Card.Rank.Four},
            {'5', Card.Rank.Five},
            {'6', Card.Rank.Six},
            {'7', Card.Rank.Seven},
            {'8', Card.Rank.Eight},
            {'9', Card.Rank.Nine},
            {'1', Card.Rank.Ten},
            {'J', Card.Rank.Jack},
            {'Q', Card.Rank.Queen},
            {'K', Card.Rank.King},
            {'A', Card.Rank.Ace}
        };

        public static Hand MakeHand(string card1, string card2, string card3, string card4, string card5)
        {
            var hand = new Hand();

            hand.AddCard(stringToCard(card1));
            hand.AddCard(stringToCard(card2));
            hand.AddCard(stringToCard(card3));
            hand.AddCard(stringToCard(card4));
            hand.AddCard(stringToCard(card5));
            
            return hand;
        }

        private static Card stringToCard(string cardString)
        {
            return cardString.Length == 3
                ? new Card(rankDictionary[cardString[0]], suitDictionary[cardString[2]])
                : new Card(rankDictionary[cardString[0]], suitDictionary[cardString[1]]);
        }
    }
}