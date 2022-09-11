using System;
using System.Collections.Generic;
using System.IO;
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

        public Voo(string id, string destino, Aeronave idAeronave, string dataVoo, string dataCadastro, char situacao)
        {
            Id = id;
            Destino = destino;
            IdAeronave = idAeronave;
            DataVoo = dataVoo;
            DataCadastro = dataCadastro;
            Situacao = situacao;
        }

        public void CadastrarVoo()
        {
            GerarIdVoo();

            //destino
            Console.Write("Informe a IATA do aeroporto de destino (XXX): ");

            //id da aeronave
            // perguntar!! preciso saber se a aeronave existe... para isso consultar no arquivo.
            Console.WriteLine("Informe a inscrição da aeronave que irá realizar o voo: ");
            

            

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

            DataVoo = dataVoo.ToShortDateString().Replace("/", "") + horaVoo.ToShortTimeString().Replace(":", "");

            DataCadastro = DateTime.Now.ToShortDateString().Replace("/", "");

            Situacao = 'A';

            string caminho = $"C:\\Users\\artur\\source\\repos\\ProjetoOnTheFly\\ProjetoOnTheFly\\Dados\\Voo.dat";
            string texto = $"{ToString()}\n";
            File.AppendAllText(caminho, texto);


            Console.WriteLine("\n CADASTRO REALIZADO COM SUCESSO!\nPressione Enter para continuar...");
            Console.ReadKey();
        }

        public void GerarIdVoo()
        {
            Random random = new Random();
            Id = "V" + random.Next(0001, 9999).ToString();

            foreach (string linha in File.ReadLines($"C:\\Users\\artur\\source\\repos\\ProjetoOnTheFly\\ProjetoOnTheFly\\Dados\\Voo.dat"))
            {
                if (linha.Contains("Voo") & linha.Contains(Id))
                {
                    Console.WriteLine(linha);
                }
            }
        }

        public override string ToString()
        {
            return $"{Id}{Destino}{IdAeronave}{DataVoo}{DataCadastro}{Situacao}";
        }
    }
}
