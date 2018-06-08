using System.Threading.Tasks;

namespace Nestor.Contracts
{
	public interface IBotProvider
	{
		Task SendImage(string uri, string caption);

		Task SendLocation(float latitude, float longitude);

		Task SendMessage(string text);
	}
}