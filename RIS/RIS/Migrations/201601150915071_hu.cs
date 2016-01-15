namespace RIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JichuidSets",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        biao = c.String(nullable: false, maxLength: 100),
                        lie = c.String(nullable: false, maxLength: 50),
                        fenlei = c.String(nullable: false, maxLength: 50),
                        gengxinpinlv = c.String(),
                        gengxinshijian = c.DateTime(nullable: false),
                        jichuid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => new { t.biao, t.lie, t.fenlei }, unique: true, name: "Index_biao_lie_fenlei_weiyi");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.JichuidSets", "Index_biao_lie_fenlei_weiyi");
            DropTable("dbo.JichuidSets");
        }
    }
}
