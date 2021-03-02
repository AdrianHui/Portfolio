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
            if (map.Current.Collapsed
                || map.Current.LeftCoord + nodeText.Length > Console.WindowWidth
                || GetLastRowCoord() + 3 >= Console.WindowHeight)
            {
                return;
            }

            Node newNode = new Node(nodeText);
            newNode.Parent = map.Current;
            map.Current.Childs.Add(newNode);
            newNode.Siblings = map.Current.Childs;
            map.Current = newNode;
        }

        public void Enter(string nodeText = "new node")
        {
            if (map.Current == map.CentralNode
                || GetLastRowCoord() + 3 >= Console.WindowHeight)
            {
                return;
            }

            Node newNode = new Node(nodeText);
            newNode.Parent = map.Current.Parent;
            map.Current.Parent.Childs.Add(newNode);
            newNode.Siblings = map.Current.Parent.Childs;
            map.Current = newNode;
        }

        public void Backspace()
        {
            if (map.Current.Text == "")
            {
                return;
            }

            map.Current.Text =
                map.Current.Text.Substring(0, map.Current.Text.Length - 1);
        }

        public void UpArrow()
        {
            if (map.Current == map.CentralNode)
            {
                return;
            }

            var index = map.Current.Siblings.IndexOf(map.Current);
            if (index != 0 && map.Current.Siblings[index - 1].Childs.Count > 0)
            {
                map.Current = map.Current.Siblings[index - 1];
                while (map.Current.Childs.Count != 0 && !map.Current.Collapsed)
                {
                    map.Current = map.Current.Childs.Last();
                }
            }
            else
            {
                map.Current = index == 0
                ? map.Current.Parent
                : map.Current.Parent.Childs[index - 1];
            }
        }

        public void DownArrow()
        {
            if (map.Current.Childs.Count > 0 && !map.Current.Collapsed)
            {
                map.Current = map.Current.Childs.First();
            }
            else
            {
                Node temp = map.Current;
                while (temp == temp.Siblings.Last()
                    && temp != map.CentralNode.Childs.Last())
                {
                    temp = temp.Parent;
                }

                if (temp.Childs.Count > 0 && temp == temp.Siblings.Last())
                {
                    return;
                }

                map.Current = temp == temp.Siblings.Last()
                    ? temp
                    : temp.Siblings[temp.Siblings.IndexOf(temp) + 1];
            }
        }

        public void RightArrow()
        {
            if (map.Current.Collapsed)
            {
                map.Current.Collapsed = false;
            }
            else
            {
                map.Current = map.Current.Childs.Count > 0
                    ? map.Current.Childs.First()
                    : map.Current;
            }
        }

        public void LeftArrow()
        {
            if (!map.Current.Collapsed && map.Current.Childs.Count != 0)
            {
                map.Current.Collapsed = true;
            }
            else
            {
                map.Current = map.Current.Parent ?? map.Current;
            }
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
            map.Current.Text = map.Current.LeftCoord + 1 < Console.WindowWidth
                && character > low && character < high
                        ? map.Current.Text + character
                        : map.Current.Text;
        }

        private int GetLastRowCoord()
        {
            const int helpMenuRows = 13;
            if (map.CentralNode.Childs.Count == 0)
            {
                return map.CentralNode.TopCoord + helpMenuRows;
            }

            Node temp = map.CentralNode.Childs.Last();
            while (temp.Childs.Count > 0 && !temp.Collapsed)
            {
                temp = temp.Childs.Last();
            }

            return temp.TopCoord + helpMenuRows;
        }
    }
}
