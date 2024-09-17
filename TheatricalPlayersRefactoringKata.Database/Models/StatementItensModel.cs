using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheatricalPlayersRefactoringKata.Database.Models
{
    [Table("StatementItens")]
    public class StatementItensModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid StatementId { get; set; }
        public string PlayId { get; set; }
        public decimal AmountOwed { get; set; }
        public int Credits { get; set; }
        public int Seats { get; set; }
    }
}
