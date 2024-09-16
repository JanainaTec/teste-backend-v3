using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using TheatricalPlayersRefactoringKata.Models.Dto;
using TheatricalPlayersRefactoringKata.Userful.StringWriterEncoding;
using TheatricalPlayersRefactoringKata.Models.Enums;

namespace TheatricalPlayersRefactoringKata.Core.Rules
{
    public class StatementPrinterRules
    {
        public StatementDto CreateStatemnt(InvoiceInput invoice, Dictionary<string, PlayInput> plays)
        {
            var totalAmount = 0;
            var volumeCredits = 0;
            var statement = new StatementDto();
            statement.Customer = invoice.Customer;
            var result = "";
            var itensList = new List<ItemDto>();

            foreach (var perf in invoice.Performances)
            {
                var play = plays[perf.PlayId];
                var lines = play.Lines;
                if (lines < 1000) lines = 1000;
                if (lines > 4000) lines = 4000;
                var thisAmount = lines * 10;

                Enum.TryParse(play.Type, out PlayType playType);

                switch (playType)
                {
                    case PlayType.tragedy:
                        thisAmount = AmountForTypeTragedy(perf.Audience, thisAmount);
                        break;
                    case PlayType.comedy:
                        thisAmount = AmountForTypeComedy(perf.Audience, thisAmount);
                        break;
                    case PlayType.history:
                        var tragedyAmount = AmountForTypeTragedy(perf.Audience, lines * 10);
                        var comedyAmount = AmountForTypeComedy(perf.Audience, lines * 10);
                        thisAmount = tragedyAmount + comedyAmount;
                        break;
                    default:
                        throw new Exception("unknown type: " + play.Type);
                }
                var item = new ItemDto
                {
                    AmountOwed = Convert.ToDecimal(thisAmount / 100.00),
                    EarnedCredits = Math.Max(perf.Audience - 30, 0),
                    Seats = perf.Audience,
                    play = play.Name
                };


                volumeCredits += Math.Max(perf.Audience - 30, 0);

                if (PlayType.comedy == playType)
                {
                    volumeCredits += (int)Math.Floor((decimal)perf.Audience / 5);
                    item.EarnedCredits += (int)Math.Floor((decimal)perf.Audience / 5);
                }

                totalAmount += thisAmount;

                itensList.Add(item);
            }
            statement.Items = itensList;
            statement.AmountOwed = Convert.ToDecimal(totalAmount / 100.00);
            statement.EarnedCredits = volumeCredits;

            return statement;
        }
        
        public int AmountForTypeTragedy(int audience, int thisAmount)
        {
            if (audience > 30)
            {
                thisAmount += 1000 * (audience - 30);
            }
            return thisAmount;
        }

        public int AmountForTypeComedy(int audience, int thisAmount)
        {
            if (audience > 20)
            {
                thisAmount += 10000 + 500 * (audience - 20);
            }
            return thisAmount += 300 * audience;
        }

        public string CrateText(StatementDto statement)
        {
            decimal totalAmount = 0;
            int totalCredits = 0;
            var result = string.Format("Statement for {0}\n", statement.Customer);
            CultureInfo cultureInfo = new CultureInfo("en-US");

            foreach (var item in statement.Items)
            {
                result += String.Format(cultureInfo, "  {0}: {1:C} ({2} seats)\n", item.play, item.AmountOwed, item.Seats);
                totalAmount += item.AmountOwed;
                totalCredits += item.EarnedCredits;
            }

            result += String.Format(cultureInfo, "Amount owed is {0:C}\n", Convert.ToDecimal(totalAmount));
            result += String.Format("You earned {0} credits\n", totalCredits);

            return result;
        }

        public string CreateXmlString(StatementDto statement)
        {
            string xml = string.Empty;
            var serialize = new XmlSerializer(typeof(StatementDto));

            using (var strignWriter = new StringWriterWithEncoding(new StringBuilder(), UTF8Encoding.UTF8))
            {
                using (var xmlWriter = XmlWriter.Create(strignWriter, new XmlWriterSettings { Indent = true }))
                {
                    serialize.Serialize(xmlWriter, statement);
                    xml = strignWriter.GetStringBuilder().ToString();
                }
            }
            return xml;
        }

        public string CreateXmlFile(StatementDto statement)
        {
            var result = "";
            try
            {
                DateTime date = DateTime.Now;
                var arquivoXml = $@"c:\dados\{statement.Customer + date.ToString("yyyyMMddHHmmss")}.xml";

                XmlSerializer serializador = new XmlSerializer(typeof(StatementDto));

                using (var xmlWriter = XmlTextWriter.Create(arquivoXml, new XmlWriterSettings { Indent = true, Encoding = Encoding.UTF8 }))
                {
                    serializador.Serialize(xmlWriter, statement);
                }

                return result = $"Arquivo {statement.Customer + date.ToString("yyyyMMddHHmmss")}.xml gerado com Sucesso!";

            }
            catch (Exception e)
            {
                return result = $"Arquivo Xml não pode ser gerado! Mensagem : {e.Message}";
            }
        }
    }
}
