using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    public class Host
    {
        public string Evaluate(string source)
        {
            var parser = new Parser();
            var words = parser.ToWords(source);
            var root = parser.ToNodes(words);

            var result = new StringBuilder();
            var addSpacing = false;
            foreach (var node in root)
            {
                if (addSpacing)
                {
                    result.Append(" ");
                }
                else
                {
                    addSpacing = true;
                }
                result.Append(node.Evaluate());
            }

            return result.ToString();
        }
    }
}
