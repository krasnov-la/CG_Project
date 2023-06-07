using CGProject.Math;

namespace CGProject.Engine
{
    public class PlayerCamera : GameCamera
    {
        float angle = 0;
        public PlayerCamera(Game game, Point position, Vector direction, Tuple<float, float> FoV, float drawDist)
            : base(game, position, direction, FoV, drawDist)
        {
            game.Mapper.Add(ConsoleKey.W, new Tuple<Entity, Action<Entity>>(this, MoveForward));
            game.Mapper.Add(ConsoleKey.S, new Tuple<Entity, Action<Entity>>(this, MoveBackward));
            game.Mapper.Add(ConsoleKey.A, new Tuple<Entity, Action<Entity>>(this, MoveLeft));
            game.Mapper.Add(ConsoleKey.D, new Tuple<Entity, Action<Entity>>(this, MoveRight));
            game.Mapper.Add(ConsoleKey.Spacebar, new Tuple<Entity, Action<Entity>>(this, MoveUp));
            game.Mapper.Add(ConsoleKey.C, new Tuple<Entity, Action<Entity>>(this, MoveDown));
            game.Mapper.Add(ConsoleKey.LeftArrow, new Tuple<Entity, Action<Entity>>(this, RotateLeft));
            game.Mapper.Add(ConsoleKey.RightArrow, new Tuple<Entity, Action<Entity>>(this, RotateRight));
            game.Mapper.Add(ConsoleKey.UpArrow, new Tuple<Entity, Action<Entity>>(this, RotateUp));
            game.Mapper.Add(ConsoleKey.DownArrow, new Tuple<Entity, Action<Entity>>(this, RotateDown));
        }

        static void MoveUp(Entity ent)
        {
            PlayerCamera cam = (PlayerCamera)ent;
            cam.Move(new Vector(0, 0, 0.1f));
        }
        static void MoveDown(Entity ent)
        {
            PlayerCamera cam = (PlayerCamera)ent;
            cam.Move(new Vector(0, 0, -0.1f));
        }
        static void MoveForward(Entity ent)
        {
            PlayerCamera cam = (PlayerCamera) ent;
            cam.Move(cam.CoordinateSystem.VS.Normalize(cam.Direction) / 10);
        }
        static void MoveLeft(Entity ent)
        {
            PlayerCamera cam = (PlayerCamera)ent;
            throw new NotImplementedException();
        }
        static void MoveRight(Entity ent)
        {
            PlayerCamera cam = (PlayerCamera)ent;
            throw new NotImplementedException();
        }
        static void MoveBackward(Entity ent)
        {
            PlayerCamera cam = (PlayerCamera)ent;
            cam.Move(-1 * cam.CoordinateSystem.VS.Normalize(cam.Direction) / 10);
        }

        static void RotateLeft(Entity ent)
        {
            PlayerCamera cam = (PlayerCamera)ent;
            cam.Rotate3D(0, 0, 10);
        }

        static void RotateRight(Entity ent)
        {
            PlayerCamera cam = (PlayerCamera)ent;
            cam.Rotate3D(0, 0, -10);
        }

        static void RotateUp(Entity ent)
        {
            PlayerCamera cam = (PlayerCamera)ent;
            throw new NotImplementedException();
        }
        static void RotateDown(Entity ent)
        {
            PlayerCamera cam = (PlayerCamera)ent;
            throw new NotImplementedException();
        }
    }
}
