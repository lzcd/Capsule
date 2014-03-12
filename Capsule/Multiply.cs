﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    class Multiply : INode, IApplyable
    {
        public INode Evaluate(Context context)
        {
            return this;
        }

        public INode Apply(Context context, params INode[] parameters)
        {
            if (!parameters.Any())
            {
                return new Error("Nothing to multiply");
            }
            var tally = 1M;
            foreach (var parameter in parameters)
            {
                var evaluatedParameter = parameter.Evaluate(context);
                var number = evaluatedParameter as Number;
                if (number == null)
                {
                    return new Error("Unexpected lack of number, " + evaluatedParameter + ", in multiplication");
                }
                tally *= number.Value;
            }
            return new Number(tally);
        }
    }
}
