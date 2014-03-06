using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    class Lambda : INode, IApplyable
    {

        public INode Evaluate(Context context)
        {
            return this;
        }

        private bool isRecording = true;
        private Nodes parameterNames;
        private INode behaviour;
        private Context definitionContext;

        public INode Apply(Context context, params INode[] parameters)
        {
            if (isRecording)
            {
                var parameterNames = parameters.First() as Nodes;
                if (parameterNames == null)
                {
                    return new Error("Unexpected parameter names, " + parameters.First() + ", in lambda definition");
                }
                var behaviour = parameters.Skip(1).First();
                var error = default(Error);
                if (!TryRecord(context, parameterNames, behaviour, out error))
                {
                    return error;
                }
                return this;
            }

            var result = Playback(context, parameters);
            return result;
        }

        private INode Playback(Context context, INode[] parameters)
        {
            if (parameters.Length != parameterNames.Count)
            {
                return new Error("Unexpected number of parameters, " + parameters.Length + ", passed to lambda definition with " + parameterNames.Count + " arguments");
            }

            var childContext = new Context(definitionContext);
            for (var parameterIndex = 0; parameterIndex < parameters.Length; parameterIndex++)
            {
                var parameterName = parameterNames[parameterIndex] as Symbol;
                if (parameterName == null)
                {
                    return new Error("Unexpected lack of parameter name, " + parameterNames[parameterIndex] + ", in lambda call");
                }
                var parameterValue = parameters[parameterIndex];
                childContext.Fallback = context;
                var evaluatedParameterValue = parameterValue.Evaluate(childContext);
                childContext[parameterName.Name] = evaluatedParameterValue;
            }

            var evaluatedBehaviour = behaviour.Evaluate(childContext);

            return evaluatedBehaviour;
        }

        public bool TryRecord(Context context, Nodes parameterNames, INode behaviour, out Error error)
        {
            error = null;

            this.parameterNames = parameterNames;
            this.behaviour = behaviour;
            definitionContext = context.Clone();
            isRecording = false;

            return true;
        }
    }
}
