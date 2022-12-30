using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoanCalculator.Models;
using LoanCalculator.Helpers;

namespace LoanCalculator.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        Loan loan = new Loan();
        loan.Payment = 0.0;
        loan.TotalInterest = 1.0;
        loan.TotalCost = 0.0;
        loan.Rate = 3.5;
        loan.Amount = 15000;
        loan.Time = 60;
        return View(loan);
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Index(Loan loan)
    {
      var loanHelper = new LoanHelper();
      Loan newLoan = new();

      newLoan = loanHelper.GetPayments(loan);
      
      return View(newLoan);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
