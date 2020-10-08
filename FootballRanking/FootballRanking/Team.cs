using System;
using System.Collections.Generic;
using System.Text;

namespace FootballRanking
{
    class Team
    {
        string name;
        int points;

        public Team(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public int ComparePoints(Team teamToCompareWith)
        {
            return this.points.CompareTo(teamToCompareWith.points);
        }

        public int CompareNames(Team teamToCompareWith)
        {
            return this.name.CompareTo(teamToCompareWith.name);
        }

        public void IncreasePoints(int points)
        {
            this.points += points;
        }
    }
}
