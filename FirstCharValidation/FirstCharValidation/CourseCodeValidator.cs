using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    class CourseCodeValidator : IPattern
    {
        private readonly IPattern pattern;
        public CourseCodeValidator()
        {
            var digit = new Range('0', '9');
            var twoSemesters = new Any("2468");
            var oneSemester = new Any("13579");
            var semesters = new Choice(oneSemester, twoSemesters);
            var year = new Any("012345679");
            var courseNumber = new Sequence(year, semesters, digit, digit);
            var letter = new Choice(new Range('A', 'Z'), new Range('a', 'z'));
            var acadunit = new Sequence(letter, letter, letter);
            pattern = new Sequence(acadunit, courseNumber);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
