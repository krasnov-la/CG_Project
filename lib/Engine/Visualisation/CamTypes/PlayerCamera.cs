using CGProject.Math;

namespace CGProject.Engine
{
    public class PlayerCamera : GameCamera
    {
        float angle = 0;
        public PlayerCamera(Game game, Point position, Vector direction, Tuple<float, float> FoV, float drawDist)
            : base(game, position, direction, FoV, drawDist)
        {
            game.Mapper.Add(ConsoleKey.W, this, MoveForward);
            game.Mapper.Add(ConsoleKey.S, this, MoveBackward);
            game.Mapper.Add(ConsoleKey.A, this, MoveLeft);
            game.Mapper.Add(ConsoleKey.D, this, MoveRight);
            game.Mapper.Add(ConsoleKey.Spacebar, this, MoveUp);
            game.Mapper.Add(ConsoleKey.C, this, MoveDown);
            game.Mapper.Add(ConsoleKey.LeftArrow, this, RotateLeft);
            game.Mapper.Add(ConsoleKey.RightArrow, this, RotateRight);
            game.Mapper.Add(ConsoleKey.UpArrow, this, RotateUp);
            game.Mapper.Add(ConsoleKey.DownArrow, this, RotateDown);
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
            cam.Move(cam.CoordinateSystem.VS.Normalize(cam.Direction) / 1);
        }
        static void MoveLeft(Entity ent)
        {
            PlayerCamera cam = (PlayerCamera)ent;
            Vector right = cam.CoordinateSystem.VS.VectorProduct(cam.Direction, new Vector(0, 0, 1));
            cam.Move(-1 * cam.CoordinateSystem.VS.Normalize(right) / 1);
        }
        static void MoveRight(Entity ent)
        {
            PlayerCamera cam = (PlayerCamera)ent;
            Vector right = cam.CoordinateSystem.VS.VectorProduct(cam.Direction, new Vector(0, 0, 1));
            cam.Move(cam.CoordinateSystem.VS.Normalize(right) / 1);
        }
        static void MoveBackward(Entity ent)
        {
            PlayerCamera cam = (PlayerCamera)ent;
            cam.Move(-1 * cam.CoordinateSystem.VS.Normalize(cam.Direction) / 1);
        }

        static void RotateLeft(Entity ent)
        {
            PlayerCamera cam = (PlayerCamera)ent;
            cam.Rotate3D(0, 0, 15);
        }

        static void RotateRight(Entity ent)
        {
            PlayerCamera cam = (PlayerCamera)ent;
            cam.Rotate3D(0, 0, -15);
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
