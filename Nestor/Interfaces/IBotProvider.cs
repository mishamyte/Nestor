using System;
using System.Threading.Tasks;

namespace Nestor.Interfaces
{
	public interface IBotProvider
	{
		Task SendMessage(string text);
		Task SendLocation(float latitude, float longitude);
		Task SendImage(Uri uri, string caption);
	}
}
