using ApprovalTests;
using ApprovalTests.Reporters;
using System.Collections.Generic;
using TheatricalPlayersRefactoringKata.Domain;
using TheatricalPlayersRefactoringKata.Models.Enums;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests;

public class StatementPrinterTests
{
    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestStatementExampleLegacy()
    {
        var plays = new Dictionary<string, PlayInput>();
        plays.Add("hamlet", new PlayInput("Hamlet", 4024, PlayType.tragedy));
        plays.Add("as-like", new PlayInput("As You Like It", 2670, PlayType.comedy));
        plays.Add("othello", new PlayInput("Othello", 3560, PlayType.tragedy));

        InvoiceInput invoice = new InvoiceInput(
            "BigCo",
            new List<PerformanceDto>
            {
                new PerformanceDto("hamlet", 55),
                new PerformanceDto("as-like", 35),
                new PerformanceDto("othello", 40),
            }
        );

        StatementPrinter statementPrinter = new StatementPrinter();
        var result = statementPrinter.Print(invoice, plays);

        Approvals.Verify(result);
    }

    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestTextStatementExample()
    {
        var plays = new Dictionary<string, PlayInput>();
        plays.Add("hamlet", new PlayInput("Hamlet", 4024, PlayType.tragedy));
        plays.Add("as-like", new PlayInput("As You Like It", 2670, PlayType.comedy));
        plays.Add("othello", new PlayInput("Othello", 3560, PlayType.tragedy));
        plays.Add("henry-v", new PlayInput("Henry V", 3227, PlayType.history));
        plays.Add("john", new PlayInput("King John", 2648, PlayType.history));
        plays.Add("richard-iii", new PlayInput("Richard III", 3718, PlayType.history));

        InvoiceInput invoice = new InvoiceInput(
            "BigCo",
            new List<PerformanceDto>
            {
                new PerformanceDto("hamlet", 55),
                new PerformanceDto("as-like", 35),
                new PerformanceDto("othello", 40),
                new PerformanceDto("henry-v", 20),
                new PerformanceDto("john", 39),
                new PerformanceDto("henry-v", 20)
            }
        );

        StatementPrinter statementPrinter = new StatementPrinter();
        var result = statementPrinter.Print(invoice, plays);

        Approvals.Verify(result);
    }
}
