using System.Windows.Forms;
using EEM.Common.Contracts;

namespace EEM.Plugins.Common.Contracts
{
  public interface IPlugin
  {
    /// <summary>
    /// Author of the plug-in
    /// </summary>
    string Author { get; }

    /// <summary>
    /// Description of the plug-in
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Main interface for your plug-in.
    /// </summary>
    /// <remarks>
    /// If you want a screen for your plug-in then set this to your form and 
    /// call MainInterface.Show() in Initialize(). 
    /// 
    /// If you do not want a screen, (i.e. your writing a plug-in that logs chat to 
    /// a log file and does not need a screen.) do not call MainInterface.Show().
    /// </remarks>
    /// <example>
    ///   MainInterface = new MyPluginScreen();
    ///   MainInterface.MdiParent = enterpriseEmpireManager.GetMdiParent();
    ///   MainInterface.Show();
    /// </example>
    Form MainInterface { get; }

    /// <summary>
    /// Name of the plug-in
    /// </summary>
    string Name { get; }
    
    /// <summary>
    /// Current Version of the plug-in
    /// </summary>
    string Version { get; }
    
    /// <summary>
    /// EEM calls after it loads to send you a reference to itself and the LoUAdapter.
    /// </summary>
    /// <param name="enterpriseEmpireManager"></param>
    void Initialize(IEnterpriseEmpireManager enterpriseEmpireManager);

    /// <summary>
    /// EEM calls this when unloading your plug-in.
    /// </summary>
    void Dispose();
  }
}
