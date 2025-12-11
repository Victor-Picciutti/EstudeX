using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace EstudeX.Models
{
    public class TipoUtilizador
    {
        public int IdTipoUtilizador { get; set; }

        public string Cargo { get; set; }

        [JsonIgnore]
        public ICollection<Utilizador>? Utilizadores { get; set; }
       
    }
}