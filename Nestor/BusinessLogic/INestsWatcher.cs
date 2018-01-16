using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nestor.DTO;
using Nestor.Model;

namespace Nestor.BusinessLogic
{
	internal interface INestsWatcher : IDisposable
	{
		Task<IList<NestDto>> GetMissingAndOutdatedNests();

		void ProcessNest(NestDto nestDto);

		void RecordNestUpdateToHistory(Nest nest);
	}
}
