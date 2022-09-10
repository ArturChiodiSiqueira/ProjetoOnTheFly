using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOnTheFly
{
    internal class PassagemVoo
    {
        public string Id { get; set; }
        public Voo IdVoo { get; set; }
        public string DataCadastro { get; set; }
        public float Valor { get; set; }
        public char Situacao { get; set; }
    }
}
