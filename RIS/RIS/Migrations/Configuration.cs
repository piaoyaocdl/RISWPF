namespace RIS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RIS.Shujuku>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RIS.Shujuku shujuku)
        {
            //ÓÃ»§
            var guanliyuan = new YonghuSet { zhanghao = "guanliyuan", mima = "ceshi" };
            if (shujuku.YonghuSet.Where(z=>z.zhanghao.Equals(guanliyuan.zhanghao)).Count()==0)
            {
                shujuku.YonghuSet.Add(guanliyuan);
            }
            var jichuid = new JichuidSet { biao = "Linchuanghla_jiancedanSet", lie = "bianhao", gengxinpinlv = "year", gengxinshijian = DateTime.Now,fenlei="",jichuid=0 };
            if (shujuku.JichuidSet.Where(z=>z.biao.Equals(jichuid.biao)&&z.lie.Equals(jichuid.lie)).Count()==0)
            {
                shujuku.JichuidSet.Add(jichuid);
            }
        }

        
    }
}
