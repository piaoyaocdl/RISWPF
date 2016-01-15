namespace RIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fewfw : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Linchuanghla_jiancedanSet", "bianhao", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Linchuanghla_jiancedanSet", "bianhao", unique: true, name: "Index_bianhao_weiyi");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Linchuanghla_jiancedanSet", "Index_bianhao_weiyi");
            DropColumn("dbo.Linchuanghla_jiancedanSet", "bianhao");
        }
    }
}
