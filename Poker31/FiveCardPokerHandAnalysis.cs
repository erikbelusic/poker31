using System.Collections.Generic;
using System.Linq;

namespace Poker31
{
    public class FiveCardPokerHandAnalysis
    {
        private readonly List<Card> _orderedCardList;
        private readonly List<int> _frequencyList;

        public FiveCardPokerHandAnalysis(Hand hand)
        {
            _orderedCardList = CreateOrderedCardList(hand);
            _frequencyList = CreateFrequencyList(_orderedCardList);
        }

        public bool IsConsecutive()
        {
            return (
                _orderedCardList[0].GetValue() + 1 == _orderedCardList[1].GetValue() &&
                _orderedCardList[0].GetValue() + 2 == _orderedCardList[2].GetValue() &&
                _orderedCardList[0].GetValue() + 3 == _orderedCardList[3].GetValue() &&
                (
                    _orderedCardList[0].GetValue() + 4 == _orderedCardList[4].GetValue() ||
                    (_orderedCardList[0].GetValue() == 2 && _orderedCardList[4].GetValue() == 14)
                )
            );
        }
        
        public bool IsSameSuit()
        {
            return _orderedCardList.All((card) => _orderedCardList[0].GetSuit() == card.GetSuit());
        }

        public List<Card> GetOrderedCardList()
        {
            return _orderedCardList;
        }
        
        public List<int> GetOrderedFrequencyList()
        {
            return _frequencyList;
        }
        
        private List<Card> CreateOrderedCardList(Hand originalHand)
        {
            var cardList = new List<Card>(originalHand.GetCards());
            cardList.Sort();
            return cardList;
        }
        
        private List<int> CreateFrequencyList(List<Card> orderedCardList)
        {
            int[] frequencyArray = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            
            foreach (var card in orderedCardList)
            {
                frequencyArray[card.GetValue()] += 1;
            }

            return new List<int>(frequencyArray);
        }
    }
}