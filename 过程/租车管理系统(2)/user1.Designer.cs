namespace 租车管理系统
{
    partial class user1
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.预约车辆ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.到店取车ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.归还车辆ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询订单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统ToolStripMenuItem,
            this.预约车辆ToolStripMenuItem,
            this.到店取车ToolStripMenuItem,
            this.归还车辆ToolStripMenuItem,
            this.查询订单ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            this.menuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip2_ItemClicked);
            // 
            // 系统ToolStripMenuItem
            // 
            this.系统ToolStripMenuItem.Name = "系统ToolStripMenuItem";
            this.系统ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.系统ToolStripMenuItem.Text = "系统";
            // 
            // 预约车辆ToolStripMenuItem
            // 
            this.预约车辆ToolStripMenuItem.Name = "预约车辆ToolStripMenuItem";
            this.预约车辆ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.预约车辆ToolStripMenuItem.Text = "预约车辆";
            this.预约车辆ToolStripMenuItem.Click += new System.EventHandler(this.预约车辆ToolStripMenuItem_Click);
            // 
            // 到店取车ToolStripMenuItem
            // 
            this.到店取车ToolStripMenuItem.Name = "到店取车ToolStripMenuItem";
            this.到店取车ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.到店取车ToolStripMenuItem.Text = "到店取车";
            this.到店取车ToolStripMenuItem.Click += new System.EventHandler(this.到店取车ToolStripMenuItem_Click);
            // 
            // 归还车辆ToolStripMenuItem
            // 
            this.归还车辆ToolStripMenuItem.Name = "归还车辆ToolStripMenuItem";
            this.归还车辆ToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.归还车辆ToolStripMenuItem.Text = "归还车辆与续租车辆";
            this.归还车辆ToolStripMenuItem.Click += new System.EventHandler(this.归还车辆ToolStripMenuItem_Click);
            // 
            // 查询订单ToolStripMenuItem
            // 
            this.查询订单ToolStripMenuItem.Name = "查询订单ToolStripMenuItem";
            this.查询订单ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.查询订单ToolStripMenuItem.Text = "查询订单";
            this.查询订单ToolStripMenuItem.Click += new System.EventHandler(this.查询订单ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // user1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.menuStrip2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "user1";
            this.Text = "用户主页面";
            this.Load += new System.EventHandler(this.user1_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 预约车辆ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 归还车辆ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询订单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 到店取车ToolStripMenuItem;
    }
}