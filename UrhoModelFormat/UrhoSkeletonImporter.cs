using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrhoModelFormat
{
    /// <summary>
    /// Imports a skeleton from an Urho3D model
    /// </summary>
    [MoCapPluginLib.AdvertiseSettings(Name = "Urho3D Model Skeleton")]
    public class UrhoSkeletonImporter : MoCapPluginLib.ISkeletonImporter
    {
        public MoCapPluginLib.Skeleton ReadSkeleton(string fileName)
        {
            return null;
        }
    }
}
