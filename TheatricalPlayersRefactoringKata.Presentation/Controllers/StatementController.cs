using Microsoft.AspNetCore.Mvc;
using TheatricalPlayersRefactoringKata.Database.Models;
using TheatricalPlayersRefactoringKata.Domain.Implementation.Interface;
using TheatricalPlayersRefactoringKata.Models.Dto;
using TheatricalPlayersRefactoringKata.Models.Input;

namespace TheatricalPlayersRefactoringKata.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatementController : Controller
    {
        private readonly IStatementPrinter _statementPrinter;
        public StatementController(
          IStatementPrinter statementPrinter)
        {
            _statementPrinter = statementPrinter;
        }

        [HttpPost("CreateXmlFile")]
        public IActionResult OnPostCreateXml([FromBody] StatementPrinterInput model)
        {
            try
            {
                InvoiceInput invoice = new InvoiceInput(model.Invoice.Customer, model.Invoice.Performances)
                {
                    Customer = model.Invoice.Customer,
                    Performances = model.Invoice.Performances,
                };

                var result = _statementPrinter.CreateXmlFile(invoice, model.Plays);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpGet("All")]
        [ProducesDefaultResponseType(typeof(List<StatementDto>))]
        public IActionResult OnGetAllStatement()
        {
            try
            {
                var result = _statementPrinter.GetAllStatement();
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }

        }
    }
}
