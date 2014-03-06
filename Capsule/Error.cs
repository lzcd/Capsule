using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    class Error : INode
    {
        private string message;

        public Error(string message)
        {
            this.message = message;
        }

        public INode Evaluate(Context context)
        {
            return this;
        }

        public override string ToString()
        {
            return message;
        }
    }
}
