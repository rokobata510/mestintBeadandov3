using AICore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mestintBeadandov3.NemLopott
{
    internal abstract class HorseFeastGraphSearch
    {
        protected NemLopottNode startNode;

        public HorseFeastGraphSearch()
        {
            startNode = new NemLopottNode();
        }

        public abstract NemLopottNode Search();

        public void PrintSolution(NemLopottNode terminalNode)
        {
            if (terminalNode == null)
            {
                Console.WriteLine("There is no solution for this problem.");
                return;
            }

            Stack<NemLopottNode> solution = new Stack<NemLopottNode>();
            NemLopottNode node = terminalNode;
            while (node != null)
            {
                solution.Push(node);
                node = node.Parent;
            }

            foreach (NemLopottNode n in solution)
            {
                Console.WriteLine(n);
            }
        }

        public Stack<NemLopottNode> GetSolution(NemLopottNode terminalNode)
        {
            if (terminalNode == null)
            {
                Console.WriteLine("There is no solution for this problem.");
                return null;
            }

            Stack<NemLopottNode> solution = new Stack<NemLopottNode>();
            NemLopottNode node = terminalNode;
            while (node != null)
            {
                solution.Push(node);
                node = node.Parent;
            }

            return solution;
        }
    }
}

