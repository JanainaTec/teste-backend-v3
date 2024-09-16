using System;
using System.Collections.Generic;
using TheatricalPlayersRefactoringKata.Core.Rules;
using TheatricalPlayersRefactoringKata.Domain.Implementation;

namespace TheatricalPlayersRefactoringKata.Domain;

public class StatementPrinter : IStatementPrinter
{

    private readonly StatementPrinterRules _statementPrinterRules;

    public StatementPrinter(StatementPrinterRules statementPrinterRules)
    {
        _statementPrinterRules = statementPrinterRules;
    }

    public string PrintStatement(InvoiceInput invoice, Dictionary<string, PlayInput> plays, string printType)
    {
        var result = "";
        var statement = _statementPrinterRules.CreateStatemnt(invoice, plays);

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
}
