using System.Data.Entity;
using System.Data.Entity.Infrastructure.Pluralization;

namespace Nestor.Domain
{
	internal class NestorDbConfiguration : DbConfiguration
	{
		internal NestorDbConfiguration()
		{
			var nestsInfoPlural = new CustomPluralizationEntry("NestInfo", "NestsInfo");
			var nestsUpdatesPlural = new CustomPluralizationEntry("NestUpdate", "NestsUpdates");
			var pluralizationService = new EnglishPluralizationService(new[] { nestsInfoPlural, nestsUpdatesPlural });

			SetPluralizationService(pluralizationService);
		}
	}
}