using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Network;
using Cosmos.HAL;
using Cosmos.System.Network.Config;
using Cosmos.System.Network.IPv4;
using System.IO;
using Cosmos.System.Network.IPv4.UDP.DHCP;
using System.Threading;
using Cosmos.Core;

namespace IronOS
{
    public class Kernel : Sys.Kernel
    {
        Canvas canvas;
        private string xFirstByte;
        private Sys.Network.IPv4.EndPoint EndPoint;
        NetworkDevice nic = NetworkDevice.GetDeviceByName("eth0");

        private bool isGuiMode = false;
        private int mouseX = 100;
        private int mouseY = 100;
        private int buttonX = 80;
        private int buttonY = 100;
        private int buttonWidth = 140;
        private int buttonHeight = 25;
        private bool mousePreviouslyDown = false;

        protected override void BeforeRun()
        {
            IPConfig.Enable(nic, new Address(192, 168, 1, 69), new Address(255, 255, 255, 0), new Address(192, 168, 1, 254));
            using (var xClient = new DHCPClient())
            {
                xClient.SendDiscoverPacket();
            }

            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("Iron OS Has Booted Successfully.");
            System.Console.WriteLine(@"
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
            System.Console.WriteLine("Type 'help' for commands.");
        }

        protected override void Run()
        {
            if (!isGuiMode)
            {
                string input = System.Console.ReadLine();
                HandleThisCommand(input);
            }
            else
            {
                while (isGuiMode)
                {
                    try
                    {
                        DrawGUI();
                    }
                    catch (Exception ex)
                    {
                        System.Console.Clear();
                        System.Console.WriteLine("GUI Error: " + ex.Message);
                        isGuiMode = false;
                    }
                }
            }
        }

        private void DrawGUI()
        {
            canvas.Clear(Color.Black);
            canvas.Mode = new Mode(800, 600, ColorDepth.ColorDepth32);

            Pen winPen = new Pen(Color.DarkGray);
            Pen borderPen = new Pen(Color.White);
            Pen buttonPen = new Pen(Color.LightGray);
            Pen cursorPen = new Pen(Color.Yellow);
            Pen whitePen = new Pen(Color.White);
            Pen blackPen = new Pen(Color.Black);

            // Test square to verify graphics mode works
            for (int x = 0; x < 50; x++)
            {
                for (int y = 0; y < 50; y++)
                {
                    canvas.DrawPoint(whitePen, x, y);
                }
            }

            int winX = 50, winY = 50, winWidth = 300, winHeight = 160;

            for (int i = 0; i < winWidth; i++)
            {
                canvas.DrawPoint(borderPen, winX + i, winY);
                canvas.DrawPoint(borderPen, winX + i, winY + winHeight);
            }
            for (int i = 0; i < winHeight; i++)
            {
                canvas.DrawPoint(borderPen, winX, winY + i);
                canvas.DrawPoint(borderPen, winX + winWidth, winY + i);
            }

            for (int i = 1; i < winWidth; i++)
            {
                for (int j = 1; j < winHeight; j++)
                {
                    canvas.DrawPoint(winPen, winX + i, winY + j);
                }
            }

            canvas.DrawString("Iron OS GUI Mode", PCScreenFont.Default, whitePen, winX + 10, winY + 10);

            for (int i = 0; i < buttonWidth; i++)
            {
                for (int j = 0; j < buttonHeight; j++)
                {
                    canvas.DrawPoint(buttonPen, buttonX + i, buttonY + j);
                }
            }

            canvas.DrawString("Click Me", PCScreenFont.Default, blackPen, buttonX + 30, buttonY + 5);
            canvas.DrawPoint(cursorPen, mouseX, mouseY);

            mouseX = (int)MouseManager.X;
            mouseY = (int)MouseManager.Y;

            bool mouseNowDown = MouseManager.MouseState == MouseState.Left;

            if (mouseNowDown && !mousePreviouslyDown)
            {
                if (mouseX >= buttonX && mouseX <= buttonX + buttonWidth &&
                    mouseY >= buttonY && mouseY <= buttonY + buttonHeight)
                {
                    canvas.Clear(Color.DarkBlue);
                    canvas.DrawString("You clicked the button!", PCScreenFont.Default, whitePen, 100, 100);
                    Thread.Sleep(1000);
                }
            }

            mousePreviouslyDown = mouseNowDown;
            Thread.Sleep(30);
        }

        private void HandleThisCommand(string input)
        {
            if (input == "help")
            {
                System.Console.WriteLine("Commands: help, about, clear, shutdown, restart, gui");
            }
            else if (input == "about")
            {
                System.Console.WriteLine("Iron OS v1.0.2 - Custom OS built using COSMOS.");
            }
            else if (input == "clear")
            {
                System.Console.Clear();
            }
            else if (input == "shutdown")
            {
                System.Console.WriteLine("Shutting down...");
                Thread.Sleep(2000);
                Sys.Power.Shutdown();
            }
            else if (input == "restart")
            {
                System.Console.WriteLine("Restarting...");
                Thread.Sleep(2000);
                Sys.Power.Reboot();
            }
            else if (input == "gui")
            {
                canvas = FullScreenCanvas.GetFullScreenCanvas();
                isGuiMode = true;
            }
            else
            {
                System.Console.WriteLine("Unknown command.");
            }
        }
    }
}
