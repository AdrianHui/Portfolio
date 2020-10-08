using System;

namespace FootballRanking
{
    class Standings
    {
        Team[] teams;

        public Standings(Team[] teams)
        {
            this.teams = teams;
        }

        public void AddTeam(string name, int points)
        {
            Array.Resize(ref teams, teams.Length + 1);
            this.teams[teams.Length - 1] = new Team(name, points);
        }

        public void SortTeams()
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

        public string GetTeamByRankingPosition(int index)
        {
            return teams[index - 1].GetTeamName();
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

            if (homeTeamGoals > awayTeamGoals)
            {
                teams[GetTeamRanking(homeTeam) - 1].IncreasePoints(3);
            }

            if (homeTeamGoals < awayTeamGoals)
            {
                teams[GetTeamRanking(awayTeam) - 1].IncreasePoints(3);
            }

            SortTeams();
        }
    } 
}
