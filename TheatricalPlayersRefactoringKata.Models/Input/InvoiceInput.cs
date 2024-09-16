using System.Text.Json.Serialization;

namespace TheatricalPlayersRefactoringKata;


public class InvoiceInput
{
    private string _customer;
    private List<PerformanceDto> _performances;

    public string Customer { get => _customer; set => _customer = value; }
    public List<PerformanceDto> Performances { get => _performances; set => _performances = value; }


    public InvoiceInput(string customer, List<PerformanceDto> performance)
    {
        this._customer = customer;
        this._performances = performance;
    }

}
