using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EstudeX.Models
{
    public class Serie
    {
        public int IdSerie { get; set; }
        
        public DateOnly Inicio { get; set; }

        public DateTime Ano { get; set; }

        [JsonIgnore]
        public ICollection<Aluno>? Alunos { get; set; }
    }
}