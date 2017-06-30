using System;
using System.Threading.Tasks;
using Nestor.Interfaces;

namespace Nestor.Parser
{
	public abstract class Parser : IDisposable
	{
		protected readonly ISettings Settings;

		protected Parser(ISettings settings)
		{
			Settings = settings;
		}

		public abstract Task<string> GetNests();

		public abstract void Dispose();
	}
}
