using System;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Redirector.Configuration;

namespace Redirector
{
  public class Program
  {
    public static void Main(string[] args)
    {

      if (args.Length == 0)
      {
        Console.WriteLine("ERROR: You must specify a path to the mapping file");
        return;
      }

      if (args.Length > 0)
      {
        var mappingFile = args[0];
        if (!File.Exists(mappingFile))
        {
            Console.WriteLine($"ERROR: mapping file not found - {mappingFile}");
            return;
        }
        RedirectMap.Initialize(mappingFile);
      }

      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
  }
}