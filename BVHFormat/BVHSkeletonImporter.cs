using MoCapPluginLib;
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
    public class BVHSkeletonImporter : ISkeletonImporter
    {
        public Skeleton ReadSkeleton(string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);

            BVHParser parser = new BVHParser();
            parser.parse(lines);

            Skeleton skeleton = new Skeleton();
            skeleton.Name = System.IO.Path.GetFileNameWithoutExtension(fileName);

            BvhBone rootBone = parser.getRootBone();
            Joint rootJoint = new Joint();
            processBone(rootBone, rootJoint);
            skeleton.Root = rootJoint;

            return skeleton;
        }

        void processBone(BvhBone bone, Joint joint)
        {
            joint.Position = new Vector3(bone.getOffsetX(), bone.getOffsetY(), bone.getOffsetZ());
            joint.Name = bone.getName();
            joint.Kind = JointNameTable.GetJointType(joint.Name);

            if (joint.Name.StartsWith("Left") || joint.Name.StartsWith("l"))
            {
                joint.Side = JointSide.Left;
            } 
            else if (joint.Name.StartsWith("Right") || joint.Name.StartsWith("r"))
            {
                joint.Side = JointSide.Right;
            }

            if (bone.hasChildren())
            {
                foreach (BvhBone childBone in bone.getChildren())
                {
                    Joint childJoint = new Joint();
                    processBone(bone, childJoint);
                    if (childJoint.Kind != JointType.Invalid)
                        joint.Children.Add(childJoint);
                }
            }
        }
    }
}
