namespace Nestor.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update3_vNestsWithoutInfo : DbMigration
    {
        public override void Up()
        {
	        SqlFile(@"..\..\Migrations\SQL\Update3_vNestsWithoutInfo.sql");
		}
        
        public override void Down()
        {
        }
    }
}
