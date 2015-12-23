namespace DEVGIS.ModelMaker
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("TOP9营销榜", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("20切换大图", 2);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("8宫格三色", 3);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("6图不规则开关", 4);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("3屏滚动", 5);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("关于", 1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.lvMenu = new System.Windows.Forms.ListView();
            this.imageListMain = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lvMenu
            // 
            this.lvMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMenu.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            listViewItem1.Tag = "m01";
            listViewItem2.Tag = "m03";
            listViewItem3.Tag = "m02";
            listViewItem4.Tag = "m04";
            listViewItem5.Tag = "m05";
            listViewItem6.Tag = "about";
            this.lvMenu.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6});
            this.lvMenu.LargeImageList = this.imageListMain;
            this.lvMenu.Location = new System.Drawing.Point(0, 0);
            this.lvMenu.Name = "lvMenu";
            this.lvMenu.Size = new System.Drawing.Size(587, 389);
            this.lvMenu.TabIndex = 0;
            this.lvMenu.UseCompatibleStateImageBehavior = false;
            this.lvMenu.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvMenu_MouseDoubleClick);
            // 
            // imageListMain
            // 
            this.imageListMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMain.ImageStream")));
            this.imageListMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMain.Images.SetKeyName(0, "p01.png");
            this.imageListMain.Images.SetKeyName(1, "about.png");
            this.imageListMain.Images.SetKeyName(2, "p03.png");
            this.imageListMain.Images.SetKeyName(3, "p02.png");
            this.imageListMain.Images.SetKeyName(4, "p04.png");
            this.imageListMain.Images.SetKeyName(5, "p05.png");
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 389);
            this.Controls.Add(this.lvMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DEVGIS淘宝代码生成器-官方店flysoft.taobao.com-免费版";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvMenu;
        private System.Windows.Forms.ImageList imageListMain;
    }
}