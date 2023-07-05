using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MoneyMonkeyLite.Models
{
    internal class Purchase
    {
        public int Id { get; set; }
        public string User { get; set; }
        public double Value { get; set; }
        public string? Description { get; set; }
        public DateOnly Date { get; set; }
        public DateTime TimeStamp { get; set; }
        public int CategoryId { get; set; }
    }
}
