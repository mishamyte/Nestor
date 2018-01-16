using System.Data.Entity;
using System.Data.Entity.Infrastructure.Pluralization;

namespace Nestor.DAL
{
    internal class NestsDbConfiguration : DbConfiguration
    {
	    internal NestsDbConfiguration()
        {
            var nestsInfoPlural = new CustomPluralizationEntry("NestInfo", "NestsInfo");
			var nestsUpdatesPlural = new CustomPluralizationEntry("NestUpdate", "NestsUpdates");
            var pluralizationService = new EnglishPluralizationService(new[] { nestsInfoPlural, nestsUpdatesPlural });

            SetPluralizationService(pluralizationService);
        }
    }
}
