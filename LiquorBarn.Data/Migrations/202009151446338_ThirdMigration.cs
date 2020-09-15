namespace LiquorBarn.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomSpecific",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomCocktailId = c.Int(nullable: false),
                        SpecificLiquorId = c.Int(),
                        LiquorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomCocktail", t => t.CustomCocktailId, cascadeDelete: true)
                .ForeignKey("dbo.Liquor", t => t.LiquorId)
                .ForeignKey("dbo.SpecificLiquor", t => t.SpecificLiquorId)
                .Index(t => t.CustomCocktailId)
                .Index(t => t.SpecificLiquorId)
                .Index(t => t.LiquorId);
            
            CreateTable(
                "dbo.CustomCocktail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Name = c.String(),
                        Ingredients = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.SpecificLiquor", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomSpecific", "SpecificLiquorId", "dbo.SpecificLiquor");
            DropForeignKey("dbo.CustomSpecific", "LiquorId", "dbo.Liquor");
            DropForeignKey("dbo.CustomSpecific", "CustomCocktailId", "dbo.CustomCocktail");
            DropForeignKey("dbo.CustomCocktail", "UserId", "dbo.ApplicationUser");
            DropIndex("dbo.CustomCocktail", new[] { "UserId" });
            DropIndex("dbo.CustomSpecific", new[] { "LiquorId" });
            DropIndex("dbo.CustomSpecific", new[] { "SpecificLiquorId" });
            DropIndex("dbo.CustomSpecific", new[] { "CustomCocktailId" });
            DropColumn("dbo.SpecificLiquor", "Name");
            DropTable("dbo.CustomCocktail");
            DropTable("dbo.CustomSpecific");
        }
    }
}
