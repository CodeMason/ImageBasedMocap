using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCapPluginLib
{
    /// <summary>
    /// Marks a class that advertises settings
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class AdvertiseSettings : Attribute
    {
        public string Name { get; set; }
    }

    /// <summary>
    /// Marks properties that are for settings display.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class AdvertiseSetting : Attribute
    {
    }
}
