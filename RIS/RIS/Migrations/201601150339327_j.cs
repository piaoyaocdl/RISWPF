namespace RIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class j : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.YonghuSets",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        zhanghao = c.String(nullable: false, maxLength: 50),
                        mima = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.zhanghao, unique: true, name: "Index_zhanghao_weiyi");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.YonghuSets", "Index_zhanghao_weiyi");
            DropTable("dbo.YonghuSets");
        }
    }
}
