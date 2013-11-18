using EEM.Plugins.Common.Contracts;

namespace EEM
{
	/// <summary>
	/// Data Class for Available Plug-in.  Holds and instance of the loaded Plug-in, as well as the Plug-in's Assembly Path
	/// </summary>
	internal class AvailablePlugin
	{
		//This is the actual AvailablePlugin object.. 
		//Holds an instance of the plug-in to access
		//Also holds assembly path... not really necessary
		public string AssemblyPath { get; set; }
		public IPlugin Instance { get; set; }

		public AvailablePlugin()
		{
			AssemblyPath = "";
			Instance = null;
		}
	}
}