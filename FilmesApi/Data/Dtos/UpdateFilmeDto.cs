using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Data.Dtos
{
    public class UpdateFilmeDto
    {
   

        [Required(ErrorMessage = "Titulo obrigatorio")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Titulo obrigatorio")]
        public string Diretor { get; set; }

        public string Genero { get; set; }

        [Range(1, 600, ErrorMessage = "Duracao deve ter entre 1 e 600")]
        public int Duracao { get; set; }
    }
}
