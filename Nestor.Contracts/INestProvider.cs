using System;
using System.Threading.Tasks;

namespace Nestor.Contracts
{
	public interface INestProvider : IDisposable
	{
		Task<string> GetNestsJsonData();
	}
}