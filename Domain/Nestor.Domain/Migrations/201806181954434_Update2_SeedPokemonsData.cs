namespace Nestor.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2_SeedPokemonsData : DbMigration
    {
        public override void Up()
        {
	        SqlFile(@"..\..\Migrations\SQL\Update2_SeedPokemonsData.sql");
		}
        
        public override void Down()
        {
        }
    }
}
