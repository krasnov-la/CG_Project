namespace CGProject.Engine
{
    public abstract class Canvas
    {
        readonly int _hor;
        readonly int _vert;
        public float?[,] _distances;
        protected Game _game;

        public int Hor { get => _hor; }
        public int Vert { get => _vert;}

        public Canvas(Game game, int hor, int vert)
        {
            _hor = hor;
            _vert = vert;
            _distances = new float?[hor, vert];
            _game = game;
        }

        public abstract void Draw(GameCamera cam);

        public abstract void Update(GameCamera cam);
    }
}
