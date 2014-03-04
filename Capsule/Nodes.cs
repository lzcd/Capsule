using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    class Nodes : INode
    {
        private INode[] nodes;
        private INode first;
        private INode[] rest;

        public Nodes(params INode[] nodes)
        {
            this.nodes = nodes;
            first = nodes.FirstOrDefault();
            if (nodes.Length > 1)
            {
                rest = nodes.Skip(1).ToArray();
            }
            else
            {
                rest = new INode[] { };
            }
        }

        public INode Evaluate()
        {
            if (first == null)
            {
                return this;
            }

            var evaluatedFirst = first.Evaluate();

            var applicable = evaluatedFirst as IApplyable;
            if (applicable == null)
            {
                return this;
            }

            var result = applicable.Apply(rest);

            return result;
        }

        public override string ToString()
        {
            var description = new StringBuilder();
            description.Append("(");
            var addSpacing = false;
            foreach (var node in nodes)
            {
                if (addSpacing)
                {
                    description.Append(" ");
                }
                else
                {
                    addSpacing = true;
                }
                description.Append(node.ToString());
            }
            description.Append(")");
            return description.ToString();
        }
    }
}
