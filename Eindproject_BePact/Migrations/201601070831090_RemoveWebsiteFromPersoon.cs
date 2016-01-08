namespace Eindproject_BePact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveWebsiteFromPersoon : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Persoon", "Website");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Persoon", "Website", c => c.String());
        }
    }
}
