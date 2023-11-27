using Hotel_Domain.Models;
using Hotel_Domain.ViewModels; // Import the InvoiceViewModel namespace
using Hotel_Repository.Services.Custom_Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hotel_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceService _invoiceService;

        public InvoiceController(InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            var invoices = await _invoiceService.GetAllInvoicesAsync();
            return Ok(invoices);
        }


        [HttpGet("{invoiceId}")]
        public async Task<IActionResult> GetInvoiceById(int invoiceId)
        {
            var invoice = await _invoiceService.GetInvoiceByIdAsync(invoiceId);

            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(invoice);
        }
        [HttpPost]
        public async Task<IActionResult> AddInvoice([FromBody] InvoiceViewModel invoiceViewModel)
        {
            // Convert InvoiceViewModel to Invoice entity
            var invoice = new Invoice
            {
                // Map properties accordingly
                InvoiceId=invoiceViewModel.InvoiceId,
                TotalAmount = invoiceViewModel.TotalAmount,
                IssueDate = invoiceViewModel.IssueDate,
                ReservationId= invoiceViewModel.ReservationId,
                DueDate = invoiceViewModel.DueDate,
                PaymentStatus=invoiceViewModel.PaymentStatus,
                // Map other properties as needed
            };

            await _invoiceService.AddInvoiceAsync(invoice);
            return CreatedAtAction(nameof(GetInvoiceById), new { invoiceId = invoice.InvoiceId }, invoice);
        }

        [HttpPut("{invoiceId}")]
        public async Task<IActionResult> UpdateInvoice(int invoiceId, [FromBody] InvoiceViewModel invoiceViewModel)
        {
            var existingInvoice = await _invoiceService.GetInvoiceByIdAsync(invoiceId);

            if (existingInvoice == null)
            {
                return NotFound();
            }

            // Map properties accordingly
            existingInvoice.InvoiceId = invoiceViewModel.InvoiceId;
            existingInvoice.TotalAmount = invoiceViewModel.TotalAmount;
            existingInvoice.IssueDate = invoiceViewModel.IssueDate;
            existingInvoice.DueDate = invoiceViewModel.DueDate;
            existingInvoice.ReservationId = invoiceViewModel.ReservationId;
            existingInvoice.PaymentStatus = invoiceViewModel.PaymentStatus;
            
            
            // Map other properties as needed

            await _invoiceService.UpdateInvoiceAsync(existingInvoice);
            return NoContent();
        }

        [HttpDelete("{invoiceId}")]
        public async Task<IActionResult> DeleteInvoice(int invoiceId)
        {
            await _invoiceService.DeleteInvoiceAsync(invoiceId);
            return NoContent();
        }
    }
}
