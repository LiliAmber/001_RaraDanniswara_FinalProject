using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Payment.Data;
using Payment.Models;
// using Payment.Services;

namespace Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //==auth process==
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class PaymentController : ControllerBase
    {
        //==tryin mysql without services===
        private readonly ApiDbContext _context;
        public PaymentController(ApiDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemData>>> GetPaymentDetails()
        {
            return await _context.Payments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentDetailsById(int id) 
        {
            var item = await _context.Payments.FirstOrDefaultAsync(x => x.paymentDetailId == id);

            if(item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaymentDetails(ItemData data) 
        {
            if(ModelState.IsValid) 
            {
                await _context.Payments.AddAsync(data);
                await _context.SaveChangesAsync();

                // return CreatedAtAction(nameof(GetPaymentDetailsById), new {data.paymentDetailId}, data);
                return Ok("Successfully create a new payment details, please check your database");
            }

            return new JsonResult("Something went wrong") {StatusCode = 500};
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePaymentDetails(int id, ItemData item)
        {
            if(id != item.paymentDetailId)
                return BadRequest();
            
            var existItem = await _context.Payments.FirstOrDefaultAsync(x => x.paymentDetailId == id);

            if(existItem == null)
                return NotFound();

            existItem.cardOwnerName = item.cardOwnerName;
            existItem.cardNumber = item.cardNumber;
            existItem.expirationDate = item.expirationDate;
            existItem.securityCode = item.securityCode;
            
            // Implement the changes on the database level
            await _context.SaveChangesAsync();

            // return NoContent();
            return Ok("Successfully update selected payment details");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentDetails(int id)
        {
            var existItem = await _context.Payments.FirstOrDefaultAsync(x => x.paymentDetailId == id);

            if(existItem == null)
                return NotFound();

            _context.Payments.Remove(existItem);
            await _context.SaveChangesAsync();

            //==respon disini==
            // return Ok(existItem);
            return Ok("Successfully delete selected payment details");
        }
    }
}