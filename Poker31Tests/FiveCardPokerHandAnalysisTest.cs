using NUnit.Framework;
using Poker31;

namespace Poker31Tests
{
    [TestFixture]
    public class FiveCardPokerHandAnalysisTest
    {
        [Test]
        public void IsConsecutiveReturnsFalseFor5678A()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Card.Rank.Five, Card.Suit.Clubs));
            hand.AddCard(new Card(Card.Rank.Six, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Seven, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Eight, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Ace, Card.Suit.Diamonds));

            var analysis = new FiveCardPokerHandAnalysis(hand);
            Assert.IsFalse(analysis.IsConsecutive());
        }

        [Test]
        public void IsConsecutiveReturnsFalseForA2567()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Card.Rank.Five, Card.Suit.Clubs));
            hand.AddCard(new Card(Card.Rank.Six, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Seven, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Two, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Ace, Card.Suit.Diamonds));

            var analysis = new FiveCardPokerHandAnalysis(hand);
            Assert.IsFalse(analysis.IsConsecutive());
        }

        [Test]
        public void IsConsecutiveReturnsTrueFor10JQKA()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Card.Rank.Ace, Card.Suit.Clubs));
            hand.AddCard(new Card(Card.Rank.King, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Queen, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Jack, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Ten, Card.Suit.Diamonds));

            var analysis = new FiveCardPokerHandAnalysis(hand);
            Assert.IsTrue(analysis.IsConsecutive());
        }

        [Test]
        public void IsConsecutiveReturnsTrueFor56789()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Card.Rank.Five, Card.Suit.Clubs));
            hand.AddCard(new Card(Card.Rank.Six, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Seven, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Eight, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Nine, Card.Suit.Diamonds));

            var analysis = new FiveCardPokerHandAnalysis(hand);
            Assert.IsTrue(analysis.IsConsecutive());
        }

        [Test]
        public void IsConsecutiveReturnsTrueForA2345()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Card.Rank.Ace, Card.Suit.Clubs));
            hand.AddCard(new Card(Card.Rank.Two, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Three, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Four, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Five, Card.Suit.Diamonds));

            var analysis = new FiveCardPokerHandAnalysis(hand);
            Assert.IsTrue(analysis.IsConsecutive());
        }

        [Test]
        public void IsSameSuitReturnsFalseWhenAllCardsAreSameSuit()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Card.Rank.Ace, Card.Suit.Clubs));
            hand.AddCard(new Card(Card.Rank.Two, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Three, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Four, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Five, Card.Suit.Diamonds));

            var analysis = new FiveCardPokerHandAnalysis(hand);
            Assert.IsFalse(analysis.IsSameSuit());
        }

        [Test]
        public void IsSameSuitReturnsTrueWhenAllCardsAreSameSuit()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Card.Rank.Ace, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Two, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Three, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Four, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Five, Card.Suit.Diamonds));

            var analysis = new FiveCardPokerHandAnalysis(hand);
            Assert.IsTrue(analysis.IsSameSuit());
        }
    }
}