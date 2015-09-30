using System.Collections.Generic;

namespace Scanner
{
    public class PlayingStatus
    {
        static public PlayingStatus Create(Fixture fixture, Child player)
        {
            return new PlayingStatus();
        }

        internal static IEnumerable<Child> UpdatePlayers(List<Fixture> fixtures, List<Child> children)
        {
            foreach (var fixture in fixtures)
            {
                foreach (var child in children)
                {
                    var playingStatus = PlayingStatus.Create(fixture, child);
                    child.SetPlayingStatus(playingStatus);

                    child.InformParent();
                    
                    yield return child;
                }
            }
        }
    }
}