using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CGProject;
using CGProject.Math;
using CGProject.Engine;

class Program
{

    static void PrintID(Entity entity)
    {
        Console.WriteLine(entity.ID);
    }
    static void Main()
    {
        EntityDict dict = new EntityDict();

        VectorSpace vs = new VectorSpace(new Vector(1, 0, 0),
                                         new Vector(0, 1, 0),
                                         new Vector(0, 0, 1));

        CoordinateSystem cs = new CoordinateSystem(new Point(0, 0, 0), vs);

        for (int i = 0;  i < 10; i++)
        {
            Entity ent = new Entity(cs);

            dict.Add(ent.ID, ent);
        }

        dict.Exec(PrintID);
    }
}