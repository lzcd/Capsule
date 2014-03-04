using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    interface IApplicable
    {
        INode Apply(params INode[] paramaters);
    }
}
