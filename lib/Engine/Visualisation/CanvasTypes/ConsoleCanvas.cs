using System.Text;

namespace CGProject.Engine
{
    public class ConsoleCanvas : Canvas
    {
        static readonly string charMap = "@WNM0B$%&#D8XKAUbGOV496Pkqwfvszr*+<>;:.";

        public ConsoleCanvas(Game game, int hor, int vert) : base(game, hor, vert) { }

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

        char GetChar(int i, int j, GameCamera cam)
        {
            if (_distances[i, j] == null) return charMap[charMap.Length - 1];
            float ratio = (float)_distances[i, j] / cam.DrawDist;
            int index = (int)(ratio * (charMap.Length - 1));
            return charMap[index];
        }
    }
}
