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
    public partial class M04Form : Form
    {
        public M04Form()
        {
            InitializeComponent();
        }

        private void btCreatM04_Click(object sender, EventArgs e)
        {
            String M04ModelPath = Path.Combine(Application.StartupPath, "Modeles\\m04.devm");
            if (!File.Exists(M04ModelPath))
            {
                MessageBox.Show("模板文件不存在！");
                return;
            }
            else
            {
                //读取模板文件
                String M04ModelString = File.ReadAllText(M04ModelPath, Encoding.Default);

                //执行替换操作
                M04ModelString = M04ModelString.Replace("*#*#*#*#BigPA01", tbM04BigPA01.Text);
                M04ModelString = M04ModelString.Replace("*#*#*#*#BigPA02", tbM04BigPA02.Text);
                M04ModelString = M04ModelString.Replace("*#*#*#*#BigPA03", tbM04BigPA03.Text);
                M04ModelString = M04ModelString.Replace("*#*#*#*#BigPA04", tbM04BigPA04.Text);
                M04ModelString = M04ModelString.Replace("*#*#*#*#BigPA05", tbM04BigPA05.Text);
                M04ModelString = M04ModelString.Replace("*#*#*#*#BigPA06", tbM04BigPA06.Text);

                M04ModelString = M04ModelString.Replace("*#*#*#*#BigPB01", tbM04BigPB01.Text);
                M04ModelString = M04ModelString.Replace("*#*#*#*#BigPB02", tbM04BigPB02.Text);
                M04ModelString = M04ModelString.Replace("*#*#*#*#BigPB03", tbM04BigPB03.Text);
                M04ModelString = M04ModelString.Replace("*#*#*#*#BigPB04", tbM04BigPB04.Text);
                M04ModelString = M04ModelString.Replace("*#*#*#*#BigPB05", tbM04BigPB05.Text);
                M04ModelString = M04ModelString.Replace("*#*#*#*#BigPB06", tbM04BigPB06.Text);

                M04ModelString = M04ModelString.Replace("*#*#*#*#URL01", tbM04URL01.Text);
                M04ModelString = M04ModelString.Replace("*#*#*#*#URL02", tbM04URL02.Text);
                M04ModelString = M04ModelString.Replace("*#*#*#*#URL03", tbM04URL03.Text);
                M04ModelString = M04ModelString.Replace("*#*#*#*#URL04", tbM04URL04.Text);
                M04ModelString = M04ModelString.Replace("*#*#*#*#URL05", tbM04URL05.Text);
                M04ModelString = M04ModelString.Replace("*#*#*#*#URL06", tbM04URL06.Text);

                tbM04Code.Text = M04ModelString;
                tbM04Code.SelectAll();
                tbM04Code.Copy();
                tabControl2.SelectedIndex = 2;
                MessageBox.Show("代码已经复制到剪切板，请直接粘贴！");
            }
        }

        private void btExportM04_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "M04模板文件(*.m04)|*.m04";
            String InitialDirectory = Path.Combine(Application.StartupPath, "Saves");
            if (!Directory.Exists(InitialDirectory))
            {
                Directory.CreateDirectory(InitialDirectory);
            }
            sfd.InitialDirectory = InitialDirectory;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                M04 m04 = GetM04();
                try
                {
                    SerialHelper.SaveToXML(sfd.FileName, typeof(M04), m04);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Err:" + ex.Message);
                }
            }
        }

        private void btImportM04_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "M04模板文件(*.m04)|*.m04";
            String InitialDirectory = Path.Combine(Application.StartupPath, "Saves");
            if (!Directory.Exists(InitialDirectory))
            {
                Directory.CreateDirectory(InitialDirectory);
            }
            sfd.InitialDirectory = InitialDirectory;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                M04 m04 = GetM04();
                object o = null;
                try
                {
                    o = SerialHelper.LoadFromXML(sfd.FileName, typeof(M04));
                    if (o is M04)
                    {
                        m04 = o as M04;
                        this.SetM04(m04);
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
        /// <param name="m04"></param>
        private void SetM04(M04 m04)
        {
            tbM04BigPA01.Text = m04.BigPA01;
            tbM04BigPA02.Text = m04.BigPA02;
            tbM04BigPA03.Text = m04.BigPA03;
            tbM04BigPA04.Text = m04.BigPA04;
            tbM04BigPA05.Text = m04.BigPA05;
            tbM04BigPA06.Text = m04.BigPA06;

            tbM04BigPB01.Text = m04.BigPB01;
            tbM04BigPB02.Text = m04.BigPB02;
            tbM04BigPB03.Text = m04.BigPB03;
            tbM04BigPB04.Text = m04.BigPB04;
            tbM04BigPB05.Text = m04.BigPB05;
            tbM04BigPB06.Text = m04.BigPB06;

            tbM04URL01.Text = m04.URL01;
            tbM04URL02.Text = m04.URL02;
            tbM04URL03.Text = m04.URL03;
            tbM04URL04.Text = m04.URL04;
            tbM04URL05.Text = m04.URL05;
            tbM04URL06.Text = m04.URL06;
        }

        /// <summary>
        /// 讲界面值转模型
        /// </summary>
        /// <returns></returns>
        private M04 GetM04()
        {
            M04 m04 = new M04();

            m04.BigPA01 = tbM04BigPA01.Text;
            m04.BigPA02 = tbM04BigPA02.Text;
            m04.BigPA03 = tbM04BigPA03.Text;
            m04.BigPA04 = tbM04BigPA04.Text;
            m04.BigPA05 = tbM04BigPA05.Text;
            m04.BigPA06 = tbM04BigPA06.Text;

            m04.BigPB01 = tbM04BigPB01.Text;
            m04.BigPB02 = tbM04BigPB02.Text;
            m04.BigPB03 = tbM04BigPB03.Text;
            m04.BigPB04 = tbM04BigPB04.Text;
            m04.BigPB05 = tbM04BigPB05.Text;
            m04.BigPB06 = tbM04BigPB06.Text;

            m04.URL01 = tbM04URL01.Text;
            m04.URL02 = tbM04URL02.Text;
            m04.URL03 = tbM04URL03.Text;
            m04.URL04 = tbM04URL04.Text;
            m04.URL05 = tbM04URL05.Text;
            m04.URL06 = tbM04URL06.Text;
            return m04;
        }

    }
}
