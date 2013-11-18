using System.Windows.Forms;

namespace EEM.Common.Contracts
{
  public interface IEnterpriseEmpireManager
  {

    /// <summary>
    /// Get the Mdi Parent
    /// </summary>
    /// <returns></returns>
    Form GetMdiParent();

    /// <summary>
    /// Adds an item to a menu.
    /// </summary>
    /// <param name="tools"></param>
    /// <param name="rawDataOptionsMenuItem"></param>
    void AddMenuItem(EEMMenuItems tools, ToolStripMenuItem rawDataOptionsMenuItem);

    /// <summary>
    /// Removes an item from a menu.
    /// </summary>
    /// <param name="menuItem"></param>
    /// <param name="toolStripMenuItem"></param>
    void RemoveMenuItem(EEMMenuItems menuItem, ToolStripMenuItem toolStripMenuItem);


    /// <summary>
    /// Adapter used to send commands to LoU
    /// </summary>
    ILoUAdapter LoUAdapter { get; }
  }
}