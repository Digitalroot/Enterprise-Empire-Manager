using System;
using System.IO;
using System.Reflection;
using EEM.Common.Contracts;
using EEM.Plugins.Common.Contracts;

namespace EEM 
{
  /// <summary>
  /// Plug-in framework based on Redth's "Plug-ins in C#" 5 Mar 2004 
  /// http://www.codeproject.com/KB/cs/pluginsincsharp.aspx
  /// 
  /// ToDo: Change Plug-in framework to System.AddIn
  /// 
  /// Summary description for PluginServices.
  /// </summary>
  public class PluginServices
  {
    /// <summary>
    /// A Collection of all Plug-in Found and Loaded by the FindPlugins()
    /// </summary>
    internal AvailablePlugins AvailablePlugins { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    public PluginServices()
    {
      AvailablePlugins = new AvailablePlugins();
    }

    /// <summary>
    /// Searches the Application's Startup Directory for Plug-ins
    /// </summary>
    public void FindPlugins()
    {
      if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "plug-ins"))
      {
        FindPlugins(AppDomain.CurrentDomain.BaseDirectory + "plug-ins");        
      }
    }
    /// <summary>
    /// Searches the passed Path for Plug-ins
    /// </summary>
    /// <param name="path">Directory to search for Plug-ins in</param>
    public void FindPlugins(string path)
    {
      //First empty the collection, we're reloading them all
      AvailablePlugins.Clear();
    
      //Go through all the files in the plug-in directory
      foreach (string fileOn in Directory.GetFiles(path))
      {
        var file = new FileInfo(fileOn);
        
        //Preliminary check, must be .dll
        if (file.Extension.Equals(".dll"))
        {	
          //Add the 'plug-in'
          AddPlugin(fileOn);				
        }
      }
    }
    
    /// <summary>
    /// Unloads and Closes all AvailablePlugins
    /// </summary>
    public void ClosePlugins()
    {
      foreach (AvailablePlugin pluginOn in AvailablePlugins)
      {
        //Close all plug-in instances
        //We call the plug-in Dispose sub first incase it has to do 
        //Its own cleanup stuff
        pluginOn.Instance.Dispose(); 
        
        //After we give the plug-in a chance to tidy up, get rid of it
        pluginOn.Instance = null;
      }
      
      //Finally, clear our collection of available plug-ins
      AvailablePlugins.Clear();
    }

    /// <summary>
    /// Initialize all AvailablePlugins
    /// </summary>
    public void InitializePlugins(IEnterpriseEmpireManager enterpriseEmpireManager)
    {
      foreach (AvailablePlugin pluginOn in AvailablePlugins)
      {
        pluginOn.Instance.Initialize(enterpriseEmpireManager);
      }
    }

    /// <summary>
    /// Adds a plug-in
    /// </summary>
    /// <param name="fileName"></param>
    private void AddPlugin(string fileName)
    {
      //Create a new assembly from the plug-ins file we're adding..
      Assembly pluginAssembly = Assembly.LoadFrom(fileName);
      
      //Next we'll loop through all the Types found in the assembly
      foreach (Type pluginType in pluginAssembly.GetTypes())
      {
        if (pluginType.IsPublic) //Only look at public types
        {
          if (!pluginType.IsAbstract)  //Only look at non-abstract types
          {
            //Gets a type object of the interface we need the plug-ins to match
            Type typeInterface = pluginType.GetInterface("EEM.Plugins.Common.Contracts.IPlugin", true);
            
            //Make sure the interface we want to use actually exists
            if (typeInterface != null)
            {
              //Create a new available plug-in since the type implements the IPlugin interface
              var newPlugin = new AvailablePlugin();
              
              //Set the filename where we found it
              newPlugin.AssemblyPath = fileName;
              
              //Create a new instance and store the instance in the collection for later use
              //We could change this later on to not load an instance.. we have 2 options
              //1- Make one instance, and use it whenever we need it.. it's always there
              //2- Don't make an instance, and instead make an instance whenever we use it, then close it
              //For now we'll just make an instance of all the plug-ins
              newPlugin.Instance = (IPlugin)Activator.CreateInstance(pluginAssembly.GetType(pluginType.ToString()));
              
              //Set the Plug-in's host to this class which inherited IPluginHost
              //newPlugin.Instance.Host = this;

              //Call the initialization sub of the plug-in
              //newPlugin.Instance.Initialize();
              
              //Add the new plug-in to our collection here
              AvailablePlugins.Add(newPlugin);
              
            }
          }				
        }			
      }
    }
  }
}

