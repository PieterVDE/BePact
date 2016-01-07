namespace Eindproject_BePact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bedrijf", "Naam", c => c.String(maxLength: 50));
            AlterColumn("dbo.Bedrijf", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Bedrijf", "Telefoonnr", c => c.String(maxLength: 15));
            CreateIndex("dbo.Activiteit", "ActiviteitType", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Activiteit", new[] { "ActiviteitType" });
            AlterColumn("dbo.Bedrijf", "Telefoonnr", c => c.String());
            AlterColumn("dbo.Bedrijf", "Email", c => c.String());
            AlterColumn("dbo.Bedrijf", "Naam", c => c.String());
        }
    }
}
