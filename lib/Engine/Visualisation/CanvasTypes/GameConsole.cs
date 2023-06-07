using CGProject.Engine;
using System.Text;
using System.Xml.Linq;

namespace CG_Project.Engine
{
    public class GameConsole : Canvas
    {
        static readonly string charMap = "@WNM0B$%&#D8XKAUbGOV496Pkqwfvszr*+<>;:.";

        public GameConsole(Game game, int hor, int vert) : base(game, hor, vert) { }

        public override void Draw(GameCamera cam)
        {
            Update(cam);
            StringBuilder image = new StringBuilder();
            for (int j = 0; j < _distances.GetLength(1); j++)
            {
                for (int i = 0; i < _distances.GetLength(0); i++)
                    image.Append(GetChar(i, j, cam));

                image.Append('\n');
            }
            Console.Clear();
            Console.Write(image.ToString());
        }

        public override void Update(GameCamera cam)
        {
            Ray[,] rays = cam.GetRays(Hor, Vert);
            for (int i = 0; i < Hor; i++)
                for (int j = 0; j < Vert; j++)
                {
                    _distances[i, j] = null;
                    foreach (GameObject obj in _game.Objects)
                    {
                        float? intersect = obj.IntersectionDist(rays[i, j]);
                        if (intersect == null) continue;
                        if (intersect > cam.DrawDist) continue;
                        if (_distances[i, j] == null) _distances[i, j] = intersect;
                        if (_distances[i, j] > intersect) _distances[i, j] = intersect;
                    }
                }
        }

        char GetChar(int i, int j, GameCamera cam)
        {
            if (_distances[i, j] == null) return charMap[charMap.Length - 1];
            float ratio = (float)_distances[i, j] / cam.DrawDist;
            int index = (int)(ratio * (charMap.Length - 1));
            return charMap[index];
        }
    }
}
