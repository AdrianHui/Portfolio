using System;
using System.Collections.Generic;
using System.Text;

namespace MindMap
{
    public interface ICurrentView
    {
        public int Top { get; set; }

        public int Left { get; set; }

        public void Print();

        public void MoveDown();

        public void MoveUp();

        public void MoveLeft();

        public void MoveRight();
    }
}
