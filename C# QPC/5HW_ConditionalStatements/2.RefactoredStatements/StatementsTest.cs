namespace RefactoredStatements
{
    using System;

    public class StatementsTest
    {

//      Note: The first task is completed in the first project but
//      here it is again:
//
//      Potato potato;
//      if (potato != null)
//      {
//           if(potato.isPeeled && !potato.IsRotten)
//           {
//              Cook(potato);
//           }
//      }
        static void Main()
        {
            int xCoord = 5;
            int yCoord = 7;
            const int MaxX = 100;
            const int MaxY = 100;
            const int MinX = 100;
            const int MinY = 100;
            bool shouldVisitCell = true;
            bool isInRange = false;

            isInRange = ((xCoord >= MinX) && (xCoord <= MaxX)) && 
                        ((yCoord >= MinY) && (yCoord <= MaxY));

            if (isInRange && shouldVisitCell)
            {
                VisitCell();
            }
        }
  
        private static void VisitCell()
        {
            Console.WriteLine("Cell visited!");
        }
    }
}
