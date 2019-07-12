using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

using Google.Apis.Discovery;

using System.Threading.Tasks;

namespace BLL.Services
{
    public class ParseService
    {
        const string pathNode = "../BLL/Node.js";

        public string Execute(string url = null)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "node.exe",
                        Arguments = $"{pathNode}/index.js {url}"
                    }
                };
                process.Start();
                process.WaitForExit();
                var info = new FileInfo($"{pathNode}/res.html");
                if (info.Exists && info.Length > 0)
                {
                    return File.ReadAllText($"{pathNode}/res.html");
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        public async Task<string> Search(string searchString)
        {
            //var service = new DiscoveryService(new BaseClientService.Initializer
            //{
            //    ApplicationName = "Discovery Sample",
            //    ApiKey = "[YOUR_API_KEY_HERE]",
            //});

            //// Run the request.
            //Console.WriteLine("Executing a list request...");
            //var result = await service.Apis.List().ExecuteAsync();

            //// Display the results.
            //if (result.Items != null)
            //{
            //    foreach (DirectoryList.ItemsData api in result.Items)
            //    {
            //        Console.WriteLine(api.Id + " - " + api.Title);
            //    }
            //}
            return "";
        }
    }
}
