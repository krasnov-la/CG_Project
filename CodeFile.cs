using CGProject;
using CGProject.Engine;
using CGProject.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

internal class Program
{

    static void PrintID(Entity entity)
    {
        Console.WriteLine(entity.Identifier.ID);
    }
    static void Main()
    {
        /*EntityList dict = new EntityList();

        VectorSpace vs = new VectorSpace(new Vector(1, 0, 0),
                                         new Vector(0, 1, 0),
                                         new Vector(0, 0, 1));


        CoordinateSystem cs = new CoordinateSystem(new Point(0, 0, 0), vs);

        Game g = new Game();

        for (int i = 0; i < 10; i++)
        {
            Entity ent = new Entity(cs);

            dict.Add(ent.Identifier, ent);
        }

        dict.Exec(PrintID);*/
        VectorSpace vs = new VectorSpace(new Vector(1, 0, 0),
                                         new Vector(0, 1, 0),
                                         new Vector(0, 0, 1));

        CoordinateSystem cs = new CoordinateSystem(new Point(0, 0, 0), vs);

        Game game = new Game(cs, new EntityList();


        game.CoordinateSystem.
    }
}