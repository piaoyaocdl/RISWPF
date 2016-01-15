namespace RIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fefe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Linchuanghla_jiancedanSet", "menzheng_zhuyuan", c => c.String());
            DropColumn("dbo.Linchuanghla_jiancedanSet", "menzheng_yiyuan");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Linchuanghla_jiancedanSet", "menzheng_yiyuan", c => c.String());
            DropColumn("dbo.Linchuanghla_jiancedanSet", "menzheng_zhuyuan");
        }
    }
}
