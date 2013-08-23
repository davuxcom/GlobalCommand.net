using System;

namespace GCPluginFramework
{
    /// <summary>
    /// Specify the type of the plugin.  (Use Default always)
    /// </summary>
    public enum PluginType
    {
        /// <summary>
        /// Default plugin
        /// </summary>
        Default,
        /// <summary>
        /// Unknown plugin
        /// </summary>
        Unknown
    };
    
    /// <summary>
    /// PluginAttribute for IGCPLugin interface
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class PluginAttribute : Attribute
    {
        private PluginType _Type;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="T">Type of plugin</param>
        public PluginAttribute(PluginType T)
        {
            _Type = T;
        }

        /// <summary>
        /// Return the type of plugin.
        /// </summary>
        public PluginType Type
        {
            get { return _Type; }
        }
    }
    
    /// <summary>
    /// GlobalCommand Plugin Interface.
    /// </summary>
    public interface IGCPlugin
    {

        /// <summary>
        /// Author of this plugin
        /// </summary>
        string Author { get; }
        /// <summary>
        /// Short description of the plugin
        /// </summary>
        string Description { get; }
        /// <summary>
        /// This is the full name of the application
        /// </summary>
        string FriendlyName { get; }
        /// <summary>
        /// This is the short name that will be used to execute commands.  [ShortName.Command]
        /// </summary>
        string ShortName { get; }
        /// <summary>
        /// Access saved settings between sessions
        /// </summary>
        /// <param name="settings">array of settings</param>
        void LoadSettings(string[]  settings);
        /// <summary>
        /// This is called at the end of the session, return a string array to be saved at next load
        /// </summary>
        /// <returns></returns>
        string[]  SaveSettings();



        /// <summary>
        /// Get a list of cmds to populate the 'insert' menu with.  These cmds must have
        /// a description for the help system.
        /// </summary>
        /// <returns>
        /// Array of gcCommands that will be used to build the insert menut for this plugin
        /// </returns>
        gcCommand[] getCommands();

        /// <summary>
        /// Execute the cmd specified in getcmds.  This should actually carry out the operation.
        /// 
        /// </summary>
        /// <param name="cmd">String representing the key in the command [Namespace.Key Arguments]</param>
        /// <param name="args">Arguments passed by the user at design time, or at runtime (#)</param>
        /// <returns>return a string to be printed to the screen in place of the command.</returns>
        string ExecuteCommand(string cmd, string args);
        
        /// <summary>
        /// Preview the cmd to be executed.  No actions should ever be carried out in this method.
        /// </summary>
        /// <param name="cmd">String represending the key in the command [Namespace.key Arguments]</param>
        /// <param name="args">Arguments passed by the user at design time.</param>
        /// <returns>Return a string that is HTML formatted to look like the output in the designated application.</returns>
        string PreviewCommandOutput(string cmd, string args);
        
        /// <summary>
        /// Short string description
        /// </summary>
        /// <returns>String for the plugin list</returns>
        string ToString();
        
        /// <summary>
        /// Display the configuration dialog in a blocking way.  (ShowDialog())
        /// </summary>
        /// <returns>
        /// true if dialog was displayed, false otherwise.
        /// </returns>
        bool ShowConfigDialog();
        
        
    }


    /// <summary>
    /// Primary class for holding an cmd that represents a possible action which GlobalCommand can take on the plugin.
    /// </summary>
    public class gcCommand
    {
        /// <summary>
        /// Key represents [Namespace.KEY Arguments] in the command structure.
        /// </summary>
        public string CommandKey;
        /// <summary>
        /// Provide a short description for the help system.
        /// </summary>
        public string Description;



        /// <summary>
        /// Build a new gcCommand completely.
        /// </summary>
        /// <param name="desc">Description of the command</param>
        /// <param name="key">Key for the command</param>
        public gcCommand(string desc, string key)
        {
            Description = desc;
            CommandKey = key;
        }

        /// <summary>
        /// returns the Command key
        /// </summary>
        /// <returns>Command Key</returns>
        public override string ToString()
        {
            return CommandKey;
        }
    }


}
