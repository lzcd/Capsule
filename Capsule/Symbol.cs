using System;
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
                case "=":
                    return new Equal();
                case "+":
                    return new Add();
                case "-":
                    return new Subtract();
                case "*":
                    return new Multiply();
                case "if":
                    return new If();
                case "lambda":
                    return new Lambda();
                case "define":
                    return new Define();
            }

            var flag = default(Flag);
            if (Flag.TryParse(Name, out flag))
            {
                return flag;
            }

            var number = default(Number);
            if (Number.TryParse(Name, out number))
            {
                return number;
            }

            return new Error("Unable to determine value of " + Name);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
