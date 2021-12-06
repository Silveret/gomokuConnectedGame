namespace Client
{
    partial class Form1
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
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.port_Lab = new System.Windows.Forms.Label();
            this.serverIP_Lab = new System.Windows.Forms.Label();
            this.port_TB = new System.Windows.Forms.TextBox();
            this.serverIP_TB = new System.Windows.Forms.TextBox();
            this.entry_Btn = new System.Windows.Forms.Button();
            this.log_LB = new System.Windows.Forms.ListBox();
            this.message_TB = new System.Windows.Forms.TextBox();
            this.nickname_Lab = new System.Windows.Forms.Label();
            this.nickname_TB = new System.Windows.Forms.TextBox();
            this.onlineList_LB = new System.Windows.Forms.ListBox();
            this.onlineList_Lab = new System.Windows.Forms.Label();
            this.message_Lab = new System.Windows.Forms.Label();
            this.DMon = new System.Windows.Forms.Button();
            this.DM2_Lab = new System.Windows.Forms.Label();
            this.DMoff = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // port_Lab
            // 
            this.port_Lab.AutoSize = true;
            this.port_Lab.Location = new System.Drawing.Point(1024, 93);
            this.port_Lab.Name = "port_Lab";
            this.port_Lab.Size = new System.Drawing.Size(30, 12);
            this.port_Lab.TabIndex = 12;
            this.port_Lab.Text = "Port :";
            this.port_Lab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // serverIP_Lab
            // 
            this.serverIP_Lab.AutoSize = true;
            this.serverIP_Lab.Location = new System.Drawing.Point(852, 92);
            this.serverIP_Lab.Name = "serverIP_Lab";
            this.serverIP_Lab.Size = new System.Drawing.Size(54, 12);
            this.serverIP_Lab.TabIndex = 11;
            this.serverIP_Lab.Text = "Server IP :";
            this.serverIP_Lab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // port_TB
            // 
            this.port_TB.Location = new System.Drawing.Point(1060, 89);
            this.port_TB.Name = "port_TB";
            this.port_TB.Size = new System.Drawing.Size(100, 22);
            this.port_TB.TabIndex = 10;
            this.port_TB.Text = "5236";
            // 
            // serverIP_TB
            // 
            this.serverIP_TB.Location = new System.Drawing.Point(911, 89);
            this.serverIP_TB.Name = "serverIP_TB";
            this.serverIP_TB.Size = new System.Drawing.Size(100, 22);
            this.serverIP_TB.TabIndex = 9;
            this.serverIP_TB.Text = "127.0.0.1";
            // 
            // entry_Btn
            // 
            this.entry_Btn.Location = new System.Drawing.Point(1065, 123);
            this.entry_Btn.Name = "entry_Btn";
            this.entry_Btn.Size = new System.Drawing.Size(84, 31);
            this.entry_Btn.TabIndex = 13;
            this.entry_Btn.Text = "Enter";
            this.entry_Btn.UseVisualStyleBackColor = true;
            this.entry_Btn.Click += new System.EventHandler(this.entry_Btn_Click);
            // 
            // log_LB
            // 
            this.log_LB.FormattingEnabled = true;
            this.log_LB.ItemHeight = 12;
            this.log_LB.Location = new System.Drawing.Point(1026, 171);
            this.log_LB.Margin = new System.Windows.Forms.Padding(2);
            this.log_LB.Name = "log_LB";
            this.log_LB.Size = new System.Drawing.Size(434, 364);
            this.log_LB.TabIndex = 14;
            // 
            // message_TB
            // 
            this.message_TB.Location = new System.Drawing.Point(1091, 554);
            this.message_TB.Name = "message_TB";
            this.message_TB.Size = new System.Drawing.Size(369, 22);
            this.message_TB.TabIndex = 16;
            this.message_TB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.message_TB_KeyUp);
            // 
            // nickname_Lab
            // 
            this.nickname_Lab.AutoSize = true;
            this.nickname_Lab.Location = new System.Drawing.Point(852, 135);
            this.nickname_Lab.Name = "nickname_Lab";
            this.nickname_Lab.Size = new System.Drawing.Size(58, 12);
            this.nickname_Lab.TabIndex = 18;
            this.nickname_Lab.Text = "Nickname :";
            this.nickname_Lab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nickname_TB
            // 
            this.nickname_TB.Location = new System.Drawing.Point(911, 132);
            this.nickname_TB.Name = "nickname_TB";
            this.nickname_TB.Size = new System.Drawing.Size(100, 22);
            this.nickname_TB.TabIndex = 17;
            // 
            // onlineList_LB
            // 
            this.onlineList_LB.FormattingEnabled = true;
            this.onlineList_LB.ItemHeight = 12;
            this.onlineList_LB.Location = new System.Drawing.Point(783, 219);
            this.onlineList_LB.Margin = new System.Windows.Forms.Padding(2);
            this.onlineList_LB.Name = "onlineList_LB";
            this.onlineList_LB.Size = new System.Drawing.Size(214, 316);
            this.onlineList_LB.TabIndex = 19;
            // 
            // onlineList_Lab
            // 
            this.onlineList_Lab.AutoSize = true;
            this.onlineList_Lab.Location = new System.Drawing.Point(852, 192);
            this.onlineList_Lab.Name = "onlineList_Lab";
            this.onlineList_Lab.Size = new System.Drawing.Size(56, 12);
            this.onlineList_Lab.TabIndex = 20;
            this.onlineList_Lab.Text = "Online List";
            this.onlineList_Lab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // message_Lab
            // 
            this.message_Lab.AutoSize = true;
            this.message_Lab.Location = new System.Drawing.Point(1035, 559);
            this.message_Lab.Name = "message_Lab";
            this.message_Lab.Size = new System.Drawing.Size(50, 12);
            this.message_Lab.TabIndex = 21;
            this.message_Lab.Text = "Message :";
            this.message_Lab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DMon
            // 
            this.DMon.Location = new System.Drawing.Point(794, 540);
            this.DMon.Name = "DMon";
            this.DMon.Size = new System.Drawing.Size(72, 31);
            this.DMon.TabIndex = 22;
            this.DMon.Text = "DM";
            this.DMon.UseVisualStyleBackColor = true;
            this.DMon.Click += new System.EventHandler(this.DMon_Click);
            // 
            // DM2_Lab
            // 
            this.DM2_Lab.AutoSize = true;
            this.DM2_Lab.Location = new System.Drawing.Point(954, 557);
            this.DM2_Lab.Name = "DM2_Lab";
            this.DM2_Lab.Size = new System.Drawing.Size(0, 12);
            this.DM2_Lab.TabIndex = 23;
            this.DM2_Lab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DMoff
            // 
            this.DMoff.Enabled = false;
            this.DMoff.Location = new System.Drawing.Point(872, 545);
            this.DMoff.Name = "DMoff";
            this.DMoff.Size = new System.Drawing.Size(72, 31);
            this.DMoff.TabIndex = 24;
            this.DMoff.Text = "Cansel DM";
            this.DMoff.UseVisualStyleBackColor = true;
            this.DMoff.Click += new System.EventHandler(this.DMoff_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.board;
            this.ClientSize = new System.Drawing.Size(1471, 745);
            this.Controls.Add(this.DMoff);
            this.Controls.Add(this.DM2_Lab);
            this.Controls.Add(this.DMon);
            this.Controls.Add(this.message_Lab);
            this.Controls.Add(this.onlineList_Lab);
            this.Controls.Add(this.onlineList_LB);
            this.Controls.Add(this.nickname_Lab);
            this.Controls.Add(this.nickname_TB);
            this.Controls.Add(this.message_TB);
            this.Controls.Add(this.log_LB);
            this.Controls.Add(this.entry_Btn);
            this.Controls.Add(this.port_Lab);
            this.Controls.Add(this.serverIP_Lab);
            this.Controls.Add(this.port_TB);
            this.Controls.Add(this.serverIP_TB);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "聊天室 Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.clientForm_FormClosing);
            this.Load += new System.EventHandler(this.clientForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label nickname_Lab;
        private System.Windows.Forms.TextBox nickname_TB;
        private System.Windows.Forms.TextBox message_TB;
        private System.Windows.Forms.ListBox log_LB;
        private System.Windows.Forms.Button entry_Btn;
        private System.Windows.Forms.Label port_Lab;
        private System.Windows.Forms.Label serverIP_Lab;
        private System.Windows.Forms.TextBox port_TB;
        private System.Windows.Forms.TextBox serverIP_TB;
        private System.Windows.Forms.Label onlineList_Lab;
        private System.Windows.Forms.ListBox onlineList_LB;
        private System.Windows.Forms.Label message_Lab;
        private System.Windows.Forms.Button DMon;
        private System.Windows.Forms.Label DM2_Lab;
        private System.Windows.Forms.Button DMoff;
    }
}

