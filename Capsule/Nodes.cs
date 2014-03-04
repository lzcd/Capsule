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

        public Nodes(params INode[] nodes)
        {
            this.nodes = nodes;
        }

        public INode Evaluate()
        {
            return null;    
        }
    }
}
