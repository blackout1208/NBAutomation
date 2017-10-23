using System;
using System.Configuration;

namespace NBautoFramework.Config.ConfigElement
{
    /// <summary>
    /// The Collection of elements of configuration from xml file
    /// </summary>
    [ConfigurationCollection(typeof(NBautoFrameworkElement), AddItemName = "testSetting", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class NBautoFrameworkElementCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// Creates the NBautoFrameworkElement object
        /// </summary>
        /// <returns>NBautoFrameworkElement object</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new NBautoFrameworkElement();
        }

        /// <summary>
        /// Gets identifier from the xml node
        /// </summary>
        /// <param name="element">Xml node</param>
        /// <returns>The value of element</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as NBautoFrameworkElement)?.Environment ?? throw new InvalidOperationException("Element is null.");
        }

        /// <summary>
        /// DriversFolder attribute on configuration file.
        /// </summary>
        [ConfigurationProperty("driversFolder", IsRequired = true)]
        public string DriversFolder { get { return (string)base["driversFolder"]; } }

        /// <summary>
        /// LogFolder attribute on configuration file.
        /// </summary>
        [ConfigurationProperty("logsFolder", IsRequired = true)]
        public string LogsFolder { get { return (string)base["logsFolder"]; } }

        /// <summary>
        /// Gets the value that corresponds to the attribute
        /// </summary>
        /// <param name="attribute">The attribute of the node</param>
        public new NBautoFrameworkElement this[string attribute]
        {
            get { return (NBautoFrameworkElement) this.BaseGet(attribute); }
        }
    }
}
