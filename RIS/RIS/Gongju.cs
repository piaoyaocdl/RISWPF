﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;

namespace RIS
{
    public class Gongju
    {
        public static Task<MessageDialogResult> tanchutishi(string xinxi)
        {
            return DialogManager.ShowMessageAsync((MetroWindow)App.Current.MainWindow, "提示", xinxi);
        }
        public static Task<MessageDialogResult> tanchutishi(MetroWindow metroWindow, string xinxi)
        {
            return DialogManager.ShowMessageAsync(metroWindow, "提示", xinxi);
        }


    }
}