namespace TheatricalPlayersRefactoringKata.Core.Rules
{
    public class StatementPrinterRules
    {
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
    }
}
