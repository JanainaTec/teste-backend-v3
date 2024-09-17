using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheatricalPlayersRefactoringKata.Database.Models
{
    [Table("Statements")]
    public class StatementModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Customer { get; set; }
        public decimal TotalAmount { get; set; }
        public int TotalCredit { get; set; }
    }
}
