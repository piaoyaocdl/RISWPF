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
            }
        }
        //修改申请单
        private void shenqingdanliebiao_Xiugai_Click(object sender, RoutedEventArgs e)
        {

        }
        //删除申请单
        private void shenqingdanliebiao_Shanchu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
