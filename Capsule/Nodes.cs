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
        public INode First { get; private set; }
        public INode[] Rest { get; private set; }

        public Nodes(params INode[] nodes)
        {
            this.nodes = nodes;
            First = nodes.FirstOrDefault();
            if (nodes.Length > 1)
            {
                Rest = nodes.Skip(1).ToArray();
            }
            else
            {
                Rest = new INode[] { };
            }
        }

        public INode Evaluate(Context context)
        {
            if (First == null)
            {
                return this;
            }

            var childContext = new Context(context);
            var evaluatedFirst = First.Evaluate(childContext);

            var applicable = evaluatedFirst as IApplyable;
            if (applicable == null)
            {
                return this;
            }

            var result = applicable.Apply(childContext, Rest);

            return result;
        }

        public INode this[int index]
        {
            get
            {
                return nodes[index];
            }
        }

        public System.Collections.Generic.IEnumerator<INode> GetEnumerator()
        {
            foreach (var node in nodes)
            {
                yield return node;
            }
        }

        public int Count
        {
            get
            {
                return nodes.Length;
            }
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
