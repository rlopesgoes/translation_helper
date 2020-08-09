/*****************************************************************
 XML TRANSLATION MANAGER
 A SIMPLE TOOL TO HELP MAINTAIN XML TRANSLATION FILES

 AUTHOR: RICARDO LOPES
 
 ****************************************************************/

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace XMLEditor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>().UseUrls("http://0.0.0.0:5005").UseKestrel();
    }
}
