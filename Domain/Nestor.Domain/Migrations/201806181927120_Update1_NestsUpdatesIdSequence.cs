namespace Nestor.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1_NestsUpdatesIdSequence : DbMigration
    {
        public override void Up()
        {
			SqlFile(@"..\..\Migrations\SQL\Update1_NestsUpdatesIdSequence.sql");
        }
        
        public override void Down()
        {
        }
    }
}
