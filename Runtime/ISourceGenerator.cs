/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Peter Bjorklund. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;

namespace Piot.CSharpSourceGenerator
{
	public interface ISwitchScope : IDisposable
	{
		public ISourceScope Case(string s, string comment = "", bool useBrackets = false);
		public ISourceScope Default(string comment = "", bool useBrackets = false);
	}

	public interface IIfScope : IDisposable
	{
		public ISourceScope Consequence { get; }
		public ISourceScope CreateAlternative();
	}


	public interface ISourceScope : IDisposable
	{
		public void Line(string sourceLine);
		public void Lines(string sourceLines, string comment = "");
		public void Lines(string[] sourceLines);

		public ISourceScope For(string s, string comment = "");
		public IIfScope If(string s, string comment = "");
		public ISourceScope ForEach(string s, string comment = "");
		public ISourceScope While(string s, string comment = "");
		public ISourceScope Block(string s = "", string comment = "");
		public ISwitchScope Switch(string s, string comment = "");
	}

	public interface IClassScope : IDisposable
	{
		public ISourceScope PublicStaticMethod(string s, string comment = "");
	}

	public interface INamespaceScope : IDisposable
	{
		public IClassScope PublicStaticClass(string s);
	}

	public interface IRootScope : IDisposable
	{
		public void Usings(string sourceLines);
		public INamespaceScope Namespace(string s);
	}

	public interface ISourceGenerator
	{
		public void IncreaseIndent(bool insertBrackets = true);
		public void DecreaseIndent(string comment = "", bool insertBrackets = true);
		public void LineCuddle(string s);
		public void Line(string s);
		public void Lines(string[] sourceLines);
		public void Lines(string sourceLines, string comment = "");
	}
}