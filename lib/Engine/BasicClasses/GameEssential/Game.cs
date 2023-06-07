using CG_Project.Engine;
using CGProject.Math;
using System.Text.Json;

namespace CGProject.Engine
{
    public class Game
    {
        readonly CoordinateSystem _cs;
        readonly ObjectList _obj;
        readonly MainLoop loop = new();
        readonly KeyMapper mapper;
        readonly Configuration? config;
        readonly Canvas canvas;
        GameCamera playerCam;

        public KeyMapper Mapper { get { return mapper; } }

        public CoordinateSystem CoordinateSystem { get { return _cs; } }

        public ObjectList Objects { get => _obj; }

        public Game(CoordinateSystem cs, ObjectList objects)
        {
            config = JsonSerializer.Deserialize<Configuration>(File.ReadAllText("Config.json"));
            canvas = new GameConsole(this, config.HorizontalBlocks, config.VerticalBlocks);
            _cs = cs;
            _obj = objects;
            mapper = new(loop);
            playerCam = new PlayerCamera(this, new Point(0, 0, 0), new Vector(1, 0, 0),
                new Tuple<float, float>(config.HorizontalFoV, config.VerticalFoV), config.DrawDist);
            loop.Update += Update; 
            loop.Exit += Exit;
        }

        public void Run()
        {
            loop.Begin(1000/config.FPS);
        }

        void Update(object? sender, EventArgs e)
        {
            canvas.Draw(playerCam);
        }

        public void Exit(object? sender, EventArgs e)
        {
            Console.WriteLine("КОНЕЦ!!!");
        }
    }
}