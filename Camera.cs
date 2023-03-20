using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Project
{
    class Camera
    {
        Point _position;
        Vector _lookDir;
        Point _lookAt;
        float _distance;
        float _horFov;
        float _vertFovRatio;

        public Point Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Vector LookDir
        {
            get { return _lookDir; }
            set { _lookDir = value; }
        }

        public Point LookAt
        {
            get { return _lookAt; }
            set { _lookAt = value; }
        }

        public float Distance
        {
            get { return _distance; }
            set { _distance = value; }
        }

        public float HorFov
        { 
            get { return _horFov; }
            set { _horFov = value; }
        }

        public float VertFovRatio
        {
            get { return _vertFovRatio; }
            set { _vertFovRatio = value; }
        }

        public Camera() : this(VectorSpace.InitPt, VectorSpace.Basis1, Config.BaseFov, Config.VertFovRatio) { }

        public Camera(Point position, Vector lookDir, params float[] args)
        {
            Position = position;
            LookDir = !lookDir;
            LookAt = null;
            HorFov = Config.BaseFov;
            VertFovRatio = Config.VertFovRatio;
            if (args.Length > 2) throw new ArgumentException();
            if (args.Length > 0) HorFov = args[0];
            if (args.Length > 1) VertFovRatio = args[1];
        }

        public Camera(Point position, Point lookAt, params float[] args) : this(position, new Vector(lookAt - position), args)
        {
            LookAt = lookAt;
        }

        public void SendRays(int n) { }
    }
}
