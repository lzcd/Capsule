using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    public class Host
    {
        public void Evaluate(string source)
        {
            var parser = new Parser();
            var words = parser.ToWords(source);
            var root = parser.ToNodes(words);

            root.Evaluate();
        }

       

    }
}
