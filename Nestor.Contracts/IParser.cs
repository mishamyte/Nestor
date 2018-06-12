using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nestor.Contracts.Dtos;

namespace Nestor.Contracts
{
	public interface IParser : IDisposable
	{
		Task<List<SilphNestDto>> GetNests();
	}
}