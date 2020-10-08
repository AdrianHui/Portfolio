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

        public int ComparePoints(Team teamToCompareWith)
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

        public int CompareNames(Team teamToCompareWith)
        {
            if (this.name != teamToCompareWith.name)
            {
                return 1;
            }

            return 0;
        }

        public string GetTeamName()
        {
            string name = "";
            for (int i = 0; i < this.name.Length; i++)
            {
                name += this.name[i];
            }

            return name;
        }
    }
}
