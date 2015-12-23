using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DEVGIS.ModelMaker.Entities;
using DEVGIS.ModelMaker.Common;

namespace DEVGIS.ModelMaker.Forms
{
    public partial class M01Form : Form
    {
        public M01Form()
        {
            InitializeComponent();
        }

        private void btCreatM01_Click(object sender, EventArgs e)
        {
            String M01ModelPath = Path.Combine(Application.StartupPath, "Modeles\\m01.devm");
            if (!File.Exists(M01ModelPath))
            {
                MessageBox.Show("模板文件不存在！");
                return;
            }
            else
            {
                //读取模板文件
                String M01ModelString = File.ReadAllText(M01ModelPath, Encoding.Default);

                //执行替换操作
                M01ModelString=M01ModelString.Replace("*#*#*#*#SMALLP01", tbM01SmallP01.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#BIGP01", tbM01BigP01.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#REMARKS01", tbM01Remarks01.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#PRICE01", tbM01Price01.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#URL01", tbM01URL01.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#SMALLP02", tbM01SmallP02.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#BIGP02", tbM01BigP02.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#REMARKS02", tbM01Remarks02.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#PRICE02", tbM01Price02.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#URL02", tbM01URL02.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#SMALLP03", tbM01SmallP03.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#BIGP03", tbM01BigP03.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#REMARKS03", tbM01Remarks03.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#PRICE03", tbM01Price03.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#URL03", tbM01URL03.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#SMALLP04", tbM01SmallP04.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#BIGP04", tbM01BigP04.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#REMARKS04", tbM01Remarks04.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#PRICE04", tbM01Price04.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#URL04", tbM01URL04.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#SMALLP05", tbM01SmallP05.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#BIGP05", tbM01BigP05.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#REMARKS05", tbM01Remarks05.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#PRICE05", tbM01Price05.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#URL05", tbM01URL05.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#SMALLP06", tbM01SmallP06.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#BIGP06", tbM01BigP06.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#REMARKS06", tbM01Remarks06.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#PRICE06", tbM01Price06.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#URL06", tbM01URL06.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#SMALLP07", tbM01SmallP07.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#BIGP07", tbM01BigP07.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#REMARKS07", tbM01Remarks07.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#PRICE07", tbM01Price07.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#URL07", tbM01URL07.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#SMALLP08", tbM01SmallP08.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#BIGP08", tbM01BigP08.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#REMARKS08", tbM01Remarks08.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#PRICE08", tbM01Price08.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#URL08", tbM01URL08.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#SMALLP09", tbM01SmallP09.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#BIGP09", tbM01BigP09.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#REMARKS09", tbM01Remarks09.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#PRICE09", tbM01Price09.Text);
                M01ModelString=M01ModelString.Replace("*#*#*#*#URL09", tbM01URL09.Text);

                tbM01Code.Text = M01ModelString;
                tbM01Code.SelectAll();
                tbM01Code.Copy();
                tabControl2.SelectedIndex = 2;
                MessageBox.Show("代码已经复制到剪切板，请直接粘贴！");
            }
            
        }

        private void btExportM01_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "M01模板文件(*.m01)|*.m01"; 
            String InitialDirectory=Path.Combine(Application.StartupPath,"Saves");
            if(!Directory.Exists(InitialDirectory))
            {
                Directory.CreateDirectory(InitialDirectory);
            }
            sfd.InitialDirectory = InitialDirectory;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                M01 m01 =GetM01();
                try
                {
                    SerialHelper.SaveToXML(sfd.FileName, typeof(M01), m01);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Err:"+ex.Message);
                }
            }
        }

