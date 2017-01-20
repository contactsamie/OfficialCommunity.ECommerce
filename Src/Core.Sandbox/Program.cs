using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OfficialCommunity.ECommerce.Services;
using OfficialCommunity.Necropolis.Console;

namespace Core.Sandbox
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Application.Startup();

                var catalog = Application.ServiceProvider.GetService<ICatalogProvider>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Press any key to continue ...");
            Console.ReadLine();
        }
    }
}
