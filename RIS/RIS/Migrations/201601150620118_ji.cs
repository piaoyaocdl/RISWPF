namespace RIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ji : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Linchuanghla_jiancedanSet",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        huanzhexingming = c.String(nullable: false),
                        xingbie = c.String(),
                        chushengriqi = c.DateTime(),
                        shenfenzhenghao = c.String(),
                        linchuangzhenduan = c.String(),
                        menzheng_yiyuan = c.String(),
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
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Linchuanghla_jiancedanSet");
        }
    }
}
