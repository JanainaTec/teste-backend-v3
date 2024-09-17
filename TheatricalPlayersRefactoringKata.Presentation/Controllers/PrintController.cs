﻿using Microsoft.AspNetCore.Mvc;
using TheatricalPlayersRefactoringKata.Domain.Implementation.Interface;
using TheatricalPlayersRefactoringKata.Models.Input;

namespace TheatricalPlayersRefactoringKata.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrintController : Controller
    {
        private readonly IStatementPrinter _statementPrinter;
        public PrintController(
          IStatementPrinter statementPrinter)
        {
            _statementPrinter = statementPrinter;
        }


        [HttpPost("StatemenText")]
        public IActionResult OnPostText([FromBody] StatementPrinterInput model)
        {
            try
            {
                InvoiceInput invoice = new InvoiceInput(model.Invoice.Customer, model.Invoice.Performances)
                {
                    Customer = model.Invoice.Customer,
                    Performances = model.Invoice.Performances,
                };

                var result = _statementPrinter.PrintStatement(invoice, model.Plays, "TextString");
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpPost("StatementXml")]
        public IActionResult OnPostXml([FromBody] StatementPrinterInput model)
        {
            try
            {
                InvoiceInput invoice = new InvoiceInput(model.Invoice.Customer, model.Invoice.Performances)
                {
                    Customer = model.Invoice.Customer,
                    Performances = model.Invoice.Performances,
                };

                var result = _statementPrinter.PrintStatement(invoice, model.Plays, "XmlString");
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
    }
}
