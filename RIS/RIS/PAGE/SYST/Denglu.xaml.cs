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
using System.Windows.Shapes;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;

namespace RIS.PAGE.SYST
{
    /// <summary>
    /// Denglu.xaml 的交互逻辑
    /// </summary>
    public partial class Denglu 
    {
        public Denglu()
        {
            InitializeComponent();
            using (Shujuku shujuku=new Shujuku())
            {
                var dangqianshijian = DateTime.Now;
                //临床HLA--检测单--编号   更新
                var linchuanghla_jiancedanSet = shujuku.JichuidSet.Where(z => z.biao.Equals("Linchuanghla_jiancedanSet") && z.lie.Equals("bianhao")).Single();
                if (dangqianshijian.Year!=linchuanghla_jiancedanSet.gengxinshijian.Year)
                {
                    linchuanghla_jiancedanSet.gengxinshijian = dangqianshijian;
                    var ls = shujuku.Linchuanghla_jiancedanSet.OrderBy(z=>z.id).LastOrDefault();
                    if (ls==null)
                    {
                        linchuanghla_jiancedanSet.jichuid = 0;
                    }
                    else
                    {
                        linchuanghla_jiancedanSet.jichuid = ls.id;
                    }
                }

                shujuku.SaveChanges();
            }
        }

        //登陆事件
        private async void dengluUI_Click(object sender, RoutedEventArgs e)
        {
            using (Shujuku shujuku=new Shujuku())
            {
                var yonghu = shujuku.YonghuSet.Where(y => y.zhanghao.Equals(zhanghaoUI.Text) && y.mima.Equals(mimaUI.Password)).SingleOrDefault();
                if (yonghu!=null)
                {
                    App.dangqianyonghu = yonghu;
                    var ls = new Zhuchuangti();
                    ls.Show();
                    this.Close();
                }
                else
                {
                    await DialogManager.ShowMessageAsync(this, "提示", "登录信息有误！");
                }
            }
        }
    }
}
