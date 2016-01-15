using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RIS.PAGE.LINCHUANGHLA.JIANCEDAN
{
    /// <summary>
    /// Jiancedanxinxi.xaml 的交互逻辑
    /// </summary>
    public partial class Jiancedanxinxi : KONGJIAN.MyPage
    {
        public Jiancedanxinxi()
        {
            InitializeComponent();
        }
       //选的申请单
        private Linchuanghla_jiancedanSet shujuyuan_xuanzedeshengqingdan
        {
            get
            {
                if (shenqingdanliebiaoUI.SelectedIndex == -1)
                {
                    return null;
                }
                else
                {
                    return (Linchuanghla_jiancedanSet)shenqingdanliebiaoUI.SelectedItem;
                }
            }
        }
        private List<Linchuanghla_jiancedanSet> shujuyuan_shenqingdanliebiao
        {
            set { shenqingdanliebiaoUI.ItemsSource = value; }
            get { return (List<Linchuanghla_jiancedanSet>)shenqingdanliebiaoUI.ItemsSource; }
        }
        //-----------------------------------------------------------------------------------
        //添加申请单
        private void shenqingdanliebiao_Tianjia_Click(object sender, RoutedEventArgs e)
        {
            var tianjia = new Tianjiashenqingdan();
            var xin = new Linchuanghla_jiancedanSet();
            xin.bianhao = "lsbh";
            tianjia.shenqingdanUI.DataContext = xin;
            tianjia.ShowDialog();
            if (tianjia.queding)
            {
                shujuku.Linchuanghla_jiancedanSet.Add(xin);
                shujuku.SaveChanges();
                var jichuid = (xin.id-shujuku.JichuidSet.Where(z=>z.biao.Equals("Linchuanghla_jiancedanSet")&&z.lie.Equals("bianhao")).Single().jichuid).ToString();
                xin.bianhao = "H" + DateTime.Now.Year.ToString().Substring(2) + "00000".Substring(jichuid.Length) + jichuid;
                shujuku.SaveChanges();
                shenqingdanfenyeUI.dangqianye = 1;
                shenqingdanfenyeUI_Fenyechaxun(null,null);
            }
        }
        //修改申请单
        private  void shenqingdanliebiao_Xiugai_Click(object sender, RoutedEventArgs e)
        {
            if (shujuyuan_xuanzedeshengqingdan==null)
            {
                Gongju.tanchutishi("请先选择申请单！");
                return;
            }
            var tianjia = new Tianjiashenqingdan();
            tianjia.shenqingdanUI.DataContext = shujuyuan_xuanzedeshengqingdan;
            tianjia.ShowDialog();
            if (tianjia.queding)
            {
                shujuku.SaveChanges();
            }
        }
        //删除申请单
        private void shenqingdanliebiao_Shanchu_Click(object sender, RoutedEventArgs e)
        {
            if (shujuyuan_xuanzedeshengqingdan == null)
            {
                Gongju.tanchutishi("请先选择申请单！");
                return;
            }
            shujuku.Linchuanghla_jiancedanSet.Remove(shujuyuan_xuanzedeshengqingdan);
            shujuku.SaveChanges();
            shenqingdanfenyeUI_Fenyechaxun(null,null);
        }
        //分页查询
        private void shenqingdanfenyeUI_Fenyechaxun(object sender, RoutedEventArgs e)
        {
            var sql = shujuku.Linchuanghla_jiancedanSet.AsQueryable();
            if (chaxunkaishiriqiUI.SelectedDate != null)
            {
                sql = sql.Where(z => z.jiancedanriqi >= chaxunkaishiriqiUI.SelectedDate);
            }
            if (chaxunjieshuriqiUI.SelectedDate != null)
            {
                sql = sql.Where(z => z.jiancedanriqi <= chaxunjieshuriqiUI.SelectedDate);
            }
            if (chaxunhuanzhexingmingUI.Text.Trim().Length > 0)
            {
                sql = sql.Where(z => z.huanzhexingming.Equals(chaxunhuanzhexingmingUI.Text.Trim()));
            }
            if (chaxunbianhaoUI.Text.Trim().Length > 0)
            {
                sql = sql.Where(z => z.bianhao.Equals(chaxunbianhaoUI.Text.Trim()));
            }
            shenqingdanfenyeUI.gongjiye = sql.Count() / 15 + 1;
            shujuyuan_shenqingdanliebiao = sql.OrderByDescending(z => z.id).Skip(shenqingdanfenyeUI.dangqianye * 15 - 15).Take(15).ToList();
        }
        //查询按钮点击
        private void chaxunUI_Click(object sender, RoutedEventArgs e)
        {
            shujuku.Dispose();
            shujuku = new Shujuku();
            shenqingdanfenyeUI.dangqianye = 1;
            shenqingdanfenyeUI_Fenyechaxun(sender,e);
        }

        private void xiangxixinxiUI_Click(object sender, RoutedEventArgs e)
        {
            if (shujuyuan_xuanzedeshengqingdan == null)
            {
                Gongju.tanchutishi("请先选择申请单！");
                return;
            }
        }
    }
}
