﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    class Number : INode
    {
        public decimal Value { get; private set; }

        public Number(decimal value)
        {
            Value = value;
        }

        public INode Evaluate(Context context)
        {
            return this;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static bool TryParse(string text, out Number number)
        {
            var numericalValue = default(decimal);
            if (decimal.TryParse(text, out numericalValue))
            {
                number = new Number(numericalValue);
                return true;
            }

            number = null;
            return false;
        }
    }
}
