using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DEVGIS.ModelMaker;
using System.Diagnostics;

namespace ModelMaker
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Process.Start("http://flysoft.taobao.com");
            //Process.Start("http://guliangjie.taobao.com"); 
            Application.Run(new MenuForm());
            //Process.Start("http://flysoft.taobao.com");
            //Process.Start("http://guliangjie.taobao.com"); 
        }
    }
}
