namespace LiquorBarn.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCocktail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        CocktailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cocktail", t => t.CocktailId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CocktailId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCocktail", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.UserCocktail", "CocktailId", "dbo.Cocktail");
            DropIndex("dbo.UserCocktail", new[] { "CocktailId" });
            DropIndex("dbo.UserCocktail", new[] { "UserId" });
            DropTable("dbo.UserCocktail");
        }
    }
}
