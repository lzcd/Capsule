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

        public INode Evaluate()
        {
            switch (Name)
            {
                case "+":
                    return new Add();
                case "lambda":
                    return new Lambda();
            }

            return new Number(decimal.Parse(Name));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
