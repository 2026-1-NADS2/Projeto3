using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace POO2.Models
{
    [Index(nameof(cnpj), IsUnique=true)]
    public class Usuario
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string login { get; set; }

        [Required]
        public string senha { get; set; }

        [Required]
        public string email { get; set; }


        [Required]
        [MaxLength(14)]
        [MinLength(14, ErrorMessage = "CNPJ inválido")]
        public string cnpj { get; set; }
    }
}