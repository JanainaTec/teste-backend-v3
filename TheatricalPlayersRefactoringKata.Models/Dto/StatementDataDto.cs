namespace TheatricalPlayersRefactoringKata.Models.Dto
{
    public class StatementDataDto
    {
        public Guid StatementId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string PlayId { get; set; }
        public decimal AmountOwed { get; set; }
        public int ErnedCredits { get; set; }
        public int Seats { get; set; }
        public string Customer { get; set; }
        public decimal TotalAmount { get; set; }
        public int TotalCredit { get; set; }
    }
}
