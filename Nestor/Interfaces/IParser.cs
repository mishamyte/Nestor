using System.Collections.Generic;
using System.Threading.Tasks;
using Nestor.Model;

namespace Nestor.Interfaces
{
	interface IParser
	{
		Task<IList<Nest>> GetNests();
	}
}
