using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanCalculator.Models
{
  public class LoanPayment
  {
    public int Month { get; set; }
    public double Payment { get; set; }
    public double MonthlyPrincipal { get; set; }
    public double MonthlyInterest { get; set; }
    public double TotalInterest { get; set; }
    public double Balance { get; set; }
  }
}