        /// <summary>
        /// 讲模板值设置到界面
        /// </summary>
        /// <param name="m01"></param>
        private void SetM01(M01 m01)
        {
            tbM01BigP01.Text = m01.BigP01;
            tbM01BigP02.Text = m01.BigP02;
            tbM01BigP03.Text = m01.BigP03;
            tbM01BigP04.Text = m01.BigP04;
            tbM01BigP05.Text = m01.BigP05;
            tbM01BigP06.Text = m01.BigP06;
            tbM01BigP07.Text = m01.BigP07;
            tbM01BigP08.Text = m01.BigP08;
            tbM01BigP09.Text = m01.BigP09;

            tbM01Price01.Text = m01.Price01;
            tbM01Price02.Text = m01.Price02;
            tbM01Price03.Text = m01.Price03;
            tbM01Price04.Text = m01.Price04;
            tbM01Price05.Text = m01.Price05;
            tbM01Price06.Text = m01.Price06;
            tbM01Price07.Text = m01.Price07;
            tbM01Price08.Text = m01.Price08;
            tbM01Price09.Text = m01.Price09;

            tbM01Remarks01.Text = m01.Remarks01;
            tbM01Remarks02.Text = m01.Remarks02;
            tbM01Remarks03.Text = m01.Remarks03;
            tbM01Remarks04.Text = m01.Remarks04;
            tbM01Remarks05.Text = m01.Remarks05;
            tbM01Remarks06.Text = m01.Remarks06;
            tbM01Remarks07.Text = m01.Remarks07;
            tbM01Remarks08.Text = m01.Remarks08;
            tbM01Remarks09.Text = m01.Remarks09;

            tbM01SmallP01.Text = m01.SmallP01;
            tbM01SmallP02.Text = m01.SmallP02;
            tbM01SmallP03.Text = m01.SmallP03;
            tbM01SmallP04.Text = m01.SmallP04;
            tbM01SmallP05.Text = m01.SmallP05;
            tbM01SmallP06.Text = m01.SmallP06;
            tbM01SmallP07.Text = m01.SmallP07;
            tbM01SmallP08.Text = m01.SmallP08;
            tbM01SmallP09.Text = m01.SmallP09;

            tbM01URL01.Text = m01.URL01;
            tbM01URL02.Text = m01.URL02;
            tbM01URL03.Text = m01.URL03;
            tbM01URL04.Text = m01.URL04;
            tbM01URL05.Text = m01.URL05;
            tbM01URL06.Text = m01.URL06;
            tbM01URL07.Text = m01.URL07;
            tbM01URL08.Text = m01.URL08;
            tbM01URL09.Text = m01.URL09;
        }

        /// <summary>
        /// 讲界面值转模型
        /// </summary>
        /// <returns></returns>
        private M01 GetM01()
        {
            M01 m01 = new M01();

            m01.BigP01 = tbM01BigP01.Text;
            m01.BigP02 = tbM01BigP02.Text;
            m01.BigP03 = tbM01BigP03.Text;
            m01.BigP04 = tbM01BigP04.Text;
            m01.BigP05 = tbM01BigP05.Text;
            m01.BigP06 = tbM01BigP06.Text;
            m01.BigP07 = tbM01BigP07.Text;
            m01.BigP08 = tbM01BigP08.Text;
            m01.BigP09 = tbM01BigP09.Text;

            m01.Price01 = tbM01Price01.Text;
            m01.Price02 = tbM01Price02.Text;
            m01.Price03 = tbM01Price03.Text;
            m01.Price04 = tbM01Price04.Text;
            m01.Price05 = tbM01Price05.Text;
            m01.Price06 = tbM01Price06.Text;
            m01.Price07 = tbM01Price07.Text;
            m01.Price08 = tbM01Price08.Text;
            m01.Price09 = tbM01Price09.Text;

            m01.Remarks01 = tbM01Remarks01.Text;
            m01.Remarks02 = tbM01Remarks02.Text;
            m01.Remarks03 = tbM01Remarks03.Text;
            m01.Remarks04 = tbM01Remarks04.Text;
            m01.Remarks05 = tbM01Remarks05.Text;
            m01.Remarks06 = tbM01Remarks06.Text;
            m01.Remarks07 = tbM01Remarks07.Text;
            m01.Remarks08 = tbM01Remarks08.Text;
            m01.Remarks09 = tbM01Remarks09.Text;

            m01.SmallP01 = tbM01SmallP01.Text;
            m01.SmallP02 = tbM01SmallP02.Text;
            m01.SmallP03 = tbM01SmallP03.Text;
            m01.SmallP04 = tbM01SmallP04.Text;
            m01.SmallP05 = tbM01SmallP05.Text;
            m01.SmallP06 = tbM01SmallP06.Text;
            m01.SmallP07 = tbM01SmallP07.Text;
            m01.SmallP08 = tbM01SmallP08.Text;
            m01.SmallP09 = tbM01SmallP09.Text;

            m01.URL01 = tbM01URL01.Text;
            m01.URL02 = tbM01URL02.Text;
            m01.URL03 = tbM01URL03.Text;
            m01.URL04 = tbM01URL04.Text;
            m01.URL05 = tbM01URL05.Text;
            m01.URL06 = tbM01URL06.Text;
            m01.URL07 = tbM01URL07.Text;
            m01.URL08 = tbM01URL08.Text;
            m01.URL09 = tbM01URL09.Text;

            return m01;
        }

        private void btImportM01_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "M01模板文件(*.m01)|*.m01";
            String InitialDirectory = Path.Combine(Application.StartupPath, "Saves");
            if (!Directory.Exists(InitialDirectory))
            {
                Directory.CreateDirectory(InitialDirectory);
            }
            sfd.InitialDirectory = InitialDirectory;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                M01 m01 = GetM01();
                object o = null;
                try
                {
                    o=SerialHelper.LoadFromXML(sfd.FileName,typeof(M01));
                    if (o is M01)
                    {
                        m01 = o as M01;
                        this.SetM01(m01);
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
    }
}
