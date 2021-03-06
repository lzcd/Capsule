﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capsule
{
    class Define : INode, IApplyable
    {
        public INode Apply(Context context, params INode[] parameters)
        {
            if (!parameters.Any())
            {
                return new Error("Unable to define nothing");
            }
            if (parameters.Length == 1)
            {
                return new Error("Unable to define " + parameters.First() + " with no definition");
            }
            var behaviourNodes = parameters.Skip(1).ToArray();
            var behaviour = default(INode);
            if (behaviourNodes.Length == 1)
            {
                behaviour = behaviourNodes.First();
            }
            else
            {
                behaviour = new Nodes(true, behaviourNodes.ToArray());
            }

            var simpleName = parameters.First() as Symbol;
            if (simpleName != null)
            {
                context.Parent[simpleName.Name] = behaviour;
                return null;
            }

            var complexNameContainer = parameters.First() as Nodes;
            if (complexNameContainer == null)
            {
                return new Error("Unexpected lack of list in define defininition");
            }
            var complexName = complexNameContainer.First as Symbol;
            if (complexName == null)
            {
                return new Error("Unexpected lack of name in define definition");
            }

            var lambda = new Lambda();
            var error = default(Error);
            if (!lambda.TryRecord(context, new Nodes(false, complexNameContainer.Rest), behaviour, out error))
            {
                return error;
            }
            context.Parent[complexName.Name] = lambda;
            return null;
        }

        public INode Evaluate(Context context)
        {
            return this;
        }
    }
}
