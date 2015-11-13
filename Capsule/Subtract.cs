using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    class Subtract : INode, IApplyable
    {
        public INode Evaluate(Context context)
        {
            return this;
        }

        public INode Apply(Context context, params INode[] parameters)
        {
            if (!parameters.Any())
            {
                return new Error("Nothing to subtract");
            }
            var evaluatedFirstParameter = parameters.First().Evaluate(context);
            var firstNumber = evaluatedFirstParameter as Number;
            if (firstNumber == null)
            {
                return new Error("Unexpected lack of number, " + evaluatedFirstParameter + ", in subtraction");
            }

            if (parameters.Length == 1)
            {
                return new Number(-firstNumber.Value);
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
                tally -= number.Value;
            }
            return new Number(tally);
        }
    }
}
