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

                Error error;
                if (!TryRecord(parameters, out error))
                {
                    return error;
                }

                isRecording = false;
                return this;
            }

            var result = Playback(parameters);
            return result;
        }

        private INode Playback(INode[] parameters)
        {
            if (parameters.Length != parameterNames.Count)
            {
                return new Error();
            }

            for (var parameterIndex = 0; parameterIndex < parameters.Length; parameterIndex++)
            {
                var parameterName = parameterNames[parameterIndex];
                var parameterValue = parameters[parameterIndex];
            }

            var evaluatedBehaviour = behaviour.Evaluate();

            return evaluatedBehaviour;
        }

        private bool TryRecord(INode[] parameters, out Error error)
        {
            error = null;
          
            parameterNames = parameters.First() as Nodes;
            if (parameterNames == null)
            {
                error = new Error();
                return false;
            }

            behaviour = parameters.Skip(1).First();
            return true;
        }
    }
}
