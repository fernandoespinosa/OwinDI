using System.Diagnostics;
using Microsoft.Owin.Hosting;
using System;

namespace Host.Fiasco
{
    class Program
    {
        static void Main()
        {
            using (WebApp.Start<Startup>("http://localhost:8080"))
            {
                Process.Start("http://localhost:8080/");
                Console.WriteLine("Started");
                Console.ReadKey();
                Console.WriteLine("Stopping");
            }
        }
    }
}
