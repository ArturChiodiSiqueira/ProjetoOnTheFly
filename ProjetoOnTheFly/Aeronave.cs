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

        public Aeronave(string inscricao, int capacidade, int assentosOcupados, string ultimaVenda, string dataCadastro, char situacao)
        {
            Inscricao = inscricao;
            Capacidade = capacidade;
            AssentosOcupados = assentosOcupados;
            UltimaVenda = ultimaVenda;
            DataCadastro = dataCadastro;
            Situacao = situacao;
        }

        public void CadastraAeronave()
        {
            
            do
            {
                Console.WriteLine("Informe o código de identificação da aeronave seguindo o padrão definido pela ANAC (XX-XXX):");
                Inscricao = Console.ReadLine();
            } while (true);

            Console.Write("Informe a capacidade de pessoas que a aeronave comporta: ");
            Capacidade = int.Parse(Console.ReadLine());

            //preencher a prop assentos ocupados com base na quantidade de passagens vendidas para o voo em que a aeronave ira atuar
            AssentosOcupados = 0;
            while (AssentosOcupados < Capacidade)
            {
                AssentosOcupados++;
            }



        }

        public override string ToString()
        {
            return base.ToString(); 
        }
    }
}
