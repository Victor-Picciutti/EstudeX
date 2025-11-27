using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EstudeX.Models
{
    public class Duvida
    {
        public int IdDuvida { get; set; }

        public Utilizador Utilizador { get; set; }

        public int? IdUtilizador { get; set; }

        public string Descricao { get; set; } 

        public string Titulo { get; set; }

        public DateTime Momento { get; set; }

        public string statusDuvida { get; set; }

    }
}