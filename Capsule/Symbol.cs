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

        public INode Evaluate()
        {
            if (Name == "+")
            {
                return new Add();
            }

            return new Number(decimal.Parse(Name));
        }
    }
}
