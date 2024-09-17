using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheatricalPlayersRefactoringKata.Database.Models
{
    [Table("Plays")]
    public class PlayModel
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Lines { get; set; }
        public string Type { get; set; }

    }
}
