using CG_Project;
using System;

public class Test
{
	static void Main()
	{
		Point pt1 = new Point(1, 2, 3);
		Point pt2 = new Point(6, 7, 8);

        Vector vect1 = new Vector(2, 1, 1);
        Vector vect2 = new Vector(3, 1, 2);

		Console.WriteLine("p1 = " + pt1.ToString());
		Console.WriteLine("p2 = " + pt2.ToString());
        Console.WriteLine("v1 = " + vect1.ToString());
        Console.WriteLine("v2 = " + vect2.ToString());
        Console.WriteLine();
        Console.WriteLine("p1 * 2 = " + (pt1 * 2).ToString());
        Console.WriteLine("3 * p2 = " + (3 * pt2).ToString());
        Console.WriteLine("p1 / 2 = " + (pt1 / 2).ToString());
        Console.WriteLine("p1 + p2 = " + (pt1 + pt2).ToString());
        Console.WriteLine("p1 - p2 = " + (pt1 - pt2).ToString());
        Console.WriteLine("p1 + v2 = " + (pt1 + vect2).ToString());
        Console.WriteLine("p2 - v1 = " + (pt2 - vect1).ToString());
        Console.WriteLine("p1 &(dist) p2 = " + (pt1 & pt2));
        Console.WriteLine();
        Console.WriteLine("~v1 (|v1|) = " + ~vect1);
        Console.WriteLine("~v2 (|v2|) = " + ~vect2);
        Console.WriteLine("!vect2 (нормализация) = " + (!vect2).ToString());
        Console.WriteLine("v1 * 2 = " + (vect1 * 2).ToString());
        Console.WriteLine("3 * v2 = " + (3 * vect2).ToString());
        Console.WriteLine("v1 / 2 = " + (vect1 / 2).ToString());
        Console.WriteLine("v1 + v2 = " + (vect1 + vect2).ToString());
        Console.WriteLine("v2 - v1 = " + (vect2 - vect1).ToString());
        Console.WriteLine("v1 * v2 = " + (vect1 * vect2));
        Console.WriteLine("v1 ^ v2 = " + (vect1 ^ vect2).ToString());
        Console.WriteLine("v2 ^ v1 = " + (vect2 ^ vect1).ToString());
    }
}
