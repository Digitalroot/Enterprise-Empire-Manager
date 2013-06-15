namespace EEM
{
  partial class EditLoginInfoScreen
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
      this.label2 = new System.Windows.Forms.Label();
      this.txtUsername = new System.Windows.Forms.TextBox();
      this.btnSave = new System.Windows.Forms.Button();
      this.cbxSavePass = new System.Windows.Forms.CheckBox();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(35, 27);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(58, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Username:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(37, 53);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(56, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Password:";
      // 
      // txtUsername
      // 
      this.txtUsername.Location = new System.Drawing.Point(99, 24);
      this.txtUsername.Name = "txtUsername";
      this.txtUsername.Size = new System.Drawing.Size(100, 20);
      this.txtUsername.TabIndex = 1;
      // 
      // btnSave
      // 
      this.btnSave.Location = new System.Drawing.Point(124, 99);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(75, 23);
      this.btnSave.TabIndex = 5;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // cbxSavePass
      // 
      this.cbxSavePass.AutoSize = true;
      this.cbxSavePass.Location = new System.Drawing.Point(99, 76);
      this.cbxSavePass.Name = "cbxSavePass";
      this.cbxSavePass.Size = new System.Drawing.Size(100, 17);
      this.cbxSavePass.TabIndex = 4;
      this.cbxSavePass.Text = "Save Password";
      this.cbxSavePass.UseVisualStyleBackColor = true;
      // 
      // txtPassword
      // 
      this.txtPassword.Location = new System.Drawing.Point(99, 50);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.PasswordChar = '*';
      this.txtPassword.Size = new System.Drawing.Size(100, 20);
      this.txtPassword.TabIndex = 3;
      // 
      // EditLoginInfoScreen
      // 
      this.AcceptButton = this.btnSave;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(234, 147);
      this.Controls.Add(this.txtPassword);
      this.Controls.Add(this.cbxSavePass);
      this.Controls.Add(this.btnSave);
      this.Controls.Add(this.txtUsername);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "EditLoginInfoScreen";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Edit Login";
      this.TopMost = true;
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtUsername;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.CheckBox cbxSavePass;
    private System.Windows.Forms.TextBox txtPassword;
  }
}