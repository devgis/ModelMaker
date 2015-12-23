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
    public partial class M03Form : Form
    {
        public M03Form()
        {
            InitializeComponent();
        }

        private void btExportM03_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "M03模板文件(*.m03)|*.m03";
            String InitialDirectory = Path.Combine(Application.StartupPath, "Saves");
            if (!Directory.Exists(InitialDirectory))
            {
                Directory.CreateDirectory(InitialDirectory);
            }
            sfd.InitialDirectory = InitialDirectory;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                M03 m03 = GetM03();
                try
                {
                    SerialHelper.SaveToXML(sfd.FileName, typeof(M03), m03);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Err:" + ex.Message);
                }
            }
        }

        private void btImportM03_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "M03模板文件(*.m03)|*.m03";
            String InitialDirectory = Path.Combine(Application.StartupPath, "Saves");
            if (!Directory.Exists(InitialDirectory))
            {
                Directory.CreateDirectory(InitialDirectory);
            }
            sfd.InitialDirectory = InitialDirectory;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                M03 m03 = GetM03();
                object o = null;
                try
                {
                    o = SerialHelper.LoadFromXML(sfd.FileName, typeof(M03));
                    if (o is M03)
                    {
                        m03 = o as M03;
                        this.SetM03(m03);
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

        private void btCreatM03_Click(object sender, EventArgs e)
        {
            String M03ModelPath = Path.Combine(Application.StartupPath, "Modeles\\m03.devm");
            if (!File.Exists(M03ModelPath))
            {
                MessageBox.Show("模板文件不存在！");
                return;
            }
            else
            {
                //读取模板文件
                String M03ModelString = File.ReadAllText(M03ModelPath, Encoding.Default);

                //执行替换操作
                M03ModelString = M03ModelString.Replace("*#*#*#*#SMALLP01", tbM03SmallP01.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#SMALLP02", tbM03SmallP02.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#SMALLP03", tbM03SmallP03.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#SMALLP04", tbM03SmallP04.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#SMALLP05", tbM03SmallP05.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#SMALLP06", tbM03SmallP06.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#SMALLP07", tbM03SmallP07.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#SMALLP08", tbM03SmallP08.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#SMALLP09", tbM03SmallP09.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#SMALLP10", tbM03SmallP10.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#SMALLP11", tbM03SmallP11.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#SMALLP12", tbM03SmallP12.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#SMALLP13", tbM03SmallP13.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#SMALLP14", tbM03SmallP14.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#SMALLP15", tbM03SmallP15.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#SMALLP16", tbM03SmallP16.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#SMALLP17", tbM03SmallP17.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#SMALLP18", tbM03SmallP18.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#SMALLP19", tbM03SmallP19.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#SMALLP20", tbM03SmallP20.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#BIGP01", tbM03BigP01.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#BIGP02", tbM03BigP02.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#BIGP03", tbM03BigP03.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#BIGP04", tbM03BigP04.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#BIGP05", tbM03BigP05.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#BIGP06", tbM03BigP06.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#BIGP07", tbM03BigP07.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#BIGP08", tbM03BigP08.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#BIGP09", tbM03BigP09.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#BIGP10", tbM03BigP10.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#BIGP11", tbM03BigP11.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#BIGP12", tbM03BigP12.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#BIGP13", tbM03BigP13.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#BIGP14", tbM03BigP14.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#BIGP15", tbM03BigP15.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#BIGP16", tbM03BigP16.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#BIGP17", tbM03BigP17.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#BIGP18", tbM03BigP18.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#BIGP19", tbM03BigP19.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#BIGP20", tbM03BigP20.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#URL01", tbM03URL01.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#URL02", tbM03URL02.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#URL03", tbM03URL03.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#URL04", tbM03URL04.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#URL05", tbM03URL05.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#URL06", tbM03URL06.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#URL07", tbM03URL07.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#URL08", tbM03URL08.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#URL09", tbM03URL09.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#URL10", tbM03URL10.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#URL11", tbM03URL11.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#URL12", tbM03URL12.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#URL13", tbM03URL13.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#URL14", tbM03URL14.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#URL15", tbM03URL15.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#URL16", tbM03URL16.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#URL17", tbM03URL17.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#URL18", tbM03URL18.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#URL19", tbM03URL19.Text);
                M03ModelString = M03ModelString.Replace("*#*#*#*#URL20", tbM03URL20.Text);
                tbM03Code.Text = M03ModelString;
                tbM03Code.SelectAll();
                tbM03Code.Copy();
                tabControl2.SelectedIndex = 2;
                MessageBox.Show("代码已经复制到剪切板，请直接粘贴！");
            }
        }

        /// <summary>
        /// 讲模板值设置到界面
        /// </summary>
        /// <param name="m03"></param>
        private void SetM03(M03 m03)
        {
            tbM03BigP01.Text = m03.BigP01;
            tbM03BigP02.Text = m03.BigP02;
            tbM03BigP03.Text = m03.BigP03;
            tbM03BigP04.Text = m03.BigP04;
            tbM03BigP05.Text = m03.BigP05;
            tbM03BigP06.Text = m03.BigP06;
            tbM03BigP07.Text = m03.BigP07;
            tbM03BigP08.Text = m03.BigP08;
            tbM03BigP09.Text = m03.BigP09;
            tbM03BigP10.Text = m03.BigP10;
            tbM03BigP11.Text = m03.BigP11;
            tbM03BigP12.Text = m03.BigP12;
            tbM03BigP13.Text = m03.BigP13;
            tbM03BigP14.Text = m03.BigP14;
            tbM03BigP15.Text = m03.BigP15;
            tbM03BigP16.Text = m03.BigP16;
            tbM03BigP17.Text = m03.BigP17;
            tbM03BigP18.Text = m03.BigP18;
            tbM03BigP19.Text = m03.BigP19;
            tbM03BigP20.Text = m03.BigP20;

            tbM03SmallP01.Text = m03.SmallP01;
            tbM03SmallP02.Text = m03.SmallP02;
            tbM03SmallP03.Text = m03.SmallP03;
            tbM03SmallP04.Text = m03.SmallP04;
            tbM03SmallP05.Text = m03.SmallP05;
            tbM03SmallP06.Text = m03.SmallP06;
            tbM03SmallP07.Text = m03.SmallP07;
            tbM03SmallP08.Text = m03.SmallP08;
            tbM03SmallP09.Text = m03.SmallP09;
            tbM03SmallP10.Text = m03.SmallP10;
            tbM03SmallP11.Text = m03.SmallP11;
            tbM03SmallP12.Text = m03.SmallP12;
            tbM03SmallP13.Text = m03.SmallP13;
            tbM03SmallP14.Text = m03.SmallP14;
            tbM03SmallP15.Text = m03.SmallP15;
            tbM03SmallP16.Text = m03.SmallP16;
            tbM03SmallP17.Text = m03.SmallP17;
            tbM03SmallP18.Text = m03.SmallP18;
            tbM03SmallP19.Text = m03.SmallP19;
            tbM03SmallP20.Text = m03.SmallP20;

            tbM03URL01.Text = m03.URL01;
            tbM03URL02.Text = m03.URL02;
            tbM03URL03.Text = m03.URL03;
            tbM03URL04.Text = m03.URL04;
            tbM03URL05.Text = m03.URL05;
            tbM03URL06.Text = m03.URL06;
            tbM03URL07.Text = m03.URL07;
            tbM03URL08.Text = m03.URL08;
            tbM03URL09.Text = m03.URL09;
            tbM03URL10.Text = m03.URL10;
            tbM03URL11.Text = m03.URL11;
            tbM03URL12.Text = m03.URL12;
            tbM03URL13.Text = m03.URL13;
            tbM03URL14.Text = m03.URL14;
            tbM03URL15.Text = m03.URL15;
            tbM03URL16.Text = m03.URL16;
            tbM03URL17.Text = m03.URL17;
            tbM03URL18.Text = m03.URL18;
            tbM03URL19.Text = m03.URL19;
            tbM03URL20.Text = m03.URL20;
        }

        /// <summary>
        /// 讲界面值转模型
        /// </summary>
        /// <returns></returns>
        private M03 GetM03()
        {
            M03 m03 = new M03();
            m03.BigP01 = tbM03BigP01.Text;
            m03.BigP02 = tbM03BigP02.Text;
            m03.BigP03 = tbM03BigP03.Text;
            m03.BigP04 = tbM03BigP04.Text;
            m03.BigP05 = tbM03BigP05.Text;
            m03.BigP06 = tbM03BigP06.Text;
            m03.BigP07 = tbM03BigP07.Text;
            m03.BigP08 = tbM03BigP08.Text;
            m03.BigP09 = tbM03SmallP09.Text;
            m03.BigP10 = tbM03SmallP10.Text;
            m03.BigP11 = tbM03BigP11.Text;
            m03.BigP12 = tbM03BigP12.Text;
            m03.BigP13 = tbM03BigP13.Text;
            m03.BigP14 = tbM03BigP14.Text;
            m03.BigP15 = tbM03BigP15.Text;
            m03.BigP16 = tbM03BigP16.Text;
            m03.BigP17 = tbM03BigP17.Text;
            m03.BigP18 = tbM03BigP18.Text;
            m03.BigP19 = tbM03BigP19.Text;
            m03.BigP20 = tbM03BigP20.Text;

            m03.SmallP01 = tbM03SmallP01.Text;
            m03.SmallP02 = tbM03SmallP02.Text;
            m03.SmallP03 = tbM03SmallP03.Text;
            m03.SmallP04 = tbM03SmallP04.Text;
            m03.SmallP05 = tbM03SmallP05.Text;
            m03.SmallP06 = tbM03SmallP06.Text;
            m03.SmallP07 = tbM03SmallP07.Text;
            m03.SmallP08 = tbM03SmallP08.Text;
            m03.SmallP09 = tbM03SmallP09.Text;
            m03.SmallP10 = tbM03SmallP10.Text;
            m03.SmallP11 = tbM03SmallP11.Text;
            m03.SmallP12 = tbM03SmallP12.Text;
            m03.SmallP13 = tbM03SmallP13.Text;
            m03.SmallP14 = tbM03SmallP14.Text;
            m03.SmallP15 = tbM03SmallP15.Text;
            m03.SmallP16 = tbM03SmallP16.Text;
            m03.SmallP17 = tbM03SmallP17.Text;
            m03.SmallP18 = tbM03SmallP18.Text;
            m03.SmallP19 = tbM03SmallP19.Text;
            m03.SmallP20 = tbM03SmallP20.Text;

            m03.URL01 = tbM03URL01.Text;
            m03.URL02 = tbM03URL02.Text;
            m03.URL03 = tbM03URL03.Text;
            m03.URL04 = tbM03URL04.Text;
            m03.URL05 = tbM03URL05.Text;
            m03.URL06 = tbM03URL06.Text;
            m03.URL07 = tbM03URL07.Text;
            m03.URL08 = tbM03URL08.Text;
            m03.URL09 = tbM03URL09.Text;
            m03.URL10 = tbM03URL10.Text;
            m03.URL11 = tbM03URL11.Text;
            m03.URL12 = tbM03URL12.Text;
            m03.URL13 = tbM03URL13.Text;
            m03.URL14 = tbM03URL14.Text;
            m03.URL15 = tbM03URL15.Text;
            m03.URL16 = tbM03URL16.Text;
            m03.URL17 = tbM03URL17.Text;
            m03.URL18 = tbM03URL18.Text;
            m03.URL19 = tbM03URL19.Text;
            m03.URL20 = tbM03URL20.Text;
            return m03;
        }

    }
}
