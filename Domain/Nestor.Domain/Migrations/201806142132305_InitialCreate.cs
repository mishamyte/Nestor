namespace Nestor.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Nests",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        PokemonId = c.Int(nullable: false),
                        NestType = c.Int(nullable: false),
                        Lat = c.Double(nullable: false),
                        Lng = c.Double(nullable: false),
                        IsRecommended = c.Boolean(nullable: false),
                        LastMigration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Pokemons", t => t.PokemonId, cascadeDelete: true)
                .Index(t => t.PokemonId);
            
            CreateTable(
                "public.NestsUpdates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NestId = c.Int(nullable: false),
                        PokemonId = c.Int(nullable: false),
                        MigrationNumber = c.Int(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Nests", t => t.NestId, cascadeDelete: true)
                .ForeignKey("public.Pokemons", t => t.PokemonId, cascadeDelete: true)
                .Index(t => t.NestId)
                .Index(t => t.PokemonId);
            
            CreateTable(
                "public.Pokemons",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.NestsInfo",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        HashtagName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.NestsUpdates", "PokemonId", "public.Pokemons");
            DropForeignKey("public.Nests", "PokemonId", "public.Pokemons");
            DropForeignKey("public.NestsUpdates", "NestId", "public.Nests");
            DropIndex("public.NestsUpdates", new[] { "PokemonId" });
            DropIndex("public.NestsUpdates", new[] { "NestId" });
            DropIndex("public.Nests", new[] { "PokemonId" });
            DropTable("public.NestsInfo");
            DropTable("public.Pokemons");
            DropTable("public.NestsUpdates");
            DropTable("public.Nests");
        }
    }
}
