using System;
using System.Threading.Tasks;

namespace Nestor.TelegramBot
{
	internal interface IBotProvider
	{
		Task SendImage(Uri uri, string caption);

		Task SendLocation(float latitude, float longitude);

		Task SendMessage(string text);
	}
}
