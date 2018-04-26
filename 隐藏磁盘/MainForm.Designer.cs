namespace 隐藏磁盘
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.隐藏磁盘ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.禁用磁盘ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.禁用U盘ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_achieve = new System.Windows.Forms.Button();
            this.gb_exist = new System.Windows.Forms.GroupBox();
            this.gb_noExist = new System.Windows.Forms.GroupBox();
            this.llab_selectAll = new System.Windows.Forms.LinkLabel();
            this.llab_noSeleceAll = new System.Windows.Forms.LinkLabel();
            this.llab_Refresh = new System.Windows.Forms.LinkLabel();
            this.lab_windowEdition = new System.Windows.Forms.Label();
            this.cb_reStartExplore = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.隐藏磁盘ToolStripMenuItem,
            this.禁用磁盘ToolStripMenuItem,
            this.禁用U盘ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 隐藏磁盘ToolStripMenuItem
            // 
            this.隐藏磁盘ToolStripMenuItem.BackColor = System.Drawing.Color.Coral;
            this.隐藏磁盘ToolStripMenuItem.Name = "隐藏磁盘ToolStripMenuItem";
            this.隐藏磁盘ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.隐藏磁盘ToolStripMenuItem.Text = "隐藏磁盘";
            this.隐藏磁盘ToolStripMenuItem.Click += new System.EventHandler(this.磁盘ToolStripMenuItem_Click);
            // 
            // 禁用磁盘ToolStripMenuItem
            // 
            this.禁用磁盘ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.禁用磁盘ToolStripMenuItem.Name = "禁用磁盘ToolStripMenuItem";
            this.禁用磁盘ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.禁用磁盘ToolStripMenuItem.Text = "禁用磁盘";
            this.禁用磁盘ToolStripMenuItem.Click += new System.EventHandler(this.磁盘ToolStripMenuItem_Click);
            // 
            // 禁用U盘ToolStripMenuItem
            // 
            this.禁用U盘ToolStripMenuItem.BackColor = System.Drawing.Color.Lime;
            this.禁用U盘ToolStripMenuItem.Name = "禁用U盘ToolStripMenuItem";
            this.禁用U盘ToolStripMenuItem.Size = new System.Drawing.Size(82, 25);
            this.禁用U盘ToolStripMenuItem.Text = "禁用U盘";
            this.禁用U盘ToolStripMenuItem.Click += new System.EventHandler(this.禁用U盘ToolStripMenuItem_Click);
            // 
            // btn_achieve
            // 
            this.btn_achieve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_achieve.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_achieve.Location = new System.Drawing.Point(180, 225);
            this.btn_achieve.Name = "btn_achieve";
            this.btn_achieve.Size = new System.Drawing.Size(100, 34);
            this.btn_achieve.TabIndex = 1;
            this.btn_achieve.Text = "完成操作";
            this.btn_achieve.UseVisualStyleBackColor = true;
            this.btn_achieve.Click += new System.EventHandler(this.btn_achieve_Click);
            // 
            // gb_exist
            // 
            this.gb_exist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_exist.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb_exist.ForeColor = System.Drawing.Color.SteelBlue;
            this.gb_exist.Location = new System.Drawing.Point(0, 49);
            this.gb_exist.Name = "gb_exist";
            this.gb_exist.Size = new System.Drawing.Size(280, 50);
            this.gb_exist.TabIndex = 4;
            this.gb_exist.TabStop = false;
            this.gb_exist.Text = "已存在磁盘";
            // 
            // gb_noExist
            // 
            this.gb_noExist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_noExist.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gb_noExist.ForeColor = System.Drawing.Color.MidnightBlue;
            this.gb_noExist.Location = new System.Drawing.Point(4, 128);
            this.gb_noExist.Name = "gb_noExist";
            this.gb_noExist.Size = new System.Drawing.Size(280, 50);
            this.gb_noExist.TabIndex = 5;
            this.gb_noExist.TabStop = false;
            this.gb_noExist.Text = "不存在磁盘";
            // 
            // llab_selectAll
            // 
            this.llab_selectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.llab_selectAll.AutoSize = true;
            this.llab_selectAll.Location = new System.Drawing.Point(95, 239);
            this.llab_selectAll.Name = "llab_selectAll";
            this.llab_selectAll.Size = new System.Drawing.Size(29, 12);
            this.llab_selectAll.TabIndex = 6;
            this.llab_selectAll.TabStop = true;
            this.llab_selectAll.Text = "全选";
            this.llab_selectAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llab_selectAll_LinkClicked);
            // 
            // llab_noSeleceAll
            // 
            this.llab_noSeleceAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.llab_noSeleceAll.AutoSize = true;
            this.llab_noSeleceAll.Location = new System.Drawing.Point(130, 239);
            this.llab_noSeleceAll.Name = "llab_noSeleceAll";
            this.llab_noSeleceAll.Size = new System.Drawing.Size(41, 12);
            this.llab_noSeleceAll.TabIndex = 7;
            this.llab_noSeleceAll.TabStop = true;
            this.llab_noSeleceAll.Text = "全不选";
            this.llab_noSeleceAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llab_selectAll_LinkClicked);
            // 
            // llab_Refresh
            // 
            this.llab_Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llab_Refresh.AutoSize = true;
            this.llab_Refresh.Location = new System.Drawing.Point(130, 33);
            this.llab_Refresh.Name = "llab_Refresh";
            this.llab_Refresh.Size = new System.Drawing.Size(29, 12);
            this.llab_Refresh.TabIndex = 8;
            this.llab_Refresh.TabStop = true;
            this.llab_Refresh.Text = "刷新";
            this.llab_Refresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llab_selectAll_LinkClicked);
            // 
            // lab_windowEdition
            // 
            this.lab_windowEdition.AutoSize = true;
            this.lab_windowEdition.Location = new System.Drawing.Point(12, 33);
            this.lab_windowEdition.Name = "lab_windowEdition";
            this.lab_windowEdition.Size = new System.Drawing.Size(89, 12);
            this.lab_windowEdition.TabIndex = 9;
            this.lab_windowEdition.Text = "windowsedition";
            // 
            // cb_reStartExplore
            // 
            this.cb_reStartExplore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_reStartExplore.AutoSize = true;
            this.cb_reStartExplore.Location = new System.Drawing.Point(172, 32);
            this.cb_reStartExplore.Name = "cb_reStartExplore";
            this.cb_reStartExplore.Size = new System.Drawing.Size(108, 16);
            this.cb_reStartExplore.TabIndex = 10;
            this.cb_reStartExplore.Text = "重启任务管理器";
            this.cb_reStartExplore.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.cb_reStartExplore);
            this.Controls.Add(this.lab_windowEdition);
            this.Controls.Add(this.llab_Refresh);
            this.Controls.Add(this.llab_noSeleceAll);
            this.Controls.Add(this.llab_selectAll);
            this.Controls.Add(this.gb_exist);
            this.Controls.Add(this.gb_noExist);
            this.Controls.Add(this.btn_achieve);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "隐藏磁盘";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 隐藏磁盘ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 禁用磁盘ToolStripMenuItem;
        private System.Windows.Forms.Button btn_achieve;
        private System.Windows.Forms.GroupBox gb_exist;
        private System.Windows.Forms.GroupBox gb_noExist;
        private System.Windows.Forms.LinkLabel llab_selectAll;
        private System.Windows.Forms.LinkLabel llab_noSeleceAll;
        private System.Windows.Forms.ToolStripMenuItem 禁用U盘ToolStripMenuItem;
        private System.Windows.Forms.LinkLabel llab_Refresh;
        private System.Windows.Forms.Label lab_windowEdition;
        private System.Windows.Forms.CheckBox cb_reStartExplore;
    }
}

