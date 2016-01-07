namespace Eindproject_BePact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activiteit",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ActiviteitType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PersoonActiviteit",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PersoonID = c.Int(nullable: false),
                        ActiviteitID = c.Int(nullable: false),
                        Beschrijving = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Activiteit", t => t.ActiviteitID, cascadeDelete: true)
                .ForeignKey("dbo.Persoon", t => t.PersoonID, cascadeDelete: true)
                .Index(t => t.PersoonID)
                .Index(t => t.ActiviteitID);
            
            CreateTable(
                "dbo.Persoon",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Voornaam = c.String(),
                        Achternaam = c.String(),
                        Email = c.String(),
                        Telefoonnr = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersoonActiviteit", "PersoonID", "dbo.Persoon");
            DropForeignKey("dbo.PersoonActiviteit", "ActiviteitID", "dbo.Activiteit");
            DropIndex("dbo.PersoonActiviteit", new[] { "ActiviteitID" });
            DropIndex("dbo.PersoonActiviteit", new[] { "PersoonID" });
            DropTable("dbo.Persoon");
            DropTable("dbo.PersoonActiviteit");
            DropTable("dbo.Activiteit");
        }
    }
}
