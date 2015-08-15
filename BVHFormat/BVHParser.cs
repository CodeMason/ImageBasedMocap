using MoCapPluginLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVHFormat
{
    public class BvhLine
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

        public String _boneName;
        float _offsetX;
        float _offsetY;
        float _offsetZ;
        int _nbChannels;
        List<String> _channelsProps;
        int _nbFrames;
        float _frameTime;
        List<float> _frames;

        public BvhLine(string line)
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
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public List<float> getFrames()
        {
            return _frames;
        }

        public float getFrameTime()
        {
            return _frameTime;
        }

        public int getNbFrames()
        {
            return _nbFrames;
        }

        public List<String> getChannelsProps()
        {
            return _channelsProps;
        }

        public int getNbChannels()
        {
            return _nbChannels;
        }

        public float getOffsetZ()
        {
            return _offsetZ;
        }

        public float getOffsetY()
        {
            return _offsetY;
        }

        public float getOffsetX()
        {
            return _offsetX;
        }

        public String getBoneName()
        {
            return _boneName;
        }

        public String getBoneType()
        {
            return _boneType;
        }

        public String getLineType()
        {
            return _lineType;
        }
    }

    public class BVHParser
    {
        Boolean _motionLoop;
  
        int _currentFrame = 0;
  
        List<BvhLine> _lines;
  
        int _currentLine;
        BvhBone _currentBone;
  
        BvhBone _rootBone;
        List< List<float> > _frames;
        int _nbFrames;
        float _frameTime;
  
        List<BvhBone> _bones;
  
        public BVHParser()
        {
            _motionLoop = true;
        }

        /**
        * if set to True motion will loop at end
        */
        public bool getMotionLoop()
        {
            return _motionLoop;
        }
  
        /**
        * set Loop state
        * @param value
        */
        public void setMotionLoop(bool value)
        {
            _motionLoop = value;
        }

        /**
        * to string
        * @return
        */
        public override String ToString()
        {
	        return _rootBone.structureToString();
        }
  
        /**
        * get frame total
        * @return
        */
        public int getNbFrames()
        {
            return _nbFrames;
        }

        /**
        * get bones list
        * @return
        */
        public List<BvhBone> getBones()
        {
            return _bones;
        }


        /**
        * call before parse BVH
        * 	create array instance
        * 	and setloopstatus true
        */
        public void init()
        {
            _bones = new List<BvhBone>();
            _motionLoop = true;
        }
  
        /**
        * go to the frame at index
        */
        public void moveFrameTo(int __index)
        {
            if(!_motionLoop)
            {
                if(__index >= _nbFrames)
                _currentFrame = _nbFrames-1;//last frame
            }else{
                while (__index >= _nbFrames)
                __index -= _nbFrames;      
                _currentFrame = __index; //looped frame
            }
            _updateFrame();
        }

        /**
        * go to millisecond of the BVH
        * @param mills millisecond
        * @param loopSec the default loopsec for 
        */
        public void moveMsTo( int mills )
        {
            float frameTime = _frameTime * 1000;
            int curFrame = (int)(mills / frameTime); 
            moveFrameTo( curFrame ); 
        }
  
        /**
        * update bone position and rotation
        */
        public void update()
        {
	        update( getBones()[0] );
        }
  
        protected void update(BvhBone bone )
        {
	        //Matrix4 m = new Matrix4();
            //
	        //m.Translate(bone.getXposition(), bone.getYposition(), bone.getZposition());
	        //m.Translate(bone.getOffsetX(), bone.getOffsetY(), bone.getOffsetZ());
	        //
	        //m.RotateY(bone.getYrotation() * MathUtils.degreesToRadians);
	        //m.RotateX(bone.getXrotation() * MathUtils.degreesToRadians);
	        //m.RotateZ(bone.getZrotation() * MathUtils.degreesToRadians);
	        //
	        //bone.global_matrix = m;
            //
	        //if (bone.getParent() != null && bone.getParent().global_matrix != null)
	        //    m.preApply(bone.getParent().global_matrix);
	        //m.mult(new Vector3(), bone.getAbsPosition());
	        //
	        //if (bone.getChildren().Count > 0)
	        //{
	        //    foreach (BvhBone child in bone.getChildren())
	        //    {
	        //        update(child);
	        //    }
	        //}
	        //else
	        //{
	        //    m.translate(bone.getEndOffsetX(), bone.getEndOffsetY(), bone.getEndOffsetZ());
	        //    m.mult(new Vector3(), bone.getAbsEndPosition());
	        //}
        }
  
  
        private void _updateFrame()
        {
            if (_currentFrame >= _frames.Count) 
                return;
            List<float> frame = _frames[_currentFrame];
            int count = 0;
            foreach (float n in frame)
            {
                //BvhBone bone = _getBoneInFrameAt(count);
                //String prop = _getBonePropInFrameAt(count);
                //if(bone != null) {
                //    Method getterMethod;
                //    try {
                //        getterMethod = bone.getClass().getDeclaredMethod("set".concat(prop), new Class[]{float.class});
                //        getterMethod.invoke(bone, n);
                //    } catch (SecurityException e) {
                //        e.printStackTrace();
                //        System.err.println("ERROR WHILST GETTING FRAME - 1");
                //    } catch (NoSuchMethodException e) {
                //        e.printStackTrace();
                //        System.err.println("ERROR WHILST GETTING FRAME - 2");
                //    } catch (IllegalArgumentException e) {
                //        e.printStackTrace();
                //        System.err.println("ERROR WHILST GETTING FRAME - 3");
                //    } catch (IllegalAccessException e) {
                //        e.printStackTrace();
                //        System.err.println("ERROR WHILST GETTING FRAME - 4");
                //    } catch (InvocationTargetException e) {
                //        e.printStackTrace();
                //        System.err.println("ERROR WHILST GETTING FRAME - 5");
                //    }
                //}
                count++;
            }      
        }    
  
        private String _getBonePropInFrameAt(int n)
        {
            int c = 0;      
            foreach (BvhBone bone in _bones)
            {
                if (c + bone.getNbChannels() > n)
                {
                n -= c;
                return bone.getChannels()[n];
                }else{
                c += bone.getNbChannels();  
                }
            }
            return null;
        }
  
        private BvhBone _getBoneInFrameAt( int n)
        {
            int c = 0;      
            foreach (BvhBone bone in _bones)
            {
                c += bone.getNbChannels();
                if ( c > n )
                return bone;
            }
            return null;
        }    
  
        public void parse(String[] srces)
        {
            String[] linesStr = srces;
            // liste de BvhLines
            _lines = new List<BvhLine>();
    
            foreach ( String lineStr in linesStr)
                _lines.Add(new BvhLine(lineStr));
      
            _currentLine = 1;
            _rootBone = _parseBone();
    
            // center locs
            //_rootBone.offsetX = _rootBone.offsetY = _rootBone.offsetZ = 0; 
    
            _parseFrames();
        }    
  
        private void _parseFrames()
        {
            int currentLine = _currentLine;
            for (; currentLine < _lines.Count; currentLine++)
                if(_lines[currentLine].getLineType() == BvhLine.MOTION) 
                    break; 

            if ( _lines.Count > currentLine) 
            {
                currentLine++; //Frames
                _nbFrames = _lines[currentLine].getNbFrames();
                currentLine++; //FrameTime
                _frameTime = _lines[currentLine].getFrameTime();
                currentLine++;
  
                _frames = new List< List<float> >();
                for (; currentLine < _lines.Count; currentLine++)
                {
                    _frames.Add(_lines[currentLine].getFrames());
                }
            }
        }
  
        private BvhBone _parseBone()
        {
        //_currentBone is Parent
            BvhBone bone = new BvhBone( _currentBone );
    
            _bones.Add(bone);
    
            bone.setName(  _lines[_currentLine]._boneName ); //1
    
            // +2 OFFSET
            _currentLine++; // 2 {
            _currentLine++; // 3 OFFSET
            bone.setOffsetX( _lines[_currentLine].getOffsetX() );
            bone.setOffsetY( _lines[_currentLine].getOffsetY() );
            bone.setOffsetZ( _lines[_currentLine].getOffsetZ() );
      
            // +3 CHANNELS
            _currentLine++;
            bone.setnbChannels( _lines[_currentLine].getNbChannels() );
            bone.setChannels( _lines[_currentLine].getChannelsProps() );
      
            // +4 JOINT or End Site or }
            _currentLine++;
            while(_currentLine < _lines.Count)
            {
                String lineType = _lines[_currentLine].getLineType();
                if ( BvhLine.BONE.Equals( lineType ) ) //JOINT or ROOT
                {
                    BvhBone child = _parseBone(); //generate new BvhBONE
                    child.setParent( bone );
                    bone.getChildren().Add(child);
                }
                else if( BvhLine.END_SITE.Equals( lineType ) )
                {
                    _currentLine++; // {
                    _currentLine++; // OFFSET
                    bone.setEndOffsetX( _lines[_currentLine].getOffsetX() );
                    bone.setEndOffsetY( _lines[_currentLine].getOffsetY() );
                    bone.setEndOffsetZ( _lines[_currentLine].getOffsetZ() );
                    _currentLine++; //}
                    _currentLine++; //}
                    return bone;
                } 
                else if( BvhLine.BRACE_CLOSED.Equals( lineType ) )
                {
                    return bone; //}
                }
                _currentLine++;
            }
            Console.WriteLine("//Something strange");
            return bone;  
        }    
    }
}
