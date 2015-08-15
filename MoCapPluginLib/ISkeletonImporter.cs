using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCapPluginLib
{
    public interface ISkeletonImporter
    {
        MoCapPluginLib.Skeleton ReadSkeleton(string fileName);
    }
}
