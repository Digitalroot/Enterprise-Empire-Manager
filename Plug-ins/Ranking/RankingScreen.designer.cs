namespace EEM.Plugin.Ranking
{
  partial class RankingScreen
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.dataGridViewAllianceRanks = new System.Windows.Forms.DataGridView();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.buttonGetAllianceRanks = new System.Windows.Forms.Button();
      this.buttonExport = new System.Windows.Forms.Button();
      this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.AllianceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Points = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Members = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Avg = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Cities = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.View = new System.Windows.Forms.DataGridViewButtonColumn();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllianceRanks)).BeginInit();
      this.tableLayoutPanel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Controls.Add(this.dataGridViewAllianceRanks, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(571, 350);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // dataGridViewAllianceRanks
      // 
      this.dataGridViewAllianceRanks.AllowUserToAddRows = false;
      this.dataGridViewAllianceRanks.AllowUserToDeleteRows = false;
      this.dataGridViewAllianceRanks.AllowUserToOrderColumns = true;
      this.dataGridViewAllianceRanks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridViewAllianceRanks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Rank,
            this.AllianceName,
            this.Points,
            this.Members,
            this.Avg,
            this.Cities,
            this.View});
      this.dataGridViewAllianceRanks.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridViewAllianceRanks.Location = new System.Drawing.Point(3, 3);
      this.dataGridViewAllianceRanks.MultiSelect = false;
      this.dataGridViewAllianceRanks.Name = "dataGridViewAllianceRanks";
      this.dataGridViewAllianceRanks.ReadOnly = true;
      this.dataGridViewAllianceRanks.Size = new System.Drawing.Size(565, 275);
      this.dataGridViewAllianceRanks.TabIndex = 0;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 3;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
      this.tableLayoutPanel2.Controls.Add(this.buttonGetAllianceRanks, 2, 0);
      this.tableLayoutPanel2.Controls.Add(this.buttonExport, 2, 1);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 284);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 2;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(565, 63);
      this.tableLayoutPanel2.TabIndex = 1;
      // 
      // buttonGetAllianceRanks
      // 
      this.buttonGetAllianceRanks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonGetAllianceRanks.Location = new System.Drawing.Point(454, 3);
      this.buttonGetAllianceRanks.Name = "buttonGetAllianceRanks";
      this.buttonGetAllianceRanks.Size = new System.Drawing.Size(108, 23);
      this.buttonGetAllianceRanks.TabIndex = 0;
      this.buttonGetAllianceRanks.Text = "Get Alliance Ranks";
      this.buttonGetAllianceRanks.UseVisualStyleBackColor = true;
      this.buttonGetAllianceRanks.Click += new System.EventHandler(this.ButtonGetAllianceRanksClick);
      // 
      // buttonExport
      // 
      this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonExport.Location = new System.Drawing.Point(487, 34);
      this.buttonExport.Name = "buttonExport";
      this.buttonExport.Size = new System.Drawing.Size(75, 23);
      this.buttonExport.TabIndex = 1;
      this.buttonExport.Text = "Export";
      this.buttonExport.UseVisualStyleBackColor = true;
      this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
      // 
      // Id
      // 
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      dataGridViewCellStyle1.Format = "N0";
      dataGridViewCellStyle1.NullValue = "0";
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.Id.DefaultCellStyle = dataGridViewCellStyle1;
      this.Id.HeaderText = "Id";
      this.Id.Name = "Id";
      this.Id.ReadOnly = true;
      this.Id.Visible = false;
      // 
      // Rank
      // 
      this.Rank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      dataGridViewCellStyle2.Format = "N0";
      dataGridViewCellStyle2.NullValue = "0";
      dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.Rank.DefaultCellStyle = dataGridViewCellStyle2;
      this.Rank.HeaderText = "Rank";
      this.Rank.Name = "Rank";
      this.Rank.ReadOnly = true;
      this.Rank.Width = 58;
      // 
      // AllianceName
      // 
      this.AllianceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      this.AllianceName.DefaultCellStyle = dataGridViewCellStyle3;
      this.AllianceName.HeaderText = "Name";
      this.AllianceName.Name = "AllianceName";
      this.AllianceName.ReadOnly = true;
      // 
      // Points
      // 
      this.Points.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      dataGridViewCellStyle4.Format = "N0";
      dataGridViewCellStyle4.NullValue = "0";
      dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.Points.DefaultCellStyle = dataGridViewCellStyle4;
      this.Points.HeaderText = "Points";
      this.Points.Name = "Points";
      this.Points.ReadOnly = true;
      this.Points.Width = 61;
      // 
      // Members
      // 
      this.Members.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      dataGridViewCellStyle5.Format = "N0";
      dataGridViewCellStyle5.NullValue = "0";
      dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.Members.DefaultCellStyle = dataGridViewCellStyle5;
      this.Members.HeaderText = "Members";
      this.Members.Name = "Members";
      this.Members.ReadOnly = true;
      this.Members.Width = 75;
      // 
      // Avg
      // 
      this.Avg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      dataGridViewCellStyle6.Format = "N0";
      dataGridViewCellStyle6.NullValue = "0";
      dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.Avg.DefaultCellStyle = dataGridViewCellStyle6;
      this.Avg.HeaderText = "Avg Points";
      this.Avg.Name = "Avg";
      this.Avg.ReadOnly = true;
      this.Avg.Width = 83;
      // 
      // Cities
      // 
      this.Cities.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      dataGridViewCellStyle7.Format = "N0";
      dataGridViewCellStyle7.NullValue = "0";
      dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.Cities.DefaultCellStyle = dataGridViewCellStyle7;
      this.Cities.HeaderText = "Cities";
      this.Cities.Name = "Cities";
      this.Cities.ReadOnly = true;
      this.Cities.Width = 57;
      // 
      // View
      // 
      this.View.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
      dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.View.DefaultCellStyle = dataGridViewCellStyle8;
      this.View.HeaderText = "View";
      this.View.Name = "View";
      this.View.ReadOnly = true;
      this.View.Text = "...";
      this.View.ToolTipText = "View Member List";
      this.View.Width = 36;
      // 
      // RankingScreen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(571, 350);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "RankingScreen";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Ranking";
      this.tableLayoutPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllianceRanks)).EndInit();
      this.tableLayoutPanel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.DataGridView dataGridViewAllianceRanks;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.Button buttonGetAllianceRanks;
    private System.Windows.Forms.Button buttonExport;
    private System.Windows.Forms.DataGridViewTextBoxColumn Id;
    private System.Windows.Forms.DataGridViewTextBoxColumn Rank;
    private System.Windows.Forms.DataGridViewTextBoxColumn AllianceName;
    private System.Windows.Forms.DataGridViewTextBoxColumn Points;
    private System.Windows.Forms.DataGridViewTextBoxColumn Members;
    private System.Windows.Forms.DataGridViewTextBoxColumn Avg;
    private System.Windows.Forms.DataGridViewTextBoxColumn Cities;
    private System.Windows.Forms.DataGridViewButtonColumn View;
  }
}

