using CGProject.Math;
using System.Text.Json;

namespace CGProject.Engine
{
    public abstract class Game
    {
        public event EventHandler<ConsoleKeyInfo>? KeyPress;
        readonly CoordinateSystem _cs;
        protected readonly ObjectList _obj;
        protected readonly KeyMapper _mapper;
        protected readonly Configuration? config;
        protected Canvas? _canvas = null;
        protected GameCamera? _playerCam = null;

        public GameCamera Cam { get => _playerCam; set => _playerCam = value; }

        public KeyMapper Mapper { get { return _mapper; } }

        public CoordinateSystem CoordinateSystem { get { return _cs; } }

        public ObjectList Objects { get => _obj; }

        public Canvas Canvas { get => _canvas; set => _canvas = value; }

        public Game(CoordinateSystem cs)
        {
            config = JsonSerializer.Deserialize<Configuration>(File.ReadAllText("Config.json"));
            _cs = cs;
            _obj = new();
            _mapper = new(this);
        }

        public Game(CoordinateSystem cs, ObjectList objects)
        {
            config = JsonSerializer.Deserialize<Configuration>(File.ReadAllText("Config.json"));
            _cs = cs;
            _obj = objects;
            _mapper = new(this);
        }

        public void Run()
        {
            Begin(1000/config.FPS);
        }

        public void Begin(int wait)
        {
            ConsoleKeyInfo info;
            do
            {
                while (Console.KeyAvailable == false)
                {
                    Thread.Sleep(wait);
                    Update();
                }
                info = Console.ReadKey(true);
                KeyPress?.Invoke(this, info);
            } while (info.Key != ConsoleKey.Escape);
            Exit();
        }

        void Update()
        {
            _canvas.Draw(_playerCam);
        }

        public void Exit()
        {
            Console.WriteLine("КОНЕЦ!!!");
        }
    }
}