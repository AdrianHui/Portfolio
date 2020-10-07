using Xunit;

namespace FootballRanking.Facts
{
    public class TeamFacts
    {
        [Fact]
        public void FirstTeamPointsGreaterThanSecondShouldReturnOne()
        {
            Team team1 = new Team("CFR", 39);
            Team team2 = new Team("FCSB", 33);
            Assert.Equal(1, team1.ComparePoints(team2));
        }

        [Fact]
        public void SecondTeamPointsGreaterThanFirstShouldReturnNegativeOne()
        {
            Team team1 = new Team("CFR", 33);
            Team team2 = new Team("FCSB", 39);
            Assert.Equal(-1, team1.ComparePoints(team2));
        }

        [Fact]
        public void FirstTeamPointsEqualSecondShouldReturnZero()
        {
            Team team1 = new Team("CFR", 33);
            Team team2 = new Team("FCSB", 33);
            Assert.Equal(0, team1.ComparePoints(team2));
        }
    }
}
