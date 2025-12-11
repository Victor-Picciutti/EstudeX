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
        public byte[]? Foto { get; set; }
        public byte[]? Senha { get; set; }
        
        [JsonIgnore]
        public TipoUtilizador? TipoUtilizador { get; set; }
        public int IdTipoUtilizador { get; set; }

        [JsonIgnore]
        public ICollection<Duvida>? Duvida { get; set; }
        [JsonIgnore]
        public ICollection<RespostaDuvida>? RespostaDuvida { get; set; }

        internal static int UtilizadorId()
        {
            throw new NotImplementedException();
        }
    }
}