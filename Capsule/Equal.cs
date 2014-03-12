using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    class Equal : INode, IApplyable
    {
        public INode Evaluate(Context context)
        {
            return this;
        }

        public INode Apply(Context context, params INode[] parameters)
        {
            if (parameters.Length < 2)
            {
                return new Error("Unexpected number, " + parameters.Length + ", of parameters for equality testing");
            }
            var firstParameter = default(INode);
            var firstParamaterHasValue = false;
            foreach (var parameter in parameters)
            {
                var evaluatedParameter = parameter.Evaluate(context);
                if (!firstParamaterHasValue)
                {
                    firstParameter = evaluatedParameter;
                    firstParamaterHasValue = true;
                    continue;
                }

                if (!firstParameter.Equals(evaluatedParameter))
                {
                    return new Flag(false);
                }
            }
            return new Flag(true);            
        }
    }
}
