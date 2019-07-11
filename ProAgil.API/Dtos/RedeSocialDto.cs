using System.ComponentModel.DataAnnotations;

namespace ProAgil.API.Dtos
{
    public class RedeSocialDto
    {
    
    public int Id { get; set; }
    [Required (ErrorMessage = "Precisa inserir {0}")]
    public string Nome { get; set; }
    [Required (ErrorMessage = "Precisa inserir {0}")]
    public string URL { get; set; }
    }
}