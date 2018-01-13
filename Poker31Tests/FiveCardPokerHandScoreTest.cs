using NUnit.Framework;
using Poker31;

namespace Poker31Tests
{
    [TestFixture]
    public class FiveCardPokerHandScoreTest
    {
        [Test]
        public void Flush()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Card.Rank.Ace, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.King, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Two, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Jack, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Ten, Card.Suit.Diamonds));

            var pokerHand = new FiveCardPokerHandScore(hand);

            Assert.AreEqual(FiveCardPokerHandScore.HandRank.Flush, pokerHand.GetHandRank());
        }

        [Test]
        public void FourOfAKind()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Card.Rank.Nine, Card.Suit.Clubs));
            hand.AddCard(new Card(Card.Rank.Nine, Card.Suit.Hearts));
            hand.AddCard(new Card(Card.Rank.Nine, Card.Suit.Spades));
            hand.AddCard(new Card(Card.Rank.Nine, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Ten, Card.Suit.Diamonds));

            var pokerHand = new FiveCardPokerHandScore(hand);

            Assert.AreEqual(FiveCardPokerHandScore.HandRank.FourOfAKind, pokerHand.GetHandRank());
        }

        [Test]
        public void FullHouse()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Card.Rank.Nine, Card.Suit.Clubs));
            hand.AddCard(new Card(Card.Rank.Nine, Card.Suit.Hearts));
            hand.AddCard(new Card(Card.Rank.Ten, Card.Suit.Spades));
            hand.AddCard(new Card(Card.Rank.Nine, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Ten, Card.Suit.Diamonds));

            var pokerHand = new FiveCardPokerHandScore(hand);

            Assert.AreEqual(FiveCardPokerHandScore.HandRank.FullHouse, pokerHand.GetHandRank());
        }

        [Test]
        public void HighCard()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Card.Rank.Ace, Card.Suit.Clubs));
            hand.AddCard(new Card(Card.Rank.Eight, Card.Suit.Hearts));
            hand.AddCard(new Card(Card.Rank.Ten, Card.Suit.Spades));
            hand.AddCard(new Card(Card.Rank.Nine, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Four, Card.Suit.Diamonds));

            var pokerHand = new FiveCardPokerHandScore(hand);

            Assert.AreEqual(FiveCardPokerHandScore.HandRank.HighCard, pokerHand.GetHandRank());
        }

        [Test]
        public void Pair()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Card.Rank.Nine, Card.Suit.Clubs));
            hand.AddCard(new Card(Card.Rank.Eight, Card.Suit.Hearts));
            hand.AddCard(new Card(Card.Rank.Ten, Card.Suit.Spades));
            hand.AddCard(new Card(Card.Rank.Nine, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Four, Card.Suit.Diamonds));

            var pokerHand = new FiveCardPokerHandScore(hand);

            Assert.AreEqual(FiveCardPokerHandScore.HandRank.Pair, pokerHand.GetHandRank());
        }

        [Test]
        public void RoyalFlush()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Card.Rank.Ace, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.King, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Queen, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Jack, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Ten, Card.Suit.Diamonds));

            var pokerHand = new FiveCardPokerHandScore(hand);

            Assert.AreEqual(FiveCardPokerHandScore.HandRank.RoyalFlush, pokerHand.GetHandRank());
        }

        [Test]
        public void Straight()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Card.Rank.Ace, Card.Suit.Hearts));
            hand.AddCard(new Card(Card.Rank.King, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Queen, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Jack, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Ten, Card.Suit.Diamonds));

            var pokerHand = new FiveCardPokerHandScore(hand);

            Assert.AreEqual(FiveCardPokerHandScore.HandRank.Straight, pokerHand.GetHandRank());
        }

        [Test]
        public void StraightFlush()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Card.Rank.Nine, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.King, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Queen, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Jack, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Ten, Card.Suit.Diamonds));

            var pokerHand = new FiveCardPokerHandScore(hand);

            Assert.AreEqual(FiveCardPokerHandScore.HandRank.StraightFlush, pokerHand.GetHandRank());
        }

        [Test]
        public void ThreeOfAKind()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Card.Rank.Nine, Card.Suit.Clubs));
            hand.AddCard(new Card(Card.Rank.Nine, Card.Suit.Hearts));
            hand.AddCard(new Card(Card.Rank.Ten, Card.Suit.Spades));
            hand.AddCard(new Card(Card.Rank.Nine, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Four, Card.Suit.Diamonds));

            var pokerHand = new FiveCardPokerHandScore(hand);

            Assert.AreEqual(FiveCardPokerHandScore.HandRank.ThreeOfAKind, pokerHand.GetHandRank());
        }

        [Test]
        public void TwoPair()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Card.Rank.Nine, Card.Suit.Clubs));
            hand.AddCard(new Card(Card.Rank.Ten, Card.Suit.Hearts));
            hand.AddCard(new Card(Card.Rank.Ten, Card.Suit.Spades));
            hand.AddCard(new Card(Card.Rank.Nine, Card.Suit.Diamonds));
            hand.AddCard(new Card(Card.Rank.Four, Card.Suit.Diamonds));

            var pokerHand = new FiveCardPokerHandScore(hand);

            Assert.AreEqual(FiveCardPokerHandScore.HandRank.TwoPair, pokerHand.GetHandRank());
        }
    }
}