using System;
using System.Windows.Forms;
using EEM.Common;

namespace EEM.Plugin.Chat
{
  public partial class OptionsScreen : Form
  {
    public OptionsScreen()
    {
      InitializeComponent();

      // Background
      colorDialogBackground.Color    = Properties.Settings.Default.ColorOfBackground;
      pictureBoxBackground.BackColor = colorDialogBackground.Color;
      LabelWhisperText.BackColor     = colorDialogBackground.Color;
      LabelAllianceText.BackColor    = colorDialogBackground.Color;
      LabelContinentChat.BackColor   = colorDialogBackground.Color;
      labelSystemChatColor.BackColor = colorDialogBackground.Color;
      labelTimeStampColor.BackColor  = colorDialogBackground.Color;

      // Whisper
      LabelWhisperText.ForeColor   = Properties.Settings.Default.ColorOfWhisperText;
      colorDialogWhisperChat.Color = Properties.Settings.Default.ColorOfWhisperText;

      // Alliance
      LabelAllianceText.ForeColor = Properties.Settings.Default.ColorOfAllianceText;
      colorDialogAlliance.Color   = Properties.Settings.Default.ColorOfAllianceText;

      // Continent
      LabelContinentChat.ForeColor = Properties.Settings.Default.ColorOfContinentText;
      colorDialogContinent.Color = Properties.Settings.Default.ColorOfContinentText;

      // System
      labelSystemChatColor.ForeColor = Properties.Settings.Default.ColorOfSystemText;
      colorDialogSystem.Color = Properties.Settings.Default.ColorOfSystemText;

      // TimeStamp
      labelTimeStampColor.ForeColor = Properties.Settings.Default.ColorOfTimeStamp;
      colorDialogTimeStamp.Color = Properties.Settings.Default.ColorOfTimeStamp;

      // Other Options.
      checkBoxOpenOnStart.Checked = Properties.Settings.Default.OpenChatWindowOnStartUp;
      checkBoxEnableLogging.Checked = Properties.Settings.Default.EnableLogging;
      textBoxLogFile.Text = Properties.Settings.Default.ChatLogFile;
      comboBoxLogFormat.SelectedIndex = ConvertChatLogFormat(Properties.Settings.Default.ChatLogFormat);

    }

    // Set Alliance Chat Color
    private void SetAllianceChatColorButton_Click(object sender, EventArgs e)
    {
      colorDialogAlliance.ShowDialog(this);
      LabelAllianceText.ForeColor = colorDialogAlliance.Color;
    }

    // Set Background Color
    private void SetBackgroundColorButton_Click(object sender, EventArgs e)
    {
      colorDialogBackground.ShowDialog(this);
      pictureBoxBackground.BackColor = colorDialogBackground.Color;
    }

    // Set Continent Chat Color
    private void SetContinentChatColorButton_Click(object sender, EventArgs e)
    {
      colorDialogContinent.ShowDialog(this);
      LabelContinentChat.ForeColor = colorDialogContinent.Color;
    }

    // Set Whisper Chat Color
    private void SetWhisperChatColorButton_Click(object sender, EventArgs e)
    {
      colorDialogWhisperChat.ShowDialog(this);
      LabelWhisperText.ForeColor = colorDialogWhisperChat.Color;
    }

    private void buttonSetSystemChatColor_Click(object sender, EventArgs e)
    {
      colorDialogSystem.ShowDialog(this);
      labelSystemChatColor.ForeColor = colorDialogSystem.Color;
    }

    private void buttonSetTimeStampColor_Click(object sender, EventArgs e)
    {
      colorDialogTimeStamp.ShowDialog(this);
      labelTimeStampColor.ForeColor = colorDialogTimeStamp.Color;
    }

    private void ApplyButton_Click(object sender, EventArgs e)
    {
      // Background
      Properties.Settings.Default.ColorOfBackground = colorDialogBackground.Color;
      pictureBoxBackground.BackColor = colorDialogBackground.Color;

      // Whisper
      Properties.Settings.Default.ColorOfWhisperText = colorDialogWhisperChat.Color;

      // Alliance
      Properties.Settings.Default.ColorOfAllianceText = colorDialogAlliance.Color;

      // Continent
      Properties.Settings.Default.ColorOfContinentText = colorDialogContinent.Color;

      // System
      Properties.Settings.Default.ColorOfSystemText = colorDialogSystem.Color;

      // TimeStamp
      Properties.Settings.Default.ColorOfTimeStamp = colorDialogTimeStamp.Color;

      // Other
      Properties.Settings.Default.OpenChatWindowOnStartUp = checkBoxOpenOnStart.Checked;
      Properties.Settings.Default.EnableLogging = checkBoxEnableLogging.Checked;
      Properties.Settings.Default.ChatLogFile = textBoxLogFile.Text;
      Properties.Settings.Default.ChatLogFormat = ConvertChatLogFormat(comboBoxLogFormat.SelectedIndex).ToString();

      // Save and Reload
      Properties.Settings.Default.Save();
      Properties.Settings.Default.Reload();
      Close();
    }

    private void pictureBoxBackground_BackColorChanged(object sender, EventArgs e)
    {
      LabelWhisperText.BackColor = pictureBoxBackground.BackColor;
      LabelAllianceText.BackColor = pictureBoxBackground.BackColor;
      LabelContinentChat.BackColor = pictureBoxBackground.BackColor;
      labelTimeStampColor.BackColor = pictureBoxBackground.BackColor;
      labelSystemChatColor.BackColor = pictureBoxBackground.BackColor;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      saveLogFileDialog.FileOk += saveLogFileDialog_FileOk;
      saveLogFileDialog.ShowDialog(this);
    }

    void saveLogFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if (!e.Cancel)
      {
        textBoxLogFile.Text = saveLogFileDialog.FileName;
      }
    }

    private static int ConvertChatLogFormat (string format)
    {
      if (format == "Apache Style") format = "ApacheStyle";

      var stringToEnum = (ChatLogFormat) ConversionUtil.StringToEnum(typeof(ChatLogFormat), format);
      return ConvertChatLogFormat(stringToEnum);
    }

    private static int ConvertChatLogFormat (ChatLogFormat format)
    {
      switch (format)
      {
        case ChatLogFormat.ApacheStyle:
          return 0;

        case ChatLogFormat.CSV:
          return 1;

        default:
          return 0;
      }      
    }

    private static ChatLogFormat ConvertChatLogFormat(int index)
    {
      switch (index)
      {
        case 0:
          return ChatLogFormat.ApacheStyle;

        case 1:
          return ChatLogFormat.CSV;

        default:
          return ChatLogFormat.ApacheStyle;
      }
    }
  }
}
