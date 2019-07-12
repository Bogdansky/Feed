using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace BLL.Services
{
    public class ParseService
    {
        const string pathNode = "../Node.js";

        public string Execute(string url = "")
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
    }
}
