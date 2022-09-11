using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoOnTheFly
{
    internal class Voo
    {
        public string Id { get; set; }
        public string Destino { get; set; }
        public string IdAeronave { get; set; }
        public string DataVoo { get; set; }
        public string DataCadastro { get; set; }
        public char Situacao { get; set; }

        string Caminho = $"C:\\Users\\artur\\source\\repos\\ProjetoOnTheFly\\ProjetoOnTheFly\\Dados\\Voo.dat";
        string CaminhoIata = $"C:\\Users\\artur\\source\\repos\\ProjetoOnTheFly\\ProjetoOnTheFly\\Dados\\ListaIatas.dat";
        string CaminhoAeronave = $"C:\\Users\\artur\\source\\repos\\ProjetoOnTheFly\\ProjetoOnTheFly\\Dados\\Aeronave.dat";

        public Voo()
        {

        }

        public Voo(string id, string destino, string idAeronave, string dataVoo, string dataCadastro, char situacao)
        {
            Id = id;
            Destino = destino;
            IdAeronave = idAeronave;
            DataVoo = dataVoo;
            DataCadastro = dataCadastro;
            Situacao = situacao;
        }

        public bool BuscarIata(string iata)
        {
            string caminho = CaminhoIata;
            foreach (string line in File.ReadLines(caminho))
            {
                if (line.Contains(iata))
                {
                    Console.WriteLine("Aeroporto encontrado!");
                    Thread.Sleep(2000);
                    return true;
                }
            }
            Console.WriteLine("Aeroporto não encontrado!");
            Thread.Sleep(2000);
            return false;
        }

        public bool BuscarAeronave(string inscricaoInformada)
        {
            string caminho = CaminhoAeronave;
            foreach (string line in File.ReadLines(caminho))
            {
                if (line.Contains(inscricaoInformada))
                {
                    Console.WriteLine("Aeronave encontrada!");
                    IdAeronave = line.Substring(0, 5);
                    Thread.Sleep(2000);
                    return true;
                }
            }
            Console.WriteLine("Aeronave não encontrada!");
            Thread.Sleep(2000);
            return false;
        }

        public void CadastrarVoo()
        {
            Console.WriteLine(">>> CADASTRO DE VOO <<<");

            Console.Write("Informe a IATA do aeroporto de destino (XXX): ");
            string iata = Console.ReadLine().ToUpper();
            Destino = iata;
            if (!BuscarIata(iata))
            {
                return;
            }

            string inscricaoInformada;
            do
            {
                Console.WriteLine("Informe a inscrição da aeronave que irá realizar o voo: ");
                inscricaoInformada = Console.ReadLine().ToUpper().Trim().Replace("-", "");
            } while (!BuscarAeronave(inscricaoInformada));
            IdAeronave = inscricaoInformada;

            GerarIdVoo();

            Console.Write("Informe a data de partida do voo: ");
            DateTime dataVoo;
            while (!DateTime.TryParse(Console.ReadLine(), out dataVoo))
            {
                Console.Write("Informe a data de partida do voo: ");
            }

            Console.Write("Informe a hora de partida do voo: ");
            DateTime horaVoo;
            while (!DateTime.TryParse(Console.ReadLine(), out horaVoo))
            {
                Console.Write("Informe a hora de partida do voo: ");
            }

            DataVoo = dataVoo.ToString("ddMMyyyy") + horaVoo.ToString("HHmm");

            DataCadastro = DateTime.Now.ToString("ddMMyyyy");

            Situacao = 'A';

            string caminho = Caminho;
            string texto = $"{ToString()}\n";
            File.AppendAllText(caminho, texto);

            Console.WriteLine("\n CADASTRO REALIZADO COM SUCESSO!\nPressione Enter para continuar...");
            Console.ReadKey();

            ImprimeVoo(caminho, Id);
            Console.ReadKey();
        }

        public void GerarIdVoo()
        {
            Random random = new Random();
            Id = "V" + random.Next(0001, 9999).ToString();

            string caminho = Caminho;
            foreach (string linha in File.ReadLines(caminho))
            {
                if (linha.Contains("Voo") & linha.Contains(Id))
                {
                    Console.WriteLine(linha);
                }
            }
        }

        public void ImprimeVoo(string caminho, string id)
        {
            foreach (string line in File.ReadLines(caminho))
            {
                if (line.Contains(id))
                {
                    Console.WriteLine($"\nId: {line.Substring(0, 5)}");
                    Console.WriteLine($"Destino: {line.Substring(5, 3)}");
                    Console.WriteLine($"Inscrição da aeronave: {line.Substring(8, 2)}-{line.Substring(10, 3)}");
                    Console.WriteLine($"Data e hora do voo: {line.Substring(13, 2)}/{line.Substring(15, 2)}/{line.Substring(17, 4)} às {line.Substring(21, 2)}:{line.Substring(23, 2)}");
                    Console.WriteLine($"Data do Cadastro: {line.Substring(25, 2)}/{line.Substring(27, 2)}/{line.Substring(29, 4)}");
                    if (line.Substring(33, 1).Contains("A"))
                        Console.WriteLine($"Situação: Ativo");
                    else
                        Console.WriteLine($"Situação: Desativado");
                }
            }
        }

        public override string ToString()
        {
            return $"{Id}{Destino}{IdAeronave}{DataVoo}{DataCadastro}{Situacao}";
        }
    }
}
