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
        public GameCamera(Game game, Point position, Vector direction, float FoV, float drawDist)
            : base(game, position, direction)
        {
            this[EntityProp.FoV] = FoV;
            this[EntityProp.DrawDist] = drawDist;
        }

        public GameCamera(Game game, Point position, Point lookAt, float FoV, float drawDist)
            : base(game, position, new Vector(0))
        {
            this[EntityProp.FoV] = FoV;
            this[EntityProp.DrawDist] = drawDist;
            RemoveProp(EntityProp.Direction);
            this[EntityProp.LookAt] = lookAt;
        }

        /*public Ray[,] GetRays(int n, int m)
        {
            Vector? initVector = null;

        }*/
    }
}