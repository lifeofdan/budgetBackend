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

        // PUT action

        // DELETE action
    }
}
