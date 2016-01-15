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

namespace RIS.PAGE.SYST
{
    /// <summary>
    /// Zhuchuangti.xaml 的交互逻辑
    /// </summary>
    public partial class Zhuchuangti
    {
        public Zhuchuangti()
        {
            InitializeComponent();
            App.Current.MainWindow = this;
        }

        private void linchuanghla_jiancedanUI_Selected(object sender, RoutedEventArgs e)
        {
            jiazai(new PAGE.LINCHUANGHLA.JIANCEDAN.Jiancedanxinxi());
        }

        private void jiazai(Page p)
        {
            jiazaiqiUI.Content = p;
        }

        private void gerenzhongxinUI_Selected(object sender, RoutedEventArgs e)
        {
            jiazai(new PAGE.SYST.Gerenzhongxin());
        }
    }
}
