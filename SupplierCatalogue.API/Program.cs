// <copyright file="Program.cs" company="Hitched Ltd">
// Copyright (c) Hitched Ltd. All rights reserved.
// </copyright>

namespace SupplierCatalogue.API
{
    using System.IO;
    using Microsoft.AspNetCore.Hosting;

    /// <summary>
    /// The application bootstrap
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main the entrypoint of the application.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
