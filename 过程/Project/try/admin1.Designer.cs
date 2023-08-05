namespace 租车管理系统
{
    partial class admin1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.车辆租赁管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.门店管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.门店的车辆信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.订单查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 25);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.车辆租赁管理ToolStripMenuItem,
            this.门店管理ToolStripMenuItem,
            this.门店的车辆信息ToolStripMenuItem,
            this.订单查询ToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(800, 25);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // 车辆租赁管理ToolStripMenuItem
            // 
            this.车辆租赁管理ToolStripMenuItem.Name = "车辆租赁管理ToolStripMenuItem";
            this.车辆租赁管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.车辆租赁管理ToolStripMenuItem.Text = "车辆管理";
            this.车辆租赁管理ToolStripMenuItem.Click += new System.EventHandler(this.车辆租赁管理ToolStripMenuItem_Click);
            // 
            // 门店管理ToolStripMenuItem
            // 
            this.门店管理ToolStripMenuItem.Name = "门店管理ToolStripMenuItem";
            this.门店管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.门店管理ToolStripMenuItem.Text = "门店管理";
            this.门店管理ToolStripMenuItem.Click += new System.EventHandler(this.门店管理ToolStripMenuItem_Click);
            // 
            // 门店的车辆信息ToolStripMenuItem
            // 
            this.门店的车辆信息ToolStripMenuItem.Name = "门店的车辆信息ToolStripMenuItem";
            this.门店的车辆信息ToolStripMenuItem.Size = new System.Drawing.Size(104, 21);
            this.门店的车辆信息ToolStripMenuItem.Text = "门店的车辆信息";
            this.门店的车辆信息ToolStripMenuItem.Click += new System.EventHandler(this.门店的车辆信息ToolStripMenuItem_Click);
            // 
            // 订单查询ToolStripMenuItem
            // 
            this.订单查询ToolStripMenuItem.Name = "订单查询ToolStripMenuItem";
            this.订单查询ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.订单查询ToolStripMenuItem.Text = "订单查询";
            this.订单查询ToolStripMenuItem.Click += new System.EventHandler(this.订单查询ToolStripMenuItem_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("华文中宋", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(190, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "欢迎车辆租赁负责人登陆";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // admin1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "admin1";
            this.Text = "车辆租赁负责人主页面";
            this.Load += new System.EventHandler(this.admin1_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 车辆租赁管理ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 门店管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 订单查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 门店的车辆信息ToolStripMenuItem;
    }
}