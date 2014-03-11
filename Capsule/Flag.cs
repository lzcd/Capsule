using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    class Flag : INode
    {
        public bool Value { get; private set; }

        public Flag(bool value)
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


        public static bool TryParse(string text, out Flag flag)
        {
            var flagValue = default(bool);
            if (bool.TryParse(text, out flagValue))
            {
                flag = new Flag(flagValue);
                return true;
            }

            flag = null;
            return false;
        }
    }
}
