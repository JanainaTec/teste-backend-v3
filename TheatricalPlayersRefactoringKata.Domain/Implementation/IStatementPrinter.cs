using System.Collections.Generic;
using TheatricalPlayersRefactoringKata.Models.Dto;

namespace TheatricalPlayersRefactoringKata.Domain.Implementation
{
    public interface IStatementPrinter
    {
        string PrintStatement(InvoiceInput invoice, Dictionary<string, PlayInput> plays, string type);
        string CreateXmlFile(InvoiceInput invoice, Dictionary<string, PlayInput> plays);
    }
}
