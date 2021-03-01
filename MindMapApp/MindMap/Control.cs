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
            if (map.Current.Collapsed
                || map.Current.LeftCoord + nodeText.Length > Console.WindowWidth)
            {
                return;
            }
            else if (map.Current.Childs.Count > 0)
            {
                newNode.Siblings = map.Current.Childs;
            }

            newNode.Parent = map.Current;
            map.Current.Childs.Add(newNode);
            newNode.Siblings = map.Current.Childs;
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
                while (map.Current == map.Current.Siblings.Last()
                    && map.Current != map.CentralNode.Childs.Last())
                {
                    map.Current = map.Current.Parent;
                }

                map.Current = map.Current == map.CentralNode.Childs.Last()
                    ? map.Current
                    : map.Current.Siblings[map.Current.Siblings.IndexOf(map.Current) + 1];
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
    }
}
