using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballRanking
{
    public static class Standings
    {
        public static List<KeyValuePair<string, int>> teams = new List<KeyValuePair<string, int>> {
            new KeyValuePair<string, int>("Dinamo", 29), new KeyValuePair<string, int>("Chiajna", 27),
            new KeyValuePair<string, int>("Viitorul", 40), new KeyValuePair<string, int>("CFR", 36)};

        public static void AddTeam(string name, int points)
        {
            KeyValuePair<string, int> team = new KeyValuePair<string, int>(name, points);
            teams.Add(team);
        }

        public static string GetTeamAtPosition(int position)
        {
            SortTeams();
            return teams[position - 1].Key + " - " + Convert.ToString(teams[position - 1].Value) + " points";
        }

        public static void SortTeams()
        {
            SortTeams(teams, 0, teams.Count - 1);
        }

        private static void SortTeams(List<KeyValuePair<string, int>> teams, int start, int end)
        {
            int pivot = 0;
            if (start >= end)
            {
                return;
            }

            pivot = Partition(teams, start, end);
            SortTeams(teams, start, pivot - 1);
            SortTeams(teams, pivot + 1, end);
        }

        private static int Partition(List<KeyValuePair<string, int>> teams, int start, int end)
        {
            int pivot = teams.ElementAt(end).Value;
            int i = start - 1;

            for (int j = start; j < end; j++)
            {
                if (teams.ElementAt(j).Value > pivot)
                {
                    i++;
                    KeyValuePair<string, int> temp = teams[i];
                    teams[i] = teams[j];
                    teams[j] = temp;
                }
            }

            KeyValuePair<string, int> temp2 = teams.ElementAt(i + 1);
            teams[i + 1] = teams[end];
            teams[end] = temp2;

            return i + 1;
        }
    }
}
