namespace EEM
{
  partial class LoadedPluginsScreen
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
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.treeViewLoadedPlugins = new System.Windows.Forms.TreeView();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.textBoxDescript = new System.Windows.Forms.TextBox();
      this.labelAuthor = new System.Windows.Forms.Label();
      this.labelVersion = new System.Windows.Forms.Label();
      this.labelPluginName = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.treeViewLoadedPlugins);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.AutoScroll = true;
      this.splitContainer1.Panel2.Controls.Add(this.label4);
      this.splitContainer1.Panel2.Controls.Add(this.label3);
      this.splitContainer1.Panel2.Controls.Add(this.label2);
      this.splitContainer1.Panel2.Controls.Add(this.label1);
      this.splitContainer1.Panel2.Controls.Add(this.textBoxDescript);
      this.splitContainer1.Panel2.Controls.Add(this.labelAuthor);
      this.splitContainer1.Panel2.Controls.Add(this.labelVersion);
      this.splitContainer1.Panel2.Controls.Add(this.labelPluginName);
      this.splitContainer1.Size = new System.Drawing.Size(493, 389);
      this.splitContainer1.SplitterDistance = 232;
      this.splitContainer1.TabIndex = 0;
      // 
      // treeViewLoadedPlugins
      // 
      this.treeViewLoadedPlugins.Dock = System.Windows.Forms.DockStyle.Fill;
      this.treeViewLoadedPlugins.Location = new System.Drawing.Point(0, 0);
      this.treeViewLoadedPlugins.Name = "treeViewLoadedPlugins";
      this.treeViewLoadedPlugins.Size = new System.Drawing.Size(232, 389);
      this.treeViewLoadedPlugins.TabIndex = 0;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(7, 100);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(63, 13);
      this.label4.TabIndex = 7;
      this.label4.Text = "Description:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(7, 73);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(76, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "Plug-in Author:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(7, 43);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(80, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Plug-in Version:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(7, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(73, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Plug-in Name:";
      // 
      // textBoxDescript
      // 
      this.textBoxDescript.Location = new System.Drawing.Point(10, 116);
      this.textBoxDescript.Multiline = true;
      this.textBoxDescript.Name = "textBoxDescript";
      this.textBoxDescript.ReadOnly = true;
      this.textBoxDescript.Size = new System.Drawing.Size(235, 259);
      this.textBoxDescript.TabIndex = 3;
      // 
      // labelAuthor
      // 
      this.labelAuthor.AutoSize = true;
      this.labelAuthor.Location = new System.Drawing.Point(90, 73);
      this.labelAuthor.Name = "labelAuthor";
      this.labelAuthor.Size = new System.Drawing.Size(73, 13);
      this.labelAuthor.TabIndex = 2;
      this.labelAuthor.Text = "Plug-in Author";
      // 
      // labelVersion
      // 
      this.labelVersion.AutoSize = true;
      this.labelVersion.Location = new System.Drawing.Point(90, 43);
      this.labelVersion.Name = "labelVersion";
      this.labelVersion.Size = new System.Drawing.Size(77, 13);
      this.labelVersion.TabIndex = 1;
      this.labelVersion.Text = "Plug-in Version";
      // 
      // labelPluginName
      // 
      this.labelPluginName.AutoSize = true;
      this.labelPluginName.Location = new System.Drawing.Point(90, 13);
      this.labelPluginName.Name = "labelPluginName";
      this.labelPluginName.Size = new System.Drawing.Size(70, 13);
      this.labelPluginName.TabIndex = 0;
      this.labelPluginName.Text = "Plug-in Name";
      // 
      // LoadedPluginsScreen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(493, 389);
      this.Controls.Add(this.splitContainer1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "LoadedPluginsScreen";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Loaded Plug-ins:";
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.TreeView treeViewLoadedPlugins;
    private System.Windows.Forms.TextBox textBoxDescript;
    private System.Windows.Forms.Label labelAuthor;
    private System.Windows.Forms.Label labelVersion;
    private System.Windows.Forms.Label labelPluginName;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label4;

  }
}