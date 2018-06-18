using System.Data.Entity.Migrations;

namespace Nestor.Domain.Migrations
{

	internal sealed class Configuration : DbMigrationsConfiguration<NestorContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(NestorContext context)
		{
		}
	}
}