using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanCalculator.Models;

namespace LoanCalculator.Helpers
{
  public class LoanHelper
  {
    public Loan GetPayments(Loan loan)
    {
      loan.Payment = CalculatePayment(loan.Amount, loan.Rate, loan.Time);
        
      double balance = loan.Amount;
      double totalInterest = 0.0;
      double monthlyInterest = 0.0;
      double monthlyPrincipal = 0.0;
      double monthlyRate = CalculateMonthlyRate(loan.Rate);

      for(int month = 1; month <= loan.Time; month++)
      {
        monthlyInterest = CalculateMonthlyInterest(balance, monthlyRate); 
        totalInterest += monthlyInterest;
        monthlyPrincipal = loan.Payment - monthlyInterest;
        balance -= monthlyPrincipal;

        LoanPayment loanPayment = new();

        loanPayment.Month = month;
        loanPayment.Payment = loan.Payment;
        loanPayment.MonthlyPrincipal = monthlyPrincipal;
        loanPayment.MonthlyInterest = monthlyInterest;
        loanPayment.Balance = balance;

        loan.Payments.Add(loanPayment);
      }

      loan.TotalInterest = totalInterest;
      loan.TotalCost = loan.Amount + totalInterest;

      return loan; 
    }

    private double CalculatePayment(double amount, double rate, int time)
    {
      double payment = 0.0; 
      
      rate = CalculateMonthlyRate(rate);
      
      payment = (amount * rate) / (1 - Math.Pow(1 + rate, -time));

      return payment;
    }

    private double CalculateMonthlyRate(double rate)
    {
      return rate / 1200;
    }

    private double CalculateMonthlyInterest(double balance, double monthlyRate)
    {
      return balance * monthlyRate;
    }
  }
}
