using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DEVGIS.ModelMaker.Forms;

namespace DEVGIS.ModelMaker
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void lvMenu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvMenu.SelectedItems[0] == null || lvMenu.SelectedItems[0].Tag == null)
            {
                return;
            }
            else
            {
                String sTag = lvMenu.SelectedItems[0].Tag.ToString();
                switch (sTag)
                {
                    case "m01":
                        M01Form frmM01 = new M01Form();
                        frmM01.StartPosition = FormStartPosition.CenterParent;
                        frmM01.WindowState = FormWindowState.Maximized;
                        frmM01.Show();
                        break;
                    case "m02":
                        M02Form frmM02 = new M02Form();
                        frmM02.StartPosition = FormStartPosition.CenterParent;
                        frmM02.WindowState = FormWindowState.Maximized;
                        frmM02.Show();
                        break;
                    case "m03":
                        M03Form frmM03 = new M03Form();
                        frmM03.StartPosition = FormStartPosition.CenterParent;
                        frmM03.WindowState = FormWindowState.Maximized;
                        frmM03.Show();
                        break;
                    case "m04":
                        M04Form frmM04 = new M04Form();
                        frmM04.StartPosition = FormStartPosition.CenterParent;
                        frmM04.WindowState = FormWindowState.Maximized;
                        frmM04.Show();
                        break;
                    case "m05":
                        M05Form frmM05 = new M05Form();
                        frmM05.StartPosition = FormStartPosition.CenterParent;
                        frmM05.WindowState = FormWindowState.Maximized;
                        frmM05.Show();
                        break;
                    case "about":
                        AboutForm frmAbout = new AboutForm();
                        frmAbout.StartPosition = FormStartPosition.CenterParent;
                        frmAbout.Show();
                        break;
                }
            }
        }
    }
}
