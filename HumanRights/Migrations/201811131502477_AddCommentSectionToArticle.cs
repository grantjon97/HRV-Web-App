namespace HumanRights.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentSectionToArticle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "Comment");
        }
    }
}
