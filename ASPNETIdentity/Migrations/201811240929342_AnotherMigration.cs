namespace ASPNETIdentity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnotherMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.IdentityUserIdentityRoles", newName: "UsersRoles");
            RenameColumn(table: "dbo.UsersRoles", name: "IdentityUser_Id", newName: "UserID");
            RenameColumn(table: "dbo.UsersRoles", name: "IdentityRole_Id", newName: "RoleID");
            RenameIndex(table: "dbo.UsersRoles", name: "IX_IdentityUser_Id", newName: "IX_UserID");
            RenameIndex(table: "dbo.UsersRoles", name: "IX_IdentityRole_Id", newName: "IX_RoleID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UsersRoles", name: "IX_RoleID", newName: "IX_IdentityRole_Id");
            RenameIndex(table: "dbo.UsersRoles", name: "IX_UserID", newName: "IX_IdentityUser_Id");
            RenameColumn(table: "dbo.UsersRoles", name: "RoleID", newName: "IdentityRole_Id");
            RenameColumn(table: "dbo.UsersRoles", name: "UserID", newName: "IdentityUser_Id");
            RenameTable(name: "dbo.UsersRoles", newName: "IdentityUserIdentityRoles");
        }
    }
}
