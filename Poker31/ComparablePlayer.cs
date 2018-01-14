using System;

namespace Poker31
{
    public class ComparablePlayer : IComparable<ComparablePlayer>
    {
        private readonly Player _player;
        private readonly int _score;

        public ComparablePlayer(Player player) 
        {
            _player = player;
            _score = new FiveCardPokerHandScore(player.GetHand()).GetHandScore();
        }

        public Player GetPlayer()
        {
            return _player;
        }
        
        public int GetScore()
        {
            return _score;
        }
        
        public int CompareTo(ComparablePlayer other)
        {
            return GetScore().CompareTo(other.GetScore());
        }
    }
}