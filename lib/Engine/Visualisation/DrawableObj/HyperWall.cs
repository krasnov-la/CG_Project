using CGProject.Engine;
using CGProject.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGProject.Engine
{
    public class HyperWall : HyperPlane
    {
        float[] _dims;
        public HyperWall(Game game, Point position, Vector normal, params float[] dims) :
            base(game, position, normal)
        {
            if (normal.Size != dims.Length) throw new EngineExceptions.ObjectDefinitionException();
            _dims = dims; 
        }

        public override float? IntersectionDist(Ray ray)
        {
            float? planeDist =  base.IntersectionDist(ray);
            if (!planeDist.HasValue) return null;
            Point intersection = ray.InitPt + (float)planeDist * ray.Dir;
            for (int i = 0; i < _dims.Length; i++)
            {
                if (System.Math.Abs(Position[i] - intersection[i]) > _dims[i]) return null; 
            }
            return planeDist;
        }
    }
}
