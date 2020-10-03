using System;
using System.Collections.Generic;
using System.Text;

namespace FootballRanking
{
    class Standings
    {
        private Team[] ranking;
        int index = 0;

        public void AddTeam(string name, int points)
        {
            ranking[index] = new Team(name, points);
            index++;
        }
    }
}
