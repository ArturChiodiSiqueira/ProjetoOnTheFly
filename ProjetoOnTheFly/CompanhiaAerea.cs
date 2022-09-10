using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoOnTheFly
{
    internal class CompanhiaAerea
    {
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string DataAbertura { get; set; }
        public string UltimoVoo { get; set; }
        public string DataCadastro { get; set; }
        public string Situacao { get; set; }

        public CompanhiaAerea()
        {
            Console.WriteLine(">>> CADSTRO DE COMPANHIA AEREA <<<");
            Console.WriteLine("Para cancelar o cadastro digite 0:\n");
            do
            {
                Console.Write("Digite seu CNPJ: ");
                Cnpj = Console.ReadLine().Replace(".", "").Replace("-", "").Replace("/", "");
                if (Cnpj == "0")
                    return;
                if (!ValidaCNPJ(Cnpj))
                {
                    Console.WriteLine("Digite um CNPJ Válido!");
                    Thread.Sleep(2000);
                }
            } while (!ValidaCNPJ(Cnpj));

            Console.Write("Digite a Razão Social:  (Max 50 caracteres): ");
            RazaoSocial = Console.ReadLine();
            if (RazaoSocial == "0")
                return;
            if (RazaoSocial.Length > 50)
            {
                Console.WriteLine("Infome uma Razão Social menor que 50 caracteres!!!!");
                Thread.Sleep(2000);
            }
            while (RazaoSocial.Length > 50) ;

            for (int i = RazaoSocial.Length; i <= 50; i++)
                RazaoSocial += " ";

            Console.Write("Digite a data de abertura: ");
            DateTime dataAbertura;
            while (!DateTime.TryParse(Console.ReadLine(), out dataAbertura))
            {
                Console.WriteLine("Formato de data incorreto!");
                Console.Write("Digite a data de abertura: ");
            }

            DataAbertura = dataAbertura.ToShortDateString().Replace("/", "");
            if (DataAbertura == "0")
                return;

            UltimoVoo = DateTime.Now.ToShortDateString().Replace("/", "");

            DataCadastro = DateTime.Now.ToShortDateString().Replace("/", "");

            Situacao = "A";

            string caminho = $"C:\\Users\\wessm\\source\\repos\\ProjetoOnTheFly\\ProjetoOnTheFly\\Dados\\CompanhiaAerea.dat";
            string texto = $"{ToString()}\n";
            File.AppendAllText(caminho, texto);
            Console.WriteLine("\nCADASTRO REALIZADO COM SUCESSO!\nPressione Enter para continuar...");
            Console.ReadKey();

        }
        public override string ToString()
        {
            return $"{Cnpj}{RazaoSocial}{DataAbertura}{UltimoVoo}{DataCadastro}{Situacao}";
        }

        public bool ValidaCNPJ(string vrCNPJ)

        {
            string CNPJ = vrCNPJ.Replace(".", "");
            CNPJ = CNPJ.Replace("/", "");
            CNPJ = CNPJ.Replace("-", "");

            int[] digitos, soma, resultado;
            int nrDig;
            string ftmt;
            bool[] CNPJOk;

            ftmt = "6543298765432";
            digitos = new int[14];
            soma = new int[2];
            soma[0] = 0;
            soma[1] = 0;
            resultado = new int[2];
            resultado[0] = 0;
            resultado[1] = 0;

            CNPJOk = new bool[2];
            CNPJOk[0] = false;
            CNPJOk[1] = false;

            try
            {
                for (nrDig = 0; nrDig < 14; nrDig++)
                {
                    digitos[nrDig] = int.Parse(
                        CNPJ.Substring(nrDig, 1));

                    if (nrDig <= 11)
                        soma[0] += (digitos[nrDig] *
                          int.Parse(ftmt.Substring(
                          nrDig + 1, 1)));

                    if (nrDig <= 12)
                        soma[1] += (digitos[nrDig] *
                          int.Parse(ftmt.Substring(
                          nrDig, 1)));
                }

                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    resultado[nrDig] = (soma[nrDig] % 11);
                    if ((resultado[nrDig] == 0) || (
                         resultado[nrDig] == 1))

                        CNPJOk[nrDig] = (
                        digitos[12 + nrDig] == 0);

                    else
                        CNPJOk[nrDig] = (
                        digitos[12 + nrDig] == (
                        11 - resultado[nrDig]));

                }
                return (CNPJOk[0] && CNPJOk[1]);
            }
            catch
            {
                return false;
            }
        }
    }
}
