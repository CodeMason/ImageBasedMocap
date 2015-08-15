using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVHFormat
{
    /// <summary>
    /// Imports a skeleton from a BVH file.
    /// </summary>
    [MoCapPluginLib.AdvertiseSettings(Name = "BVH Skeleton")]
    public class BVHSkeletonImporter : MoCapPluginLib.ISkeletonImporter
    {
        public MoCapPluginLib.Skeleton ReadSkeleton(string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);

            return null;
        }
    }
}
