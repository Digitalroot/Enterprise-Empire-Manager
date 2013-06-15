using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using EEM.Common;
using EEM.Common.Adapters;
using EEM.Common.PluginInterface;
using EEM.Common.Protocol;
using EEM.Plugin.Chat.Properties;
using Net.Sgoliver.NRtfTree.Core;

namespace EEM.Plugin.Chat
{
  public partial class ChatScreen : Form
  {
    private readonly ILoUAdapter _loUAdapter;
    private readonly IEnterpriseEmpireManager _enterpriseEmpireManager;
    internal List<string> ChatBoxData = new List<string>();
    private bool _enableLoggin;

    /// <summary>
    /// Constructor
    /// </summary>
    public ChatScreen(IEnterpriseEmpireManager empireManager)
    {
      InitializeComponent();
      SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
      chattarget.DrawItem += chatbox_DrawItem;

      _enterpriseEmpireManager = empireManager;
      _loUAdapter = empireManager.LoUAdapter;
      chattarget.SelectedIndex = 0;
      chatbox.BackColor  = Settings.Default.ColorOfBackground;
      inputbox.BackColor = Settings.Default.ColorOfBackground;
      chattarget.BackColor = Settings.Default.ColorOfBackground;
      SetInputTextColor();

      _enableLoggin = Settings.Default.EnableLogging;
    }

    void loUAdapter_OnConnectionStateChange(ConnectionState connectionState)
    {
      HandleConnectionState(connectionState);
    }

    private void HandleConnectionState(ConnectionState connectionState)
    {
      switch (connectionState)
      {
        case ConnectionState.Connected:
          PollRequestItems[] item = { PollRequestItems.CHAT };
          _loUAdapter.PollingService.AddPollRequestItems(item, String.Empty);
          break;

        case ConnectionState.Disconnected:
          break;
      }      
    }

    void loUAdapter_OnChatResponse(ChatResponse loUResponseChat)
    {
      foreach (ChatResponseD message in loUResponseChat.Messages)
      {
        switch (message.Target)
        {
          // [{"C":"CHAT","D":[{"c":"global","s":"@Info","m":"Welcome"}]}"
          // [{"C":"CHAT","D":[{"c":"social@ally","s":"A@System","m":"Your ally, Fuzzle, is now online."}]}]
          // [{"C":"CHAT","D":[{"c":"@A","s":"CSkytap","m":"."}]}]
          // [{"C":"CHAT","D":[{"c":"@A","s":"CKryllik","m":"wow iron/food nice"}]}]
          case "@A":
            WriteToChatBox(new StringBuilder().Append("[").Append(message.Who).Append("]: ").Append(message.Message).ToString(), Settings.Default.ColorOfAllianceText);
            break;
      
          case "@C":
            if (message.Who == "@Info")
            {
              WriteToChatBox(new StringBuilder().Append("[Server]: ").Append(message.Message).ToString(), Settings.Default.ColorOfSystemText);
            }
            else
            {
              WriteToChatBox(new StringBuilder().Append("[").Append(message.Who).Append("]: ").Append(message.Message).ToString(), Settings.Default.ColorOfContinentText);
            }
            break;

          case "@CCS":
            WriteToChatBox(new StringBuilder().Append("[Server]: ").Append(message.Message).ToString(), Settings.Default.ColorOfSystemText);
            break;      

          case "@CCC":
            WriteToChatBox(new StringBuilder().Append("[Server]: You are chatting with continents ").Append(message.Message).ToString(), Settings.Default.ColorOfSystemText);
            break;
      
          case "global":
            WriteToChatBox(new StringBuilder().Append("[Server]: ").Append(message.Message).ToString(), Settings.Default.ColorOfSystemText);
            break;
      
          case "privatein":
            WriteToChatBox(new StringBuilder().Append("[").Append(message.Who).Append(" whispers]: ").Append(message.Message).ToString(), Settings.Default.ColorOfWhisperText);
            break;
      
          case "privateout":
            WriteToChatBox(new StringBuilder().Append("[You whisper ").Append(message.Who).Append("]: ").Append(message.Message).ToString(), Settings.Default.ColorOfWhisperText);
            break;

          case "social@ally":
            WriteToChatBox(new StringBuilder().Append("[Server]: ").Append(message.Message).ToString(), Color.DimGray);
            break;
      
          default:
            WriteToChatBox(new StringBuilder(message.Target).Append(" [").Append(message.Who).Append("]: ").Append(message.Message).ToString(), Settings.Default.ColorOfUnknownText);
            break;
        }

        if (_enableLoggin)
        {
          WriteToLogFile(message);
        }
      }      
    }

