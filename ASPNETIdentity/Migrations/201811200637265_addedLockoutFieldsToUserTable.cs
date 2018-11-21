namespace ASPNETIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedLockoutFieldsToUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "LockoutEnd", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Users", "LockoutEnabled", c => c.Boolean());
            AddColumn("dbo.Users", "AccessFailedCount", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "AccessFailedCount");
            DropColumn("dbo.Users", "LockoutEnabled");
            DropColumn("dbo.Users", "LockoutEnd");
        }
    }
}
