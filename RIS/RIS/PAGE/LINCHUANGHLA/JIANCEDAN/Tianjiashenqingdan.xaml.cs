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

namespace RIS.PAGE.LINCHUANGHLA.JIANCEDAN
{
    /// <summary>
    /// Tianjiashenqingdan.xaml 的交互逻辑
    /// </summary>
    public partial class Tianjiashenqingdan 
    {
        public Tianjiashenqingdan()
        {
            InitializeComponent();
            queding = false;
        }

        public bool queding { set; get; }

        private void quedingUI_Click(object sender, RoutedEventArgs e)
        {
            if (huanzhexingmingUI.Text.Trim().Length==0)
            {
                Gongju.tanchutishi(this,"患者姓名不能为空！");
                return;
            }
            if (shouyangriqiUI.SelectedDate==null)
            {
                Gongju.tanchutishi(this, "收样日期不能为空！");
                return;
            }
            queding = true;
            this.Close();
        }
    }
}
