using System.Threading.Tasks;

namespace Nestor.Interfaces
{
	public interface INestProvider
	{
		Task<string> GetNestsJsonData();
	}
}
