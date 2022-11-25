using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace IronOS
{
    public class Kernel : Sys.Kernel
    {
        


        protected override void BeforeRun()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Iron OS Has Booted Successfully.");
        }

        protected override void Run()
        {
            string input = "";


            input = Console.ReadLine();


            HandleThisCommand(input);
        }

        private void HandleThisCommand(string input)
        {
            if (input == "about")
            { Console.WriteLine("IronOS Version 1.0");
            }

         
           else if (input == "help")
            {
                Console.WriteLine(" ");
                Console.WriteLine("About -- Shows information about the OS");
                Console.WriteLine(" ");
                Console.WriteLine("Help -- Shows commands");
                Console.WriteLine(" ");
                Console.WriteLine("Clear -- Clears terminal output");
                Console.WriteLine(" ");
                Console.WriteLine("Shutdown -- Shuts down the machine");
                Console.WriteLine(" ");
                Console.WriteLine("Restart -- Restarts The Machine");
            }

            else if (input == "shutdown")
            {
                Console.WriteLine("Shutting Down In Five Seconds");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Shutting Down In Four Seconds");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Shutting Down In Three Seconds");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Shutting Down In Two Seconds");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Shutting Down In One Second");
                System.Threading.Thread.Sleep(1000);
                Sys.Power.Shutdown();
            }
            else if (input == "clear")
            {
                Console.Clear();
            }
            else if (input =="restart")
            {
                Sys.Power.Reboot();
            }

            else if (input == "ping")
            {
                
            }

            Console.WriteLine();
           
        }
    }
}
