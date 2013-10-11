using System;
//Checks if a point (x,y) is in a circle k(0,5)
class PointCircle
{
    static void Main()
    {
        Console.WriteLine("Enter coordinates of the point: ");
        int xCoord = Int16.Parse(Console.ReadLine());
        int yCoord = Int16.Parse(Console.ReadLine());
        bool isInCircle = xCoord*xCoord + yCoord*yCoord <= 25; //radius of the circle is 5
        Console.WriteLine("Is the point with coordinates {0} {1} in the circle: {2}",xCoord,yCoord,isInCircle);
    }
}

