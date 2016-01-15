namespace RIS
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Shujuku : DbContext
    {
        public Shujuku()
            : base("name=Shujuku")
        {
        }

        public virtual DbSet<YonghuSet> YonghuSet { get; set; }
        public virtual DbSet<Linchuanghla_jiancedanSet> Linchuanghla_jiancedanSet { get; set; }
        public virtual DbSet<JichuidSet> JichuidSet { get; set; }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        protected override void OnModelCreating(DbModelBuilder m)
        {
            base.OnModelCreating(m);
            //基础ID
            var jichuidset = m.Entity<JichuidSet>();
            jichuidset.HasKey(y => y.id);
            jichuidset.Property(j => j.biao).HasMaxLength(100).IsRequired().HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Index_biao_lie_fenlei_weiyi", 1) { IsUnique = true }));
            jichuidset.Property(j => j.lie).HasMaxLength(50).IsRequired().HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Index_biao_lie_fenlei_weiyi", 2) { IsUnique = true }));
            jichuidset.Property(j => j.fenlei).HasMaxLength(50).IsRequired().HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Index_biao_lie_fenlei_weiyi", 3) { IsUnique = true }));

            //用户
            var yonghuSet = m.Entity<YonghuSet>();
            yonghuSet.HasKey(y => y.id);
            yonghuSet.Property(yonghu => yonghu.mima).IsRequired();
            yonghuSet.Property(yonghu => yonghu.zhanghao).IsRequired().HasMaxLength(50).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Index_zhanghao_weiyi") { IsUnique = true }));
            //临床HLA--检测单
            var linchuanghla_jiancedanSet = m.Entity<Linchuanghla_jiancedanSet>();
            linchuanghla_jiancedanSet.HasKey(y => y.id);
            linchuanghla_jiancedanSet.Property(y => y.huanzhexingming).IsRequired();
            linchuanghla_jiancedanSet.Property(y => y.shouyangriqi).IsRequired();
            linchuanghla_jiancedanSet.Property(y => y.bianhao).IsRequired().HasMaxLength(50).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Index_bianhao_weiyi") { IsUnique = true }));
        }


        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            return base.ValidateEntity(entityEntry, items);
        }
    }

    //基础ID
    public class JichuidSet
    {
        public int id { set; get; }
        public string biao { set; get; }
        public string lie { set; get; }
        public string fenlei { set; get; }
        public string gengxinpinlv { set; get; }
        public DateTime gengxinshijian { set; get; }
        public int jichuid { set; get; }


    }
    //临床HLA--检测单
    public class Linchuanghla_jiancedanSet
    {
        //id
        public int id { set; get; }
        //编号
        public string bianhao { set; get; }
        //患者姓名（非空）
        public string huanzhexingming { set; get; }
        //性别
        public string xingbie { set; get; }
        //出生日期
        public Nullable<DateTime> chushengriqi { set; get; }
        //身份证号
        public string shenfenzhenghao { set; get; }
        //临床诊断
        public string linchuangzhenduan { set; get; }
        //门诊/住院
        public string menzhen_zhuyuan { set; get; }
        //床号
        public string chuanghao { set; get; }
        //申请医院
        public string shenqingyiyuan { set; get; }
        //申请医生
        public string shenqingyisheng { set; get; }
        //采样日期
        public Nullable<DateTime> caiyangriqi { set; get; }
        //住院号
        public string zhuyuanhao { set; get; }
        //报告发送方式
        public string baogaofasongfangshi { set; get; }

        //联系方式
        public string lianxifangshi { set; get; }
        //收样者
        public string shouyangzhe { set; get; }
        //收样日期（非空）
        public Nullable<DateTime> shouyangriqi { set; get; }
        //检测单日期
        public Nullable<DateTime> jiancedanriqi { set; get; }
        //备注
        public string beizhu { set; get; }

    }
    //用户
    public class YonghuSet
    {
        public int id { get; set; }
        public string zhanghao { get; set; }
        public string mima { get; set; }
    }
}