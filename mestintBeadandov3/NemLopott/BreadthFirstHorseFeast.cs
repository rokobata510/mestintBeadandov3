using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestintBeadandov3.NemLopott
{
    internal class BreadthFirstHorseFeast : HorseFeastGraphSearch
    {
        public BreadthFirstHorseFeast() : base()
        {
        }
        public NemLopottNode? StartNode { get; set; }
        public override NemLopottNode? Search()
        {
            //breadth first graph search algorithm
            Queue<NemLopottNode> open = new Queue<NemLopottNode>();
            HashSet<NemLopottNode> closed = new HashSet<NemLopottNode>();
            open.Enqueue(StartNode);
            while (open.Count > 0)
            {
                NemLopottNode current = open.Dequeue();
                if (current.IsTerminalNode)
                {
                    return current;
                }
                closed.Add(current);
                foreach (NemLopottNode child in current.GetAllChildren())
                {
                    if (!closed.Contains(child))
                    {
                        open.Enqueue(child);
                    }
                }
            }
            return null;


        }


    }
}
