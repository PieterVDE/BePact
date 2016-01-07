namespace Eindproject_BePact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BedrijvenAndMaxLengthOnPersoonFields : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bedrijf",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Email = c.String(),
                        Telefoonnr = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Persoon", "BedrijfID", c => c.Int());
            AlterColumn("dbo.Persoon", "Voornaam", c => c.String(maxLength: 50));
            AlterColumn("dbo.Persoon", "Achternaam", c => c.String(maxLength: 50));
            AlterColumn("dbo.Persoon", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Persoon", "Telefoonnr", c => c.String(maxLength: 15));
            CreateIndex("dbo.Persoon", "BedrijfID");
            AddForeignKey("dbo.Persoon", "BedrijfID", "dbo.Bedrijf", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Persoon", "BedrijfID", "dbo.Bedrijf");
            DropIndex("dbo.Persoon", new[] { "BedrijfID" });
            AlterColumn("dbo.Persoon", "Telefoonnr", c => c.String());
            AlterColumn("dbo.Persoon", "Email", c => c.String());
            AlterColumn("dbo.Persoon", "Achternaam", c => c.String());
            AlterColumn("dbo.Persoon", "Voornaam", c => c.String());
            DropColumn("dbo.Persoon", "BedrijfID");
            DropTable("dbo.Bedrijf");
        }
    }
}
