using System.ComponentModel.DataAnnotations;

namespace ProAgil.API.Dtos
{
    public class LoteDto
    {
         public int Id {get; set;}
        [Required (ErrorMessage = "Precisa inserir {0}")]
        public string Nome {get; set;}
        [Required (ErrorMessage = "Precisa inserir {0}")]
        public decimal Preco {get; set;}
        public  string DataInicio {get; set;}

        public  string DataFim {get; set;}
        [Required (ErrorMessage = "Precisa inserir {0}")]
        public int Quantidade {get; set;}
  
    }
}