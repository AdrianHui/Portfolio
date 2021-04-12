using System;
using System.Collections.Generic;
using System.Text;

namespace MindMap
{
    public interface IMenu
    {
        public ICurrentView CurrentView { get; set; }

        public IControl Control { get; set; }
    }
}
