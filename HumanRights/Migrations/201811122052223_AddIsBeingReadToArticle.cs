namespace HumanRights.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsBeingReadToArticle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "IsBeingRead", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "IsBeingRead");
        }
    }
}
