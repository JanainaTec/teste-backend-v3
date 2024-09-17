using System;
using System.Collections.Generic;
using TheatricalPlayersRefactoringKata.Core.Rules;
using TheatricalPlayersRefactoringKata.Database.Interface;
using TheatricalPlayersRefactoringKata.Database.Repository;
using TheatricalPlayersRefactoringKata.Domain.Implementation.Interface;
using TheatricalPlayersRefactoringKata.Models.Dto;

namespace TheatricalPlayersRefactoringKata.Domain;

public class StatementPrinterService : IStatementPrinter
{

    private readonly StatementPrinterRules _statementPrinterRules;
    private readonly IStatemnetRepository _statementRepository;

    public StatementPrinterService(StatementPrinterRules statementPrinterRules , IStatemnetRepository statementRepository)
    {
        _statementPrinterRules = statementPrinterRules;
        _statementRepository = statementRepository; 
    }

    public string PrintStatement(InvoiceInput invoice, Dictionary<string, PlayInput> plays, string printType)
    {
        var result = "";
        var statement = _statementPrinterRules.CreateStatemnt(invoice, plays);

        if (statement != null)
            {
                _statementRepository.AddStatement(statement);
            }

        switch (printType)
        {
            case "TextString": result = _statementPrinterRules.CrateText(statement); break;
            case "XmlString": result = _statementPrinterRules.CreateXmlString(statement); break;
            default:
                throw new Exception("unknown printer type: " + printType);
        }
        return result;
    }

    public string CreateXmlFile(InvoiceInput invoice, Dictionary<string, PlayInput> plays)
    {
        var statement = _statementPrinterRules.CreateStatemnt(invoice, plays);

        return _statementPrinterRules.CreateXmlFile(statement);

    }

    public List<StatementDto> GetAllStatement()
    {
        try
        {
            return _statementRepository.GetAllStatement();
        }
        catch (Exception)
        {
            throw;
        }
        
    }
}
