using System.Text.Json.Serialization;
namespace POO2.Models
{
    public class Comprador : Usuario
    {
        [JsonIgnore]
        public double saldo { get; set; }
    }
}