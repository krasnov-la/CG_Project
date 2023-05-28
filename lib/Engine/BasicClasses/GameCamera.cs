using CGProject.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGProject
{
    namespace Engine
    {
        public class GameCamera : GameObject
        {
            bool _hold = false;
            public GameCamera(Game game, Point position, Vector direction, float FoV, float drawDist)
                : base(game, position, direction)
            {
                this[EntityProps.FoV] = FoV;
                this[EntityProps.DrawDist] = drawDist;
            }

            public GameCamera(Game game, Point position, Point lookAt, float FoV, float drawDist)
                : base(game, position, new Vector(0))
            {
                this[EntityProps.FoV] = FoV;
                this[EntityProps.DrawDist] = drawDist;
                this.RemoveProp(EntityProps.Direction);
                this[EntityProps.LookAt] = lookAt;
            }
        }
    }
}
