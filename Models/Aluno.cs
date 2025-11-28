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
        public string Serie { get; set; }

        [JsonIgnore]
        public Utilizador? Utilizador { get; set;}
    }
}