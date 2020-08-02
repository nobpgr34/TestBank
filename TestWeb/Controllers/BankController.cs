using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestWeb.Helper;
using TestWeb.Models;

namespace TestWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankController : ControllerBase
    {
        private static readonly List<Transaction> transactionList=new List<Transaction>();
        private static readonly  Client client=new Client(){Id=1,Name ="Test",Amount = 0};

        private readonly ILogger<BankController> _logger;

        public BankController(ILogger<BankController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            return transactionList;
        }
		
		[HttpGet ("{id}")]
        public ActionResult<Transaction> Get (int id)
        {
            var transaction=transactionList.FirstOrDefault(x => x.Id == id);
            if (transaction!=null)return transaction;
            return BadRequest ();
        }
        
        [HttpPost]
        public IActionResult Post ([FromBody] Transaction transaction)
        {
            if (transaction == null)
            {
                return BadRequest ();
            }
            transaction.Id = transactionList.Count;

          bool flag = CounterHelper.Countresult(client, transactionList, transaction);
            if (flag)
            {
                return Ok (transaction);
            }
            else
            {
                 return BadRequest();
            }
            
        }
        
        [HttpGet]
        [Route("[action]")]
        public decimal GetBankValue()
        {
            // string userInfo = $"Id: {user.Id}  Name: {user.Name}  Age: {user.Age}  HasRight: {user.HasRight}";
            return client.Amount;
        }
        
        
    }
}