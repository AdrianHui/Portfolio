using System;
using System.Collections.Generic;
using System.Linq;

namespace MindMap
{
    class Control
    {
        private readonly Map map;

        public Control(Map map)
        {
            this.map = map;
        }

        public void Insert(string nodeText = "new node")
        {
            Node newNode = new Node(nodeText);
            newNode.Parent = map.Current;
            map.Current.Childs.Add(newNode);
            map.Current = newNode;
        }

        public void Enter(string nodeText = "new node")
        {
            if (map.Current == map.CentralNode)
            {
                return;
            }

            Node newNode = new Node(nodeText);
            newNode.Parent = map.Current.Parent;
            map.Current.Parent.Childs.Add(newNode);
            map.Current = newNode;
        }

        public void Backspace()
        {
            map.Current.Text =
                map.Current.Text.Substring(0, map.Current.Text.Length - 1);
        }

        public void UpArrow()
        {
            if (map.Current == map.CentralNode)
            {
                return;
            }

            var childIndex = map.Current.Parent.Childs.IndexOf(map.Current);
            map.Current = childIndex == 0
                ? map.Current
                : map.Current.Parent.Childs[childIndex - 1];
        }

        public void DownArrow()
        {
            if (map.Current == map.CentralNode)
            {
                return;
            }

            var childIndex = map.Current.Parent.Childs.IndexOf(map.Current);
            map.Current =
                map.Current.Parent.Childs[childIndex] == map.Current.Parent.Childs.Last()
                     ? map.Current
                     : map.Current.Parent.Childs[childIndex + 1];
        }

        public void RightArrow()
        {
            map.Current = map.Current.Childs.Count > 0
                ? map.Current.Childs.First()
                : map.Current;
        }

        public void LeftArrow()
        {
            map.Current = map.Current.Parent ?? map.Current;
        }

        public void Delete()
        {
            if (map.Current == map.CentralNode)
            {
                return;
            }

            var childIndex = map.Current.Parent.Childs.IndexOf(map.Current);
            bool last = childIndex == map.Current.Parent.Childs.Count - 1;
            map.Current.Parent.Childs.RemoveAt(childIndex);
            if (map.Current.Parent.Childs.Count == 0)
            {
                map.Current = map.Current.Parent;
            }
            else
            {
                map.Current = last ? map.Current.Parent.Childs[childIndex - 1]
                                       : map.Current.Parent.Childs[childIndex];
            }
        }

        public void ChangeNodeText(char character)
        {
            const int low = 31;
            const int high = 127;
            map.Current.Text = character > low && character < high
                        ? map.Current.Text + character
                        : map.Current.Text;
        }
    }
}
