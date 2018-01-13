using System.ComponentModel;
using NUnit.Framework;
using Poker31;

namespace Poker31Tests
{
    [TestFixture]
    public class CardTest
    {
        [Test]
        public void InitializeCardWithInvalidRank()
        {
            Assert.Throws<InvalidEnumArgumentException>(() => new Card((Card.Rank) 1, Card.Suit.Diamonds));
        }

        [Test]
        public void InitializeCardWithInvalidSuit()
        {
            Assert.Throws<InvalidEnumArgumentException>(() => new Card(Card.Rank.Ace, (Card.Suit) 7));
        }
    }
}