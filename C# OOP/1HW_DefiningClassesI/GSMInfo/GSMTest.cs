using System;
using System.Collections.Generic;
using System.Linq;

namespace GSMInfo
{
    class GSMTest
    {
        static void Main()
        {
            Console.WriteLine("Default GSM:");
            GSM gsm = new GSM();
            Console.WriteLine(gsm.ToString());
            Console.WriteLine(new string('^',70));
            GSM[] gsmArr = new GSM[3];
            //initialize some telephones
            gsmArr[0] = new GSM("Nokia N73", "Nokia", 22, "Mustafa", new Battery(), new Display() , new List<Call>());
            gsmArr[1] = new GSM("Nokia C60", "Nokia", 10, "Selena", new Battery("li-ne", 100, 50), new Display(100, 256), new List<Call>());
            gsmArr[2] = new GSM("Samsung Galaxy S", "Samsung", 100, "Nakov", new Battery("Sci-fi", 100, 50), new Display(), new List<Call>());

            //demonstrate CallHistory
            gsmArr[0].CallHistory.Add(new Call());
            gsmArr[0].CallHistory.Add(new Call(DateTime.Now , DateTime.Now , "0888888888", 10));
            Console.WriteLine("Call history:");
            foreach (var item in gsmArr[0].CallHistory)
            {
                Console.WriteLine(item);
            }
            gsmArr[0].CallHistory.Remove(gsmArr[0].CallHistory[0]);
            Console.WriteLine("The price of all calls is: " + gsmArr[0].CalculateTotalPriceCalls(2.1m));
            Console.WriteLine(new string('^', 70));
            Console.WriteLine("Removing first entry of call history:");
            foreach (var item in gsmArr[0].CallHistory)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Clearing the whole call history");
            gsmArr[0].CallHistory.Clear();
            foreach (var item in gsmArr[0].CallHistory)
            {
                Console.WriteLine(item); ////this shouldn't print anything 
            }
            Console.WriteLine(new string('^', 70));
            Console.WriteLine(gsmArr[0].ToString());
            Console.WriteLine(new string('^', 70));
            Console.WriteLine(gsmArr[1].ToString());
            Console.WriteLine(new string('^', 70));
            Console.WriteLine("Demonstrating static filed for Iphone:");
            Console.WriteLine(GSM.PIPhone4SInfo);

        }
    }
}
