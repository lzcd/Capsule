using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    class If : INode, IApplyable
    {
        public INode Evaluate(Context context)
        {
            return this;
        }

        public INode Apply(Context context, params INode[] parameters)
        {
            switch (parameters.Length)
            {
                case 0:
                    return new Error("Missing criteria for if condition");
                case 1:
                    return new Error("Missing positive action for if condition");
                case 2:
                case 3:
                    break;
                default:
                    return new Error("Unexpected additional parameters for if condition");
            }
           
            var evaluatedCritera = parameters[0].Evaluate(context);
            if (evaluatedCritera is Error)
            {
                return evaluatedCritera;
            }
            var evaluatedFlag = evaluatedCritera as Flag;
            if (evaluatedFlag == null)
            {
                return new Error("Unexpected criteria, " + evaluatedCritera + ", for if condition"); 
            }

            if (evaluatedFlag.Value)
            {
                var positiveResult = parameters[1].Evaluate(context);
                return positiveResult;
            }

            if (parameters.Length == 3)
            {
                var negativeResult = parameters[2].Evaluate(context);
                return negativeResult;
            }
                        
            return null;
        }
    }
}
