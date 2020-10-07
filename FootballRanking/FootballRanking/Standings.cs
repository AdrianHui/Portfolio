using System;

namespace FootballRanking
{
    public class Standings
    {
        public void AddTeam(ref Team[] teamsArray, string name, int points)
        {
            Array.Resize(ref teamsArray, teamsArray.Length + 1);
            teamsArray[teamsArray.Length - 1] = new Team(name, points);
        }

        public void SortTeams(ref Team[] teamsArray)
        {
            for (int i = 0; i < teamsArray.Length; i++)
            {
                for (int j = i + 1; j < teamsArray.Length; j++)
                {
                    if (teamsArray[j].ComparePoints(teamsArray[i]) == 1)
                    {
                        Team temp = teamsArray[i];
                        teamsArray[i] = teamsArray[j];
                        teamsArray[j] = temp;
                    }
                }
            }
        }
    } 
}
