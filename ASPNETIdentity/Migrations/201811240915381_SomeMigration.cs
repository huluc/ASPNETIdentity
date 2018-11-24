namespace ASPNETIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UsersRoles", newName: "IdentityUserIdentityRoles");
            RenameColumn(table: "dbo.IdentityUserIdentityRoles", name: "UserID", newName: "IdentityUser_Id");
            RenameColumn(table: "dbo.IdentityUserIdentityRoles", name: "RoleID", newName: "IdentityRole_Id");
            RenameIndex(table: "dbo.IdentityUserIdentityRoles", name: "IX_UserID", newName: "IX_IdentityUser_Id");
            RenameIndex(table: "dbo.IdentityUserIdentityRoles", name: "IX_RoleID", newName: "IX_IdentityRole_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.IdentityUserIdentityRoles", name: "IX_IdentityRole_Id", newName: "IX_RoleID");
            RenameIndex(table: "dbo.IdentityUserIdentityRoles", name: "IX_IdentityUser_Id", newName: "IX_UserID");
            RenameColumn(table: "dbo.IdentityUserIdentityRoles", name: "IdentityRole_Id", newName: "RoleID");
            RenameColumn(table: "dbo.IdentityUserIdentityRoles", name: "IdentityUser_Id", newName: "UserID");
            RenameTable(name: "dbo.IdentityUserIdentityRoles", newName: "UsersRoles");
        }
    }
}
