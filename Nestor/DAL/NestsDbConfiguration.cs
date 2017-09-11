using System.Data.Entity;
using System.Data.Entity.Infrastructure.Pluralization;

namespace Nestor.DAL
{
    internal class NestsDbConfiguration : DbConfiguration
    {
        public NestsDbConfiguration()
        {
            var nestsInfoPlural = new CustomPluralizationEntry("NestInfo", "NestsInfo");
            var pluralizationService = new EnglishPluralizationService(new[] { nestsInfoPlural });

            SetPluralizationService(pluralizationService);
        }
    }
}
