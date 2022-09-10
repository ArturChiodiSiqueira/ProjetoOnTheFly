using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOnTheFly
{
    internal class Aeronave
    {
        public string Inscricao { get; set; }
        public int Capacidade { get; set; }
        public int AssentosOcupados { get; set; }
        public string UltimaVenda { get; set; }
        public string DataCadastro { get; set; }
        public char Situacao { get; set; }

        public Aeronave()
        {

        }

        public override string ToString()
        {
            return base.ToString(); 
        }
    }
}
