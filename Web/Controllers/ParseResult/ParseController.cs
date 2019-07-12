using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using Web.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Views.ParseResult
{
    public class ParseController : Controller
    {
        private ParseService parseService;

        public ParseController(ParseService _parseService)
        {
            parseService = _parseService;
        }

        // GET: /<controller>/
        public IActionResult Index(string url)
        {
            var result = parseService.Execute(url);
            Uri uri = new Uri(url);
            return View(new ParseViewModel {
                Header = $"Главная | {uri.Host}",
                Content = result
            });
        }

        public async Task<ActionResult> Search(string pattern)
        {
            var result = await parseService.Search(pattern);
            return View("Index", new ParseViewModel
            {
                Content = result,
                Header = $"Result of searching by word \"{pattern}\""
            });
        }
    }
}
