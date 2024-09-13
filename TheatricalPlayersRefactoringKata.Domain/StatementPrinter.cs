using System;
using System.Collections.Generic;
using System.Globalization;
using TheatricalPlayersRefactoringKata.Core.Rules;
using TheatricalPlayersRefactoringKata.Models.Enums;

namespace TheatricalPlayersRefactoringKata.Domain;

public class StatementPrinter
{
    public string Print(InvoiceInput invoice, Dictionary<string, PlayInput> plays)
    {
        var totalAmount = 0;
        var volumeCredits = 0;
        var result = string.Format("Statement for {0}\n", invoice.Customer);
        CultureInfo cultureInfo = new CultureInfo("en-US");

        foreach(var perf in invoice.Performances) 
        {
            var play = plays[perf.PlayId];
            var lines = play.Lines;
            if (lines < 1000) lines = 1000;
            if (lines > 4000) lines = 4000;
            var thisAmount = lines * 10;
            switch (play.Type) 
            {
                case PlayType.tragedy:
                    thisAmount = new StatementPrinterRules().AmountForTypeTragedy(perf.Audience, thisAmount);
                    break;
                case PlayType.comedy:
                    thisAmount = new StatementPrinterRules().AmountForTypeComedy(perf.Audience, thisAmount);
                    break;
                case PlayType.history:
                    var tragedyAmount = new StatementPrinterRules().AmountForTypeTragedy(perf.Audience, lines * 10);
                    var comedyAmount = new StatementPrinterRules().AmountForTypeComedy(perf.Audience, lines * 10);
                    thisAmount = tragedyAmount + comedyAmount;
                    break;
                default:
                    throw new Exception("unknown type: " + play.Type);
            }

            volumeCredits += Math.Max(perf.Audience - 30, 0);

            if (PlayType.comedy == play.Type) volumeCredits += (int)Math.Floor((decimal)perf.Audience / 5);

            result += String.Format(cultureInfo, "  {0}: {1:C} ({2} seats)\n", play.Name, Convert.ToDecimal(thisAmount / 100.00), perf.Audience);
            totalAmount += thisAmount;
        }
        result += String.Format(cultureInfo, "Amount owed is {0:C}\n", Convert.ToDecimal(totalAmount / 100.00));
        result += String.Format("You earned {0} credits\n", volumeCredits);
        return result;
    }

    

}
