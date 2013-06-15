namespace EEM.Plugin.Ranking
{
  partial class MemberList
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.dataGridViewMemberList = new System.Windows.Forms.DataGridView();
      this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.MemberName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Points = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Cities = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.buttonExport = new System.Windows.Forms.Button();
      this.tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMemberList)).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.dataGridViewMemberList, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.48687F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.51313F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(579, 419);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 2;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.21815F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.78185F));
      this.tableLayoutPanel2.Controls.Add(this.buttonExport, 1, 1);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 356);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 2;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(573, 60);
      this.tableLayoutPanel2.TabIndex = 0;
      // 
      // dataGridViewMemberList
      // 
      this.dataGridViewMemberList.AllowUserToAddRows = false;
      this.dataGridViewMemberList.AllowUserToDeleteRows = false;
      this.dataGridViewMemberList.AllowUserToOrderColumns = true;
      this.dataGridViewMemberList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridViewMemberList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Rank,
            this.MemberName,
            this.Points,
            this.Cities});
      this.dataGridViewMemberList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridViewMemberList.Location = new System.Drawing.Point(3, 3);
      this.dataGridViewMemberList.Name = "dataGridViewMemberList";
      this.dataGridViewMemberList.ReadOnly = true;
      this.dataGridViewMemberList.Size = new System.Drawing.Size(573, 347);
      this.dataGridViewMemberList.TabIndex = 1;
      // 
      // Id
      // 
      this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      dataGridViewCellStyle1.Format = "N0";
      dataGridViewCellStyle1.NullValue = "0";
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.Id.DefaultCellStyle = dataGridViewCellStyle1;
      this.Id.HeaderText = "Id";
      this.Id.Name = "Id";
      this.Id.ReadOnly = true;
      this.Id.Width = 41;
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
      // MemberName
      // 
      this.MemberName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.MemberName.DefaultCellStyle = dataGridViewCellStyle3;
      this.MemberName.HeaderText = "Name";
      this.MemberName.Name = "MemberName";
      this.MemberName.ReadOnly = true;
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
      // Cities
      // 
      this.Cities.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      dataGridViewCellStyle5.Format = "N0";
      dataGridViewCellStyle5.NullValue = "0";
      dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.Cities.DefaultCellStyle = dataGridViewCellStyle5;
      this.Cities.HeaderText = "Cities";
      this.Cities.Name = "Cities";
      this.Cities.ReadOnly = true;
      this.Cities.Width = 57;
      // 
      // buttonExport
      // 
      this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonExport.Location = new System.Drawing.Point(495, 33);
      this.buttonExport.Name = "buttonExport";
      this.buttonExport.Size = new System.Drawing.Size(75, 23);
      this.buttonExport.TabIndex = 0;
      this.buttonExport.Text = "Export";
      this.buttonExport.UseVisualStyleBackColor = true;
      this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
      // 
      // MemberList
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(579, 419);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "MemberList";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "MemberList";
      this.Load += new System.EventHandler(this.MemberListLoad);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMemberList)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.DataGridView dataGridViewMemberList;
    private System.Windows.Forms.DataGridViewTextBoxColumn Id;
    private System.Windows.Forms.DataGridViewTextBoxColumn Rank;
    private System.Windows.Forms.DataGridViewTextBoxColumn MemberName;
    private System.Windows.Forms.DataGridViewTextBoxColumn Points;
    private System.Windows.Forms.DataGridViewTextBoxColumn Cities;
    private System.Windows.Forms.Button buttonExport;
  }
}