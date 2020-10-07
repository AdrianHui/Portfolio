using System;

namespace FootballRanking
{
    public class Standings
    {
        Team[] teams = new Team[] { new Team("FCSB", 33), new Team("Viitorul", 31), new Team("CFR", 39) };

        public void AddTeam(string name, int points)
        {
            Array.Resize(ref teams, teams.Length + 1);
            teams[teams.Length - 1] = new Team(name, points);
        }
    }
}
