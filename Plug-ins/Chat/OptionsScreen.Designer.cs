namespace EEM.Plugin.Chat
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.checkBoxOpenOnStart = new System.Windows.Forms.CheckBox();
      this.labelTimeStampColor = new System.Windows.Forms.Label();
      this.buttonSetTimeStampColor = new System.Windows.Forms.Button();
      this.buttonSetSystemChatColor = new System.Windows.Forms.Button();
      this.labelSystemChatColor = new System.Windows.Forms.Label();
      this.SetContinentChatColorButton = new System.Windows.Forms.Button();
      this.LabelContinentChat = new System.Windows.Forms.Label();
      this.SetAllianceChatColorButton = new System.Windows.Forms.Button();
      this.LabelAllianceText = new System.Windows.Forms.Label();
      this.SetBackgroundColorButton = new System.Windows.Forms.Button();
      this.BackgroundColorLable = new System.Windows.Forms.Label();
      this.SetWhisperChatColorButton = new System.Windows.Forms.Button();
      this.LabelWhisperText = new System.Windows.Forms.Label();
      this.pictureBoxBackground = new System.Windows.Forms.PictureBox();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.ApplyButton = new System.Windows.Forms.Button();
      this.colorDialogWhisperChat = new System.Windows.Forms.ColorDialog();
      this.colorDialogBackground = new System.Windows.Forms.ColorDialog();
      this.colorDialogAlliance = new System.Windows.Forms.ColorDialog();
      this.colorDialogContinent = new System.Windows.Forms.ColorDialog();
      this.colorDialogSystem = new System.Windows.Forms.ColorDialog();
      this.colorDialogTimeStamp = new System.Windows.Forms.ColorDialog();
      this.checkBoxEnableLogging = new System.Windows.Forms.CheckBox();
      this.textBoxLogFile = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.saveLogFileDialog = new System.Windows.Forms.SaveFileDialog();
      this.tableLayoutPanel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).BeginInit();
      this.tableLayoutPanel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.19073F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.809264F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(226, 367);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.button1);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.textBoxLogFile);
      this.groupBox1.Controls.Add(this.checkBoxEnableLogging);
      this.groupBox1.Controls.Add(this.checkBoxOpenOnStart);
      this.groupBox1.Controls.Add(this.labelTimeStampColor);
      this.groupBox1.Controls.Add(this.buttonSetTimeStampColor);
      this.groupBox1.Controls.Add(this.buttonSetSystemChatColor);
      this.groupBox1.Controls.Add(this.labelSystemChatColor);
      this.groupBox1.Controls.Add(this.SetContinentChatColorButton);
      this.groupBox1.Controls.Add(this.LabelContinentChat);
      this.groupBox1.Controls.Add(this.SetAllianceChatColorButton);
      this.groupBox1.Controls.Add(this.LabelAllianceText);
      this.groupBox1.Controls.Add(this.SetBackgroundColorButton);
      this.groupBox1.Controls.Add(this.BackgroundColorLable);
      this.groupBox1.Controls.Add(this.SetWhisperChatColorButton);
      this.groupBox1.Controls.Add(this.LabelWhisperText);
      this.groupBox1.Controls.Add(this.pictureBoxBackground);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(3, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(220, 324);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Text Color";
      // 
      // checkBoxOpenOnStart
      // 
      this.checkBoxOpenOnStart.AutoSize = true;
      this.checkBoxOpenOnStart.Location = new System.Drawing.Point(6, 203);
      this.checkBoxOpenOnStart.Name = "checkBoxOpenOnStart";
      this.checkBoxOpenOnStart.Size = new System.Drawing.Size(171, 17);
      this.checkBoxOpenOnStart.TabIndex = 14;
      this.checkBoxOpenOnStart.Text = "Open Chat Window on Startup";
      this.checkBoxOpenOnStart.UseVisualStyleBackColor = true;
      // 
      // labelTimeStampColor
      // 
      this.labelTimeStampColor.AutoSize = true;
      this.labelTimeStampColor.Location = new System.Drawing.Point(9, 172);
      this.labelTimeStampColor.Name = "labelTimeStampColor";
      this.labelTimeStampColor.Size = new System.Drawing.Size(90, 13);
      this.labelTimeStampColor.TabIndex = 13;
      this.labelTimeStampColor.Text = "Time Stamp Color";
      // 
      // buttonSetTimeStampColor
      // 
      this.buttonSetTimeStampColor.Location = new System.Drawing.Point(134, 167);
      this.buttonSetTimeStampColor.Name = "buttonSetTimeStampColor";
      this.buttonSetTimeStampColor.Size = new System.Drawing.Size(75, 23);
      this.buttonSetTimeStampColor.TabIndex = 12;
      this.buttonSetTimeStampColor.Text = "Set";
      this.buttonSetTimeStampColor.UseVisualStyleBackColor = true;
      this.buttonSetTimeStampColor.Click += new System.EventHandler(this.buttonSetTimeStampColor_Click);
      // 
      // buttonSetSystemChatColor
      // 
      this.buttonSetSystemChatColor.Location = new System.Drawing.Point(135, 137);
      this.buttonSetSystemChatColor.Name = "buttonSetSystemChatColor";
      this.buttonSetSystemChatColor.Size = new System.Drawing.Size(75, 23);
      this.buttonSetSystemChatColor.TabIndex = 11;
      this.buttonSetSystemChatColor.Text = "Set";
      this.buttonSetSystemChatColor.UseVisualStyleBackColor = true;
      this.buttonSetSystemChatColor.Click += new System.EventHandler(this.buttonSetSystemChatColor_Click);
      // 
      // labelSystemChatColor
      // 
      this.labelSystemChatColor.AutoSize = true;
      this.labelSystemChatColor.Location = new System.Drawing.Point(9, 142);
      this.labelSystemChatColor.Name = "labelSystemChatColor";
      this.labelSystemChatColor.Size = new System.Drawing.Size(93, 13);
      this.labelSystemChatColor.TabIndex = 10;
      this.labelSystemChatColor.Text = "System Chat Color";
      // 
      // SetContinentChatColorButton
      // 
      this.SetContinentChatColorButton.Location = new System.Drawing.Point(135, 107);
      this.SetContinentChatColorButton.Name = "SetContinentChatColorButton";
      this.SetContinentChatColorButton.Size = new System.Drawing.Size(75, 23);
      this.SetContinentChatColorButton.TabIndex = 9;
      this.SetContinentChatColorButton.Text = "Set";
      this.SetContinentChatColorButton.UseVisualStyleBackColor = true;
      this.SetContinentChatColorButton.Click += new System.EventHandler(this.SetContinentChatColorButton_Click);
      // 
      // LabelContinentChat
      // 
      this.LabelContinentChat.AutoSize = true;
      this.LabelContinentChat.Location = new System.Drawing.Point(9, 112);
      this.LabelContinentChat.Name = "LabelContinentChat";
      this.LabelContinentChat.Size = new System.Drawing.Size(107, 13);
      this.LabelContinentChat.TabIndex = 8;
      this.LabelContinentChat.Text = "Continent Chat Color:";
      // 
      // SetAllianceChatColorButton
      // 
      this.SetAllianceChatColorButton.Location = new System.Drawing.Point(134, 77);
      this.SetAllianceChatColorButton.Name = "SetAllianceChatColorButton";
      this.SetAllianceChatColorButton.Size = new System.Drawing.Size(75, 23);
      this.SetAllianceChatColorButton.TabIndex = 6;
      this.SetAllianceChatColorButton.Text = "Set";
      this.SetAllianceChatColorButton.UseVisualStyleBackColor = true;
      this.SetAllianceChatColorButton.Click += new System.EventHandler(this.SetAllianceChatColorButton_Click);
      // 
      // LabelAllianceText
      // 
      this.LabelAllianceText.AutoSize = true;
      this.LabelAllianceText.BackColor = System.Drawing.Color.Transparent;
      this.LabelAllianceText.ForeColor = System.Drawing.Color.Green;
      this.LabelAllianceText.Location = new System.Drawing.Point(9, 82);
      this.LabelAllianceText.Name = "LabelAllianceText";
      this.LabelAllianceText.Size = new System.Drawing.Size(96, 13);
      this.LabelAllianceText.TabIndex = 5;
      this.LabelAllianceText.Text = "Alliance Chat Color";
      // 
      // SetBackgroundColorButton
      // 
      this.SetBackgroundColorButton.Location = new System.Drawing.Point(134, 19);
      this.SetBackgroundColorButton.Name = "SetBackgroundColorButton";
      this.SetBackgroundColorButton.Size = new System.Drawing.Size(75, 23);
      this.SetBackgroundColorButton.TabIndex = 4;
      this.SetBackgroundColorButton.Text = "Set";
      this.SetBackgroundColorButton.UseVisualStyleBackColor = true;
      this.SetBackgroundColorButton.Click += new System.EventHandler(this.SetBackgroundColorButton_Click);
      // 
      // BackgroundColorLable
      // 
      this.BackgroundColorLable.AutoSize = true;
      this.BackgroundColorLable.BackColor = System.Drawing.Color.Transparent;
      this.BackgroundColorLable.Location = new System.Drawing.Point(9, 24);
      this.BackgroundColorLable.Name = "BackgroundColorLable";
      this.BackgroundColorLable.Size = new System.Drawing.Size(95, 13);
      this.BackgroundColorLable.TabIndex = 3;
      this.BackgroundColorLable.Text = "Background Color:";
      // 
      // SetWhisperChatColorButton
      // 
      this.SetWhisperChatColorButton.Location = new System.Drawing.Point(134, 48);
      this.SetWhisperChatColorButton.Name = "SetWhisperChatColorButton";
      this.SetWhisperChatColorButton.Size = new System.Drawing.Size(75, 23);
      this.SetWhisperChatColorButton.TabIndex = 2;
      this.SetWhisperChatColorButton.Text = "Set";
      this.SetWhisperChatColorButton.UseVisualStyleBackColor = true;
      this.SetWhisperChatColorButton.Click += new System.EventHandler(this.SetWhisperChatColorButton_Click);
      // 
      // LabelWhisperText
      // 
      this.LabelWhisperText.AutoSize = true;
      this.LabelWhisperText.BackColor = System.Drawing.Color.Transparent;
      this.LabelWhisperText.ForeColor = System.Drawing.Color.Red;
      this.LabelWhisperText.Location = new System.Drawing.Point(9, 53);
      this.LabelWhisperText.Name = "LabelWhisperText";
      this.LabelWhisperText.Size = new System.Drawing.Size(101, 13);
      this.LabelWhisperText.TabIndex = 1;
      this.LabelWhisperText.Text = "Whisper Chat Color:";
      // 
      // pictureBoxBackground
      // 
      this.pictureBoxBackground.BackColor = System.Drawing.Color.White;
      this.pictureBoxBackground.Location = new System.Drawing.Point(6, 48);
      this.pictureBoxBackground.Name = "pictureBoxBackground";
      this.pictureBoxBackground.Size = new System.Drawing.Size(122, 149);
      this.pictureBoxBackground.TabIndex = 7;
      this.pictureBoxBackground.TabStop = false;
      this.pictureBoxBackground.BackColorChanged += new System.EventHandler(this.pictureBoxBackground_BackColorChanged);
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 2;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
      this.tableLayoutPanel2.Controls.Add(this.ApplyButton, 1, 0);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 333);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 1;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(220, 31);
      this.tableLayoutPanel2.TabIndex = 1;
      // 
      // ApplyButton
      // 
      this.ApplyButton.Location = new System.Drawing.Point(142, 3);
      this.ApplyButton.Name = "ApplyButton";
      this.ApplyButton.Size = new System.Drawing.Size(75, 23);
      this.ApplyButton.TabIndex = 0;
      this.ApplyButton.Text = "Apply";
      this.ApplyButton.UseVisualStyleBackColor = true;
      this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
      // 
      // checkBoxEnableLogging
      // 
      this.checkBoxEnableLogging.AutoSize = true;
      this.checkBoxEnableLogging.Location = new System.Drawing.Point(6, 226);
      this.checkBoxEnableLogging.Name = "checkBoxEnableLogging";
      this.checkBoxEnableLogging.Size = new System.Drawing.Size(81, 17);
      this.checkBoxEnableLogging.TabIndex = 15;
      this.checkBoxEnableLogging.Text = "Log to a file";
      this.checkBoxEnableLogging.UseVisualStyleBackColor = true;
      // 
      // textBoxLogFile
      // 
      this.textBoxLogFile.BackColor = System.Drawing.Color.White;
      this.textBoxLogFile.Location = new System.Drawing.Point(56, 249);
      this.textBoxLogFile.Name = "textBoxLogFile";
      this.textBoxLogFile.ReadOnly = true;
      this.textBoxLogFile.Size = new System.Drawing.Size(128, 20);
      this.textBoxLogFile.TabIndex = 16;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 252);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(44, 13);
      this.label1.TabIndex = 17;
      this.label1.Text = "Log file:";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(190, 247);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(24, 23);
      this.button1.TabIndex = 18;
      this.button1.Text = "...";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // OptionsScreen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(226, 367);
      this.Controls.Add(this.tableLayoutPanel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "OptionsScreen";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Options";
      this.TopMost = true;
      this.tableLayoutPanel1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).EndInit();
      this.tableLayoutPanel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button SetWhisperChatColorButton;
    private System.Windows.Forms.Label LabelWhisperText;
    private System.Windows.Forms.ColorDialog colorDialogWhisperChat;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.Button ApplyButton;
    private System.Windows.Forms.Button SetBackgroundColorButton;
    private System.Windows.Forms.Label BackgroundColorLable;
    private System.Windows.Forms.ColorDialog colorDialogBackground;
    private System.Windows.Forms.Button SetAllianceChatColorButton;
    private System.Windows.Forms.Label LabelAllianceText;
    private System.Windows.Forms.PictureBox pictureBoxBackground;
    private System.Windows.Forms.ColorDialog colorDialogAlliance;
    private System.Windows.Forms.Button SetContinentChatColorButton;
    private System.Windows.Forms.Label LabelContinentChat;
    private System.Windows.Forms.ColorDialog colorDialogContinent;
    private System.Windows.Forms.Label labelTimeStampColor;
    private System.Windows.Forms.Button buttonSetTimeStampColor;
    private System.Windows.Forms.Button buttonSetSystemChatColor;
    private System.Windows.Forms.Label labelSystemChatColor;
    private System.Windows.Forms.ColorDialog colorDialogSystem;
    private System.Windows.Forms.ColorDialog colorDialogTimeStamp;
    private System.Windows.Forms.CheckBox checkBoxOpenOnStart;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBoxLogFile;
    private System.Windows.Forms.CheckBox checkBoxEnableLogging;
    private System.Windows.Forms.SaveFileDialog saveLogFileDialog;
  }
}