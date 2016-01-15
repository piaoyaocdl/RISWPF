namespace RIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jj : DbMigration
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
            
            CreateTable(
                "dbo.Linchuanghla_jiancedanSet",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        bianhao = c.String(nullable: false, maxLength: 50),
                        huanzhexingming = c.String(nullable: false),
                        xingbie = c.String(),
                        chushengriqi = c.DateTime(),
                        shenfenzhenghao = c.String(),
                        linchuangzhenduan = c.String(),
                        menzhen_zhuyuan = c.String(),
                        chuanghao = c.String(),
                        shenqingyiyuan = c.String(),
                        shenqingyisheng = c.String(),
                        caiyangriqi = c.DateTime(),
                        zhuyuanhao = c.String(),
                        baogaofasongfangshi = c.String(),
                        lianxifangshi = c.String(),
                        shouyangzhe = c.String(),
                        shouyangriqi = c.DateTime(nullable: false),
                        jiancedanriqi = c.DateTime(),
                        beizhu = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.bianhao, unique: true, name: "Index_bianhao_weiyi");
            
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
            DropIndex("dbo.Linchuanghla_jiancedanSet", "Index_bianhao_weiyi");
            DropIndex("dbo.JichuidSets", "Index_biao_lie_fenlei_weiyi");
            DropTable("dbo.YonghuSets");
            DropTable("dbo.Linchuanghla_jiancedanSet");
            DropTable("dbo.JichuidSets");
        }
    }
}
