using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    class Add : INode, IApplyable
    {
        public INode Evaluate()
        {
            return this;
        }

        public INode Apply(params INode[] parameters)
        {
            var tally = 0M;
            foreach (var parameter in parameters)
            {
                var evaluatedParameter = parameter.Evaluate();
                var number = evaluatedParameter as Number;
                if (number == null)
                {
                    return new Error();
                }
                tally += number.Value;
            }
            return new Number(tally);
        }
    }
}
