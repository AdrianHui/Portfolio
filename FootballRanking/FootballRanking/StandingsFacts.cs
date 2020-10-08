using Xunit;

namespace FootballRanking.Facts
{
    public class StandingsFacts
    {
        [Fact]
        public void AddsTeamToStandings()
        {
            Team fcsb = new Team("FCSB", 33);
            Team viitorul = new Team("Viitorul", 31);
            Team cfr = new Team("CFR", 39);
            Team teamToAdd = new Team("Dinamo", 30);
            Team[] teams = new Team[] { fcsb, viitorul, cfr };
            Standings standings = new Standings(teams);
            standings.AddTeam("Dinamo", 30);
            Assert.True(standings.GetTeamRanking(teamToAdd) != -1);
        }

        [Fact]
        public void ShouldSortTeamsByPoints()
        {
            Team fcsb = new Team("FCSB", 33);
            Team dinamo = new Team("Dinamo", 30);
            Team viitorul = new Team("Viitorul", 31);
            Team cfr = new Team("CFR", 39);
            Team[] teams = new Team[] { fcsb, dinamo, viitorul, cfr };
            Standings standings = new Standings(teams);
            standings.SortTeams();
            Assert.True(standings.GetTeamRanking(cfr) == 1 && standings.GetTeamRanking(fcsb) == 2 &&
                        standings.GetTeamRanking(viitorul) == 3 && standings.GetTeamRanking(dinamo) == 4);
        }

        [Fact]
        public void ShouldWorkIfTeamsAreAlreadySorted()
        {
            Team fcsb = new Team("FCSB", 33);
            Team dinamo = new Team("Dinamo", 30);
            Team viitorul = new Team("Viitorul", 31);
            Team cfr = new Team("CFR", 39);
            Team[] teams = new Team[] { cfr, fcsb, viitorul, dinamo };
            Standings standings = new Standings(teams);
            standings.SortTeams();
            Assert.True(standings.GetTeamRanking(cfr) == 1 && standings.GetTeamRanking(fcsb) == 2 &&
                        standings.GetTeamRanking(viitorul) == 3 && standings.GetTeamRanking(dinamo) == 4);
        }

        [Fact]
        public void ShouldReturnTeamNameFromSpecifiedPosition()
        {
            Team fcsb = new Team("FCSB", 33);
            Team dinamo = new Team("Dinamo", 30);
            Team viitorul = new Team("Viitorul", 31);
            Team cfr = new Team("CFR", 39);
            Team[] teams = new Team[] { cfr, fcsb, viitorul, dinamo };
            Standings standings = new Standings(teams);
            Assert.Equal("CFR", standings.GetTeamByRankingPosition(1));
        }

        [Fact]
        public void ShouldReturnTeamRankingPosition()
        {
            Team fcsb = new Team("FCSB", 33);
            Team dinamo = new Team("Dinamo", 30);
            Team viitorul = new Team("Viitorul", 31);
            Team cfr = new Team("CFR", 39);
            Team[] teams = new Team[] { cfr, fcsb, viitorul, dinamo };
            Standings standings = new Standings(teams);
            Assert.Equal(2, standings.GetTeamRanking(fcsb));
        }

        [Fact]
        public void ShouldReturnNegativeOneIfTeamNotFound()
        {
            Team fcsb = new Team("FCSB", 33);
            Team dinamo = new Team("Dinamo", 30);
            Team viitorul = new Team("Viitorul", 31);
            Team cfr = new Team("CFR", 39);
            Team[] teams = new Team[] { cfr, viitorul, dinamo };
            Standings standings = new Standings(teams);
            Assert.Equal(-1, standings.GetTeamRanking(fcsb));
        }

        [Fact]
        public void ShouldUpdateStandingsIfIsATie()
        {
            Team fcsb = new Team("FCSB", 33);
            Team dinamo = new Team("Dinamo", 33);
            Team viitorul = new Team("Viitorul", 39);
            Team cfr = new Team("CFR", 39);
            Team[] teams = new Team[] { cfr, fcsb, viitorul, dinamo };
            Standings standings = new Standings(teams);
            standings.Match(viitorul, 1, fcsb, 1);
            Assert.True(standings.GetTeamRanking(viitorul) == 1 && standings.GetTeamRanking(cfr) == 2 &&
                        standings.GetTeamRanking(fcsb) == 3 && standings.GetTeamRanking(dinamo) == 4);
        }

        [Fact]
        public void ShouldUpdateStandingsIfHomeTeamWins()
        {
            Team fcsb = new Team("FCSB", 33);
            Team dinamo = new Team("Dinamo", 30);
            Team viitorul = new Team("Viitorul", 31);
            Team cfr = new Team("CFR", 39);
            Team[] teams = new Team[] { cfr, fcsb, viitorul, dinamo };
            Standings standings = new Standings(teams);
            standings.Match(viitorul, 2, fcsb, 1);
            Assert.True(standings.GetTeamRanking(cfr) == 1 && standings.GetTeamRanking(viitorul) == 2 &&
                        standings.GetTeamRanking(fcsb) == 3 && standings.GetTeamRanking(dinamo) == 4);
        }

        [Fact]
        public void ShouldUpdateStandingsIfAwayTeamWins()
        {
            Team fcsb = new Team("FCSB", 33);
            Team dinamo = new Team("Dinamo", 31);
            Team viitorul = new Team("Viitorul", 31);
            Team cfr = new Team("CFR", 39);
            Team[] teams = new Team[] { cfr, fcsb, viitorul, dinamo };
            Standings standings = new Standings(teams);
            standings.Match(viitorul, 1, dinamo, 3);
            Assert.True(standings.GetTeamRanking(cfr) == 1 && standings.GetTeamRanking(dinamo) == 2 &&
                        standings.GetTeamRanking(fcsb) == 3 && standings.GetTeamRanking(viitorul) == 4);
        }
    }
}