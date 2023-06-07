using CGProject.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGProject.Engine
{
    public class Game
    {
        readonly CoordinateSystem _cs;
        readonly ObjectList _obj;
        readonly MainLoop loop = new();
        readonly EventSystem system;

        public CoordinateSystem CoordinateSystem { get { return _cs; } }

        public ObjectList Objects { get => _obj; }

        public Game(CoordinateSystem cs, ObjectList objects)
        {
            _cs = cs;
            _obj = objects;
            system = new(loop);
            loop.Update += Update;
            loop.Exit += Exit;
            loop.KeyPress += KeyPress;
        }

        public void Run()
        {
            loop.Begin();
        }

        void KeyPress(object? sender, ConsoleKeyInfo info)
        {
            Console.WriteLine();
            Console.WriteLine($"Pressed : {info.KeyChar}" + " " + info.Modifiers);
        }

        void Update(object? sender, EventArgs e)
        {
            Console.Write('.');
        }

        public void Exit(object? sender, EventArgs e)
        {
            Console.WriteLine("КОНЕЦ!!!");
        }
    }
}