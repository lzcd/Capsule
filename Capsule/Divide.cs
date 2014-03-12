using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    class Divide : INode, IApplyable
    {
        public INode Evaluate(Context context)
        {
            return this;
        }

        public INode Apply(Context context, params INode[] parameters)
        {
            if (!parameters.Any())
            {
                return new Error("Nothing to divide");
            }
            var evaluatedFirstParameter = parameters.First().Evaluate(context);
            var firstNumber = evaluatedFirstParameter as Number;
            if (firstNumber == null)
            {
                return new Error("Unexpected lack of number, " + evaluatedFirstParameter + ", in division");
            }

            var tally = firstNumber.Value;
            foreach (var parameter in parameters.Skip(1))
            {
                var evaluatedParameter = parameter.Evaluate(context);
                var number = evaluatedParameter as Number;
                if (number == null)
                {
                    return new Error("Unexpected lack of number, " + evaluatedParameter + ", in subtraction");
                }
                if (number.Value == 0)
                {
                    return new Error("Unable to divide by zero");
                }
                tally /= number.Value;
            }
            return new Number(tally);
        }
    }
}
