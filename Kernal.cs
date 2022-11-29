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

namespace IronOS
{
    public class Kernel : Sys.Kernel
    {

        Canvas canvas;
        //file system\\
        Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
        private Sys.Network.IPv4.EndPoint endpoint;

        //file system\\



        protected override void BeforeRun()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Iron OS Has Booted Successfully.");
            Console.WriteLine("\n      \\(oo)\\ ________ \r\n         (__)\\         )\\ /\\ \r\n              ||------w|\r\n              ||      ||");


            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

            NetworkDevice nic = NetworkDevice.GetDeviceByName("eth0");
            IPConfig.Enable(nic, new Address(192, 168, 1, 15), new Address(255, 255, 255, 0), new Address(192, 168, 1, 254));

        }

        protected override void Run()
        {

            string input = "";

            input = Console.ReadLine();

            HandleThisCommand(input);
        }

        private void HandleThisCommand(string input)
        {


            if (input != "ping");
            static void Main(string[] args)
            {
                Ping p = new Ping();
                Console.WriteLine("enter address to ping");
                string IpPing = Console.ReadLine();

                for (; ; )
                    {
                    PingReply rep = p.Send(IpPing, 1000);
                    if (rep.Status.ToString() == "Success")
                    {
                        Console.WriteLine("reply from: " + rep.Address + " Bytes=" + rep.Buffer.Length + "time=" + rep.RoundtripTime + "Routers= " + (128 - rep.Options.Ttl));
                    }
                }
            }










            if (input == "about")
            {
                Console.WriteLine("IronOS Version 1.0.2");
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
                Console.WriteLine(" ");
                Console.WriteLine("Set Background (colour) -- Sets the background colour");
                Console.WriteLine(" ");
                Console.WriteLine("Set Text (colour) -- Sets the Text colour");
                Console.WriteLine(" ");
                Console.WriteLine("time -- Displays Time");
                Console.WriteLine(" ");
                Console.WriteLine("whoami -- Shows logged in user");
                Console.WriteLine(" ");
                Console.WriteLine("ip -- Shows your ip address");
                Console.WriteLine(" ");
                Console.WriteLine("disk space  -- Shows available space");
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
                var available_space = fs.GetAvailableFreeSpace(@"0:\");
                Console.WriteLine("Available Free Space: " + available_space);
            }

            else if (input == "dir")
            {
                var directory_list = Directory.GetFiles(@"0:\");
                foreach (var file in directory_list)
                {
                    Console.WriteLine(file);
                }
            }

           

            else if (input == "mkdir" + input)
            {
                try
                {
                    var file_stream = File.Create(@"0:\"+ input);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

           


            Console.WriteLine();

        }

       
        }
        
    }
