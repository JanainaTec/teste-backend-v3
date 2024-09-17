using ApprovalTests;
using ApprovalTests.Reporters;
using Moq;
using System.Collections.Generic;
using TheatricalPlayersRefactoringKata.Core.Rules;
using TheatricalPlayersRefactoringKata.Database;
using TheatricalPlayersRefactoringKata.Database.Interface;
using TheatricalPlayersRefactoringKata.Database.Repository;
using TheatricalPlayersRefactoringKata.Domain;
using TheatricalPlayersRefactoringKata.Models.Dto;
using TheatricalPlayersRefactoringKata.Models.Enums;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests;

public class StatementPrinterTests
{
    private readonly Mock<StatementPrinterRules> _mockStatementPrinterRules;
    private readonly Mock<IStatemnetRepository> _mockStatementRepository;
    private readonly StatementPrinterService _statementPrinterService;

    public StatementPrinterTests()
    {
        _mockStatementPrinterRules = new Mock<StatementPrinterRules>();
        _mockStatementRepository = new Mock<IStatemnetRepository>();
        _statementPrinterService = new StatementPrinterService(_mockStatementPrinterRules.Object, _mockStatementRepository.Object);
    }

    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestTextStatementExample()
    {
        var plays = new Dictionary<string, PlayInput>();
        plays.Add("hamlet", new PlayInput("Hamlet", 4024, PlayType.tragedy.ToString()));
        plays.Add("as-like", new PlayInput("As You Like It", 2670, PlayType.comedy.ToString()));
        plays.Add("othello", new PlayInput("Othello", 3560, PlayType.tragedy.ToString()));
        plays.Add("henry-v", new PlayInput("Henry V", 3227, PlayType.history.ToString()));
        plays.Add("john", new PlayInput("King John", 2648, PlayType.history.ToString()));
        plays.Add("richard-iii", new PlayInput("Richard III", 3718, PlayType.history.ToString()));

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

        var statement = new StatementDto(); 
        var result = _statementPrinterService.PrintStatement(invoice, plays, "TextString");

        Approvals.Verify(result);
        
    }

    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void TestXmlStatementExample()
    {
        var plays = new Dictionary<string, PlayInput>();
        plays.Add("hamlet", new PlayInput("Hamlet", 4024, PlayType.tragedy.ToString()));
        plays.Add("as-like", new PlayInput("As You Like It", 2670, PlayType.comedy.ToString()));
        plays.Add("othello", new PlayInput("Othello", 3560, PlayType.tragedy.ToString()));
        plays.Add("henry-v", new PlayInput("Henry V", 3227, PlayType.history.ToString()));
        plays.Add("john", new PlayInput("King John", 2648, PlayType.history.ToString()));
        plays.Add("richard-iii", new PlayInput("Richard III", 3718, PlayType.history.ToString()));

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


        var statement = new StatementDto();
        var result = _statementPrinterService.PrintStatement(invoice, plays, "XmlString");

        Approvals.Verify(result);
    }

}
