using System.Linq;

namespace Poker31
{
    public class FiveCardPokerHandScore
    {
        private readonly HandRank _rank;
        private readonly FiveCardPokerHandAnalysis _handAnalysis;

        public enum HandRank
        {
            HighCard,
            Pair,
            TwoPair,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind,
            StraightFlush,
            RoyalFlush
        }

        public FiveCardPokerHandScore(Hand hand)
        {
            _handAnalysis = new FiveCardPokerHandAnalysis(hand);
            _rank = CalculateHandRank();
        }

        public HandRank GetHandRank()
        {
            return _rank;
        }

        private HandRank CalculateHandRank()
        {
            if (IsRoyalFlush()) return HandRank.RoyalFlush;
            if (IsStraightFlush()) return HandRank.StraightFlush;
            if (FourOfAKind()) return HandRank.FourOfAKind;
            if (FullHouse()) return HandRank.FullHouse;
            if (Flush()) return HandRank.Flush;
            if (Straight()) return HandRank.Straight;
            if (ThreeOfAKind()) return HandRank.ThreeOfAKind;
            if (TwoPair()) return HandRank.TwoPair;
            if (Pair()) return HandRank.Pair;
            return HandRank.HighCard;
        }
        
        private bool IsRoyalFlush()
        {
            return _handAnalysis.IsConsecutive() && _handAnalysis.IsSameSuit() &&
                   _handAnalysis.GetOrderedCardList()[0].GetValue() == 10;
        }
        
        private bool IsStraightFlush()
        {
            return _handAnalysis.IsConsecutive() && _handAnalysis.IsSameSuit();
        }
        
        private bool FourOfAKind()
        {
            return _handAnalysis.GetOrderedFrequencyList().Any(i => i == 4);
        }

        private bool FullHouse()
        {
            return _handAnalysis.GetOrderedFrequencyList().Any(i => i == 3) && _handAnalysis.GetOrderedFrequencyList().Any(i => i == 2);;
        }
        
        private bool Flush()
        {
            return _handAnalysis.IsSameSuit();
        }
        
        private bool Straight()
        {
            return _handAnalysis.IsConsecutive();
        }
        
        private bool ThreeOfAKind()
        {
            return _handAnalysis.GetOrderedFrequencyList().Any(i => i == 3);
        }
        
        private bool TwoPair()
        {
            return 2 == _handAnalysis.GetOrderedFrequencyList().Count(i => i == 2);
        }
        
        private bool Pair()
        {
            return 1 == _handAnalysis.GetOrderedFrequencyList().Count(i => i == 2);
        }
    }
}