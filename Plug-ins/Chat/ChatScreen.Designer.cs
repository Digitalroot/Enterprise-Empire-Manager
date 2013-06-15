namespace EEM.Plugin.Chat
{
  partial class ChatScreen
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatScreen));
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.SendButton = new System.Windows.Forms.Button();
      this.inputbox = new System.Windows.Forms.TextBox();
      this.rightClickInputBox = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.cutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.selectAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.chattarget = new System.Windows.Forms.ComboBox();
      this.chatbox = new System.Windows.Forms.RichTextBox();
      this.rightClickChatBox = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.rightClickInputBox.SuspendLayout();
      this.rightClickChatBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.chatbox, 0, 0);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 359);
      this.tableLayoutPanel1.TabIndex = 1;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 3;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
      this.tableLayoutPanel2.Controls.Add(this.SendButton, 2, 0);
      this.tableLayoutPanel2.Controls.Add(this.inputbox, 1, 0);
      this.tableLayoutPanel2.Controls.Add(this.chattarget, 0, 0);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 329);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 1;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(594, 27);
      this.tableLayoutPanel2.TabIndex = 0;
      // 
      // SendButton
      // 
      this.SendButton.Location = new System.Drawing.Point(517, 3);
      this.SendButton.Name = "SendButton";
      this.SendButton.Size = new System.Drawing.Size(74, 21);
      this.SendButton.TabIndex = 1;
      this.SendButton.Text = "Send";
      this.SendButton.UseVisualStyleBackColor = true;
      this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
      // 
      // inputbox
      // 
      this.inputbox.BackColor = System.Drawing.SystemColors.Window;
      this.inputbox.ContextMenuStrip = this.rightClickInputBox;
      this.inputbox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.inputbox.ForeColor = System.Drawing.SystemColors.WindowText;
      this.inputbox.Location = new System.Drawing.Point(87, 3);
      this.inputbox.Name = "inputbox";
      this.inputbox.Size = new System.Drawing.Size(424, 20);
      this.inputbox.TabIndex = 0;
      // 
      // rightClickInputBox
      // 
      this.rightClickInputBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem1,
            this.copyToolStripMenuItem1,
            this.pasteToolStripMenuItem,
            this.selectAllToolStripMenuItem1});
      this.rightClickInputBox.Name = "rightClickInputBox";
      this.rightClickInputBox.Size = new System.Drawing.Size(123, 92);
      // 
      // cutToolStripMenuItem1
      // 
      this.cutToolStripMenuItem1.Name = "cutToolStripMenuItem1";
      this.cutToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
      this.cutToolStripMenuItem1.Text = "Cut";
      this.cutToolStripMenuItem1.Click += new System.EventHandler(this.cutToolStripMenuItem1_Click);
      // 
      // copyToolStripMenuItem1
      // 
      this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
      this.copyToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
      this.copyToolStripMenuItem1.Text = "Copy";
      this.copyToolStripMenuItem1.Click += new System.EventHandler(this.copyToolStripMenuItem1_Click);
      // 
      // pasteToolStripMenuItem
      // 
      this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
      this.pasteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
      this.pasteToolStripMenuItem.Text = "Paste";
      this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
      // 
      // selectAllToolStripMenuItem1
      // 
      this.selectAllToolStripMenuItem1.Name = "selectAllToolStripMenuItem1";
      this.selectAllToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
      this.selectAllToolStripMenuItem1.Text = "Select All";
      this.selectAllToolStripMenuItem1.Click += new System.EventHandler(this.selectAllToolStripMenuItem1_Click);
      // 
      // chattarget
      // 
      this.chattarget.Cursor = System.Windows.Forms.Cursors.Default;
      this.chattarget.Dock = System.Windows.Forms.DockStyle.Fill;
      this.chattarget.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
      this.chattarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.chattarget.FormattingEnabled = true;
      this.chattarget.Items.AddRange(new object[] {
            "Alliance",
            "Continent"});
      this.chattarget.Location = new System.Drawing.Point(3, 3);
      this.chattarget.Name = "chattarget";
      this.chattarget.Size = new System.Drawing.Size(78, 21);
      this.chattarget.TabIndex = 2;
      this.chattarget.TabStop = false;
      this.chattarget.SelectedIndexChanged += new System.EventHandler(this.chattarget_SelectedIndexChanged);
      // 
      // chatbox
      // 
      this.chatbox.BackColor = System.Drawing.Color.White;
      this.chatbox.ContextMenuStrip = this.rightClickChatBox;
      this.chatbox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.chatbox.Location = new System.Drawing.Point(3, 3);
      this.chatbox.Name = "chatbox";
      this.chatbox.ReadOnly = true;
      this.chatbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
      this.chatbox.Size = new System.Drawing.Size(594, 320);
      this.chatbox.TabIndex = 1;
      this.chatbox.TabStop = false;
      this.chatbox.Text = "";
      this.chatbox.TextChanged += new System.EventHandler(this.chatbox_TextChanged);
      // 
      // rightClickChatBox
      // 
      this.rightClickChatBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.selectAllToolStripMenuItem});
      this.rightClickChatBox.Name = "rightClickChatBox";
      this.rightClickChatBox.Size = new System.Drawing.Size(123, 48);
      // 
      // copyToolStripMenuItem
      // 
      this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
      this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
      this.copyToolStripMenuItem.Text = "Copy";
      this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
      // 
      // selectAllToolStripMenuItem
      // 
      this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
      this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
      this.selectAllToolStripMenuItem.Text = "Select All";
      this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
      // 
      // ChatScreen
      // 
      this.AcceptButton = this.SendButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size(600, 359);
      this.Controls.Add(this.tableLayoutPanel1);
      this.DoubleBuffered = true;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "ChatScreen";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "LoU Chat";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainScreen_FormClosed);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tableLayoutPanel2.PerformLayout();
      this.rightClickInputBox.ResumeLayout(false);
      this.rightClickChatBox.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.Button SendButton;
    private System.Windows.Forms.TextBox inputbox;
    private System.Windows.Forms.ComboBox chattarget;
    private System.Windows.Forms.RichTextBox chatbox;
    private System.Windows.Forms.ContextMenuStrip rightClickChatBox;
    private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
    private System.Windows.Forms.ContextMenuStrip rightClickInputBox;
    private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
  }
}

