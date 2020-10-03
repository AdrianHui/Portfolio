using System;
using System.Collections.Generic;
using System.Text;

namespace FootballRanking
{
    class Team
    {
        private string _name;
        private int _points;

        public Team(string name, int points)
        {
            this._name = name;
            this._points = points;
        }
    }
}
