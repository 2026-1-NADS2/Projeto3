using System.Text.Json.Serialization;
namespace POO2.Models
{
    public class Vendedor : Usuario
    {
        [JsonIgnore]
        public List<Anuncio> anuncios { get; set; } = new List<Anuncio>();
    }
}