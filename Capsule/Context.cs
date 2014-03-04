using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    class Context
    {
        private Context parent;

        public Context(Context parent)
        {
            this.parent = parent;
        }

        private Dictionary<string, INode> nodeByName;

        public bool TryGetValue(string key, out INode value)
        {
            if (nodeByName != null &&
                nodeByName.TryGetValue(key, out value))
            {
                return true;
            }
            if (parent != null &&
                parent.TryGetValue(key, out value))
            {
                return true;
            }
            value = null;
            return false;
        }

        public INode this[string key]
        {
            get
            {
                INode value;
                if (TryGetValue(key, out value))
                {
                    return value;
                }
                return null;
            }
            set
            {
                if (nodeByName == null)
                {
                    nodeByName = new Dictionary<string, INode>();
                }
                nodeByName.Add(key, value);
            }
        }
    }
}
