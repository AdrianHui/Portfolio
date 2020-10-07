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

        public void SortTeams()
        {
            for (int i = 0; i < teams.Length; i++)
            {
                for (int j = 1; j < teams.Length; j++)
                {
                    if (teams[j].CompareTo(teams[i]) == 1)
                    {
                        Team temp = teams[i];
                        teams[i] = teams[j];
                        teams[j] = temp;
                    }
                }

            }
        }
    }
}
