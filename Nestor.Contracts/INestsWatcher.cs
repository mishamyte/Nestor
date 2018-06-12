using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nestor.Contracts.Dtos;

namespace Nestor.Contracts
{
	public interface INestsWatcher : IDisposable
	{
		Task<IList<NestDto>> GetMissingAndOutdatedNests();

		void ProcessNest(NestDto nestDto);

		void RecordNestUpdateToHistory(NestDto nest);
	}
}