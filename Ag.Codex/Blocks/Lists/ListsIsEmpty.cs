using Ag.Codex.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Ag.Codex.Blocks.Lists
{
    public class ListsIsEmpty : IBlock
    {
        public override object Evaluate(Context context)
        {
            var value = this.Values.Evaluate("VALUE", context) as IEnumerable<object>;
            if (null == value) return true;

            return !value.Any();
        }

		public override SyntaxNode Generate(Context context)
		{
			var valueExpression = this.Values.Generate("VALUE", context) as ExpressionSyntax;
			if (valueExpression == null) throw new ApplicationException($"Unknown expression for value.");

			return SyntaxGenerator.MethodInvokeExpression(valueExpression, nameof(Enumerable.Any));
		}
	}
}