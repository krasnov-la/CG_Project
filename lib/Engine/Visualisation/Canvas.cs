using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGProject.Engine
{
    public class Canvas //done
    {
        readonly int _hor;
        readonly int _vert;
        public float?[,] _distances;
        Game _game;

        public int Hor { get => _hor; }
        public int Vert { get => _vert;}

        public Canvas(Game game, int hor, int vert)
        {
            _hor = hor;
            _vert = vert;
            _distances = new float?[hor, vert];
            _game = game;
        }

        public void Draw() { }

        public void Update(GameCamera cam)
        {
            Ray[,] rays = cam.GetRays(Hor, Vert);
            for (int i = 0; i < Hor; i++)
                for (int j = 0; j < Vert; j++)
                    foreach (GameObject obj in _game.Objects)
                    {
                        float? intersect = obj.IntersectionDist(rays[i, j]);
                        if (intersect == null) continue;
                        if (intersect > cam.DrawDist) continue;
                        if (_distances[i, j] == null) _distances[i, j] = intersect;
                        else if (_distances[i, j] > intersect) _distances[i, j] = intersect;
                    }
        }
    }
}
