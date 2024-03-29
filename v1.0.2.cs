using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using Cosmos.System.Network;
using Cosmos.HAL;
using Cosmos.System.Network.Config;
using Cosmos.System.Network.IPv4;
using System.IO;
using System.Reflection.Metadata;
using System.Net;
using System.Net.NetworkInformation;
using Cosmos.System.Network.IPv4.UDP.DHCP;
using System.Threading;
using Cosmos.Core;
using Cosmos.System.Network.IPv4.UDP.DNS;
using System.ComponentModel.Design;

namespace IronOS
{
    public class Kernel : Sys.Kernel
    {

        Canvas canvas;
        //file system\\
        //Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
        private string xFirstByte;
        private Sys.Network.IPv4.EndPoint EndPoint;

        //file system\\

        NetworkDevice nic = NetworkDevice.GetDeviceByName("eth0");




        protected override void BeforeRun()
        {
            IPConfig.Enable(nic, new Address(192, 168, 1, 69), new Address(255, 255, 255, 0), new Address(192, 168, 1, 254));
            using (var xClient = new DHCPClient())
            {

                xClient.SendDiscoverPacket();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Iron OS Has Booted Successfully.");
            Console.WriteLine(@"
  ,-.       _,---._ __  / \
 /  )    .-'       `./ /   \
(  (   ,'            `/    /|
 \  `-""             \'\   / |
  `.              ,  \ \ /  |
   /`.          ,'-`----Y   |
  (            ;        |   '
  |  ,-.    ,-'         |  /
  |  | (   |    Iron OS | /
  )  |  \  `.___v1.0.2__|/
  `--'   `--'    
");
            Console.WriteLine("Type 'help' for commands.");

            //Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);




        }

        protected override void Run()
        {




            string input = " ";

            input = Console.ReadLine();

            HandleThisCommand(input);
        }

        private void HandleThisCommand(string input)
        {


            if (input == "about")
            {
                Console.WriteLine(@"
  ,-.       _,---._ __  / \
 /  )    .-'       `./ /   \
(  (   ,'            `/    /|
 \  `-""             \'\   / |
  `.              ,  \ \ /  |
   /`.          ,'-`----Y   |
  (            ;        |   '
  |  ,-.    ,-'         |  /
  |  | (   |    Iron OS | /
  )  |  \  `.___v1.0.2__|/
  `--'   `--' 
                 
");
            }


            else if (input == "help")
            {
                Console.WriteLine(" ");
                Console.WriteLine("All commands are case specific.");
                Console.WriteLine("_______________________________");
                Console.WriteLine("about    :     Shows information about the OS");
                Console.WriteLine("help     :     Shows commands");
                Console.WriteLine("clear    :     Clears terminal output");
                Console.WriteLine("shutdown :     Shuts down the machine");
                Console.WriteLine(" ");
                Console.WriteLine("restart                     :     Restarts The Machine");
                Console.WriteLine("set background (colour)     :     Sets the background colour");
                Console.WriteLine("set text (colour)           :     Sets the Text colour");
                Console.WriteLine("time                        :     Displays Time");
                Console.WriteLine(" ");
                Console.WriteLine("whoami      :     Shows logged in user");
                Console.WriteLine("ip          :     Shows your ip address");
                Console.WriteLine("disk space  :     Shows available space");
                Console.WriteLine("mkdir       :     Creates Direcotry");
                Console.WriteLine(" ");
                Console.WriteLine("deldir   :     Deletes Direcotry");
                Console.WriteLine("meow     :     writes to file");
                Console.WriteLine("read     :     reads file content");
                Console.WriteLine("dir      :     lists all files");
                Console.WriteLine("hello    :     Says hello back.");
                Console.WriteLine(":)    :     read the output");
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
            else if (input == "restart")
            {
                Console.WriteLine("Restarting In Five Seconds");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Restarting In Four Seconds");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Restarting In Three Seconds");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Restarting In Two Seconds");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Restarting In One Second");
                System.Threading.Thread.Sleep(1000);
                Sys.Power.Reboot();
            }

            //Colour settings ---------------------------------\\
            else if (input == "set background blue")
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            }
            else if (input == "set background red")
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            else if (input == "set background yellow")
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
            else if (input == "set background black")
            {
                Console.BackgroundColor = ConsoleColor.Black;
            }

            else if (input == "set text white")
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (input == "set text blue")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (input == "set text black")
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (input == "set text green")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            //-----------------------------------------------\\


            else if (input == "time")
            {
                Console.WriteLine(DateTime.Now.ToString());
            }

            else if (input == "apt")
            {
                Console.WriteLine("This isn't linux...");
            }

            else if (input == "whoami")
            {
                Console.WriteLine("User0");
            }

            else if (input == "ip")
            {
                Console.WriteLine(NetworkConfiguration.CurrentAddress.ToString());
            }

            else if (input == "disk space")
            {
                //var available_space = fs.GetAvailableFreeSpace(@"0:\");
                //Console.WriteLine("Available Free Space: " + available_space);
            }


            //----------------FILE SYSTEM----------------\\
            else if (input == "dir")
            {
                var directory_list = Directory.GetFiles(@"0:\");
                foreach (var file in directory_list)
                {
                    Console.WriteLine(file);
                }
            }



            else if (input == "mkdir")
            {
                try
                {
                    Console.WriteLine("What Do We Call This Directory?");
                    string make = Console.ReadLine();
                    {
                    }
                    var file_stream = File.Create(@"0:\" + make);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }


            else if (input == "deldir")
            {
                try
                {
                    Console.WriteLine("What Direcotry Do You Want To Remove?");
                    string del = Console.ReadLine();
                    {
                    }
                    File.Delete(@"0:\" + del);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            else if (input == "meow")
            {

                try
                {
                    Console.WriteLine("What file do you wish to write to?");
                    string write = Console.ReadLine();
                    Console.WriteLine("What do you want the file to say?");
                    string write2 = Console.ReadLine();
                    File.WriteAllText(@"0:\" + write, write2);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }


            }



            else if (input == "read")
            {
                try
                {
                    Console.WriteLine("file name");
                    string read = Console.ReadLine();
                    Console.WriteLine(File.ReadAllText(@"0:\" + read));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            //----------------FILE SYSTEM----------------\\

            //-----------------TEST CODE------------------\\



            else if (input == "hello")
            {
                Console.WriteLine("Hi!");
            }
            else if (input == ":)")
            {
                Console.WriteLine(@"
:)
        
");
            }



            //-----------------TEST CODE------------------\\




            else Console.WriteLine("Command not found");
            Console.WriteLine();

        }
    }

}
