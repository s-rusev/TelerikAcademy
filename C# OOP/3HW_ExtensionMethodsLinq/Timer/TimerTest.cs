using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Timer
{
    class TimerTest
    {
        static void Main(string[] args)
        {
            //this is task 7 ->uncomment to demonstrate
            //Timer a = new Timer(1000);
            //a.DoWork += delegate()
            //{
            //  Console.WriteLine(DateTime.Now);
            //};
            //a.Start();
            TimerWithEvents firstTimer = new TimerWithEvents(1000); //time for the timer delay
            TimerWithEvents secondTimer = new TimerWithEvents(2000);
            //add methods to the delegates fields for the instances a and b from the class TimerWithEvents
            firstTimer.TimerTick += FirstTimerTick; 
            secondTimer.TimerTick += SecondTimerTick;
            firstTimer.Start();
            secondTimer.Start();
  
        }

        static void FirstTimerTick(object sender, EventArgs data)
        {
            Console.WriteLine("First:  " + DateTime.Now.Hour + "h " + DateTime.Now.Minute + "m " + DateTime.Now.Second +"s");
        }

        static void SecondTimerTick(object sender, EventArgs data)
        {
            Console.WriteLine("Second: " + DateTime.Now.Hour + "h " + DateTime.Now.Minute + "m " + DateTime.Now.Second +"s");
        }
        
    }
}