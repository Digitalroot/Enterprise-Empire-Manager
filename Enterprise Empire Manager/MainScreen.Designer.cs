﻿using System;
using System.Windows.Forms;

namespace EEM
{
  partial class MainScreen
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
      this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.changeLoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
      this.loadedPluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
      this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
      this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabelCurrentCityName = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabelPlayerName = new System.Windows.Forms.ToolStripStatusLabel();
      this.connectionIconStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.contextMenuStripSysTray = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip.SuspendLayout();
      this.statusStrip.SuspendLayout();
      this.contextMenuStripSysTray.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.viewMenu,
            this.toolsMenu,
            this.windowsMenu,
            this.helpMenu});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.MdiWindowListItem = this.windowsMenu;
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(720, 24);
      this.menuStrip.TabIndex = 0;
      this.menuStrip.Text = "MenuStrip";
      // 
      // fileMenu
      // 
      this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.changeLoginToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
      this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
      this.fileMenu.Name = "fileMenu";
      this.fileMenu.Size = new System.Drawing.Size(37, 20);
      this.fileMenu.Text = "&File";
      // 
      // connectToolStripMenuItem
      // 
      this.connectToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
      this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
      this.connectToolStripMenuItem.ShowShortcutKeys = false;
      this.connectToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
      this.connectToolStripMenuItem.Text = "&Connect";
      this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
      // 
      // changeLoginToolStripMenuItem
      // 
      this.changeLoginToolStripMenuItem.Name = "changeLoginToolStripMenuItem";
      this.changeLoginToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
      this.changeLoginToolStripMenuItem.Text = "Change Login";
      this.changeLoginToolStripMenuItem.Click += new System.EventHandler(this.changeLoginToolStripMenuItem_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(145, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // viewMenu
      // 
      this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadedPluginsToolStripMenuItem,
            this.toolStripSeparator1});
      this.viewMenu.Name = "viewMenu";
      this.viewMenu.Size = new System.Drawing.Size(44, 20);
      this.viewMenu.Text = "&View";
      // 
      // loadedPluginsToolStripMenuItem
      // 
      this.loadedPluginsToolStripMenuItem.Name = "loadedPluginsToolStripMenuItem";
      this.loadedPluginsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
      this.loadedPluginsToolStripMenuItem.Text = "Loaded Plug-ins";
      this.loadedPluginsToolStripMenuItem.Click += new System.EventHandler(this.loadedPluginsToolStripMenuItem_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
      // 
      // toolsMenu
      // 
      this.toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
      this.toolsMenu.Name = "toolsMenu";
      this.toolsMenu.Size = new System.Drawing.Size(48, 20);
      this.toolsMenu.Text = "&Tools";
      // 
      // optionsToolStripMenuItem
      // 
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
      this.optionsToolStripMenuItem.Text = "&Options";
      this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
      // 
      // windowsMenu
      // 
      this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.closeAllToolStripMenuItem});
      this.windowsMenu.Name = "windowsMenu";
      this.windowsMenu.Size = new System.Drawing.Size(68, 20);
      this.windowsMenu.Text = "&Windows";
      // 
      // cascadeToolStripMenuItem
      // 
      this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
      this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
      this.cascadeToolStripMenuItem.Text = "&Cascade";
      this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
      // 
      // tileVerticalToolStripMenuItem
      // 
      this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
      this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
      this.tileVerticalToolStripMenuItem.Text = "Tile &Vertical";
      this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.tileVerticalToolStripMenuItem_Click);
      // 
      // tileHorizontalToolStripMenuItem
      // 
      this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
      this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
      this.tileHorizontalToolStripMenuItem.Text = "Tile &Horizontal";
      this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.tileHorizontalToolStripMenuItem_Click);
      // 
      // closeAllToolStripMenuItem
      // 
      this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
      this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
      this.closeAllToolStripMenuItem.Text = "C&lose All";
      this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
      // 
      // helpMenu
      // 
      this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
      this.helpMenu.Name = "helpMenu";
      this.helpMenu.Size = new System.Drawing.Size(44, 20);
      this.helpMenu.Text = "&Help";
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
      this.aboutToolStripMenuItem.Text = "&About Enterprise Empire Manager";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabelCurrentCityName,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelPlayerName,
            this.connectionIconStripStatusLabel});
      this.statusStrip.Location = new System.Drawing.Point(0, 435);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(720, 22);
      this.statusStrip.TabIndex = 2;
      this.statusStrip.Text = "StatusStrip";
      // 
      // toolStripStatusLabel
      // 
      this.toolStripStatusLabel.Name = "toolStripStatusLabel";
      this.toolStripStatusLabel.Size = new System.Drawing.Size(498, 17);
      this.toolStripStatusLabel.Spring = true;
      this.toolStripStatusLabel.Text = "Click Connect from the File Menu to Connect.";
      this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // toolStripStatusLabelCurrentCityName
      // 
      this.toolStripStatusLabelCurrentCityName.Name = "toolStripStatusLabelCurrentCityName";
      this.toolStripStatusLabelCurrentCityName.Size = new System.Drawing.Size(94, 17);
      this.toolStripStatusLabelCurrentCityName.Text = "No City Selected";
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(12, 17);
      this.toolStripStatusLabel1.Text = "-";
      // 
      // toolStripStatusLabelPlayerName
      // 
      this.toolStripStatusLabelPlayerName.Name = "toolStripStatusLabelPlayerName";
      this.toolStripStatusLabelPlayerName.Size = new System.Drawing.Size(85, 17);
      this.toolStripStatusLabelPlayerName.Text = "Requires Login";
      // 
      // connectionIconStripStatusLabel
      // 
      this.connectionIconStripStatusLabel.Image = global::EEM.Properties.Resources.icon_yellowdot;
      this.connectionIconStripStatusLabel.Name = "connectionIconStripStatusLabel";
      this.connectionIconStripStatusLabel.Size = new System.Drawing.Size(16, 17);
      // 
      // notifyIcon
      // 
      this.notifyIcon.ContextMenuStrip = this.contextMenuStripSysTray;
      this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
      this.notifyIcon.Text = "EEM";
      this.notifyIcon.DoubleClick += new System.EventHandler(this.NotifyIconDoubleClick);
      // 
      // contextMenuStripSysTray
      // 
      this.contextMenuStripSysTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem1});
      this.contextMenuStripSysTray.Name = "contextMenuStrip1";
      this.contextMenuStripSysTray.Size = new System.Drawing.Size(153, 70);
      // 
      // openToolStripMenuItem
      // 
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.openToolStripMenuItem.Text = "&Open";
      this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
      // 
      // exitToolStripMenuItem1
      // 
      this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
      this.exitToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
      this.exitToolStripMenuItem1.Text = "E&xit";
      this.exitToolStripMenuItem1.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
      // 
      // MainScreen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(720, 457);
      this.Controls.Add(this.statusStrip);
      this.Controls.Add(this.menuStrip);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.IsMdiContainer = true;
      this.MainMenuStrip = this.menuStrip;
      this.Name = "MainScreen";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Enterprise Empire Manager";
      this.Resize += new System.EventHandler(this.MainScreenResize);
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.contextMenuStripSysTray.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }
    #endregion


    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem fileMenu;
    private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem viewMenu;
    private System.Windows.Forms.ToolStripMenuItem toolsMenu;
    private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem windowsMenu;
    private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpMenu;
    private System.Windows.Forms.ToolTip toolTip;

    /// <summary>
    /// File -> Exit
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Environment.Exit(0);
    }

    private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      LayoutMdi(MdiLayout.Cascade);
    }

    private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
    {
      LayoutMdi(MdiLayout.TileVertical);
    }

    private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
    {
      LayoutMdi(MdiLayout.TileHorizontal);
    }

    private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
      foreach (Form childForm in MdiChildren)
      {
        childForm.Close();
      }
    }

    private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      LayoutMdi(MdiLayout.ArrangeIcons);
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      new AboutScreen().ShowDialog(this);
    }

    private ToolStripStatusLabel connectionIconStripStatusLabel;
    private ToolStripMenuItem changeLoginToolStripMenuItem;
    private ToolStripMenuItem loadedPluginsToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;

    private void loadedPluginsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      new LoadedPluginsScreen(Plugins).ShowDialog(this);
    }

    private ToolStripStatusLabel toolStripStatusLabelPlayerName;
    private ToolStripStatusLabel toolStripStatusLabelCurrentCityName;
    private ToolStripStatusLabel toolStripStatusLabel1;
    private NotifyIcon notifyIcon;
    private ContextMenuStrip contextMenuStripSysTray;
    private ToolStripMenuItem openToolStripMenuItem;
    private ToolStripMenuItem exitToolStripMenuItem1;
  }
}



