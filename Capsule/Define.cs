using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    class Define: INode, IApplyable
    {
        public INode Apply(Context context, params INode[] parameters)
        {
            if (parameters.Length != 2)
            {
                return new Error();
            }
            var parameterName = parameters.First() as Symbol;
            if (parameterName == null)
            {
                return new Error();
            }
            var parameterValue = parameters.Skip(1).First();
            context.Parent[parameterName.Name] = parameterValue;

            return null;
        }

        public INode Evaluate(Context context)
        {
            return this;
        }
    }
}
