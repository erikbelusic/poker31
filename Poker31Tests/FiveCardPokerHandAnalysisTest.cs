using NUnit.Framework;
using Poker31;

namespace Poker31Tests
{
    [TestFixture]
    public class FiveCardPokerHandAnalysisTest
    {
        [Test]
        public void Is_Consecutive_Returns_False_For_5_6_7_8_A()
        {
            var hand = TestHelpers.MakeHand("5C", "6D", "7C", "8D", "AD");
            var analysis = new FiveCardPokerHandAnalysis(hand);
            Assert.IsFalse(analysis.IsConsecutive());
        }

        [Test]
        public void Is_Consecutive_Returns_False_For_A_2_5_6_7()
        {
            var hand = TestHelpers.MakeHand("AC", "2D", "5C", "6D", "7D");
            var analysis = new FiveCardPokerHandAnalysis(hand);
            Assert.IsFalse(analysis.IsConsecutive());
        }

        [Test]
        public void Is_Consecutive_Returns_True_For_10_J_Q_K_A()
        {
            var hand = TestHelpers.MakeHand("10C", "JD", "QC", "KD", "AD");
            var analysis = new FiveCardPokerHandAnalysis(hand);
            Assert.IsTrue(analysis.IsConsecutive());
        }

        [Test]
        public void Is_Consecutive_Returns_True_For_5_6_7_8_9()
        {
            var hand = TestHelpers.MakeHand("5C", "6D", "7C", "8D", "9D");
            var analysis = new FiveCardPokerHandAnalysis(hand);
            Assert.IsTrue(analysis.IsConsecutive());
        }

        [Test]
        public void Is_Consecutive_Returns_True_For_A_2_3_4_5()
        {
            var hand = TestHelpers.MakeHand("AC", "2D", "3C", "4D", "5D");
            var analysis = new FiveCardPokerHandAnalysis(hand);
            Assert.IsTrue(analysis.IsConsecutive());
        }

        [Test]
        public void Is_Same_Suit_Returns_False_When_All_Cards_Are_Not_Same_Suit()
        {
            var hand = TestHelpers.MakeHand("AC", "2D", "3C", "4D", "5D");
            var analysis = new FiveCardPokerHandAnalysis(hand);
            Assert.IsFalse(analysis.IsSameSuit());
        }

        [Test]
        public void Is_Same_Suit_Returns_True_When_All_Cards_Are_Same_Suit()
        {
            var hand = TestHelpers.MakeHand("AD", "2D", "3D", "4D", "5D");
            var analysis = new FiveCardPokerHandAnalysis(hand);
            Assert.IsTrue(analysis.IsSameSuit());
        }
    }
}