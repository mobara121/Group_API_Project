namespace LiquorBarn.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JustToSee : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cocktail", "Ingredients", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cocktail", "Ingredients", c => c.String());
        }
    }
}
