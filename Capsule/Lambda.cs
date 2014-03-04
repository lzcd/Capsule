using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    class Lambda : INode, IApplyable
    {
        public INode Evaluate()
        {
            return this;
        }

        private bool isRecording = true;
        private Nodes parameterNames;
        private INode behaviour;

        public INode Apply(params INode[] parameters)
        {
            if (isRecording)
            {
                if (parameters.Count() != 2)
                {
                    return new Error();
                }

                Record(parameters);

                isRecording = false;
                return this;
            }

            var result = Playback(parameters);
            return result;
        }

        private INode Playback(INode[] parameters)
        {
            throw new NotImplementedException();
        }

        private void Record(INode[] parameters)
        {
            parameterNames = parameters.First() as Nodes;
            behaviour = parameters.Skip(1).First();
        }
    }
}
