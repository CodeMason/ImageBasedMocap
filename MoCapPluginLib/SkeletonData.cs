using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoCapPluginLib
{
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
        Foot
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
