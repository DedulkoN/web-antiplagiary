namespace web_antiplagiary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DateCreate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "SecurityInfo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "SecurityInfo");
            DropColumn("dbo.AspNetUsers", "DateCreate");
        }
    }
}
