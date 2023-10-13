using CGProject.Math;

namespace CGProject.Engine
{
    public class ConsoleGame : Game
    {
        public ConsoleGame(CoordinateSystem cs) : base(cs)
        {
            _canvas = new ConsoleCanvas(this, config.HorizontalBlocks, config.VerticalBlocks);
            _playerCam = new PlayerCamera(this, new Point(0, 0, 0), new Vector(1, 0, 0),
                new Tuple<float, float>(config.HorizontalFoV, config.VerticalFoV), config.DrawDist);
        }

        public ConsoleGame(CoordinateSystem cs, ObjectList objects) : base(cs, objects)
        {
            _canvas = new ConsoleCanvas(this, config.HorizontalBlocks, config.VerticalBlocks);
            _playerCam = new PlayerCamera(this, new Point(0, 0, 0), new Vector(1, 0, 0),
                new Tuple<float, float>(config.HorizontalFoV, config.VerticalFoV), config.DrawDist);
        }
    }
}
