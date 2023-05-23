using AICore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Principal;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace mestintBeadandov3.NemLopott
{
    internal class NemLopottNode
    {
        private HorseFeastState state;
        private int depth;
        private NemLopottNode parent;

        public NemLopottNode()
        {
            this.state = new HorseFeastState();
            this.depth = 0;
            this.parent = null;
        }

        public NemLopottNode(NemLopottNode parent)
        {
            this.state = (HorseFeastState)parent.state.Clone();
            this.depth = parent.depth + 1;
            this.parent = parent;
        }

        public NemLopottNode Parent { get { return parent; } }
        public HorseFeastState State { get { return this.state; } }
        public int Depth { get { return depth; } }
        public bool IsTerminalNode { get { return state.IsGoalState(); } }

        public List<NemLopottNode> GetAllChildren()
        {
            List<NemLopottNode> children = new List<NemLopottNode>();

            for (int fromX = 0; fromX < 3; fromX++)
            {
                for (int fromY = 0; fromY < 3; fromY++)
                {
                    for (int toX = 0; toX < 3; toX++)
                    {
                        for (int toY = 0; toY < 3; toY++)
                        {
                            if (state.IsOperator(fromX, fromY, toX, toY))
                            {
                                NemLopottNode childNode = new NemLopottNode(parent: this);
                                if (childNode.state.ApplyOperator(fromX, fromY, toX, toY))
                                {
                                    children.Add(childNode);
                                }
                            }
                        }
                    }
                }
            }

            return children;
        }

        public override string ToString()
        {
            return $"Depth: {depth}\n{state}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            NemLopottNode other = (NemLopottNode)obj;
            return state.Equals(other.state);
        }

        public override int GetHashCode()
        {
            return state.GetHashCode();
        }
    }


}

