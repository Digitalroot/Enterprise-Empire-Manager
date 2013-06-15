namespace EEM.Plugin.Notifications
{
  partial class MainScreen
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
        this.label1 = new System.Windows.Forms.Label();
        this.txt_EmailTo = new System.Windows.Forms.TextBox();
        this.txt_EmailFrom = new System.Windows.Forms.TextBox();
        this.label2 = new System.Windows.Forms.Label();
        this.txt_SMTPServer = new System.Windows.Forms.TextBox();
        this.label3 = new System.Windows.Forms.Label();
        this.txt_EmailUser = new System.Windows.Forms.TextBox();
        this.lbl_user = new System.Windows.Forms.Label();
        this.cb_AuthRequired = new System.Windows.Forms.CheckBox();
        this.txt_EmailPass = new System.Windows.Forms.TextBox();
        this.lbl_pass = new System.Windows.Forms.Label();
        this.cb_SendEmail = new System.Windows.Forms.CheckBox();
        this.btn_TestEmail = new System.Windows.Forms.Button();
        this.lbl_emailerror = new System.Windows.Forms.Label();
        this.btn_Refresh = new System.Windows.Forms.Button();
        this.tabPage3 = new System.Windows.Forms.TabPage();
        this.txt_Summary = new System.Windows.Forms.TextBox();
        this.tabPage2 = new System.Windows.Forms.TabPage();
        this.grid_Player = new System.Windows.Forms.DataGridView();
        this.tabPage1 = new System.Windows.Forms.TabPage();
        this.grid_All = new System.Windows.Forms.DataGridView();
        this.tabControl1 = new System.Windows.Forms.TabControl();
        this.tabPage4 = new System.Windows.Forms.TabPage();
        this.txt_PlayerSummary = new System.Windows.Forms.TextBox();
        this.lbl_Incoming = new System.Windows.Forms.Label();
        this.lbl_NotificationInterval = new System.Windows.Forms.Label();
        this.num_NotificationInterval = new System.Windows.Forms.NumericUpDown();
        this.lbl_NotificationHelp = new System.Windows.Forms.Label();
        this.cb_SSL = new System.Windows.Forms.CheckBox();
        this.num_TestIncoming = new System.Windows.Forms.NumericUpDown();
        this.tabPage3.SuspendLayout();
        this.tabPage2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.grid_Player)).BeginInit();
        this.tabPage1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.grid_All)).BeginInit();
        this.tabControl1.SuspendLayout();
        this.tabPage4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.num_NotificationInterval)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.num_TestIncoming)).BeginInit();
        this.SuspendLayout();
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(13, 13);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(51, 13);
        this.label1.TabIndex = 1;
        this.label1.Text = "Email To:";
        // 
        // txt_EmailTo
        // 
        this.txt_EmailTo.Location = new System.Drawing.Point(13, 30);
        this.txt_EmailTo.Name = "txt_EmailTo";
        this.txt_EmailTo.Size = new System.Drawing.Size(158, 20);
        this.txt_EmailTo.TabIndex = 1;
        this.txt_EmailTo.TextChanged += new System.EventHandler(this.txt_EmailTo_TextChanged);
        // 
        // txt_EmailFrom
        // 
        this.txt_EmailFrom.Location = new System.Drawing.Point(13, 70);
        this.txt_EmailFrom.Name = "txt_EmailFrom";
        this.txt_EmailFrom.Size = new System.Drawing.Size(158, 20);
        this.txt_EmailFrom.TabIndex = 2;
        this.txt_EmailFrom.TextChanged += new System.EventHandler(this.txt_EmailFrom_TextChanged);
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(13, 53);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(61, 13);
        this.label2.TabIndex = 3;
        this.label2.Text = "Email From:";
        // 
        // txt_SMTPServer
        // 
        this.txt_SMTPServer.Location = new System.Drawing.Point(13, 110);
        this.txt_SMTPServer.Name = "txt_SMTPServer";
        this.txt_SMTPServer.Size = new System.Drawing.Size(158, 20);
        this.txt_SMTPServer.TabIndex = 3;
        this.txt_SMTPServer.TextChanged += new System.EventHandler(this.txt_SMTPServer_TextChanged);
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(13, 93);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(74, 13);
        this.label3.TabIndex = 5;
        this.label3.Text = "SMTP Server:";
        // 
        // txt_EmailUser
        // 
        this.txt_EmailUser.Location = new System.Drawing.Point(25, 192);
        this.txt_EmailUser.Name = "txt_EmailUser";
        this.txt_EmailUser.Size = new System.Drawing.Size(146, 20);
        this.txt_EmailUser.TabIndex = 6;
        this.txt_EmailUser.TextChanged += new System.EventHandler(this.txt_EmailUser_TextChanged);
        // 
        // lbl_user
        // 
        this.lbl_user.AutoSize = true;
        this.lbl_user.Location = new System.Drawing.Point(22, 176);
        this.lbl_user.Name = "lbl_user";
        this.lbl_user.Size = new System.Drawing.Size(58, 13);
        this.lbl_user.TabIndex = 7;
        this.lbl_user.Text = "Username:";
        // 
        // cb_AuthRequired
        // 
        this.cb_AuthRequired.AutoSize = true;
        this.cb_AuthRequired.Location = new System.Drawing.Point(16, 156);
        this.cb_AuthRequired.Name = "cb_AuthRequired";
        this.cb_AuthRequired.Size = new System.Drawing.Size(100, 17);
        this.cb_AuthRequired.TabIndex = 5;
        this.cb_AuthRequired.Text = "Auth Required?";
        this.cb_AuthRequired.UseVisualStyleBackColor = true;
        this.cb_AuthRequired.CheckedChanged += new System.EventHandler(this.cb_AuthRequired_CheckedChanged);
        // 
        // txt_EmailPass
        // 
        this.txt_EmailPass.Location = new System.Drawing.Point(25, 231);
        this.txt_EmailPass.Name = "txt_EmailPass";
        this.txt_EmailPass.Size = new System.Drawing.Size(146, 20);
        this.txt_EmailPass.TabIndex = 7;
        this.txt_EmailPass.UseSystemPasswordChar = true;
        this.txt_EmailPass.TextChanged += new System.EventHandler(this.txt_EmailPass_TextChanged);
        // 
        // lbl_pass
        // 
        this.lbl_pass.AutoSize = true;
        this.lbl_pass.Location = new System.Drawing.Point(22, 215);
        this.lbl_pass.Name = "lbl_pass";
        this.lbl_pass.Size = new System.Drawing.Size(56, 13);
        this.lbl_pass.TabIndex = 10;
        this.lbl_pass.Text = "Password:";
        // 
        // cb_SendEmail
        // 
        this.cb_SendEmail.AutoSize = true;
        this.cb_SendEmail.Location = new System.Drawing.Point(12, 317);
        this.cb_SendEmail.Name = "cb_SendEmail";
        this.cb_SendEmail.Size = new System.Drawing.Size(118, 17);
        this.cb_SendEmail.TabIndex = 9;
        this.cb_SendEmail.Text = "Send Notifications?";
        this.cb_SendEmail.UseVisualStyleBackColor = true;
        this.cb_SendEmail.CheckedChanged += new System.EventHandler(this.cb_SendEmail_CheckedChanged);
        // 
        // btn_TestEmail
        // 
        this.btn_TestEmail.Location = new System.Drawing.Point(97, 257);
        this.btn_TestEmail.Name = "btn_TestEmail";
        this.btn_TestEmail.Size = new System.Drawing.Size(75, 23);
        this.btn_TestEmail.TabIndex = 8;
        this.btn_TestEmail.Text = "Test Email";
        this.btn_TestEmail.UseVisualStyleBackColor = true;
        this.btn_TestEmail.Click += new System.EventHandler(this.btn_TestEmail_Click);
        // 
        // lbl_emailerror
        // 
        this.lbl_emailerror.AutoSize = true;
        this.lbl_emailerror.Location = new System.Drawing.Point(10, 289);
        this.lbl_emailerror.Name = "lbl_emailerror";
        this.lbl_emailerror.Size = new System.Drawing.Size(0, 13);
        this.lbl_emailerror.TabIndex = 14;
        // 
        // btn_Refresh
        // 
        this.btn_Refresh.Location = new System.Drawing.Point(823, 3);
        this.btn_Refresh.Name = "btn_Refresh";
        this.btn_Refresh.Size = new System.Drawing.Size(75, 23);
        this.btn_Refresh.TabIndex = 16;
        this.btn_Refresh.Text = "Refresh";
        this.btn_Refresh.UseVisualStyleBackColor = true;
        this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
        // 
        // tabPage3
        // 
        this.tabPage3.Controls.Add(this.txt_Summary);
        this.tabPage3.Location = new System.Drawing.Point(4, 22);
        this.tabPage3.Name = "tabPage3";
        this.tabPage3.Size = new System.Drawing.Size(719, 362);
        this.tabPage3.TabIndex = 2;
        this.tabPage3.Text = "Alliance Summary";
        this.tabPage3.UseVisualStyleBackColor = true;
        // 
        // txt_Summary
        // 
        this.txt_Summary.Location = new System.Drawing.Point(0, 0);
        this.txt_Summary.Multiline = true;
        this.txt_Summary.Name = "txt_Summary";
        this.txt_Summary.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        this.txt_Summary.Size = new System.Drawing.Size(719, 362);
        this.txt_Summary.TabIndex = 0;
        // 
        // tabPage2
        // 
        this.tabPage2.Controls.Add(this.grid_Player);
        this.tabPage2.Location = new System.Drawing.Point(4, 22);
        this.tabPage2.Name = "tabPage2";
        this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage2.Size = new System.Drawing.Size(719, 362);
        this.tabPage2.TabIndex = 1;
        this.tabPage2.Text = "Player Incoming";
        this.tabPage2.UseVisualStyleBackColor = true;
        // 
        // grid_Player
        // 
        this.grid_Player.AllowUserToAddRows = false;
        this.grid_Player.AllowUserToDeleteRows = false;
        this.grid_Player.AllowUserToOrderColumns = true;
        this.grid_Player.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.grid_Player.Dock = System.Windows.Forms.DockStyle.Fill;
        this.grid_Player.Location = new System.Drawing.Point(3, 3);
        this.grid_Player.Name = "grid_Player";
        this.grid_Player.ReadOnly = true;
        this.grid_Player.Size = new System.Drawing.Size(713, 356);
        this.grid_Player.TabIndex = 1;
        // 
        // tabPage1
        // 
        this.tabPage1.Controls.Add(this.grid_All);
        this.tabPage1.Location = new System.Drawing.Point(4, 22);
        this.tabPage1.Name = "tabPage1";
        this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage1.Size = new System.Drawing.Size(719, 362);
        this.tabPage1.TabIndex = 0;
        this.tabPage1.Text = "All Incoming";
        this.tabPage1.UseVisualStyleBackColor = true;
        // 
        // grid_All
        // 
        this.grid_All.AllowUserToAddRows = false;
        this.grid_All.AllowUserToOrderColumns = true;
        this.grid_All.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.grid_All.Dock = System.Windows.Forms.DockStyle.Fill;
        this.grid_All.Location = new System.Drawing.Point(3, 3);
        this.grid_All.Name = "grid_All";
        this.grid_All.ReadOnly = true;
        this.grid_All.Size = new System.Drawing.Size(713, 356);
        this.grid_All.TabIndex = 0;
        // 
        // tabControl1
        // 
        this.tabControl1.Controls.Add(this.tabPage1);
        this.tabControl1.Controls.Add(this.tabPage3);
        this.tabControl1.Controls.Add(this.tabPage2);
        this.tabControl1.Controls.Add(this.tabPage4);
        this.tabControl1.Location = new System.Drawing.Point(178, 13);
        this.tabControl1.Name = "tabControl1";
        this.tabControl1.SelectedIndex = 0;
        this.tabControl1.Size = new System.Drawing.Size(727, 388);
        this.tabControl1.TabIndex = 15;
        // 
        // tabPage4
        // 
        this.tabPage4.Controls.Add(this.txt_PlayerSummary);
        this.tabPage4.Location = new System.Drawing.Point(4, 22);
        this.tabPage4.Name = "tabPage4";
        this.tabPage4.Size = new System.Drawing.Size(719, 362);
        this.tabPage4.TabIndex = 3;
        this.tabPage4.Text = "Player Summary";
        this.tabPage4.UseVisualStyleBackColor = true;
        // 
        // txt_PlayerSummary
        // 
        this.txt_PlayerSummary.Location = new System.Drawing.Point(0, 2);
        this.txt_PlayerSummary.Multiline = true;
        this.txt_PlayerSummary.Name = "txt_PlayerSummary";
        this.txt_PlayerSummary.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        this.txt_PlayerSummary.Size = new System.Drawing.Size(716, 360);
        this.txt_PlayerSummary.TabIndex = 1;
        // 
        // lbl_Incoming
        // 
        this.lbl_Incoming.AutoSize = true;
        this.lbl_Incoming.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lbl_Incoming.Location = new System.Drawing.Point(646, 7);
        this.lbl_Incoming.Name = "lbl_Incoming";
        this.lbl_Incoming.Size = new System.Drawing.Size(155, 20);
        this.lbl_Incoming.TabIndex = 17;
        this.lbl_Incoming.Text = "Waiting for Results...";
        // 
        // lbl_NotificationInterval
        // 
        this.lbl_NotificationInterval.AutoSize = true;
        this.lbl_NotificationInterval.Location = new System.Drawing.Point(12, 337);
        this.lbl_NotificationInterval.Name = "lbl_NotificationInterval";
        this.lbl_NotificationInterval.Size = new System.Drawing.Size(98, 13);
        this.lbl_NotificationInterval.TabIndex = 18;
        this.lbl_NotificationInterval.Text = "Notification Interval";
        // 
        // num_NotificationInterval
        // 
        this.num_NotificationInterval.Location = new System.Drawing.Point(16, 354);
        this.num_NotificationInterval.Name = "num_NotificationInterval";
        this.num_NotificationInterval.Size = new System.Drawing.Size(48, 20);
        this.num_NotificationInterval.TabIndex = 10;
        this.num_NotificationInterval.ValueChanged += new System.EventHandler(this.num_NotificationInterval_ValueChanged);
        // 
        // lbl_NotificationHelp
        // 
        this.lbl_NotificationHelp.Location = new System.Drawing.Point(70, 356);
        this.lbl_NotificationHelp.Name = "lbl_NotificationHelp";
        this.lbl_NotificationHelp.Size = new System.Drawing.Size(101, 44);
        this.lbl_NotificationHelp.TabIndex = 20;
        this.lbl_NotificationHelp.Text = "# of incoming before sending each notification";
        // 
        // cb_SSL
        // 
        this.cb_SSL.AutoSize = true;
        this.cb_SSL.Location = new System.Drawing.Point(16, 133);
        this.cb_SSL.Name = "cb_SSL";
        this.cb_SSL.Size = new System.Drawing.Size(98, 17);
        this.cb_SSL.TabIndex = 4;
        this.cb_SSL.Text = "SSL Required?";
        this.cb_SSL.UseVisualStyleBackColor = true;
        this.cb_SSL.CheckedChanged += new System.EventHandler(this.cb_SSL_CheckedChanged);
        // 
        // num_TestIncoming
        // 
        this.num_TestIncoming.Location = new System.Drawing.Point(522, 4);
        this.num_TestIncoming.Name = "num_TestIncoming";
        this.num_TestIncoming.Size = new System.Drawing.Size(48, 20);
        this.num_TestIncoming.TabIndex = 21;
        this.num_TestIncoming.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
        this.num_TestIncoming.Visible = false;
        // 
        // MainScreen
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(907, 405);
        this.Controls.Add(this.num_TestIncoming);
        this.Controls.Add(this.cb_SSL);
        this.Controls.Add(this.lbl_NotificationHelp);
        this.Controls.Add(this.num_NotificationInterval);
        this.Controls.Add(this.lbl_NotificationInterval);
        this.Controls.Add(this.lbl_Incoming);
        this.Controls.Add(this.btn_Refresh);
        this.Controls.Add(this.tabControl1);
        this.Controls.Add(this.lbl_emailerror);
        this.Controls.Add(this.btn_TestEmail);
        this.Controls.Add(this.cb_SendEmail);
        this.Controls.Add(this.txt_EmailPass);
        this.Controls.Add(this.lbl_pass);
        this.Controls.Add(this.cb_AuthRequired);
        this.Controls.Add(this.txt_EmailUser);
        this.Controls.Add(this.lbl_user);
        this.Controls.Add(this.txt_SMTPServer);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.txt_EmailFrom);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.txt_EmailTo);
        this.Controls.Add(this.label1);
        this.Name = "MainScreen";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Notifications";
        this.tabPage3.ResumeLayout(false);
        this.tabPage3.PerformLayout();
        this.tabPage2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.grid_Player)).EndInit();
        this.tabPage1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.grid_All)).EndInit();
        this.tabControl1.ResumeLayout(false);
        this.tabPage4.ResumeLayout(false);
        this.tabPage4.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.num_NotificationInterval)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.num_TestIncoming)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txt_EmailTo;
    private System.Windows.Forms.TextBox txt_EmailFrom;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txt_SMTPServer;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txt_EmailUser;
    private System.Windows.Forms.Label lbl_user;
    private System.Windows.Forms.CheckBox cb_AuthRequired;
    private System.Windows.Forms.TextBox txt_EmailPass;
    private System.Windows.Forms.Label lbl_pass;
    private System.Windows.Forms.CheckBox cb_SendEmail;
    private System.Windows.Forms.Button btn_TestEmail;
    private System.Windows.Forms.Label lbl_emailerror;
    private System.Windows.Forms.Button btn_Refresh;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.DataGridView grid_All;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.DataGridView grid_Player;
    private System.Windows.Forms.TextBox txt_Summary;
    private System.Windows.Forms.TabPage tabPage4;
    private System.Windows.Forms.TextBox txt_PlayerSummary;
    private System.Windows.Forms.Label lbl_Incoming;
    private System.Windows.Forms.Label lbl_NotificationInterval;
    private System.Windows.Forms.NumericUpDown num_NotificationInterval;
    private System.Windows.Forms.Label lbl_NotificationHelp;
    private System.Windows.Forms.CheckBox cb_SSL;
    private System.Windows.Forms.NumericUpDown num_TestIncoming;

  }
}