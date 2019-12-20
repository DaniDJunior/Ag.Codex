using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Ag.Codex.Blocks.Variables
{
    public class ConstantGet : IBlock
    {
        public override object Evaluate(Context context)
        {
            var variableName = this.Type;

            if (!context.Variables.ContainsKey(variableName)) return null;

            return context.Variables[variableName];
        }

        public override SyntaxNode Generate(Context context)
        {
            var variableName = this.Type;

            return IdentifierName(variableName);
        }
    }
}
