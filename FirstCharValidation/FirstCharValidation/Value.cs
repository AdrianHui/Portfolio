using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            var value = new Choice(new String(),
                                   new Number(),
                                   new Text("true"),
                                   new Text("false"),
                                   new Text("null"));
            var whiteSpace = new Optional(new Choice(new Text("\\n"),
                                                     new Text("\\t"),
                                                     new Text("\\r"),
                                                     new Character(' ')));
            var element = new Sequence(whiteSpace, value, whiteSpace);
            var elements = new List(element, new Character(','));
            var member = new Sequence(whiteSpace, new String(), whiteSpace, new Character(':'), element);
            var members = new List(member, new Character(','));
            var array = new Sequence(new Character('['), whiteSpace, elements, new Character(']'));
            var jsonObject = new Sequence(new Character('{'), whiteSpace, members, new Character('}'));
            value.Add(array);
            value.Add(jsonObject);
            pattern = value;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
