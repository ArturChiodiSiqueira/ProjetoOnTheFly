using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOnTheFly
{
    internal class Voo
    {
        public string Id { get; set; }
        public string Destino { get; set; }
        public Aeronave IdAeronave { get; set; }
        public string DataVoo { get; set; }
        public string DataCadastro { get; set; }
        public char Situacao { get; set; }

        public Voo()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
