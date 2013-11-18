using System.Windows.Forms;

namespace EEM
{
  public partial class LoadedPluginsScreen : Form
  {
    private readonly PluginServices _plugins;

    public LoadedPluginsScreen(PluginServices plugins)
    {
      _plugins = plugins;
      InitializeComponent();
      LoadPlugins();
      treeViewLoadedPlugins.AfterSelect += treeViewLoadedPlugins_AfterSelect;
    }

    private void LoadPlugins()
    {
      foreach (AvailablePlugin plugin in _plugins.AvailablePlugins)
      {
        treeViewLoadedPlugins.Nodes.Add(new TreeNode {Name = plugin.Instance.Name, 
                                                      Text = plugin.Instance.Name});
      }
    }

    void treeViewLoadedPlugins_AfterSelect(object sender, TreeViewEventArgs e)
    {
      AvailablePlugin plugin = _plugins.AvailablePlugins.Find(treeViewLoadedPlugins.SelectedNode.Name);
      labelPluginName.Text = plugin.Instance.Name;
      labelVersion.Text = plugin.Instance.Version;
      labelAuthor.Text = plugin.Instance.Author;
      textBoxDescript.Text = plugin.Instance.Description;
    }
  }
}
