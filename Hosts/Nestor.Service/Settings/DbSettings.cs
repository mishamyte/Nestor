using Nestor.Contracts.Settings;

namespace Nestor.Service.Settings
{
	public class DbSettings : IDbSettings
	{
		public string ConnectionString { get; set; }

		public bool LowerFirstLetter { get; set; }

		public string Schema { get; set; }
	}
}
