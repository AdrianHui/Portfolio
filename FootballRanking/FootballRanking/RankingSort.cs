using System;
using System.Collections.Generic;
using System.Text;

namespace FootballRanking
{
    class RankingSort : Standings
    {
        private Team[] sortedRanking;

        public void Sort(Team[] teams)
        {
            Sort(teams, 0, teams.Length - 1);
        }

        private void Sort(Team[] teams, int start, int end)
        {
            int pivot = 0;
            if (start >= end)
            {
                return;
            }

            pivot = Partition(teams, start, end);
            Sort(teams, start, pivot - 1);
            Sort(teams, pivot + 1, end);
        }

        private int Partition(Team[] teams, int start, int end)
        {
            //int pivot = teams[end].points;
            int i = start - 1;

            for (int j = start; j < end; j++)
            {
                //if (teams[j].points > pivot)
                //{
                //    i++;
                //    Team temp = teams[i];
                //    teams[i] = teams[j];
                //    teams[j] = temp;
                //}
            }

            Team temp2 = teams[i + 1];
            teams[i + 1] = teams[end];
            teams[end] = temp2;

            return i + 1;
        }
    }
}
