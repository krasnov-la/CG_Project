using CGProject.Math;

namespace CGProject.Engine
{
    public abstract class GameCamera : Entity //done
    {
        Vector? _dir = null;
        Point? _lookAt = null;
        Tuple<float, float> _fov;
        float _dist;

        public GameCamera(Game game, Point position, Vector direction, Tuple<float, float> FoV, float drawDist)
            : base(game.CoordinateSystem, position)
        {
            _dir = direction;
            _fov = FoV;
            DrawDist = drawDist;
        }

        public GameCamera(Game game, Point position, Point lookAt, Tuple<float, float> FoV, float drawDist)
            : base(game.CoordinateSystem, position)
        {
            _lookAt = lookAt;
            _fov = FoV;
            DrawDist = drawDist;
        }

        public float DrawDist { get => _dist;
            set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException("DrawDist", "Distance cannot be less than zero");
                _dist = value;
            }
        }

        public Vector? Direction { get => _dir; }

        public Tuple<float, float> FoV { get => _fov; }

        public void Rotate3D(float x, float y, float z)
        {
            if (_dir == null) return;
            _dir = (Vector)(Matrix.Rotation(x, y, z) * _dir);
        }

        public void SetDir(Vector vector)
        {
            if (vector.Size != 3) throw new EngineExceptions.DimensionException();
            _dir = vector;
        }

        public Ray[,] GetRays(int hBlocks, int vBlocks)
        {
            Ray[,] rayMatrix = new Ray[hBlocks, vBlocks]; 
            Vector initVector = _dir == null ? 
                (CoordinateSystem.VS.AsBaseVector(_lookAt) - CoordinateSystem.VS.AsBaseVector(Position)) : 
                _dir;

            float hFoV = _fov.Item1;
            float vFoV = _fov.Item2;

            float dHor = hFoV / (hBlocks - 1);
            float dVert = vFoV / (vBlocks - 1);

            for (int i = 0; i < hBlocks; i++)
                for (int j = 0; j < vBlocks; j++)
                {
                    float hor = -(i * dHor - hFoV / 2);
                    float vert = j * dVert - vFoV / 2;

                    Ray tmp = new(CoordinateSystem, Position, initVector);
                    tmp.Normalize();
                    tmp.Dir = (Vector)(Matrix.Rotation(0, vert, hor) * tmp.Dir);
                    float len = CoordinateSystem.VS.Length(initVector);
                    tmp.Dir *= len * len / CoordinateSystem.VS.ScalarProduct(tmp.Dir, initVector);
                    rayMatrix[i, j] = tmp;
                }


            return rayMatrix;
        }
    }
}