using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using budgetBackend.Models;
using budgetBackend.Services;

namespace budgetBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        public BankAccountController()
        {
        }

        // GET all action
        [HttpGet]
        public ActionResult<List<BankAccount>> GetAll() =>
            BankAccountService.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<BankAccount> Get(int id)
        {
            var account = BankAccountService.Get(id);

            if (account == null)
                return NotFound();

            return account;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(BankAccount bankAccount)
        {
            BankAccountService.Add(bankAccount);
            return CreatedAtAction(nameof(Create), new { id = bankAccount.Id }, bankAccount);
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, BankAccount bankAccount)
        {
            // This code will update the pizza and return a result

            var existingBankAccount = BankAccountService.Get(id);
            
            if (existingBankAccount is null)
                return NotFound();

            existingBankAccount.AccountId = bankAccount.AccountId;

            BankAccountService.Save(existingBankAccount);

            return Ok(BankAccountService.Get(id));
        }

        [HttpPut("{id}/deposit={ammount}")]
        public IActionResult MakeDeposit(int id, int ammount)
        {
            var existingBankAccount = BankAccountService.Get(id);

            if(existingBankAccount is null)
                return NotFound();

            existingBankAccount.MakeDeposit(ammount);

            return Ok(BankAccountService.Get(id));
        }

        [HttpPut("{id}/withdraw={ammount}")]
        public IActionResult MakeWithdrawl(int id, int ammount)
        {
            var existingBankAccount = BankAccountService.Get(id);

            if(existingBankAccount is null)
                return NotFound();

            try
            {
                existingBankAccount.MakeWithdrawl(ammount);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
            return Ok(BankAccountService.Get(id));
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bankAccount = BankAccountService.Get(id);

            if (bankAccount is null)
                return NotFound();
            
            // This code will delete the bank account and return a result.
            BankAccountService.Remove(id);

            return NoContent();
        }
    }
}
