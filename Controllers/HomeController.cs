using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormsApp.Models;

namespace FormsApp.Controllers;

public class HomeController : Controller
{

    public HomeController()
    {
    }

    public IActionResult Index(string SearchString)
    {
        var products = Repository.Products;

        if(!String.IsNullOrEmpty(SearchString))
        {
            ViewData["SearchString"] = SearchString;
            products = products.Where(p => p.Name.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();


        }
        return View(products);
    }

    public IActionResult Privacy()
    {
        return View();
    }

}
