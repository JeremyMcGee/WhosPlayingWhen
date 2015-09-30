using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public partial class PlayingStatus
    {
        public PlayingStatus()
        {
        }

        [Key]
        public int Id { get; set; }

        static public PlayingStatus Create(Fixture fixture, Child player)
        {
            var newPlayingStatus = new PlayingStatus
            {
                Fixture = fixture,
                Player = player
            };

            player.PlayingStatuses.Add(newPlayingStatus);
            fixture.PlayingStatuses.Add(newPlayingStatus);

            return newPlayingStatus;
        }

        public Fixture Fixture { get; set; }

        public Child Player { get; set; }

        public void InformParent()
        {

        }
    }
}