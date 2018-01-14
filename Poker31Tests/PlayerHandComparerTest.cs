using NUnit.Framework;
using Poker31;
using System.Collections.Generic;

namespace Poker31Tests
{
    [TestFixture]
    public class PlayerHandComparerTest
    {
        private Player _playerWithFullHouse;
        private Player _playerWithFlush;
        private Player _playerWithTiedFlush;

        [SetUp]
        public void SetUp()
        {
            _playerWithFullHouse = new Player("Player with Full House");
            _playerWithFullHouse.addCardToHand(new Card(Card.Rank.Eight, Card.Suit.Clubs));
            _playerWithFullHouse.addCardToHand(new Card(Card.Rank.Eight, Card.Suit.Diamonds));
            _playerWithFullHouse.addCardToHand(new Card(Card.Rank.Eight, Card.Suit.Spades));
            _playerWithFullHouse.addCardToHand(new Card(Card.Rank.Seven, Card.Suit.Spades));
            _playerWithFullHouse.addCardToHand(new Card(Card.Rank.Seven, Card.Suit.Clubs));
            
            _playerWithFlush = new Player("Player with Flush");
            _playerWithFlush.addCardToHand(new Card(Card.Rank.Ace, Card.Suit.Diamonds));
            _playerWithFlush.addCardToHand(new Card(Card.Rank.King, Card.Suit.Diamonds));
            _playerWithFlush.addCardToHand(new Card(Card.Rank.Queen, Card.Suit.Diamonds));
            _playerWithFlush.addCardToHand(new Card(Card.Rank.Four, Card.Suit.Diamonds));
            _playerWithFlush.addCardToHand(new Card(Card.Rank.Three, Card.Suit.Diamonds));
            
            _playerWithTiedFlush = new Player("Player with Tied Flush");
            _playerWithTiedFlush.addCardToHand(new Card(Card.Rank.Ace, Card.Suit.Clubs));
            _playerWithTiedFlush.addCardToHand(new Card(Card.Rank.King, Card.Suit.Clubs));
            _playerWithTiedFlush.addCardToHand(new Card(Card.Rank.Queen, Card.Suit.Clubs));
            _playerWithTiedFlush.addCardToHand(new Card(Card.Rank.Four, Card.Suit.Clubs));
            _playerWithTiedFlush.addCardToHand(new Card(Card.Rank.Three, Card.Suit.Clubs));
        }
        
        [Test]
        public void GetLosers_Returns_The_Player_With_The_Lowest_Hand_When_There_Is_No_Tie()
        {
            var players = new List<Player> {_playerWithFlush, _playerWithFullHouse};

            var losers = PlayerHandComparer.GetLosers(players);
            
            Assert.AreEqual(1, losers.Count);
            Assert.Contains(_playerWithFlush, losers);
        }
        
        [Test]
        public void GetLosers_Returns_The_Players_With_The_Lowest_Hand_When_There_Is_A_Tie_For_Last()
        {
            var players = new List<Player> {_playerWithFlush, _playerWithTiedFlush, _playerWithFullHouse};

            var losers = PlayerHandComparer.GetLosers(players);
            
            Assert.AreEqual(2, losers.Count);
            Assert.Contains(_playerWithFlush, losers);
            Assert.Contains(_playerWithTiedFlush, losers);
        }
    }
}