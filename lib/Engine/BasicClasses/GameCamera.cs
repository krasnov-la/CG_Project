using CGProject.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGProject.Engine
{
    public class GameCamera : GameObject
    {
        bool _hold = false;
        public GameCamera(Game game, Point position, Vector direction, Tuple<float, float> FoV, float drawDist)
            : base(game, position, direction)
        {
            this[EntityProp.FoV] = FoV;
            this[EntityProp.DrawDist] = drawDist;
        }

        public GameCamera(Game game, Point position, Point lookAt, Tuple<float, float> FoV, float drawDist)
            : base(game, position, new Vector(0))
        {
            _hold = true;
            this[EntityProp.FoV] = FoV;
            this[EntityProp.DrawDist] = drawDist;
            RemoveProp(EntityProp.Direction);
            this[EntityProp.LookAt] = lookAt;
        }

        public Ray[,] GetRays(int hBlocks, int vBlocks)
        {
            Ray[,] rayMatrix = new Ray[hBlocks, vBlocks]; 
            Vector initVector = _hold ? 
                (_game.CoordinateSystem.VS.AsVector(this[EntityProp.LookAt]) - _game.CoordinateSystem.VS.AsVector(this[EntityProp.Position])) : 
                this[EntityProp.Direction];

            float hFoV = this[EntityProp.FoV].Item1;
            float vFoV = this[EntityProp.FoV].Item2;

            float dHor = hFoV / hBlocks;
            float dVert = vFoV / vBlocks;

            for (int i = 0; i < hBlocks; i++)
                for (int j = 0; j < vBlocks; j++)
                {
                    float hor = i * dHor - hFoV / 2;
                    float vert = j * dVert - vFoV / 2;

                    Ray tmp = new Ray(_game.CoordinateSystem, this[EntityProp.Position], initVector);
                    tmp.Normalize();
                    tmp.Rotate3D(0, vert, hor);
                    //Console.WriteLine(tmp.Dir.Transposed());
                    //Console.WriteLine(tmp.Dir.Transposed());
                    //Console.WriteLine();
                    rayMatrix[i, j] = tmp;
                }


            return rayMatrix;
        }
    }
}