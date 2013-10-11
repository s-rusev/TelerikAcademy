using System;
/*Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3)
 * and out of the rectangle R(top=1, left=-1, width=6, height=2).
*/
class CircleRectanglePoint
{
    static void Main()
    {
        Console.WriteLine("Enter coordinates of the point: ");
        double xCoord = Double.Parse(Console.ReadLine());
        double yCoord = Double.Parse(Console.ReadLine());
        bool isInCircle = (xCoord - 1) * (xCoord - 1) + (yCoord-1) * (yCoord-1) <= 9;
        bool isInRectangle = ((xCoord >= -1) && (xCoord <= 5)) && ((yCoord >= -1) && (yCoord <= 1));
        if ((isInCircle) && (isInRectangle == false))
        {
            Console.WriteLine("The point is in the circle and outside the rectangle!");
        }
        else 
        {
            if (isInCircle && isInRectangle)
            {
                Console.WriteLine("The point is in both the circle and the rectangle!");
            }
            else 
            {
                if (isInRectangle)
                {
                    Console.WriteLine("The point is only in the rectangle!");
                }
                else 
                {
                    Console.WriteLine("The point is outside the rectangle and outside the circle!");
                }
            }
        }
    }
}

