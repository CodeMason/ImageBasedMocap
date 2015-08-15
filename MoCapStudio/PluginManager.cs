using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;

namespace MoCapStudio
{
    public class PluginInfo
    {
        public object Plugin { get; private set; }
        public string Name { get; private set; }

        public PluginInfo(object obj, string name)
        {
            Plugin = obj;
            Name = name;
        }
    }

    public class PluginAssemblyInfo
    {
        public string Name { get; private set; }
        public string[] Parts { get; private set; }

        public List<string> Components { get; private set; }

        public PluginAssemblyInfo(string aName, string[] nameParts)
        {
            Name = aName;
            Parts = nameParts;
            Components = new List<string>();
        }
    }

    public class PluginManager
    {
        static PluginManager inst_;
        Dictionary<Type, List<PluginInfo> > Plugins;
        Dictionary<Type, PluginInfo> Selected;
        List<PluginAssemblyInfo> Assemblies;

        private PluginManager()
        {
            Assemblies = new List<PluginAssemblyInfo>();
            Plugins = new Dictionary<Type, List<PluginInfo>>();
            Selected = new Dictionary<Type, PluginInfo>();

            // Build lists
            Plugins[typeof(MoCapPluginLib.IAnimationExporter)] = new List<PluginInfo>();
            Plugins[typeof(MoCapPluginLib.ISkeletonImporter)] = new List<PluginInfo>();

            string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "plugins");
            if (!System.IO.Directory.Exists(path))
                return;

            foreach (string file in System.IO.Directory.GetFiles(path))
            {
                if (System.IO.Path.GetExtension(file).Equals(".dll") && System.IO.File.Exists(file))
                {
                    try
                    {
                        Assembly asm = Assembly.LoadFile(file);
                        Type[] types = asm.GetExportedTypes();
                        FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(asm.Location);
                        PluginAssemblyInfo plugin = new PluginAssemblyInfo(asm.ManifestModule.Name, new string[] { myFileVersionInfo.ProductName, myFileVersionInfo.ProductVersion, myFileVersionInfo.CompanyName, myFileVersionInfo.Comments });
                        Assemblies.Add(plugin);

                        foreach (Type t in types)
                        {
                            foreach (Type keyType in Plugins.Keys)
                            {
                                if (t.GetInterfaces().Contains(keyType))
                                {
                                    object plugObject = Activator.CreateInstance(t);
                                    if (plugObject != null)
                                    {
                                        string plugName = t.Name;
                                        MoCapPluginLib.AdvertiseSettings settingsRoot = t.GetCustomAttribute<MoCapPluginLib.AdvertiseSettings>();
                                        if (settingsRoot != null)
                                            plugName = settingsRoot.Name;
                                        PluginInfo plugInfo = new PluginInfo(plugObject, plugName);
                                        Plugins[keyType].Add(plugInfo);
                                    }
                                }
                            }
                        }

                        if (plugin.Components.Count > 0)
                            Assemblies.Add(plugin);
                    }
                    catch (Exception ex)
                    {
                        ErrorHandler.GetInst().PushError(ex);
                    }
                }
            }
        }

        public static PluginManager GetInst()
        {
            if (inst_ == null)
                inst_ = new PluginManager();
            return inst_;
        }

        public List<PluginInfo> GetPlugins(Type forType)
        {
            return Plugins[forType];
        }

        public List<PluginAssemblyInfo> GetAssemblies()
        {
            return Assemblies;
        }
    }
}
