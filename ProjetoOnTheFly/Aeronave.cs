using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

        string Caminho = $"C:\\Users\\artur\\source\\repos\\ProjetoOnTheFly\\ProjetoOnTheFly\\Dados\\Aeronave.dat";

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
            Console.WriteLine(">>> CADASTRO DE AERONAVE <<<");

            CadastraIdAeronave();

            if (VerificaAeronave(Caminho, Inscricao))
            {
                Console.WriteLine("Esta Aeronave já está cadastrada!!");
                Thread.Sleep(3000);
                return;
            }

            do
            {
                Console.Write("Informe a capacidade de pessoas que a aeronave comporta: ");
                Capacidade = int.Parse(Console.ReadLine());
            } while (Capacidade < 0 | Capacidade > 999);

            AssentosOcupados = 0;

            UltimaVenda = DateTime.Now.ToString("ddMMyyyy");

            DataCadastro = DateTime.Now.ToString("ddMMyyyy");

            Situacao = 'A';
            string caminho = Caminho;
            string texto = $"{ToString()}\n";
            File.AppendAllText(caminho, texto);

            Console.WriteLine("\n CADASTRO REALIZADO COM SUCESSO!\nPressione Enter para continuar...");
            Console.ReadKey();

            ImprimeAeronave(caminho, Inscricao);
            Console.ReadKey();
        }

        public bool VerificaAeronave(string caminho, string inscricao)
        {
            foreach (string line in File.ReadLines(caminho))
            {
                if (line.Contains(inscricao))
                {
                    return true;
                }
            }
            return false;
        }

        public void CadastraIdAeronave()
        {
            do
            {
                Console.Write("Informe o código de identificação da aeronave seguindo o padrão definido pela ANAC (XX-XXX):");
                Inscricao = Console.ReadLine().ToUpper().Trim().Replace("-", "");
            } while (Inscricao.Length != 5);
        }

        public void ImprimeAeronave(string caminho, string inscricao)
        {
            foreach (string line in File.ReadLines(caminho))
            {
                if (line.Contains(inscricao))
                {
                    Console.WriteLine($"\nInscrição: {line.Substring(0, 2)}-{line.Substring(2, 3)}");
                    Console.WriteLine($"Capacidade: {line.Substring(5, 3)}");
                    Console.WriteLine($"Assentos ocupados: {line.Substring(8, 1)}");
                    Console.WriteLine($"Ultima venda: {line.Substring(9, 2)}/{line.Substring(11, 2)}/{line.Substring(13, 4)}");
                    Console.WriteLine($"Data do Cadastro: {line.Substring(17, 2)}/{line.Substring(19, 2)}/{line.Substring(21, 4)}");
                    if (line.Substring(25, 1).Contains("A"))
                        Console.WriteLine($"Situação: Ativo");
                    else
                        Console.WriteLine($"Situação: Desativado");
                }
            }
        }

        public override string ToString()
        {
            return $"{Inscricao}{Capacidade}{AssentosOcupados}{UltimaVenda}{DataCadastro}{Situacao}";
        }
    }
}
