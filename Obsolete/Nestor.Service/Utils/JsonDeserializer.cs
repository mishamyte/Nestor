using Nestor.Service.Loggers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Nestor.Service.Utils
{
	internal static class JsonDeserializer
	{
		internal static bool TryDeserializeObject<T>(string data, out T result)
		{
			var success = true;

			var parsedResult = JsonConvert.DeserializeObject<T>(data, new JsonSerializerSettings
			{
				Error = delegate (object sender, ErrorEventArgs args)
				{
					success = false;
					var logger = new ConsoleLogger();
					logger.LogError(args.ErrorContext.Error.ToString());
					args.ErrorContext.Handled = true;
				}
			});

			result = success ? parsedResult : default(T);

			return success;
		}
	}
}
