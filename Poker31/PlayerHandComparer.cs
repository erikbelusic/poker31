using System.Collections.Generic;

namespace Poker31
{
    public static class PlayerHandComparer
    {
        public static List<Player> GetLosers(List<Player> players)
        {
            var comparablePlayers = new List<ComparablePlayer>();
            
            foreach (var player in players)
            {
                comparablePlayers.Add(new ComparablePlayer(player));
            }
            
            comparablePlayers.Sort();
            
            var losers = new List<Player>();
            foreach (var comparablePlayer in comparablePlayers)
            {
                if (comparablePlayer.GetScore() == comparablePlayers[0].GetScore())
                {
                    losers.Add(comparablePlayer.GetPlayer());
                }
            }
            
            return losers;
        }
    }
}