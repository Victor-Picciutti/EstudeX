using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstudeX.Models.Enuns;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace EstudeX.Models
{
    public class Utilizador
    {
        public int IdUtilizador { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string CPF { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

        public string TipoUtilizador { get; set; }

        [JsonIgnore]
        public ICollection<Duvida>? Duvida { get; set; }
        [JsonIgnore]
        public ICollection<RespostaDuvida>? RespostaDuvida { get; set; }
    }
}