using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.API.Dtos
{
    public class EventoDto
    {
        public int Id {get; set;}
        public string Local {get; set;}
        public string DataEvento {get; set;}

        public string Tema {get; set;}
        [Required (ErrorMessage = "Precisa inserir {0}")]     
        [Range (2, 12000, ErrorMessage = "{0} precisa estar entre 2 e 120000")]
        public int QtdPessoas {get; set;}
        [Required (ErrorMessage = "Precisa inserir {0}")]
        public string ImagemURL {get; set;}
        [Phone (ErrorMessage = "{0} inválido")]
        public string Telefone {get; set;}
        [Required (ErrorMessage = "Precisa inserir {0}")]
        [EmailAddress (ErrorMessage = "{0} inválido")]
        public string Email {get; set;}

        public List<LoteDto> Lotes {get; set;}

        public List<RedeSocialDto> RedesSociais { get; set; }

        public List<PalestranteDto> Palestrantes { get; set; }           
    }
}