using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MoneyMonkeyServerLite.Data.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Purchase>? Purchase { get; set; }
    }
}
