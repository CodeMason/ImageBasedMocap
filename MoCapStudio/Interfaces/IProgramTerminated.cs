using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MoCapStudio.Interfaces
{
    [AttributeUsage(AttributeTargets.Class)]
    public class IProgramTerminated : Attribute
    {

        public static void Terminate()
        {
            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    foreach (Type t in asm.GetTypes())
                    {
                        IProgramTerminated init = t.GetCustomAttribute<IProgramTerminated>();
                        if (init != null)
                        {
                            MethodInfo mi = t.GetMethod("Terminate", BindingFlags.Static | BindingFlags.NonPublic);
                            if (mi != null)
                                mi.Invoke(null, null);
                        }
                    }
                }
                catch (Exception)
                {
                    //eat it
                }
            }
        }
    }
}
