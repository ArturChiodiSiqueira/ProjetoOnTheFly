using System;
using System.Collections.Generic;
using System.IO;
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
            Console.WriteLine(">>> CADSTRO DE AERONAVE <<<");
            
            CadastraIdAeronave();

            do
            {
                Console.Write("Informe a capacidade de pessoas que a aeronave comporta: ");
                Capacidade = int.Parse(Console.ReadLine());
            } while (Capacidade < 0 && Capacidade > 999); //perguntar!! n ta dando certo... ta cadastrando aeronave com mais de 999

            AssentosOcupados = 0;

            UltimaVenda = DateTime.Now.ToShortDateString().Replace("/", "");

            DataCadastro = DateTime.Now.ToShortDateString().Replace("/", "");

            Situacao = 'A';
            string caminho = $"C:\\Users\\artur\\source\\repos\\ProjetoOnTheFly\\ProjetoOnTheFly\\Dados\\Aeronave.dat";
            string texto = $"{ToString()}\n";
            File.AppendAllText(caminho, texto);

            Console.WriteLine("\n CADASTRO REALIZADO COM SUCESSO!\nPressione Enter para continuar...");
            Console.ReadKey();
        }

        public void CadastraIdAeronave()
        {
            do
            {
                Console.Write("Informe o código de identificação da aeronave seguindo o padrão definido pela ANAC (XX-XXX):");
                Inscricao = Console.ReadLine().ToUpper().Trim().Replace("-", " ");
            } while (Inscricao.Length != 6);
        }

        public override string ToString()
        {
            return $"{Inscricao}{Capacidade}{AssentosOcupados}{UltimaVenda}{DataCadastro}{Situacao}";
        }
    }
}
