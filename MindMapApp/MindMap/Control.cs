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
                || map.Current.Coordinates.left + nodeText.Length > map.WindowSize.width)
            {
                return;
            }

            ChangeFirstNodeWhenMaxNodesNumberIsReached();
            Node newNode = new Node(nodeText);
            newNode.Parent = map.Current;
            map.Current.Childs.Add(newNode);
            newNode.Siblings = map.Current.Childs;
            map.Current = newNode;
            PageDownIfCurrentNodeIsNotVisible();
        }

        public void Enter(string nodeText = "new node")
        {
            if (map.Current == map.CentralNode)
            {
                return;
            }

            ChangeFirstNodeWhenMaxNodesNumberIsReached();
            Node newNode = new Node(nodeText);
            newNode.Parent = map.Current.Parent;
            map.Current.Parent.Childs.Add(newNode);
            newNode.Siblings = map.Current.Parent.Childs;
            map.Current = newNode;
            PageDownIfCurrentNodeIsNotVisible();
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
            else if (map.Current == map.FirstNode)
            {
                map.FirstNode = GetNodeAbove(map.FirstNode);
            }

            var index = map.Current.Siblings.IndexOf(map.Current);
            if (index != 0 && map.Current.Siblings[index - 1].Childs.Count > 0)
            {
                map.Current = GetNodeAbove(map.Current);
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
            if (map.Current.Coordinates.top
                == map.FirstNode.Coordinates.top + map.WindowSize.height - 16
                && map.Current != GetLastNode())
            {
                ChangeFirstNodeToNodeBelow();
            }

            if (map.Current.Childs.Count > 0 && !map.Current.Collapsed)
            {
                map.Current = map.Current.Childs.First();
            }
            else
            {
                map.Current = GetNodeBelow(map.Current);
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
                map.FirstNode = map.Current.Coordinates.top < map.FirstNode.Coordinates.top
                    ? map.Current
                    : map.FirstNode;
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
            map.Current.Text = map.Current.Coordinates.left + 1 < map.WindowSize.width
                && character > low && character < high
                        ? map.Current.Text + character
                        : map.Current.Text;
        }

        private void ChangeFirstNodeToNodeBelow()
        {
            if (map.FirstNode == map.CentralNode
                || map.FirstNode != map.FirstNode.Siblings.Last()
                || map.FirstNode.Childs.Count > 0)
            {
                map.FirstNode = map.FirstNode.Childs.Count > 0
                   ? map.FirstNode.Childs.First()
                   : map.FirstNode.Siblings[map.FirstNode.Siblings.IndexOf(map.FirstNode) + 1];
            }
            else
            {
                map.FirstNode = GetNodeBelow(map.FirstNode);
            }
        }

        private void ChangeFirstNodeWhenMaxNodesNumberIsReached()
        {
            if (map.DisplayedNodesCount == 0 || map.DisplayedNodesCount < map.MaxNodesNumber)
            {
                return;
            }

            ChangeFirstNodeToNodeBelow();
            map.DisplayedNodesCount--;
        }

        private void PageDownIfCurrentNodeIsNotVisible()
        {
            var nodeAbove = GetNodeAbove(map.Current);
            if (nodeAbove.Coordinates.top + 2
                <= map.FirstNode.Coordinates.top + map.WindowSize.height - 16)
            {
                return;
            }

            while (nodeAbove.Coordinates.top + 2
                > map.FirstNode.Coordinates.top + (map.WindowSize.height - 16))
            {
                ChangeFirstNodeToNodeBelow();
            }
        }

        private Node GetNodeAbove(Node node)
        {
            var index = map.Current.Siblings.IndexOf(map.Current);
            var temp = index == 0 ? node.Parent : node.Siblings[index - 1];
            if (index != 0 && map.Current.Siblings[index - 1].Childs.Count > 0)
            {
                while (temp.Childs.Count != 0 && !temp.Collapsed)
                {
                    temp = temp.Childs.Last();
                }
            }

            return temp;
        }

        private Node GetNodeBelow(Node node)
        {
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

        private Node GetLastNode()
        {
            var temp = map.CentralNode.Childs.Last();
            if (temp.Childs.Count == 0)
            {
                return temp;
            }

            while (temp.Childs.Count > 0)
            {
                temp = temp.Childs.Last();
            }

            return temp;
        }
    }
}