using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoOnTheFly
{
    internal class PassagemVoo
    {
        public string Id { get; set; }
        public string IdVoo { get; set; }
        public string DataCadastro { get; set; }
        public float Valor { get; set; }
        public char Situacao { get; set; }

        string Caminho = $"C:\\Users\\Luciano\\source\\repos\\ProjetoOnTheFly\\ProjetoOnTheFly\\Dados\\PassagemVoo.dat";
        public PassagemVoo()
        {
            string idVoo;
            float valorPas;
            int capacidade;

            Console.WriteLine(" Digite o codigo do Voo: ");
            idVoo = Console.ReadLine();

            Console.WriteLine(" Digite a capacidade do avião: ");
            capacidade = int.Parse(Console.ReadLine());

            Console.WriteLine(" Digite o valor da Passagem: ");
            valorPas = float.Parse(Console.ReadLine().Replace(",",""));


            for (int i = 0; i < capacidade ; i++)
            {

                int id = Random(0001, 9999);
                Id = $"PA{id}";

                IdVoo = $"V{idVoo}";

                // Console.WriteLine(" Digite o valor da passagem");
                Valor = valorPas; //float.Parse(Console.ReadLine().Replace(",", ""));

                DataCadastro = DateTime.Now.ToShortDateString().Replace("/", "");

                Situacao = 'L';


                string caminho = Caminho;
                string texto = $"{ToString()}\n";
                File.AppendAllText(caminho, texto);


               // Console.ReadKey();
            }          

  
        }
        public override string ToString()
        {
            return $"{Id}{IdVoo}{DataCadastro}{Valor}{Situacao}";
        }

        public int Random( int min, int Max)
        {
           // bool repetido =  false;
            Random r = new Random();
           /* do
            {
                foreach (string linha in File.ReadLines(Caminho))
                {
                    if (linha.Contains("PassagemVoo") & linha.Contains(r))
                    {
                        repetido = true;
                        break;
                    }
                }
            } while (repetido);*/
            return r.Next(0001,9999);

        }

    }
}
