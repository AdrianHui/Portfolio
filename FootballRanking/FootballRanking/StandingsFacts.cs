using Xunit;

namespace FootballRanking.Facts
{
    public class StandingsFacts
    {
        [Fact]
        public void AddsTeamToStandings()
        {
            Standings standings = new Standings();
            Team fcsb = new Team("FCSB", 33);
            Team viitorul = new Team("Viitorul", 31);
            Team cfr = new Team("CFR", 39);
            Team[] teams = new Team[] { fcsb, viitorul, cfr };
            standings.AddTeam(ref teams, "Dinamo", 30);
            Team teamToAdd = new Team("Dinamo", 30);
            Assert.True(teams[teams.Length - 1].CompareNames(teamToAdd) == 0 &&
                teams[teams.Length - 1].ComparePoints(teamToAdd) == 0);
        }

        [Fact]
        public void ShouldSortTeamsByPoints()
        {
            Standings standings = new Standings();
            Team fcsb = new Team("FCSB", 33);
            Team dinamo = new Team("Dinamo", 30);
            Team viitorul = new Team("Viitorul", 31);
            Team cfr = new Team("CFR", 39);
            Team[] teams = new Team[] { fcsb, dinamo, viitorul, cfr };
            standings.SortTeams(ref teams);
            Assert.True(teams[0].CompareNames(cfr) == 0 && teams[0].ComparePoints(cfr) == 0 &&
                        teams[1].CompareNames(fcsb) == 0 && teams[1].ComparePoints(fcsb) == 0 &&
                        teams[2].CompareNames(viitorul) == 0 && teams[2].ComparePoints(viitorul) == 0 &&
                        teams[3].CompareNames(dinamo) == 0 && teams[3].ComparePoints(dinamo) == 0);
        }

        [Fact]
        public void ShouldWorkIfTeamsAreAlreadySorted()
        {
            Standings standings = new Standings();
            Team fcsb = new Team("FCSB", 33);
            Team dinamo = new Team("Dinamo", 30);
            Team viitorul = new Team("Viitorul", 31);
            Team cfr = new Team("CFR", 39);
            Team[] teams = new Team[] { cfr, fcsb, viitorul, dinamo };
            standings.SortTeams(ref teams);
            Assert.True(teams[0].CompareNames(cfr) == 0 && teams[0].ComparePoints(cfr) == 0 &&
                        teams[1].CompareNames(fcsb) == 0 && teams[1].ComparePoints(fcsb) == 0 &&
                        teams[2].CompareNames(viitorul) == 0 && teams[2].ComparePoints(viitorul) == 0 &&
                        teams[3].CompareNames(dinamo) == 0 && teams[3].ComparePoints(dinamo) == 0);
        }

        [Fact]
        public void ShouldReturnTeamNameFromSpecifiedPosition()
        {
            Standings standings = new Standings();
            Team fcsb = new Team("FCSB", 33);
            Team dinamo = new Team("Dinamo", 30);
            Team viitorul = new Team("Viitorul", 31);
            Team cfr = new Team("CFR", 39);
            Team[] teams = new Team[] { cfr, fcsb, viitorul, dinamo };
            Assert.Equal("CFR", standings.GetTeamByRankingPosition(teams, 1));
        }

        [Fact]
        public void ShouldReturnTeamRankingPosition()
        {
            Standings standings = new Standings();
            Team fcsb = new Team("FCSB", 33);
            Team dinamo = new Team("Dinamo", 30);
            Team viitorul = new Team("Viitorul", 31);
            Team cfr = new Team("CFR", 39);
            Team[] teams = new Team[] { cfr, fcsb, viitorul, dinamo };
            Assert.Equal(2, standings.GetTeamRanking(teams, fcsb));
        }

        [Fact]
        public void ShouldReturnNegativeOneIfTeamNotFound()
        {
            Standings standings = new Standings();
            Team fcsb = new Team("FCSB", 33);
            Team dinamo = new Team("Dinamo", 30);
            Team viitorul = new Team("Viitorul", 31);
            Team cfr = new Team("CFR", 39);
            Team[] teams = new Team[] { cfr, viitorul, dinamo };
            Assert.Equal(-1, standings.GetTeamRanking(teams, fcsb));
        }

        [Fact]
        public void ShouldUpdateStandingsIfIsATie()
        {
            Standings standings = new Standings();
            Team fcsb = new Team("FCSB", 33);
            Team dinamo = new Team("Dinamo", 30);
            Team viitorul = new Team("Viitorul", 31);
            Team cfr = new Team("CFR", 39);
            Team[] teams = new Team[] { cfr, fcsb, viitorul, dinamo };
            standings.Match(ref teams, viitorul, 1, fcsb, 1);
            Assert.True(teams[0].CompareNames(cfr) == 0 && teams[0].ComparePoints(cfr) == 0 &&
                        teams[1].CompareNames(fcsb) == 0 && teams[1].ComparePoints(fcsb) == 0 &&
                        teams[2].CompareNames(viitorul) == 0 && teams[2].ComparePoints(viitorul) == 0 &&
                        teams[3].CompareNames(dinamo) == 0 && teams[3].ComparePoints(dinamo) == 0);
        }

        [Fact]
        public void ShouldUpdateStandingsIfHomeTeamWins()
        {
            Standings standings = new Standings();
            Team fcsb = new Team("FCSB", 33);
            Team dinamo = new Team("Dinamo", 30);
            Team viitorul = new Team("Viitorul", 31);
            Team cfr = new Team("CFR", 39);
            Team[] teams = new Team[] { cfr, fcsb, viitorul, dinamo };
            standings.Match(ref teams, viitorul, 2, fcsb, 1);
            Assert.True(teams[0].CompareNames(cfr) == 0 && teams[0].ComparePoints(cfr) == 0 &&
                        teams[1].CompareNames(viitorul) == 0 && teams[1].ComparePoints(viitorul) == 0 &&
                        teams[2].CompareNames(fcsb) == 0 && teams[2].ComparePoints(fcsb) == 0 &&
                        teams[3].CompareNames(dinamo) == 0 && teams[3].ComparePoints(dinamo) == 0);
        }

        [Fact]
        public void ShouldUpdateStandingsIfAwayTeamWins()
        {
            Standings standings = new Standings();
            Team fcsb = new Team("FCSB", 33);
            Team dinamo = new Team("Dinamo", 30);
            Team viitorul = new Team("Viitorul", 31);
            Team cfr = new Team("CFR", 39);
            Team[] teams = new Team[] { cfr, fcsb, viitorul, dinamo };
            standings.Match(ref teams, viitorul, 1, dinamo, 3);
            Assert.True(teams[0].CompareNames(cfr) == 0 && teams[0].ComparePoints(cfr) == 0 &&
                        teams[1].CompareNames(fcsb) == 0 && teams[1].ComparePoints(fcsb) == 0 &&
                        teams[2].CompareNames(dinamo) == 0 && teams[2].ComparePoints(dinamo) == 0 &&
                        teams[3].CompareNames(viitorul) == 0 && teams[3].ComparePoints(viitorul) == 0);
        }
    }
}
