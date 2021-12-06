namespace Server
{
    partial class serverForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.log_LB = new System.Windows.Forms.ListBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.disconnectBtn = new System.Windows.Forms.Button();
            this.port_TB = new System.Windows.Forms.TextBox();
            this.ip_TB = new System.Windows.Forms.TextBox();
            this.port_Lab = new System.Windows.Forms.Label();
            this.ip_Lab = new System.Windows.Forms.Label();
            this.onlineList_LB = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // log_LB
            // 
            this.log_LB.FormattingEnabled = true;
            this.log_LB.ItemHeight = 12;
            this.log_LB.Location = new System.Drawing.Point(309, 20);
            this.log_LB.Margin = new System.Windows.Forms.Padding(2);
            this.log_LB.Name = "log_LB";
            this.log_LB.Size = new System.Drawing.Size(367, 424);
            this.log_LB.TabIndex = 0;
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(33, 69);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(105, 35);
            this.connectBtn.TabIndex = 3;
            this.connectBtn.Text = "建立連線";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // disconnectBtn
            // 
            this.disconnectBtn.Enabled = false;
            this.disconnectBtn.Location = new System.Drawing.Point(158, 69);
            this.disconnectBtn.Name = "disconnectBtn";
            this.disconnectBtn.Size = new System.Drawing.Size(105, 35);
            this.disconnectBtn.TabIndex = 4;
            this.disconnectBtn.Text = "中斷連線";
            this.disconnectBtn.UseVisualStyleBackColor = true;
            this.disconnectBtn.Click += new System.EventHandler(this.disconnectBtn_Click);
            // 
            // port_TB
            // 
            this.port_TB.Location = new System.Drawing.Point(191, 26);
            this.port_TB.Name = "port_TB";
            this.port_TB.Size = new System.Drawing.Size(100, 22);
            this.port_TB.TabIndex = 6;
            this.port_TB.Text = "5236";
            // 
            // ip_TB
            // 
            this.ip_TB.Location = new System.Drawing.Point(42, 26);
            this.ip_TB.Name = "ip_TB";
            this.ip_TB.Size = new System.Drawing.Size(100, 22);
            this.ip_TB.TabIndex = 5;
            this.ip_TB.Text = "127.0.0.1";
            // 
            // port_Lab
            // 
            this.port_Lab.AutoSize = true;
            this.port_Lab.Location = new System.Drawing.Point(155, 30);
            this.port_Lab.Name = "port_Lab";
            this.port_Lab.Size = new System.Drawing.Size(30, 12);
            this.port_Lab.TabIndex = 8;
            this.port_Lab.Text = "Port :";
            this.port_Lab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ip_Lab
            // 
            this.ip_Lab.AutoSize = true;
            this.ip_Lab.Location = new System.Drawing.Point(16, 29);
            this.ip_Lab.Name = "ip_Lab";
            this.ip_Lab.Size = new System.Drawing.Size(21, 12);
            this.ip_Lab.TabIndex = 7;
            this.ip_Lab.Text = "IP :";
            this.ip_Lab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // onlineList_LB
            // 
            this.onlineList_LB.FormattingEnabled = true;
            this.onlineList_LB.ItemHeight = 12;
            this.onlineList_LB.Location = new System.Drawing.Point(42, 128);
            this.onlineList_LB.Margin = new System.Windows.Forms.Padding(2);
            this.onlineList_LB.Name = "onlineList_LB";
            this.onlineList_LB.Size = new System.Drawing.Size(214, 316);
            this.onlineList_LB.TabIndex = 9;
            // 
            // serverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 466);
            this.Controls.Add(this.onlineList_LB);
            this.Controls.Add(this.port_Lab);
            this.Controls.Add(this.ip_Lab);
            this.Controls.Add(this.port_TB);
            this.Controls.Add(this.ip_TB);
            this.Controls.Add(this.disconnectBtn);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.log_LB);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "serverForm";
            this.Text = "聊天室 Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.serverForm_FormClosed);
            this.Load += new System.EventHandler(this.serverForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox log_LB;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Button disconnectBtn;
        private System.Windows.Forms.TextBox port_TB;
        private System.Windows.Forms.TextBox ip_TB;
        private System.Windows.Forms.Label port_Lab;
        private System.Windows.Forms.Label ip_Lab;
        private System.Windows.Forms.ListBox onlineList_LB;
    }
}

