using System;

namespace TestWeb.Models
{
    public class Transaction
    {
      
            public int Id { get; set; }
            public int type { get; set; }
            public DateTime Date { get; set; }
           
            public decimal Amount { get; set; }
       
    }
}