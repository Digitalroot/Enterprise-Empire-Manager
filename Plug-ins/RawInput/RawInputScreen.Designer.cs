namespace EEM.Plugin.RawInput
{
  partial class RawInputScreen
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
      this.SendButton = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.txtInput = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtUrl = new System.Windows.Forms.TextBox();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.ResultBox = new System.Windows.Forms.TextBox();
      this.tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // SendButton
      // 
      this.SendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.SendButton.Location = new System.Drawing.Point(587, 63);
      this.SendButton.Name = "SendButton";
      this.SendButton.Size = new System.Drawing.Size(75, 23);
      this.SendButton.TabIndex = 0;
      this.SendButton.Text = "Send";
      this.SendButton.UseVisualStyleBackColor = true;
      this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label1.Location = new System.Drawing.Point(3, 0);
      this.label1.Name = "label1";
      this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
      this.label1.Size = new System.Drawing.Size(91, 27);
      this.label1.TabIndex = 1;
      this.label1.Text = "Enter Raw Input:";
      // 
      // txtInput
      // 
      this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtInput.Location = new System.Drawing.Point(100, 3);
      this.txtInput.Name = "txtInput";
      this.txtInput.Size = new System.Drawing.Size(556, 20);
      this.txtInput.TabIndex = 2;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label2.Location = new System.Drawing.Point(3, 27);
      this.label2.Name = "label2";
      this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
      this.label2.Size = new System.Drawing.Size(91, 27);
      this.label2.TabIndex = 3;
      this.label2.Text = "Url To Send To:";
      // 
      // txtUrl
      // 
      this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtUrl.Location = new System.Drawing.Point(100, 30);
      this.txtUrl.Name = "txtUrl";
      this.txtUrl.Size = new System.Drawing.Size(556, 20);
      this.txtUrl.TabIndex = 4;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.SendButton, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.ResultBox, 0, 2);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(665, 404);
      this.tableLayoutPanel1.TabIndex = 5;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 2;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.Controls.Add(this.txtInput, 1, 0);
      this.tableLayoutPanel2.Controls.Add(this.txtUrl, 1, 1);
      this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
      this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 2;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(659, 54);
      this.tableLayoutPanel2.TabIndex = 0;
      // 
      // ResultBox
      // 
      this.ResultBox.BackColor = System.Drawing.SystemColors.Window;
      this.ResultBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ResultBox.Location = new System.Drawing.Point(3, 92);
      this.ResultBox.Multiline = true;
      this.ResultBox.Name = "ResultBox";
      this.ResultBox.Size = new System.Drawing.Size(659, 309);
      this.ResultBox.TabIndex = 1;
      // 
      // RawInputScreen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(665, 404);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "RawInputScreen";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Raw Input";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tableLayoutPanel2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button SendButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtInput;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtUrl;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.TextBox ResultBox;
  }
}