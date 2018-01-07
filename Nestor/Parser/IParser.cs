using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nestor.Model;

namespace Nestor.Parser
{
	internal interface IParser : IDisposable
	{
		Task<IList<Nest>> GetNests();
	}
}
