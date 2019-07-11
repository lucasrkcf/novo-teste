using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.API.Dtos
{
    public class PalestranteDto
    {
       public int Id { get; set; }

        public string Nome { get; set; }
        [Required (ErrorMessage = "Precisa inserir {0}")]
        public string MiniCurriculo { get; set; }
        [Required (ErrorMessage = "Precisa inserir {0}")]       
        public string ImagemURL { get; set; }
        [Required (ErrorMessage = "Precisa inserir {0}")]
        public string Telefone { get; set; }
        [Required (ErrorMessage = "Precisa inserir {0}")]
        public string Email { get; set; }

        public List<RedeSocialDto> RedesSociais { get; set; }

        public List<EventoDto> Eventos { get; set; }    
    }
}