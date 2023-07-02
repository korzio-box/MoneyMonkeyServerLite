using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using MoneyMonkeyServerLite.Data.Models;

namespace MoneyMonkeyServerLite.Data.Models
{
    [Index(nameof(Date))]
    public class Purchase
    {
        [ForeignKey("CategoryId")]
        public int Id { get; set; }

        [MaxLength(60)]
        public string User { get; set; }

        public double Value { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly Date { get; set; }

        public DateTime TimeStamp { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }



    }
}
