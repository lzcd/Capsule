using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    class Lambda : INode, IApplyable
    {
        public Lambda()
        {

        }

        public Lambda(Nodes parameterNames, INode behaviour)
        {
            this.parameterNames = parameterNames;
            this.behaviour = behaviour;
            isRecording = false;
        }

        public INode Evaluate(Context context)
        {
            return this;
        }

        private bool isRecording = true;
        private Nodes parameterNames;
        private INode behaviour;

        public INode Apply(Context context, params INode[] parameters)
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

            var result = Playback(context, parameters);
            return result;
        }

        private INode Playback(Context context, INode[] parameters)
        {
            if (parameters.Length != parameterNames.Count)
            {
                return new Error();
            }

            var childContext = new Context(context);
            for (var parameterIndex = 0; parameterIndex < parameters.Length; parameterIndex++)
            {
                var parameterName = parameterNames[parameterIndex] as Symbol;
                if (parameterName == null)
                {
                    return new Error();
                }
                var parameterValue = parameters[parameterIndex];
                var evaluatedParameterValue = parameterValue.Evaluate(context);
                childContext[parameterName.Name] = evaluatedParameterValue;
            }

            var evaluatedBehaviour = behaviour.Evaluate(childContext);

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
