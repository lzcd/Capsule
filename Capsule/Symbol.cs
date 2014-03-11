﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    class Symbol : INode
    {
        public string Name { get; private set; }

        public Symbol(string name)
        {
            Name = name;
        }

        public INode Evaluate(Context context)
        {
            INode value;
            if (context.TryGetValue(Name, out value))
            {
                if (value is Symbol)
                {
                    return value.Evaluate(context);
                }
                return value;
            }
            switch (Name)
            {
                case "+":
                    return new Add();
                case "*":
                    return new Multiply();
                case "lambda":
                    return new Lambda();
                case "define":
                    return new Define();
            }

            var numericalValue = default(decimal);
            if (decimal.TryParse(Name, out numericalValue))
            {
                return new Number(numericalValue);
            }

            return new Error("Unable to determine value of " + Name);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
