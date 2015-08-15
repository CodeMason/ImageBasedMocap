using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVHFormat
{
    public class BVHLine
    {
        public static String HIERARCHY = "HIERARCHY";
        public static String BONE = "BONE";
        public static String BRACE_OPEN = "BRACE_OPEN";
        public static String BRACE_CLOSED = "BRACE_CLOSED";
        public static String OFFSET = "OFFSET";
        public static String CHANNELS = "CHANNELS";
        public static String END_SITE = "END_SITE";
    
        public static String MOTION = "MOTION";
        public static String FRAMES = "FRAMES";
        public static String FRAME_TIME = "FRAME_TIME";
        public static String FRAME = "FRAME";
    
    
        public static String BONE_TYPE_ROOT = "ROOT";
        public static String BONE_TYPE_JOINT = "JOINT";

        String _lineStr;

        String _lineType;
        String _boneType;

        String _boneName;
        float _offsetX;
        float _offsetY;
        float _offsetZ;
        int _nbChannels;
        List<String> _channelsProps;
        int _nbFrames;
        float _frameTime;
        List<float> _frames;

        public BVHLine(string line)
        {
            _parse(line);
        }

        public override String ToString()
        {
            return _lineStr;
        }

        void _parse(String __lineStr)
        {
            _lineStr = __lineStr;
            _lineStr = _lineStr.Trim();
            _lineStr = _lineStr.Replace("\t", "");
            _lineStr = _lineStr.Replace("\n", "");
            _lineStr = _lineStr.Replace("\r", "");  
      
            String[] words = _lineStr.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
    
            _lineType = _parseLineType(words);
      
            //    
            if (HIERARCHY.Equals(_lineType) )
            {
                return;
            } else if (BONE.Equals(_lineType) ) {
                _boneType = (words[0] == "ROOT") ? BONE_TYPE_ROOT : BONE_TYPE_JOINT;
                _boneName = words[1];
                return;
            } else if (OFFSET.Equals(_lineType) ) {
                _offsetX = float.Parse(words[1]);
                _offsetY = float.Parse(words[2]);
                _offsetZ = float.Parse(words[3]);
                return;
            } else if (CHANNELS.Equals(_lineType) ) {
                _nbChannels = int.Parse(words[1]);
                _channelsProps = new List<String>();
                for (int i = 0; i < _nbChannels; i++)
                    _channelsProps.Add(words[i+2]);
                return;
        
            } else if (FRAMES.Equals(_lineType) ) {
                _nbFrames = int.Parse(words[1]);
                return;
            } else if (FRAME_TIME.Equals(_lineType) ) {
                _frameTime = float.Parse(words[2]);
                return;
            } else if (FRAME.Equals(_lineType) ) {
                _frames = new List<float>();
                foreach (String word in words) 
                    _frames.Add(float.Parse(word));
                return;
            } else if (END_SITE.Equals(_lineType) ||
                BRACE_OPEN.Equals(_lineType) ||
                BRACE_CLOSED.Equals(_lineType) ||
                MOTION.Equals(_lineType)) {
                return;
            }
        }

        String _parseLineType(String[] __words)
        {
            //trace("'" + __words[0] + "' : " + __words[0].length);
            if ("HIERARCHY".Equals(__words[0]))
                return HIERARCHY;
            if ("ROOT".Equals(__words[0]) ||
                "JOINT".Equals(__words[0]))
                return BONE;
            if ("{".Equals(__words[0]))
                return BRACE_OPEN;
            if ("}".Equals(__words[0]))
                return BRACE_CLOSED;
            if ("OFFSET".Equals(__words[0]))
                return OFFSET;
            if ("CHANNELS".Equals(__words[0]))
                return CHANNELS;
            if ("End".Equals(__words[0]))
                return END_SITE;
            if ("MOTION".Equals(__words[0]))
                return MOTION;
            if ("Frames:".Equals(__words[0]))
                return FRAMES;
            if ("Frame".Equals(__words[0]))
                return FRAME_TIME;

            try
            {
                float.Parse(__words[0]); //check is Parsable
                return FRAME;
            }
            catch (Exception e)
            {
                
            }
            return null;
        }
    }

    public class BVHParser
    {
    }
}
