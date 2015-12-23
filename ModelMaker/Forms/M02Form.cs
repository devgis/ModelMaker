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
    public partial class M02Form : Form
    {
        public M02Form()
        {
            InitializeComponent();
        }

        private void btCreatM02_Click(object sender, EventArgs e)
        {
            String M02ModelPath = Path.Combine(Application.StartupPath, "Modeles\\m02.devm");
            if (!File.Exists(M02ModelPath))
            {
                MessageBox.Show("模板文件不存在！");
                return;
            }
            else
            {
                //读取模板文件
                String M02ModelString = File.ReadAllText(M02ModelPath, Encoding.Default);

                //执行替换操作
                M02ModelString = M02ModelString.Replace("*#*#*#*#BigPA01", tbM02BigPA01.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#BigPA02", tbM02BigPA02.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#BigPA03", tbM02BigPA03.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#BigPA04", tbM02BigPA04.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#BigPA05", tbM02BigPA05.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#BigPA06", tbM02BigPA06.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#BigPA07", tbM02BigPA07.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#BigPA08", tbM02BigPA08.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#BigPB01", tbM02BigPB01.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#BigPB02", tbM02BigPB02.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#BigPB03", tbM02BigPB03.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#BigPB04", tbM02BigPB04.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#BigPB05", tbM02BigPB05.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#BigPB06", tbM02BigPB06.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#BigPB07", tbM02BigPB07.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#BigPB08", tbM02BigPB08.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#BigPC01", tbM02BigPC01.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#BigPC02", tbM02BigPC02.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#BigPC03", tbM02BigPC03.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#BigPC04", tbM02BigPC04.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#BigPC05", tbM02BigPC05.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#BigPC06", tbM02BigPC06.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#BigPC07", tbM02BigPC07.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#BigPC08", tbM02BigPC08.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#URL01", tbM02URL01.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#URL02", tbM02URL02.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#URL03", tbM02URL03.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#URL04", tbM02URL04.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#URL05", tbM02URL05.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#URL06", tbM02URL06.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#URL07", tbM02URL07.Text);
                M02ModelString = M02ModelString.Replace("*#*#*#*#URL08", tbM02URL08.Text);
                tbM02Code.Text = M02ModelString;
                tbM02Code.SelectAll();
                tbM02Code.Copy();
                tabControl2.SelectedIndex = 2;
                MessageBox.Show("代码已经复制到剪切板，请直接粘贴！");
            }
        }

        private void btExportM02_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "M02模板文件(*.m02)|*.m02";
            String InitialDirectory = Path.Combine(Application.StartupPath, "Saves");
            if (!Directory.Exists(InitialDirectory))
            {
                Directory.CreateDirectory(InitialDirectory);
            }
            sfd.InitialDirectory = InitialDirectory;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                M02 m02 = GetM02();
                try
                {
                    SerialHelper.SaveToXML(sfd.FileName, typeof(M02), m02);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Err:" + ex.Message);
                }
            }
        }

        private void btImportM02_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "M02模板文件(*.m02)|*.m02";
            String InitialDirectory = Path.Combine(Application.StartupPath, "Saves");
            if (!Directory.Exists(InitialDirectory))
            {
                Directory.CreateDirectory(InitialDirectory);
            }
            sfd.InitialDirectory = InitialDirectory;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                M02 m02 = GetM02();
                object o = null;
                try
                {
                    o = SerialHelper.LoadFromXML(sfd.FileName, typeof(M02));
                    if (o is M02)
                    {
                        m02 = o as M02;
                        this.SetM02(m02);
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
        /// <param name="m02"></param>
        private void SetM02(M02 m02)
        {
            tbM02BigPA01.Text = m02.BigPA01;
            tbM02BigPA02.Text = m02.BigPA02;
            tbM02BigPA03.Text = m02.BigPA03;
            tbM02BigPA04.Text = m02.BigPA04;
            tbM02BigPA05.Text = m02.BigPA05;
            tbM02BigPA06.Text = m02.BigPA06;
            tbM02BigPA07.Text = m02.BigPA07;
            tbM02BigPA08.Text = m02.BigPA08;

            tbM02BigPB01.Text = m02.BigPB01;
            tbM02BigPB02.Text = m02.BigPB02;
            tbM02BigPB03.Text = m02.BigPB03;
            tbM02BigPB04.Text = m02.BigPB04;
            tbM02BigPB05.Text = m02.BigPB05;
            tbM02BigPB06.Text = m02.BigPB06;
            tbM02BigPB07.Text = m02.BigPB07;
            tbM02BigPB08.Text = m02.BigPB08;

            tbM02BigPC01.Text = m02.BigPC01;
            tbM02BigPC02.Text = m02.BigPC02;
            tbM02BigPC03.Text = m02.BigPC03;
            tbM02BigPC04.Text = m02.BigPC04;
            tbM02BigPC05.Text = m02.BigPC05;
            tbM02BigPC06.Text = m02.BigPC06;
            tbM02BigPC07.Text = m02.BigPC07;
            tbM02BigPC08.Text = m02.BigPC08;

            tbM02URL01.Text = m02.URL01;
            tbM02URL02.Text = m02.URL02;
            tbM02URL03.Text = m02.URL03;
            tbM02URL04.Text = m02.URL04;
            tbM02URL05.Text = m02.URL05;
            tbM02URL06.Text = m02.URL06;
            tbM02URL07.Text = m02.URL07;
            tbM02URL08.Text = m02.URL08;
        }

        /// <summary>
        /// 讲界面值转模型
        /// </summary>
        /// <returns></returns>
        private M02 GetM02()
        {
            M02 m02 = new M02();

            m02.BigPA01 = tbM02BigPA01.Text;
            m02.BigPA02 = tbM02BigPA02.Text;
            m02.BigPA03 = tbM02BigPA03.Text;
            m02.BigPA04 = tbM02BigPA04.Text;
            m02.BigPA05 = tbM02BigPA05.Text;
            m02.BigPA06 = tbM02BigPA06.Text;
            m02.BigPA07 = tbM02BigPA07.Text;
            m02.BigPA08 = tbM02BigPA08.Text;

            m02.BigPB01 = tbM02BigPB01.Text;
            m02.BigPB02 = tbM02BigPB02.Text;
            m02.BigPB03 = tbM02BigPB03.Text;
            m02.BigPB04 = tbM02BigPB04.Text;
            m02.BigPB05 = tbM02BigPB05.Text;
            m02.BigPB06 = tbM02BigPB06.Text;
            m02.BigPB07 = tbM02BigPB07.Text;
            m02.BigPB08 = tbM02BigPB08.Text;

            m02.BigPC01 = tbM02BigPC01.Text;
            m02.BigPC02 = tbM02BigPC02.Text;
            m02.BigPC03 = tbM02BigPC03.Text;
            m02.BigPC04 = tbM02BigPC04.Text;
            m02.BigPC05 = tbM02BigPC05.Text;
            m02.BigPC06 = tbM02BigPC06.Text;
            m02.BigPC07 = tbM02BigPC07.Text;
            m02.BigPC08 = tbM02BigPC08.Text;

            m02.URL01 = tbM02URL01.Text;
            m02.URL02 = tbM02URL02.Text;
            m02.URL03 = tbM02URL03.Text;
            m02.URL04 = tbM02URL04.Text;
            m02.URL05 = tbM02URL05.Text;
            m02.URL06 = tbM02URL06.Text;
            m02.URL07 = tbM02URL07.Text;
            m02.URL08 = tbM02URL08.Text;

            return m02;
        }
    }
}
