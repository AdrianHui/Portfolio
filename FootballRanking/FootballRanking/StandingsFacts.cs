using Xunit;

namespace FootballRanking.Facts
{
    public class StandingsFacts
    {
        [Fact]
        public void AddsTeamsToStandings()
        {
            Standings standings = new Standings();
            Team[] teams = new Team[] { new Team("FCSB", 33),
                            new Team("Viitorul", 31),
                            new Team("CFR", 39) };
            Team dinamo = new Team("Dinamo", 30);
            standings.AddTeam(ref teams, "Dinamo", 30);
            Assert.True(teams[teams.Length - 1].CompareNames(dinamo) == 1 &&
                teams[teams.Length - 1].ComparePoints(dinamo) == 0);
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
            Assert.True(teams[0].CompareNames(cfr) == 1 && teams[0].ComparePoints(cfr) == 0 &&
                        teams[1].CompareNames(fcsb) == 1 && teams[1].ComparePoints(fcsb) == 0 &&
                        teams[2].CompareNames(viitorul) == 1 && teams[2].ComparePoints(viitorul) == 0 &&
                        teams[3].CompareNames(dinamo) == 1 && teams[3].ComparePoints(dinamo) == 0);
        }
    }
}
