using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    class Parser
    {
        public Nodes ToNodes(List<string> words)
        {
            var stack = new Stack<List<INode>>();
            var root = new List<INode>();
            stack.Push(root);
            var currentList = root;
            foreach (var word in words)
            {

                switch (word)
                {
                    case "(":
                        stack.Push(new List<INode>());
                        break;
                    case ")":
                        var nodeList = stack.Pop();
                        var nodes = new Nodes(false, nodeList.ToArray());
                        stack.Peek().Add(nodes);
                        break;
                    default:
                        var symbol = new Symbol(word);
                        stack.Peek().Add(symbol);
                        break;
                }
            }
            return new Nodes(true, root.ToArray());
        }

        public List<string> ToWords(string text)
        {
            var words = new List<string>();
            var word = new StringBuilder();
            foreach (var c in text)
            {
                switch (c)
                {
                    case ' ':
                    case '\t':
                    case '\n':
                    case '\r':
                        Add(word, words);
                        break;
                    case '(':
                    case ')':
                        Add(word, words);
                        Add(c.ToString(), words);
                        break;
                    default:
                        Add(c, word);
                        break;
                }
            }
            Add(word, words);

            return words;
        }

        private static void Add(char c, StringBuilder word)
        {
            word.Append(c);
        }

        private static void Add(StringBuilder word, List<string> words)
        {
            if (word.Length > 0)
            {
                words.Add(word.ToString());
                word.Clear();
            }
        }

        private static void Add(string word, List<string> words)
        {
            words.Add(word);
        }
    }
}
