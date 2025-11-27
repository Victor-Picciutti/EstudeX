using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstudeX.Models.Enuns;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace EstudeX.Models
{
    public class RespostaDuvida
    {
        public int IdRespostaDuvida { get; set; }

        public int IdUtilizador { get; set; }

        public int IdDuvida { get; set; }

        public DateTime Momento { get; set; }

        public string ConteudoResposta { get; set; }

        [JsonIgnore]
        public Utilizador? Utilizador { get; set; }
        [JsonIgnore]
        public Duvida? Duvida { get; set; }
    }
}