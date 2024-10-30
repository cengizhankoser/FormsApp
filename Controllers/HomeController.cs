using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormsApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FormsApp.Controllers;

public class HomeController : Controller
{

    public HomeController()
    {
    }

    public IActionResult Index(string SearchString, string category)
    {
        var products = Repository.Products;

        if(!String.IsNullOrEmpty(SearchString))
        {
            ViewData["SearchString"] = SearchString;
            products = products.Where(p => p.Name.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();


        }
        if(!String.IsNullOrEmpty(category) && category != "0")
        {
            products = products.Where(p => p.CategoryId == int.Parse(category)).ToList();
        }
        // ViewData["Categories"] = new SelectList(Repository.Categories,"CategoryId", "Name", category);

        var model = new ProductViewModel{
            Products = products,
            Categories = Repository.Categories,
            SelectedCategory = category
        };
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

}
