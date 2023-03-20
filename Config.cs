using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace CG_Project
{
    static class Config
    {
        static float _vertFovRatio = 0.5625f; // 16:9
        static float _baseFov = 100;
        static float _drawDist = 100;

        public static float VertFovRatio
        {
            get { return _vertFovRatio; }
            set { _vertFovRatio = value; }
        }

        public static float BaseFov
        { 
            get { return _baseFov; }
            set { _baseFov = value; }
        }

        public static float DrawDist
        { 
            get { return _drawDist; }
            set { _drawDist = value; }
        }

        public static void prop()
        {
            
        }
    }
}
