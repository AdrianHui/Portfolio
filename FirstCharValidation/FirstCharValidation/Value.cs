using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            var value = new Choice(new String(),
                                   new Number(),
                                   new Text("true"),
                                   new Text("false"),
                                   new Text("null"));
            var whiteSpace = new Optional(new OneOrMore(new Any(" \n\t\r")));
            var element = new Sequence(whiteSpace, value, whiteSpace);
            var elements = new List(element, new Character(','));
            var member = new Sequence(whiteSpace, new String(), whiteSpace, new Character(':'), element);
            var members = new List(member, new Character(','));
            var array = new Sequence(new Character('['), whiteSpace, elements, whiteSpace, new Character(']'));
            var jsonObject = new Sequence(new Character('{'), whiteSpace, members, whiteSpace, new Character('}'));
            value.Add(array);
            value.Add(jsonObject);
            pattern = element;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
