namespace ProxyWatcher
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuProxy1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuProxy2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuProxy3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "Proxy Watcher";
            this.notifyIcon.ContextMenuStrip = this.contextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Proxy Watcher";
            this.notifyIcon.Visible = true;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuProxy1,
            this.toolStripMenuProxy2,
            this.toolStripMenuProxy3,
            this.toolStripSeparator1,
            this.toolStripMenuExit});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(262, 120);
            // 
            // toolStripMenuProxy1
            // 
            this.toolStripMenuProxy1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripMenuProxy1.Name = "toolStripMenuProxy1";
            this.toolStripMenuProxy1.Size = new System.Drawing.Size(261, 22);
            this.toolStripMenuProxy1.Text = "pac.hannover-re.grp/us7-proxy.pac";
            this.toolStripMenuProxy1.Click += new System.EventHandler(this.ProxySelected);
            // 
            // toolStripMenuProxy2
            // 
            this.toolStripMenuProxy2.Name = "toolStripMenuProxy2";
            this.toolStripMenuProxy2.Size = new System.Drawing.Size(261, 22);
            this.toolStripMenuProxy2.Text = "usproxy.hannover-re.grp/proxy.pac";
            this.toolStripMenuProxy2.Click += new System.EventHandler(this.ProxySelected);
            // 
            // toolStripMenuProxy3
            // 
            this.toolStripMenuProxy3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuProxy3.Name = "toolStripMenuProxy3";
            this.toolStripMenuProxy3.Size = new System.Drawing.Size(261, 22);
            this.toolStripMenuProxy3.Text = "pac.hannover-re.grp/proxy.pac";
            this.toolStripMenuProxy3.Click += new System.EventHandler(this.ProxySelected);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(258, 6);
            // 
            // toolStripMenuExit
            // 
            this.toolStripMenuExit.Name = "toolStripMenuExit";
            this.toolStripMenuExit.Size = new System.Drawing.Size(261, 22);
            this.toolStripMenuExit.Text = "Exit";
            this.toolStripMenuExit.Click += new System.EventHandler(this.toolStripMenuExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 54);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Proxy Watcher";
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuProxy1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuProxy2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuProxy3;
    }
}

