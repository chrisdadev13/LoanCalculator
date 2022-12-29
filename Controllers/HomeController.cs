using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoanCalculator.Models;

namespace LoanCalculator.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Loan loan = new Loan();
        loan.Payment = 0.0;
        loan.TotalInterest = 0.0;
        loan.TotalCost = 0.0;
        loan.Rate = 3.5;
        loan.Amount = 15000;
        loan.Time = 60;
        return View(loan);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
