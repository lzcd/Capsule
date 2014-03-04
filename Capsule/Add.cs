using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    class Add : INode, IAppyable
    {
        public INode Evaluate()
        {
            return this;
        }

        public INode Apply(params INode[] parameters)
        {
            return new Number(42);
        }
    }
}
