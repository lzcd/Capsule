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
        private bool evaluateAllUponNoOperator;

        public Nodes(bool evaluateAllUponNoOperator, params INode[] nodes)
        {
            this.evaluateAllUponNoOperator = evaluateAllUponNoOperator;
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
                if (!evaluateAllUponNoOperator)
                {
                    return this;
                }

                var results = new List<INode>();
                if (evaluatedFirst != null)
                {
                    results.Add(evaluatedFirst);
                }
                foreach (var node in nodes.Skip(1))
                {
                    var evaluatedNode = node.Evaluate(childContext);
                    if (evaluatedNode != null)
                    {
                        results.Add(evaluatedNode);
                    }
                }
                return new Nodes(false, results.ToArray());
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
