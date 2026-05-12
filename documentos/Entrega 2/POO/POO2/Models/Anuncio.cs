using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace POO2.Models
{
    public class Anuncio
    {
        [Key]
        public int id { get; set; }
        
        [Required]
        public string nome { get; set; } //Nome
        
        [Required]
        public string desc { get; set; }
        
        [Required]
        public string categoria { get; set; }
        
        [Required]
        public string marca { get; set; }
        
        
        [Required]
        [MaxLength(14)]
        [MinLength(14, ErrorMessage = "CPF inválido")]

        public string fornecedor { get; set; } //CNPJ
        
        [NotMapped]
        [JsonIgnore]
        [ForeignKey(nameof(fornecedor))]
        public Vendedor vendedor { get; set; }
        
        [Required]
        public int MOQ { get; set; } //Quantidade minima
        
        [Required]
        public string regiao { get; set; }
        
        [Required]
        public string prazoEntregaMinimo { get; set; }
        
        [Required]
        public string contato { get; set; }
        
        
        public string status { get; set; } = "rascunho";//(rascunho/ativo/pausado)
    }
}