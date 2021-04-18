using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppsBeginner2.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set;}
        [System.ComponentModel.DisplayName("Expense")]
        public string ExpenseName { get; set; }
        public int Amount { get; set; }
        

     
    }
}
