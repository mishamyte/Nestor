using System;
using System.Threading.Tasks;

namespace Nestor.Parser
{
	internal interface INestProvider : IDisposable
	{
		Task<string> GetNestsJsonData();
	}
}
