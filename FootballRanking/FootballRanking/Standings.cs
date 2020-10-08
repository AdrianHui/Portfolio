using System;

namespace FootballRanking
{
    class Standings
    {
        Team[] teams;

        public Standings(Team[] teams)
        {
            this.teams = teams;
            SortTeams();
        }

        public void AddTeam(Team team)
        {
            Array.Resize(ref teams, teams.Length + 1);
            this.teams[teams.Length - 1] = team;
            SortTeams();
        }

        private void SortTeams()
        {
            for (int i = 0; i < teams.Length; i++)
            {
                for (int j = 0; j < teams.Length - 1; j++)
                {
                    if (teams[j].ComparePoints(teams[j + 1]) == -1)
                    {
                        Team temp = teams[j];
                        teams[j] = teams[j + 1];
                        teams[j + 1] = temp;
                    }
                }
            }
        }

        public Team GetTeamByRankingPosition(int index)
        {
            return teams[index - 1];
        }

        public int GetTeamRanking(Team team)
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

        public void Match(Team homeTeam, int homeTeamGoals, Team awayTeam, int awayTeamGoals)
        {
            if (homeTeamGoals == awayTeamGoals)
            {
                teams[GetTeamRanking(homeTeam) - 1].IncreasePoints(1);
                teams[GetTeamRanking(awayTeam) - 1].IncreasePoints(1);
            }
            else if (homeTeamGoals > awayTeamGoals)
            {
                teams[GetTeamRanking(homeTeam) - 1].IncreasePoints(3);
            }
            else
            {
                teams[GetTeamRanking(awayTeam) - 1].IncreasePoints(3);
            }

            SortTeams();
        }
    } 
}
