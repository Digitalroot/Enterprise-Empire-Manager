namespace EEM.Common
{
  partial class LoadingScreen
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
      this.progressBarLoading = new System.Windows.Forms.ProgressBar();
      this.labelLoadingInfo = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // progressBarLoading
      // 
      this.progressBarLoading.Location = new System.Drawing.Point(12, 29);
      this.progressBarLoading.Name = "progressBarLoading";
      this.progressBarLoading.Size = new System.Drawing.Size(100, 23);
      this.progressBarLoading.TabIndex = 0;
      // 
      // labelLoadingInfo
      // 
      this.labelLoadingInfo.AutoSize = true;
      this.labelLoadingInfo.Location = new System.Drawing.Point(13, 13);
      this.labelLoadingInfo.Name = "labelLoadingInfo";
      this.labelLoadingInfo.Size = new System.Drawing.Size(45, 13);
      this.labelLoadingInfo.TabIndex = 1;
      this.labelLoadingInfo.Text = "Loading";
      // 
      // LoadingScreen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(126, 71);
      this.ControlBox = false;
      this.Controls.Add(this.labelLoadingInfo);
      this.Controls.Add(this.progressBarLoading);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "LoadingScreen";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Loading";
      this.TopMost = true;
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    internal System.Windows.Forms.ProgressBar progressBarLoading;
    internal System.Windows.Forms.Label labelLoadingInfo;
  }
}