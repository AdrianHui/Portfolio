using System;
using System.Collections.Generic;
using System.Text;

namespace FootballRanking
{
    public class Team
    {
        readonly string name;
        readonly int points;
        readonly int ranking;

        public Team(string name, int points, int ranking)
        {
            this.name = name;
            this.points = points;
            this.ranking = ranking;
        }
    }
}
