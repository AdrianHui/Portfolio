using System.Collections.Generic;
using System.Linq;
using Xunit;
using static FootballRanking.Standings;

namespace FootballRanking.Facts
{
    public class StandingsFacts
    {
        [Fact]
        public void AddTeamToStandings()
        {
            AddTeam("FCSB", 33);
            AddTeam("Viitorul", 40);
            KeyValuePair<string, int> teamToCheck = new KeyValuePair<string, int>("FCSB", 33);
            Assert.True(teams[0].Key == teamToCheck.Key && teams[0].Value == teamToCheck.Value);
        }

        [Fact]
        public void SortTeamsByPoints()
        {
            SortTeams();
            Assert.True(teams[0].Value > teams[1].Value);
        }
    }
}
