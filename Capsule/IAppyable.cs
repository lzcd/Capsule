using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    interface IAppyable
    {
        INode Apply(params INode[] parameters);
    }
}
