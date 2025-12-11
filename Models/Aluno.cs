using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace EstudeX.Models
{
    public class Aluno : Utilizador
    {
        public int idSerie { get; set; }
        public Serie? Serie { get; set; }
        
    }
}