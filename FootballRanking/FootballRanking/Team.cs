using System;
using System.Collections.Generic;
using System.Text;

namespace FootballRanking
{
    public class Team
    {
        string name;
        int points;

        public Team(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public int CompareTo(Team teamToCompareWith)
        {
            if (this.points < teamToCompareWith.points)
            {
                return -1;
            }

            if (this.points > teamToCompareWith.points)
            {
                return 1;
            }

            return 0;
        }
    }
}
