using CGProject.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CGProject.Engine
{
    public class HyperEllipse : GameObject
    {
        Vector[] _semiAxes;
        public HyperEllipse(Game game, Point position, params Vector[] semiAxes) 
            : base(game, position)
        {
            if (!VectorSpace.IsValidBasis(semiAxes)) throw new EngineExceptions.ObjectDefinitionException();
            _semiAxes = semiAxes;
        }

        public override float? IntersectionDist(Ray ray)
        {
            Vector[] eigenVectors = new Vector[_semiAxes.Length];
            _semiAxes.CopyTo(eigenVectors, 0);

            for (int i = 0; i < eigenVectors.Length; i++)
            {
                eigenVectors[i] /= CoordinateSystem.VS.Length(eigenVectors[i]);
            }

            VectorSpace canonicalVS = new(eigenVectors);

            return CanonicalIntersectionDist(ray, canonicalVS);
        }

        private float? CanonicalIntersectionDist(Ray ray, VectorSpace canonicalVS)
        {
            float quadraticA = 0;
            float quadraticB = 0;
            float quadraticC = -1;

            for (int i = 0; i < _semiAxes.Length; i++)
            {
                quadraticA += ray.Dir[i] * ray.Dir[i] / canonicalVS.Length(_semiAxes[i]);
                quadraticB += (ray.InitPt[i] - Position[i]) * ray.Dir[i] / canonicalVS.Length(_semiAxes[i]);
                quadraticC += (ray.InitPt[i] - Position[i]) * (ray.InitPt[i] - Position[i]) / canonicalVS.Length(_semiAxes[i]);
            }
            quadraticB *= 2;

            float discriminant = quadraticB * quadraticB - 4 * quadraticA * quadraticC;

            if (discriminant < 0) return null;

            float solution1, solution2;

            solution1 = (float)((-quadraticB - System.Math.Sqrt(discriminant)) / (2 * quadraticA));
            solution2 = (float)((-quadraticB + System.Math.Sqrt(discriminant)) / (2 * quadraticA));

            if (solution1 < 0)
                if (solution2 < 0) return null;
                else return solution2;
            else
                if (solution2 < 0) return solution1;
                else return solution1 < solution2 ? solution1 : solution2;
        }

        public override void Rotate3D(float angleX, float angleY, float angleZ)
        {
            for (int i = 0; i < _semiAxes.Length; i++)
                _semiAxes[i] = (Vector)(Matrix.Rotation(angleX, angleY, angleZ) * _semiAxes[i]);  
        }

        public override void RotatePlanar(int axis1, int axis2, float angle)
        {
            for (int i = 0; i < _semiAxes.Length; i++)
                _semiAxes[i] = (Vector)(Matrix.GeneralRotation(_semiAxes.Length, axis1, axis2, angle) * _semiAxes[i]);
        }
    }
}
