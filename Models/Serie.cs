using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EstudeX.Models
{
    public class Serie
    {
        public int idSerie { get; set; }
        
        public DateOnly Inicio { get; set; }

        public string Ano { get; set; }

        [JsonIgnore]
        public ICollection<Aluno>? Alunos { get; set; }
    }
}