namespace EEM
{
  partial class OptionsScreen
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
      this.textBoxGameServer = new System.Windows.Forms.TextBox();
      this.buttonSave = new System.Windows.Forms.Button();
      this.checkBoxConnectOnStartUp = new System.Windows.Forms.CheckBox();
      this.checkBoxMinToSysTray = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(341, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Your Game Server URL: (i.e. \"http://prodgame01.lordofultima.com/7\" )";
      // 
      // textBoxGameServer
      // 
      this.textBoxGameServer.Location = new System.Drawing.Point(16, 30);
      this.textBoxGameServer.Name = "textBoxGameServer";
      this.textBoxGameServer.Size = new System.Drawing.Size(338, 20);
      this.textBoxGameServer.TabIndex = 1;
      this.textBoxGameServer.Text = "http://prodgame01.lordofultima.com/7";
      // 
      // buttonSave
      // 
      this.buttonSave.Location = new System.Drawing.Point(279, 79);
      this.buttonSave.Name = "buttonSave";
      this.buttonSave.Size = new System.Drawing.Size(75, 23);
      this.buttonSave.TabIndex = 4;
      this.buttonSave.Text = "Save";
      this.buttonSave.UseVisualStyleBackColor = true;
      this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
      // 
      // checkBoxConnectOnStartUp
      // 
      this.checkBoxConnectOnStartUp.AutoSize = true;
      this.checkBoxConnectOnStartUp.Location = new System.Drawing.Point(16, 56);
      this.checkBoxConnectOnStartUp.Name = "checkBoxConnectOnStartUp";
      this.checkBoxConnectOnStartUp.Size = new System.Drawing.Size(118, 17);
      this.checkBoxConnectOnStartUp.TabIndex = 5;
      this.checkBoxConnectOnStartUp.Text = "Connect on Startup";
      this.checkBoxConnectOnStartUp.UseVisualStyleBackColor = true;
      // 
      // checkBoxMinToSysTray
      // 
      this.checkBoxMinToSysTray.AutoSize = true;
      this.checkBoxMinToSysTray.Location = new System.Drawing.Point(16, 79);
      this.checkBoxMinToSysTray.Name = "checkBoxMinToSysTray";
      this.checkBoxMinToSysTray.Size = new System.Drawing.Size(139, 17);
      this.checkBoxMinToSysTray.TabIndex = 6;
      this.checkBoxMinToSysTray.Text = "Minimize to System Tray";
      this.checkBoxMinToSysTray.UseVisualStyleBackColor = true;
      // 
      // OptionsScreen
      // 
      this.AcceptButton = this.buttonSave;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(375, 111);
      this.Controls.Add(this.checkBoxMinToSysTray);
      this.Controls.Add(this.checkBoxConnectOnStartUp);
      this.Controls.Add(this.buttonSave);
      this.Controls.Add(this.textBoxGameServer);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "OptionsScreen";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Options:";
      this.TopMost = true;
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBoxGameServer;
    private System.Windows.Forms.Button buttonSave;
    private System.Windows.Forms.CheckBox checkBoxConnectOnStartUp;
    private System.Windows.Forms.CheckBox checkBoxMinToSysTray;
  }
}