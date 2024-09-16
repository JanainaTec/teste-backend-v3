using System.Xml.Serialization;

namespace TheatricalPlayersRefactoringKata.Models.Dto
{
    [XmlRoot("Statement")]
    public class StatementDto
    {
        [XmlElement(ElementName = "Customer")]
        public string Customer { get; set; }

        [XmlArrayItem("Item")]
        public List<ItemDto>? Items { get; set; }

        [XmlElement(ElementName = "AmountOwed")]
        public decimal AmountOwed { get; set; }

        [XmlElement(ElementName = "EarnedCredits")]
        public int EarnedCredits { get; set; }

    }
}
