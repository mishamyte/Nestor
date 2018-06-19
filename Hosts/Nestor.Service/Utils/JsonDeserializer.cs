using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;

namespace Nestor.Service
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
					Log.Error(args.ErrorContext.Error, "Error while deserializing JSON");
					args.ErrorContext.Handled = true;
				}
			});

			result = success ? parsedResult : default(T);

			return success;
		}
	}
}
