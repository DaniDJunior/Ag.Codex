using System;
using System.Collections.Generic;
using System.Linq;
using Ag.Codex.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Ag.Codex.Blocks.Math
{
	public class MathRandomFloat : IBlock
	{
		static Random rand = new Random();

		public override object Evaluate(Context context)
		{
			return rand.NextDouble();
		}

	}
}