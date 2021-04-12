using System;
using System.Collections.Generic;
using System.Text;

namespace MindMap
{
    public interface IControl
    {
        public void Insert();

        public void Enter();

        public void Backspace();

        public void UpArrow();

        public void DownArrow();

        public void RightArrow();

        public void LeftArrow();

        public void Delete();

        public void ChangeText(char character);
    }
}
