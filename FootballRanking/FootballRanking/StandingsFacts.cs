using System.Collections.Generic;
using System.Linq;
using Xunit;
using static FootballRanking.Standings;

namespace FootballRanking.Facts
{
    public class StandingsFacts
    {
        [Fact]
        public void AddsTeamsToStandings()
        {
            AddTeam("FCSB", 33);
            KeyValuePair<string, int> team1 = new KeyValuePair<string, int>("FCSB", 33);
            Assert.True(teams[teams.Count - 1].Key == team1.Key &&
                teams[teams.Count - 1].Value == team1.Value);
        }

        [Fact]
        public void TeamsAreSortedByPoints()
        {
            SortTeams();
            Assert.True(teams[0].Key == "Viitorul" && teams[1].Key == "CFR" &&
                teams[2].Key == "Dinamo" && teams[3].Key == "Chiajna");
        }

        [Fact]
        public void ReturnTeamAndPointsAtGivenPosition()
        {
            string teamAtPosition = "CFR - 36 points";
            Assert.True(GetTeamAtPosition(2) == teamAtPosition);
        }
    }
}
