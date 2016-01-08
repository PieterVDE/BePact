namespace Eindproject_BePact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWebsiteFieldToPersoon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Persoon", "Website", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Persoon", "Website");
        }
    }
}
