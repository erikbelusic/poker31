using System.ComponentModel;
using NUnit.Framework;
using Poker31;

namespace Poker31Tests
{
    [TestFixture]
    public class CardTest
    {
        [Test]
        public void Should_Throw_Exception_When_Initialized_With_Invalid_Rank()
        {
            Assert.Throws<InvalidEnumArgumentException>(() => new Card((Card.Rank) 1, Card.Suit.Diamonds));
        }

        [Test]
        public void Should_Throw_Exception_When_Initialized_With_Invalid_Suit()
        {
            Assert.Throws<InvalidEnumArgumentException>(() => new Card(Card.Rank.Ace, (Card.Suit) 7));
        }
    }
}