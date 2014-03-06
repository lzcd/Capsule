using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    public class Host
    {
        private Context context;

        public Host()
        {
            context = new Context(null);
        }

        public string Evaluate(string source)
        {
            var parser = new Parser();
            var words = parser.ToWords(source);
            var root = parser.ToNodes(words);

            var resultDescription = new StringBuilder();
            var addSpacing = false;
            foreach (var node in root)
            {
                var result = node.Evaluate(context);
                if (result == null)
                {
                    continue;
                }

                if (addSpacing)
                {
                    resultDescription.Append(" ");
                }
                else
                {
                    addSpacing = true;
                }
                resultDescription.Append(result.ToString());
                if (result is Error)
                {
                    break;
                }
            }

            return resultDescription.ToString();
        }
    }
}
