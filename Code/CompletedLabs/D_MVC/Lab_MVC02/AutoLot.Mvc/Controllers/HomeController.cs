// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Mvc - HomeController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/01
// ==================================

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AutoLot.Mvc.Models;

namespace AutoLot.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
