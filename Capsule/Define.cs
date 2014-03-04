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
            var parameterValue = parameters.Skip(1).First();

            var simpleName = parameters.First() as Symbol;
            if (simpleName != null)
            {
                context.Parent[simpleName.Name] = parameterValue;
                return null;
            }

            var complexNameContainer = parameters.First() as Nodes;
            if (complexNameContainer == null)
            {
                return new Error();
            }
            var complexName = complexNameContainer.First as Symbol;
            if (complexName == null)
            {
                return new Error();
            }

            var lambda = new Lambda(new Nodes(complexNameContainer.Rest), parameterValue);
            context.Parent[complexName.Name] = lambda;
            return null;
        }

        public INode Evaluate(Context context)
        {
            return this;
        }
    }
}
