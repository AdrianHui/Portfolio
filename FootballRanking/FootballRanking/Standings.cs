using System;

namespace FootballRanking
{
    public class Standings
    {
        public void AddTeam(ref Team[] teams, string name, int points)
        {
            Array.Resize(ref teams, teams.Length + 1);
            teams[teams.Length - 1] = new Team(name, points);
        }

        public void SortTeams(ref Team[] teams)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                for (int j = i + 1; j < teams.Length; j++)
                {
                    if (teams[j].ComparePoints(teams[i]) == 1)
                    {
                        Team temp = teams[i];
                        teams[i] = teams[j];
                        teams[j] = temp;
                    }
                }
            }
        }

        public string GetTeamByRankingPosition(Team[] teams, int index)
        {
            return teams[index - 1].GetTeamName();
        }

        public int GetTeamRanking(Team[] teams, Team team)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (team.CompareNames(teams[i]) == 0)
                {
                    return i + 1;
                }
            }

            return -1;
        }
    } 
}
