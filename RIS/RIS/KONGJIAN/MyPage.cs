using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RIS.KONGJIAN
{
    public class MyPage : Page
    {
        public MyPage()
        {
            this.shujuku = new Shujuku();
            IsVisibleChanged += MyPage_IsVisibleChanged;
        }

        protected Shujuku shujuku { set; get; }

        private void MyPage_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(bool)e.NewValue)
            {
                this.shujuku.Dispose();
            }
        }
    }
}
