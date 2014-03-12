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
            if (Value)
            {
                return trueText;
            }

            return falseText;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Flag;
            if (other == null)
            {
                return false;
            }

            if (other.Value != Value)
            {
                return false;
            }

            return true;
        }

        private static string trueText = "true";
        private static string falseText = "false";

        private static Flag trueFlag = new Flag(true);
        private static Flag falseFlag = new Flag(false);

        public static bool TryParse(string text, out Flag flag)
        {
            if (trueText.Equals(text, StringComparison.InvariantCultureIgnoreCase))
            {
                flag = trueFlag;
                return true;
            }

            if (falseText.Equals(text, StringComparison.InvariantCultureIgnoreCase))
            {
                flag = falseFlag;
                return true;
            }

            flag = null;
            return false;
        }
    }
}
