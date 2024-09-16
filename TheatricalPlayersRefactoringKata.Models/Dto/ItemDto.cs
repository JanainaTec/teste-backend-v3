using System.Xml.Serialization;

namespace TheatricalPlayersRefactoringKata.Models.Dto
{
    public class ItemDto
    {
        public decimal AmountOwed { get; set; }
        public int EarnedCredits { get; set; }
        public int Seats { get; set; }

        [XmlIgnore]
        public string play { get; set; }
    }
}
