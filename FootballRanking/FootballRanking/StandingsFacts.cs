using Xunit;

namespace FootballRanking.Facts
{
    public class StandingsFacts
    {
        [Fact]
        public void AddsTeamsToStandings()
        {
            Standings standings = new Standings();
            standings.AddTeam("Dinamo", 30);
        }
    }
}
