using System.Linq;

namespace Poker31
{
    public class FiveCardPokerHandScore
    {
        private readonly HandRank _rank;
        private readonly FiveCardPokerHandAnalysis _handAnalysis;
        private readonly int _score;

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
            _score = CalculateTotalHandScore();
        }

        public HandRank GetHandRank()
        {
            return _rank;
        }
        
        public int GetHandScore()
        {
            return _score;
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

        private int CalculateTotalHandScore()
        {
            if (_rank == HandRank.RoyalFlush) return MakeScore((int) _rank);
            if (_rank == HandRank.StraightFlush) return ScoreByConsecutiveValuesWhenAceCanBeLow();
            if (_rank == HandRank.FourOfAKind) return FourOfAKindScore();
            if (_rank == HandRank.FullHouse) return FullHouseScore();
            if (_rank == HandRank.Flush) return ScoreByConsecutiveValuesWhenAceIsAlwaysHigh();
            if (_rank == HandRank.Straight) return ScoreByConsecutiveValuesWhenAceCanBeLow();
            if (_rank == HandRank.ThreeOfAKind) return ThreeOfAKindScore();
            if (_rank == HandRank.TwoPair) return TwoPairScore();
            if (_rank == HandRank.Pair) return PairScore();
            return ScoreByConsecutiveValuesWhenAceIsAlwaysHigh();
        }

        private int PairScore()
        {
            var pair = _handAnalysis.GetOrderedFrequencyList().FindIndex(i => i == 2);
            var kickers = _handAnalysis.GetOrderedCardList().Where(card => card.GetValue() != pair).ToList();
            kickers.Sort();
            return MakeScore((int) _rank, pair, kickers[2].GetValue(), kickers[1].GetValue(), kickers[0].GetValue());
        }

        private int TwoPairScore()
        {
            var lowPair = _handAnalysis.GetOrderedFrequencyList().FindIndex(i => i == 2);
            var highPair = _handAnalysis.GetOrderedFrequencyList().FindLastIndex(i => i == 2);
            var kickers = _handAnalysis.GetOrderedCardList().Where(card => card.GetValue() != lowPair || card.GetValue() != highPair).ToList();
            kickers.Sort();
            return MakeScore((int) _rank, highPair, lowPair, kickers[0].GetValue());
        }

        private int ThreeOfAKindScore()
        {
            var trips = _handAnalysis.GetOrderedFrequencyList().FindIndex(i => i == 3);
            var kickers = _handAnalysis.GetOrderedCardList().Where(card => card.GetValue() != trips).ToList();
            kickers.Sort();
            return MakeScore((int) _rank, trips, kickers[1].GetValue(), kickers[0].GetValue());
        }

        private int FullHouseScore()
        {
            return MakeScore((int) _rank, _handAnalysis.GetOrderedFrequencyList().FindIndex(i => i == 3));
        }

        private int FourOfAKindScore()
        {
            return MakeScore((int) _rank, _handAnalysis.GetOrderedFrequencyList().FindIndex(i => i == 4));
        }

        private int ScoreByConsecutiveValuesWhenAceCanBeLow()
        {
            if (_handAnalysis.GetOrderedCardList()[4].GetValue() == 14 &&
                _handAnalysis.GetOrderedCardList()[0].GetValue() == 2)
            {
                return MakeScore((int) _rank, _handAnalysis.GetOrderedCardList()[3].GetValue(), _handAnalysis.GetOrderedCardList()[2].GetValue(), _handAnalysis.GetOrderedCardList()[1].GetValue(), _handAnalysis.GetOrderedCardList()[0].GetValue(), _handAnalysis.GetOrderedCardList()[4].GetValue());
            }

            return ScoreByConsecutiveValuesWhenAceIsAlwaysHigh();
        }
        
        private int ScoreByConsecutiveValuesWhenAceIsAlwaysHigh()
        {
            return MakeScore((int) _rank, _handAnalysis.GetOrderedCardList()[4].GetValue(), _handAnalysis.GetOrderedCardList()[3].GetValue(), _handAnalysis.GetOrderedCardList()[2].GetValue(), _handAnalysis.GetOrderedCardList()[1].GetValue(), _handAnalysis.GetOrderedCardList()[0].GetValue());
        }
        
        private int MakeScore(int handRank, int decider1 = 0, int decider2 = 0, int decider3 = 0, int decider4 = 0,
            int decider5 = 0)
        {
            return handRank*759375 + decider1*50625 + decider2*3375 + decider3*225 + decider4*15 + decider5;
        }
    }
}