using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestintBeadandov3.NemLopott
{
    internal class DepthFirstHorseFeast : HorseFeastGraphSearch
    {
        private Stack<NemLopottNode> openNodes;
        private List<NemLopottNode> closedNodes;
        private bool circleDetection;

        public DepthFirstHorseFeast(bool circleDetection)
        {
            this.openNodes = new Stack<NemLopottNode>();
            this.openNodes.Push(this.startNode);
            this.closedNodes = new List<NemLopottNode>();
            this.circleDetection = circleDetection;
        }

        public DepthFirstHorseFeast() : this(true) { }

        public override NemLopottNode Search()
        {
            if (circleDetection)
                return SearchTerminalNodeWithCircleDetection();
            return SearchTerminalNodeWithoutCircleDetection();
        }

        private NemLopottNode SearchTerminalNodeWithCircleDetection()
        {
            while (openNodes.Count != 0)
            {
                NemLopottNode actual = openNodes.Pop();
                List<NemLopottNode> children = actual.GetAllChildren();
                foreach (NemLopottNode child in children)
                {
                    if (child.IsTerminalNode)
                        return child;

                    if (!closedNodes.Contains(child) && !openNodes.Contains(child))
                        openNodes.Push(child);
                }
                closedNodes.Add(actual);
            }
            return null;
        }

        private NemLopottNode SearchTerminalNodeWithoutCircleDetection()
        {
            while (openNodes.Count != 0)
            {
                NemLopottNode actual = openNodes.Pop();
                List<NemLopottNode> children = actual.GetAllChildren();
                foreach (NemLopottNode child in children)
                {
                    if (child.IsTerminalNode)
                        return child;
                    openNodes.Push(child);
                }
            }
            return null;
        }
    }



}
