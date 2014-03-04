using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    class Error : INode
    {
        public INode Evaluate()
        {
            return this;
        }
    }
}
