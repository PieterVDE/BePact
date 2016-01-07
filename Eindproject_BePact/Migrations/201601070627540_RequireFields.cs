namespace Eindproject_BePact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequireFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Persoon", "Voornaam", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Persoon", "Achternaam", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Persoon", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Persoon", "Telefoonnr", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Bedrijf", "Naam", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Bedrijf", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Bedrijf", "Telefoonnr", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bedrijf", "Telefoonnr", c => c.String(maxLength: 15));
            AlterColumn("dbo.Bedrijf", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Bedrijf", "Naam", c => c.String(maxLength: 50));
            AlterColumn("dbo.Persoon", "Telefoonnr", c => c.String(maxLength: 15));
            AlterColumn("dbo.Persoon", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Persoon", "Achternaam", c => c.String(maxLength: 50));
            AlterColumn("dbo.Persoon", "Voornaam", c => c.String(maxLength: 50));
        }
    }
}
