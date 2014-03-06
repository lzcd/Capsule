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
            var result = root.Evaluate(context);
            return result.ToString();
        }
    }
}
