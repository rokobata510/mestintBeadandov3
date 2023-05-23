using AICore;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestintBeadandov3.NemLopott
{
    internal class BacktrackHorseFeast : HorseFeastGraphSearch
    {
        private int maxDepth;
        private bool isMemorable;

        public BacktrackHorseFeast(int maxDepth, bool isMemorable)
        {
            this.maxDepth = maxDepth;
            this.isMemorable = isMemorable;
        }
        public BacktrackHorseFeast() : this(0, false) { }
        public BacktrackHorseFeast(int maxDepth) : this(maxDepth, false) { }
        public BacktrackHorseFeast(bool isMemorable) : this(0, isMemorable) { }

        public override NemLopottNode Search()
        {
            return Search(startNode);
        }

        private NemLopottNode Search(NemLopottNode actualNode)
        {
            int actualDepth = actualNode.Depth;

            //Check if we reached the maximum depth
            if (maxDepth != 0 && actualDepth >= maxDepth)
                return null;

            //Check if we already checked the same node
            NemLopottNode actualParent = null;
            if (isMemorable)
                actualParent = actualNode.Parent;
            while (actualParent != null)
            {
                if (actualNode.Equals(actualParent))
                    return null;
                actualParent = actualParent.Parent;
            }

            //Check if the actual node is a terminal node
            if (actualNode.IsTerminalNode)
                return actualNode;

            //Select a new node
            for (int fromX = 0; fromX < 3; fromX++)
            {
                
                for (int fromY = 0; fromY < 3; fromY++)
                {
                    for (int toX = 0; toX < 3; toX++)
                    {
                        for (int toY = 0; toY < 3; toY++)
                        {

                            NemLopottNode newNode = new NemLopottNode(actualNode);
                            if (newNode.State.ApplyOperator(fromX, fromY, toX, toY))
                            {
                                foreach (NemLopottNode node in newNode.GetAllChildren())
                                {
                                    bool contains = false;

                                    if (node.Equals(newNode))
                                    {
                                        contains = true;
                                    }
                                    if (!contains)
                                    {
                                        NemLopottNode terminalNode = Search(newNode);
                                        if (terminalNode != null)
                                            return terminalNode;
                                    }
                                }
                                
                            }
                        }
                    }
                }
            }

            return null; //There is no solution of the problem

        }
    }
}
