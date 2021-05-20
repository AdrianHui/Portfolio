using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMap
{
    class HTML
    {
        public HTML()
        {
        }

        public string DocType()
        {
            return "<!DOCTYPE html>\n";
        }

        public string SetHTML(string html)
        {
            return $"<HTML>\n{html}\n</HTML>\n";
        }

        public string Head(string head)
        {
            return $"<HEAD>\n{head}\n</HEAD>\n";
        }

        public string Title(string title)
        {
            return $"\t<TITLE>{title}</TITLE>\n";
        }

        public string Body(string body)
        {
            return $"<BODY>\n{body}\n</BODY>\n";
        }
    }
}
