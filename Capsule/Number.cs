using System;
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
    }
}
