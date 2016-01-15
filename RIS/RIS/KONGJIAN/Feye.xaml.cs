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

namespace RIS.KONGJIAN
{
    /// <summary>
    /// Feye.xaml 的交互逻辑
    /// </summary>
    public partial class Feye : UserControl
    {
        public Feye()
        {
            InitializeComponent();
            gongjiye = 1;
            dangqianye = 1;
        }
        public event RoutedEventHandler Fenyechaxun;
        public int gongjiye
        {
            set { this.gongjiyeUI.Content = value; }
            get { return (int)this.gongjiyeUI.Content; }
        }

        public int dangqianye
        {
            set {this.dangqianyeUI.Content=value; }
            get { return (int)this.dangqianyeUI.Content; }
        }

        private void shouyeUI_Click(object sender, RoutedEventArgs e)
        {
            if (Fenyechaxun==null)
            {
                Gongju.tanchutishi("没有定义此功能！");
                return;
            }
            dangqianye = 1;
            Fenyechaxun(sender,e);
        }

        private void qianyeUI_Click(object sender, RoutedEventArgs e)
        {
            if (Fenyechaxun == null)
            {
                Gongju.tanchutishi("没有定义此功能！");
                return;
            }
            dangqianye = Math.Max(1, dangqianye - 1);
            Fenyechaxun(sender, e);
        }

        private void houyeUI_Click(object sender, RoutedEventArgs e)
        {
            if (Fenyechaxun == null)
            {
                Gongju.tanchutishi("没有定义此功能！");
                return;
            }
            dangqianye = Math.Min(gongjiye, dangqianye + 1);
            Fenyechaxun(sender, e);
        }

        private void weiye_Click(object sender, RoutedEventArgs e)
        {
            if (Fenyechaxun == null)
            {
                Gongju.tanchutishi("没有定义此功能！");
                return;
            }
            dangqianye = gongjiye;
            Fenyechaxun(sender, e);
        }
    }
}
