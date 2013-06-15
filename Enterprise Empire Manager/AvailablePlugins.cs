using System.Collections;

namespace EEM
{
	/// <summary>
	/// Collection for AvailablePlugin Type
	/// </summary>
	internal class AvailablePlugins : CollectionBase
	{
		//A Simple Home-brew class to hold some info about our Available Plug-ins
			
		/// <summary>
		/// Add a Plug-in to the collection of Available plug-ins
		/// </summary>
		/// <param name="pluginToAdd">The Plug-in to Add</param>
		public void Add(AvailablePlugin pluginToAdd)
		{
			List.Add(pluginToAdd); 
		}
		
		/// <summary>
		/// Remove a Plug-in to the collection of Available plug-ins
		/// </summary>
		/// <param name="pluginToRemove">The Plug-in to Remove</param>
		public void Remove(AvailablePlugin pluginToRemove)
		{
			List.Remove(pluginToRemove);
		}
		
		/// <summary>
		/// Finds a plug-in in the available Plug-ins
		/// </summary>
		/// <param name="pluginNameOrPath">The name or File path of the plug-in to find</param>
		/// <returns>Available Plug-in, or null if the plug-in is not found</returns>
		public AvailablePlugin Find(string pluginNameOrPath)
		{
			AvailablePlugin toReturn = null;
			
			//Loop through all the plug-ins
			foreach (AvailablePlugin pluginOn in List)
			{
				//Find the one with the matching name or filename
				if ((pluginOn.Instance.Name.Equals(pluginNameOrPath)) || pluginOn.AssemblyPath.Equals(pluginNameOrPath))
				{
					toReturn = pluginOn;
					break;		
				}
			}
			return toReturn;
		}
	}
}