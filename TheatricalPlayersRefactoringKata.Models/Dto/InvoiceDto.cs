namespace TheatricalPlayersRefactoringKata.Models.Dto
{
    public class InvoiceDto
    {
        public string Customer { get; set; }
        public List<PerformanceDto> Performances { get; set; }
    }
}