    private void WriteToLogFile(ChatResponseD message)
    {
      if (!_enableLoggin)
      {
        return;
      }

      using (var streamWriter = new StreamWriter(Settings.Default.ChatLogFile, true))
      {
        var logformat = (ChatLogFormat) ConversionUtil.StringToEnum(typeof(ChatLogFormat), Settings.Default.ChatLogFormat);
        var stringBuilder = new StringBuilder();
        switch (logformat)
        {
          case ChatLogFormat.ApacheStyle:
            
            stringBuilder.Append("[")
                         .Append(DateTime.Now.ToString("F"))
                         .Append("] [chat] [")
                         .Append(message.Target)
                         .Append("] [")
                         .Append(message.Who)
                         .Append("] ")
                         .Append(message.Message);
            break;

          case ChatLogFormat.CSV:
            stringBuilder.Append(DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss zzz"))
                         .Append(",")
                         .Append(message.Target)
                         .Append(",")
                         .Append(message.Who)
                         .Append(",\"")
                         .Append(message.Message.Replace('\"', '\''))
                         .Append("\"");
            break;
        }

        streamWriter.WriteLine(stringBuilder);
      }
    }

    /// <summary>
    /// Makes the chat box scroll to the bottom when text is added.
    /// todo: Add a pause button to stop the scrolling if the user wants it to stop.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // ReSharper disable InconsistentNaming
    private void chatbox_TextChanged(object sender, EventArgs e)
    // ReSharper restore InconsistentNaming
    {
      chatbox.ScrollToBottom();
    }


    /// <summary>
    /// Draws the Chat Target Drop Down List with different colors for each option.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // ReSharper disable InconsistentNaming
    private static void chatbox_DrawItem(object sender, DrawItemEventArgs e)
    // ReSharper restore InconsistentNaming
    {
      //
      // Draw the background of the ListBox control for each item.
      // Create a new Brush and initialize to a Black colored brush
      // by default.
      //
      e.DrawBackground();
      Brush myBrush = Brushes.Black;
      //
      // Determine the color of the brush to draw each item based on 
      // the index of the item to draw.
      //
      switch (e.Index)
      {
        case 0:
          myBrush = new SolidBrush(Settings.Default.ColorOfAllianceText);
          break;
        case 1:
          myBrush = new SolidBrush(Settings.Default.ColorOfContinentText);
          break;
      }
      //
      // Draw the current item text based on the current 
      // Font and the custom brush settings.
      //
      e.Graphics.DrawString(((ComboBox)sender).Items[e.Index].ToString(), 
          e.Font, myBrush,e.Bounds,StringFormat.GenericDefault);
      //
      // If the ListBox has focus, draw a focus rectangle 
      // around the selected item.
      //
      e.DrawFocusRectangle();
    }

    /// <summary>
    /// Chat box context menu
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // ReSharper disable InconsistentNaming
    private void copyToolStripMenuItem_Click(object sender, EventArgs e)
    // ReSharper restore InconsistentNaming
    {
      chatbox.Copy();
    }

    /// <summary>
    /// Input box context menu
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // ReSharper disable InconsistentNaming
    private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
    // ReSharper restore InconsistentNaming
    {
      inputbox.Copy();
    }

    /// <summary>
    /// Input box context menu
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // ReSharper disable InconsistentNaming
    private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
    // ReSharper restore InconsistentNaming
    {
      inputbox.Cut();
    }
    
    /// <summary>
    /// Save settings on form close.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // ReSharper disable InconsistentNaming
    private void MainScreen_FormClosed(object sender, FormClosedEventArgs e)
    // ReSharper restore InconsistentNaming
    {
      Settings.Default.Save();
    }

    /// <summary>
    /// Menu, Tools -> Options
    /// </summary>
    public void ShowOptionsScreen()
    {
      new OptionsScreen().ShowDialog(this);
      chatbox.BackColor = Settings.Default.ColorOfBackground;
      inputbox.BackColor = Settings.Default.ColorOfBackground;
      chattarget.BackColor = Settings.Default.ColorOfBackground;
      SetInputTextColor();

      _enableLoggin = Settings.Default.EnableLogging;
    }

    /// <summary>
    /// Input box context menu
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // ReSharper disable InconsistentNaming
    private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
    // ReSharper restore InconsistentNaming
    {
      inputbox.Paste();
    }

    /// <summary>
    /// Removes the first line of text from a RTF
    /// </summary>
    private void PurgeChatBox()
    {
      var tree = new RtfTree();
      tree.LoadRtfText(chatbox.Rtf);

      var root = tree.RootNode.ChildNodes[0];

      RtfTreeNode node;

      for (int i = 0; i < root.ChildNodes.Count; i++)
      {
        node = root.ChildNodes[i];

        if(node.NodeType == RtfNodeType.Control) root.RemoveChild(i); // This removes control chars that are used to display non-latin chars. 

        if (node.NodeType != RtfNodeType.Text) continue;

        root.RemoveChild(i); // Remove TimeStamp.
        root.RemoveChild(i); // Remove Color Node.
        root.RemoveChild(i); // Remove Message Text.
        root.RemoveChild(i); // Remove Parm (New Line).
        root.RemoveChild(i); // Remove Color Node.

        chatbox.Rtf = tree.Rtf;
        chatbox.ScrollToBottom();
        chatbox.SelectionStart = chatbox.Text.Length; // Fixes a bug when text is inserted at the cursor

        return;
      }
    }

    /// <summary>
    /// Input box context menu
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // ReSharper disable InconsistentNaming
    private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
    // ReSharper restore InconsistentNaming
    {
      inputbox.Focus();
      inputbox.SelectAll();
    }

    /// <summary>
    /// Chat box context menu
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // ReSharper disable InconsistentNaming
    private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
    // ReSharper restore InconsistentNaming
    {
      chatbox.Focus();
      chatbox.SelectAll();
    }


    /// <summary>
    /// Send button is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // ReSharper disable InconsistentNaming
    private void SendButton_Click(object sender, EventArgs e)
    // ReSharper restore InconsistentNaming
    {
      inputbox.Focus();
      if (_loUAdapter.ConnectionState != ConnectionState.Connected) return;
      if (inputbox.Text == String.Empty) return;
      if (_loUAdapter.ConnectionState != ConnectionState.Connected) return;
      string input = inputbox.Text;
      inputbox.Text = String.Empty;

      if (chattarget.Text == @"Alliance" && 
          !input.StartsWith("/w") &&
          !input.StartsWith("/c"))
      {
        input = "/a " + input;
      }

      _loUAdapter.SendChat(input);
    }

    /// <summary>
    /// Sets of the color of input text box.
    /// </summary>
    private void SetInputTextColor()
    {
      inputbox.ForeColor = chattarget.Text == @"Alliance" ? Settings.Default.ColorOfAllianceText : Settings.Default.ColorOfContinentText;
    }
    
    /// <summary>
    /// Prints black text to the chatbox.
    /// </summary>
    /// <param name="message"></param>
    private void WriteToChatBox(string message)
    {
      WriteToChatBox(message, Settings.Default.ColorOfUnknownText);
    }

    /// <summary>
    /// Prints a message to the chatbox.
    /// </summary>
    /// <param name="message">Message to print</param>
    /// <param name="color">Color of the text</param>
    /// <param name="purgeIfFull">Purge the top Message if the chatbox is to big?</param>
    private void WriteToChatBox(string message, Color color, bool purgeIfFull = true)
    {
      chatbox.ScrollToBottom(); 
      chatbox.SelectionStart = chatbox.Text.Length; // Fixes a bug when text is inserted at the cursor

      if (purgeIfFull)
      {
        while (chatbox.Lines.Length > 500)
        {
          PurgeChatBox();
        }
      }

      var font = new Font("Tahoma", 8, FontStyle.Regular);
      chatbox.SelectionFont = font;
      chatbox.SelectionColor = Settings.Default.ColorOfTimeStamp;
      chatbox.SelectedText = new StringBuilder("[").Append(DateTime.Now).Append("] ").ToString();

      font = new Font("Tahoma", 8, FontStyle.Regular);
      chatbox.SelectionFont = font;
      chatbox.SelectionColor = color;
      chatbox.SelectedText = message + Environment.NewLine;
    }

    /// <summary>
    /// Chat Target Selected Index Changed Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // ReSharper disable InconsistentNaming
    private void chattarget_SelectedIndexChanged(object sender, EventArgs e)
    // ReSharper restore InconsistentNaming
    {
      SetInputTextColor();
    }

    private void ChatScreenFormClosing(object sender, FormClosingEventArgs e)
    {
      _loUAdapter.PollingService.OnPollItemRemoval -= PollingService_OnPollItemRemoval;
      _loUAdapter.OnChatResponse -= loUAdapter_OnChatResponse;
      _loUAdapter.OnConnectionStateChange -= loUAdapter_OnConnectionStateChange;
      _loUAdapter.PollingService.RemovePollRequestItem(PollRequestItems.CHAT);
    }

    private void ChatScreenLoad(object sender, EventArgs e)
    {
      _loUAdapter.OnChatResponse += loUAdapter_OnChatResponse;
      _loUAdapter.OnConnectionStateChange += loUAdapter_OnConnectionStateChange;
      _loUAdapter.PollingService.OnPollItemRemoval += PollingService_OnPollItemRemoval;
      HandleConnectionState(_loUAdapter.ConnectionState);
    }

    /// <summary>
    /// We want to check and see if Chat was removed.
    /// </summary>
    /// <param name="pollRequestItem"></param>
    void PollingService_OnPollItemRemoval(PollRequestItems pollRequestItem)
    {
      if (pollRequestItem == PollRequestItems.CHAT)
      {
        PollRequestItems[] item = { PollRequestItems.CHAT };
        _loUAdapter.PollingService.AddPollRequestItems(item, String.Empty);
      }
    }
  }
}
