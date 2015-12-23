using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DEVGIS.ModelMaker.Entities;
using System.IO;
using DEVGIS.ModelMaker.Common;

namespace DEVGIS.ModelMaker.Forms
{
    public partial class M05Form : Form
    {
        public M05Form()
        {
            InitializeComponent();
        }

        private void btCreatM05_Click(object sender, EventArgs e)
        {
            String M05ModelPath = Path.Combine(Application.StartupPath, "Modeles\\m05.devm");
            if (!File.Exists(M05ModelPath))
            {
                MessageBox.Show("模板文件不存在！");
                return;
            }
            else
            {
                //读取模板文件
                String M05ModelString = File.ReadAllText(M05ModelPath, Encoding.Default);

                //执行替换操作
                M05ModelString = M05ModelString.Replace("*#*#*#*#BigP01", tbM05BigP01.Text);
                M05ModelString = M05ModelString.Replace("*#*#*#*#BigP02", tbM05BigP02.Text);
                M05ModelString = M05ModelString.Replace("*#*#*#*#BigP03", tbM05BigP03.Text);

                M05ModelString = M05ModelString.Replace("*#*#*#*#URL01", tbM05URL01.Text);
                M05ModelString = M05ModelString.Replace("*#*#*#*#URL02", tbM05URL02.Text);
                M05ModelString = M05ModelString.Replace("*#*#*#*#URL03", tbM05URL03.Text);

                tbM05Code.Text = M05ModelString;
                tbM05Code.SelectAll();
                tbM05Code.Copy();
                tabControl2.SelectedIndex = 2;
                MessageBox.Show("代码已经复制到剪切板，请直接粘贴！");
            }
        }

        private void btExportM05_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "M05模板文件(*.m05)|*.m05";
            String InitialDirectory = Path.Combine(Application.StartupPath, "Saves");
            if (!Directory.Exists(InitialDirectory))
            {
                Directory.CreateDirectory(InitialDirectory);
            }
            sfd.InitialDirectory = InitialDirectory;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                M05 m05 = GetM05();
                try
                {
                    SerialHelper.SaveToXML(sfd.FileName, typeof(M05), m05);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Err:" + ex.Message);
                }
            }
        }

        private void btImportM05_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "M05模板文件(*.m05)|*.m05";
            String InitialDirectory = Path.Combine(Application.StartupPath, "Saves");
            if (!Directory.Exists(InitialDirectory))
            {
                Directory.CreateDirectory(InitialDirectory);
            }
            sfd.InitialDirectory = InitialDirectory;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                M05 m05 = null;
                object o = null;
                try
                {
                    o = SerialHelper.LoadFromXML(sfd.FileName, typeof(M05));
                    if (o is M05)
                    {
                        m05 = o as M05;
                        this.SetM05(m05);
                    }
                    else
                    {
                        MessageBox.Show("模板文件不正确！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Err:" + ex.Message);
                }
            }
        }
             /// <summary>
        /// 讲模板值设置到界面
        /// </summary>
        /// <param name="m05"></param>
        private void SetM05(M05 m05)
        {
            tbM05BigP01.Text=m05.BigP01;
            tbM05BigP02.Text=m05.BigP02;
            tbM05BigP03.Text=m05.BigP03;

            tbM05URL01.Text=m05.URL01;
            tbM05URL02.Text=m05.URL02;
            tbM05URL03.Text=m05.URL03;
        }

        /// <summary>
        /// 讲界面值转模型
        /// </summary>
        /// <returns></returns>
        private M05 GetM05()
        {
            M05 m05 = new M05();

            m05.BigP01 = tbM05BigP01.Text;
            m05.BigP02 = tbM05BigP02.Text;
            m05.BigP03 = tbM05BigP03.Text;

            m05.URL01 = tbM05URL01.Text;
            m05.URL02 = tbM05URL02.Text;
            m05.URL03 = tbM05URL03.Text;
            return m05;
        }
    }
}
