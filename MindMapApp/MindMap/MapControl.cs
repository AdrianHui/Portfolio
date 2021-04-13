using System;
using System.Collections.Generic;
using System.Linq;

namespace MindMap
{
    class MapControl : IControl
    {
        private readonly Map map;

        public MapControl(Map map)
        {
            this.map = map;
        }

        public void Insert()
        {
            if (map.Current.Collapsed)
            {
                return;
            }

            Node newNode = new Node("new node");
            newNode.Parent = map.Current;
            map.Current.Childs.Add(newNode);
            newNode.Siblings = map.Current.Childs;
            map.Current = newNode;
            var nodeAbove = map.GetNodeAbove(map.Current);
            map.Current.Coordinates = (nodeAbove.Coordinates.left + 3,
                nodeAbove.Coordinates.top + 2);
            map.CurrentView.MoveDown();
            map.CurrentView.MoveRight();
        }

        public void Enter()
        {
            if (map.Current == map.CentralNode)
            {
                return;
            }

            Node newNode = new Node("new node");
            newNode.Parent = map.Current.Parent;
            map.Current.Parent.Childs.Add(newNode);
            newNode.Siblings = map.Current.Parent.Childs;
            map.Current = newNode;
            var nodeAbove = map.GetNodeAbove(map.Current);
            map.Current.Coordinates = (map.Current.Parent.Coordinates.left + 3,
                nodeAbove.Coordinates.top + 2);
            map.CurrentView.MoveDown();
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
                map.Current = map.GetNodeAbove(map.Current);
            }
            else
            {
                map.Current = index == 0
                ? map.Current.Parent
                : map.Current.Parent.Childs[index - 1];
            }

            map.CurrentView.MoveUp();
            map.CurrentView.MoveRight();
            map.CurrentView.MoveLeft();
        }

        public void DownArrow()
        {
            if (map.Current.Childs.Count > 0 && !map.Current.Collapsed)
            {
                map.Current = map.Current.Childs.First();
            }
            else
            {
                map.Current = GetNodeBelow(map.Current);
            }

            map.CurrentView.MoveDown();
            map.CurrentView.MoveRight();
            map.CurrentView.MoveLeft();
        }

        public void RightArrow()
        {
            if (map.Current.Collapsed)
            {
                map.Current.Collapsed = false;
                return;
            }

            map.Current = map.Current.Childs.Count > 0
                ? map.Current.Childs.First()
                : map.Current;
            map.CurrentView.MoveDown();
            map.CurrentView.MoveRight();
        }

        public void LeftArrow()
        {
            if (!map.Current.Collapsed && map.Current.Childs.Count != 0)
            {
                map.Current.Collapsed = true;
                return;
            }

            map.Current = map.Current.Parent ?? map.Current;
            map.CurrentView.MoveUp();
            map.CurrentView.MoveLeft();
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

        public void ChangeText(char character)
        {
            const int low = 31;
            const int high = 127;
            if ((map.Current.Coordinates.left - map.CurrentView.Left)
                + map.CurrentView.Window.Width / 4 + 3 + map.Current.Text.Length + 1
                >= map.CurrentView.Window.Width - 1)
            {
                map.CurrentView.Left++;
            }

            map.Current.Text = character > low && character < high
                        ? map.Current.Text + character
                        : map.Current.Text;
        }

        private Node GetNodeBelow(Node node)
        {
            if (node == map.CentralNode && node.Childs.Count == 0)
            {
                return node;
            }

            while (node == node.Siblings.Last()
                && node != map.CentralNode.Childs.Last())
            {
                node = node.Parent;
            }

            if (node.Childs.Count > 0 && node == node.Siblings.Last())
            {
                return map.Current;
            }

            return node == node.Siblings.Last()
                ? node
                : node.Siblings[node.Siblings.IndexOf(node) + 1];
        }
    }
}