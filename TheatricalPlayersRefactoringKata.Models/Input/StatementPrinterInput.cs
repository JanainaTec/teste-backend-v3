using TheatricalPlayersRefactoringKata.Models.Dto;

namespace TheatricalPlayersRefactoringKata.Models.Input
{
    public class StatementPrinterInput
    {
        public InvoiceDto Invoice { get; set; }
        public Dictionary<string, PlayInput> Plays { get; set; }
    }
}
