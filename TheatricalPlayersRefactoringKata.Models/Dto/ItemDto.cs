using System.Xml.Serialization;

namespace TheatricalPlayersRefactoringKata.Models.Dto
{
    public class ItemDto
    {
        [XmlIgnore]
        public string Play { get; set; }
        public decimal AmountOwed { get; set; }
        public int EarnedCredits { get; set; }
        public int Seats { get; set; }
    }
}
