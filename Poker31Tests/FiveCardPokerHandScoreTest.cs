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
            var hand = TestHelpers.MakeHand("AD", "KD", "2D", "JD", "10D");
            var pokerHand = new FiveCardPokerHandScore(hand);
            Assert.AreEqual(FiveCardPokerHandScore.HandRank.Flush, pokerHand.GetHandRank());
        }

        [Test]
        public void FourOfAKind()
        {
            var hand = TestHelpers.MakeHand("9H", "9D", "9C", "9S", "10D");
            var pokerHand = new FiveCardPokerHandScore(hand);
            Assert.AreEqual(FiveCardPokerHandScore.HandRank.FourOfAKind, pokerHand.GetHandRank());
        }

        [Test]
        public void FullHouse()
        {
            var hand = TestHelpers.MakeHand("9H", "9D", "9C", "10S", "10D");
            var pokerHand = new FiveCardPokerHandScore(hand);
            Assert.AreEqual(FiveCardPokerHandScore.HandRank.FullHouse, pokerHand.GetHandRank());
        }

        [Test]
        public void HighCard()
        {
            var hand = TestHelpers.MakeHand("AC", "8H", "9C", "10S", "4D");
            var pokerHand = new FiveCardPokerHandScore(hand);
            Assert.AreEqual(FiveCardPokerHandScore.HandRank.HighCard, pokerHand.GetHandRank());
        }

        [Test]
        public void Pair()
        {
            var hand = TestHelpers.MakeHand("9H", "9D", "6C", "4S", "10D");
            var pokerHand = new FiveCardPokerHandScore(hand);
            Assert.AreEqual(FiveCardPokerHandScore.HandRank.Pair, pokerHand.GetHandRank());
        }

        [Test]
        public void RoyalFlush()
        {
            var hand = TestHelpers.MakeHand("AD", "KD", "QD", "JD", "10D");
            var pokerHand = new FiveCardPokerHandScore(hand);
            Assert.AreEqual(FiveCardPokerHandScore.HandRank.RoyalFlush, pokerHand.GetHandRank());
        }

        [Test]
        public void Straight()
        {
            var hand = TestHelpers.MakeHand("AC", "KD", "QD", "JD", "10D");
            var pokerHand = new FiveCardPokerHandScore(hand);
            Assert.AreEqual(FiveCardPokerHandScore.HandRank.Straight, pokerHand.GetHandRank());
        }

        [Test]
        public void StraightFlush()
        {
            var hand = TestHelpers.MakeHand("9D", "KD", "QD", "JD", "10D");
            var pokerHand = new FiveCardPokerHandScore(hand);
            Assert.AreEqual(FiveCardPokerHandScore.HandRank.StraightFlush, pokerHand.GetHandRank());
        }

        [Test]
        public void ThreeOfAKind()
        {
            var hand = TestHelpers.MakeHand("9H", "9D", "9C", "7S", "10D");
            var pokerHand = new FiveCardPokerHandScore(hand);
            Assert.AreEqual(FiveCardPokerHandScore.HandRank.ThreeOfAKind, pokerHand.GetHandRank());
        }

        [Test]
        public void TwoPair()
        {
            var hand = TestHelpers.MakeHand("9H", "9D", "8C", "10S", "10D");
            var pokerHand = new FiveCardPokerHandScore(hand);
            Assert.AreEqual(FiveCardPokerHandScore.HandRank.TwoPair, pokerHand.GetHandRank());
        }

        [Test]
        public void Royal_Flush_Has_Score_Of_6834375()
        {
            var hand = TestHelpers.MakeHand("AD", "KD", "QD", "JD", "10D");
            var pokerHand = new FiveCardPokerHandScore(hand);
            Assert.AreEqual(6834375, pokerHand.GetHandScore());
        }

        [Test]
        public void Straight_Flush_With_K_Q_J_10_9_Has_Score_Of_6776259()
        {
            var hand = TestHelpers.MakeHand("9D", "KD", "QD", "JD", "10D");
            var pokerHand = new FiveCardPokerHandScore(hand);
            Assert.AreEqual(6776259, pokerHand.GetHandScore());
        }

        [Test]
        public void Quad_5s_Has_Score_Of_5568750()
        {
            var hand = TestHelpers.MakeHand("5D", "5C", "5H", "5S", "10D");
            var pokerHand = new FiveCardPokerHandScore(hand);
            Assert.AreEqual(5568750, pokerHand.GetHandScore());
        }

        [Test]
        public void Aces_Full_Has_Score_Of_5265000()
        {
            var hand = TestHelpers.MakeHand("AD", "AC", "AH", "10S", "10D");
            var pokerHand = new FiveCardPokerHandScore(hand);
            Assert.AreEqual(5265000, pokerHand.GetHandScore());
        }
        
        [Test]
        public void Flush_With_A_9_8_7_2_Has_Score_Of_4537907()
        {
            var hand = TestHelpers.MakeHand("AD", "9D", "8D", "7D", "2D");
            var pokerHand = new FiveCardPokerHandScore(hand);
            Assert.AreEqual(4537907, pokerHand.GetHandScore());
        }
        
        [Test]
        public void Straight_With_A_2_3_4_5_Has_Score_Of_3304844()
        {
            var hand = TestHelpers.MakeHand("AD", "2C", "3D", "4D", "5D");
            var pokerHand = new FiveCardPokerHandScore(hand);
            Assert.AreEqual(3304844, pokerHand.GetHandScore());
        }
        
        [Test]
        public void Straight_With_2_3_4_5_6_Has_Score_Of_3359072()
        {
            var hand = TestHelpers.MakeHand("6D", "2C", "3D", "4D", "5D");
            var pokerHand = new FiveCardPokerHandScore(hand);
            Assert.AreEqual(3359072, pokerHand.GetHandScore());
        }
        
        [Test]
        public void Trip_4s_With_A_10_Kicker_Has_Score_Of_2530125()
        {
            var hand = TestHelpers.MakeHand("4D", "4C", "4D", "AD", "10D");
            var pokerHand = new FiveCardPokerHandScore(hand);
            Assert.AreEqual(2530125, pokerHand.GetHandScore());
        }
        
        [Test]
        public void Two_Pair_Of_9s_And_8s_With_4_Kicker_Has_Score_Of_2002275()
        {
            var hand = TestHelpers.MakeHand("8D", "8C", "9D", "9C", "4D");
            var pokerHand = new FiveCardPokerHandScore(hand);
            Assert.AreEqual(2002275, pokerHand.GetHandScore());
        }
        
        [Test]
        public void Pair_Of_Ks_With_4_3_2_Kicker_Has_Score_Of_1431705()
        {
            var hand = TestHelpers.MakeHand("KD", "KC", "4D", "3C", "2D");
            var pokerHand = new FiveCardPokerHandScore(hand);
            Assert.AreEqual(1431705, pokerHand.GetHandScore());
        }
        
        [Test]
        public void Ace_High_With_9_8_4_3_Kicker_Has_Score_Of_740988()
        {
            var hand = TestHelpers.MakeHand("8D", "9C", "4D", "3C", "AD");
            var pokerHand = new FiveCardPokerHandScore(hand);
            Assert.AreEqual(740988, pokerHand.GetHandScore());
        }
    }
}