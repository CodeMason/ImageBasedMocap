using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCapPluginLib
{
    public class JointNameTable
    {
        static Dictionary<string, JointType> mapping_;

        public static JointType GetJointType(string name)
        {
            if (mapping_ == null)
            {
                mapping_ = new Dictionary<string, JointType>();
                mapping_["head"] = JointType.Head;
                mapping_["neck"] = JointType.Neck;

                mapping_["uppertorso"] = JointType.UpperTorso;
                mapping_["chest"] = JointType.UpperTorso;
                
                mapping_["shoulder"] = JointType.Shoulder;
                mapping_["arm"] = JointType.Shoulder;
                mapping_["upperarm"] = JointType.Shoulder;

                mapping_["pelvis"] = JointType.Pelvis;
                mapping_["hips"] = JointType.Pelvis;

                mapping_["hip"] = JointType.Hip;
                mapping_["upleg"] = JointType.Hip;
                mapping_["upperleg"] = JointType.Hip;

                mapping_["elbow"] = JointType.Elbow;
                mapping_["forearm"] = JointType.Elbow;
                mapping_["lowerarm"] = JointType.Elbow;

                mapping_["wrist"] = JointType.Wrist;
                mapping_["hand"] = JointType.Wrist;

                mapping_["knee"] = JointType.Knee;
                mapping_["leg"] = JointType.Knee;
                mapping_["lowerleg"] = JointType.Knee;

                mapping_["ankle"] = JointType.Ankle;
                mapping_["foot"] = JointType.Foot;

                mapping_["lowertorso"] = JointType.LowerTorso;
                mapping_["spine"] = JointType.LowerTorso;
            }

            foreach (string key in mapping_.Keys)
            {
                if (name.ToLower().Contains(key))
                    return mapping_[key];
            }
            return JointType.Invalid;
        }
    }

    /// <summary>
    /// Nature of the joint
    /// </summary>
    public enum JointType
    {
        Head,
        Neck,
        UpperTorso,
        Shoulder,
        Elbow,
        Wrist,

        LowerTorso,
        Pelvis,
        Hip,
        Knee,
        Ankle,
        Foot,

        Invalid
    }

    /// <summary>
    /// Body side to which the joint belongs
    /// </summary>
    public enum JointSide
    {
        None = 0,
        Left,
        Right
    }

    /// <summary>
    /// Data for a skeleton joint.
    /// </summary>
    public class Joint
    {
        public Joint()
        {
            Children = new List<Joint>();
            RotationTolerance = 1.0f;
            LinearTolerance = 1.0f;
        }

        public String Name { get; set; }
        public JointType Kind { get; set; }
        public JointSide Side { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Matrix4 Transform { get; set; }

        public List<Joint> Children { get; private set; }
        public float RotationTolerance { get; set; } // Tolerance for rotational constraints
        public float LinearTolerance { get; set; } // Tolerance for linear constraints
    }

    public class Skeleton
    {
        public string Name { get; set; }
        public Joint Root { get; set; }
    }
}
