namespace EEM.Plugin.CityInfo
{
  partial class BannerUser
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.labelScore = new System.Windows.Forms.Label();
      this.labelRank = new System.Windows.Forms.Label();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.labelTitle = new System.Windows.Forms.Label();
      this.labelScoreValue = new System.Windows.Forms.Label();
      this.labelTitleValue = new System.Windows.Forms.Label();
      this.labelRankValue = new System.Windows.Forms.Label();
      this.labelGold = new System.Windows.Forms.Label();
      this.labelMana = new System.Windows.Forms.Label();
      this.labelGoldValue = new System.Windows.Forms.Label();
      this.labelManaValue = new System.Windows.Forms.Label();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // labelScore
      // 
      this.labelScore.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelScore.AutoSize = true;
      this.labelScore.Location = new System.Drawing.Point(3, 3);
      this.labelScore.Name = "labelScore";
      this.labelScore.Size = new System.Drawing.Size(38, 13);
      this.labelScore.TabIndex = 1;
      this.labelScore.Text = "Score:";
      // 
      // labelRank
      // 
      this.labelRank.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelRank.AutoSize = true;
      this.labelRank.Location = new System.Drawing.Point(3, 43);
      this.labelRank.Name = "labelRank";
      this.labelRank.Size = new System.Drawing.Size(36, 13);
      this.labelRank.TabIndex = 2;
      this.labelRank.Text = "Rank:";
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 5;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 284F));
      this.tableLayoutPanel1.Controls.Add(this.labelTitle, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.labelScore, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.labelRank, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.labelScoreValue, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.labelTitleValue, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.labelRankValue, 1, 2);
      this.tableLayoutPanel1.Controls.Add(this.labelGold, 2, 0);
      this.tableLayoutPanel1.Controls.Add(this.labelMana, 2, 1);
      this.tableLayoutPanel1.Controls.Add(this.labelGoldValue, 3, 0);
      this.tableLayoutPanel1.Controls.Add(this.labelManaValue, 3, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(635, 60);
      this.tableLayoutPanel1.TabIndex = 3;
      // 
      // labelTitle
      // 
      this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelTitle.AutoSize = true;
      this.labelTitle.Location = new System.Drawing.Point(3, 23);
      this.labelTitle.Name = "labelTitle";
      this.labelTitle.Size = new System.Drawing.Size(30, 13);
      this.labelTitle.TabIndex = 0;
      this.labelTitle.Text = "Title:";
      // 
      // labelScoreValue
      // 
      this.labelScoreValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelScoreValue.AutoSize = true;
      this.labelScoreValue.Location = new System.Drawing.Point(50, 3);
      this.labelScoreValue.Name = "labelScoreValue";
      this.labelScoreValue.Size = new System.Drawing.Size(43, 13);
      this.labelScoreValue.TabIndex = 3;
      this.labelScoreValue.Text = "*Score*";
      // 
      // labelTitleValue
      // 
      this.labelTitleValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelTitleValue.AutoSize = true;
      this.labelTitleValue.Location = new System.Drawing.Point(50, 23);
      this.labelTitleValue.Name = "labelTitleValue";
      this.labelTitleValue.Size = new System.Drawing.Size(35, 13);
      this.labelTitleValue.TabIndex = 4;
      this.labelTitleValue.Text = "*Title*";
      // 
      // labelRankValue
      // 
      this.labelRankValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelRankValue.AutoSize = true;
      this.labelRankValue.Location = new System.Drawing.Point(50, 43);
      this.labelRankValue.Name = "labelRankValue";
      this.labelRankValue.Size = new System.Drawing.Size(41, 13);
      this.labelRankValue.TabIndex = 5;
      this.labelRankValue.Text = "*Rank*";
      // 
      // labelGold
      // 
      this.labelGold.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelGold.AutoSize = true;
      this.labelGold.Location = new System.Drawing.Point(166, 3);
      this.labelGold.Name = "labelGold";
      this.labelGold.Size = new System.Drawing.Size(32, 13);
      this.labelGold.TabIndex = 6;
      this.labelGold.Text = "Gold:";
      // 
      // labelMana
      // 
      this.labelMana.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelMana.AutoSize = true;
      this.labelMana.Location = new System.Drawing.Point(166, 23);
      this.labelMana.Name = "labelMana";
      this.labelMana.Size = new System.Drawing.Size(37, 13);
      this.labelMana.TabIndex = 7;
      this.labelMana.Text = "Mana:";
      // 
      // labelGoldValue
      // 
      this.labelGoldValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelGoldValue.AutoSize = true;
      this.labelGoldValue.Location = new System.Drawing.Point(214, 3);
      this.labelGoldValue.Name = "labelGoldValue";
      this.labelGoldValue.Size = new System.Drawing.Size(37, 13);
      this.labelGoldValue.TabIndex = 8;
      this.labelGoldValue.Text = "*Gold*";
      // 
      // labelManaValue
      // 
      this.labelManaValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelManaValue.AutoSize = true;
      this.labelManaValue.Location = new System.Drawing.Point(214, 23);
      this.labelManaValue.Name = "labelManaValue";
      this.labelManaValue.Size = new System.Drawing.Size(42, 13);
      this.labelManaValue.TabIndex = 9;
      this.labelManaValue.Text = "*Mana*";
      // 
      // BannerUser
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "BannerUser";
      this.Size = new System.Drawing.Size(635, 60);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label labelScore;
    private System.Windows.Forms.Label labelRank;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label labelTitle;
    private System.Windows.Forms.Label labelGold;
    private System.Windows.Forms.Label labelMana;
    public System.Windows.Forms.Label labelScoreValue;
    public System.Windows.Forms.Label labelTitleValue;
    public System.Windows.Forms.Label labelRankValue;
    public System.Windows.Forms.Label labelGoldValue;
    public System.Windows.Forms.Label labelManaValue;
  }
}
