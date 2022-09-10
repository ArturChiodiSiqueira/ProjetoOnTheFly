using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoOnTheFly
{
    internal class Passageiro
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string UltimaCompra { get; set; }
        public string DataCadastro { get; set; }
        public string Situacao { get; set; }

        public Passageiro()
        {
            Console.WriteLine(">>> CADSTRO DE PASSAGEIRO <<<");
            Console.WriteLine("Para cancelar o cadastro digite 0:\n");
            do
            {
                Console.Write("Digite seu CPF: ");
                Cpf = Console.ReadLine().Replace(".", "").Replace("-", "");
                if (Cpf == "0")
                    return;
                if (!ValidaCPF(Cpf))
                {
                    Console.WriteLine("Digite um CPF Válido!");
                    Thread.Sleep(2000);
                }
            } while (!ValidaCPF(Cpf));

            do
            {
                Console.Write("Digite seu Nome (Max 50 caracteres): ");
                Nome = Console.ReadLine();
                if (Nome == "0")
                    return;
                if (Nome.Length > 50)
                {
                    Console.WriteLine("Infome um nome menor que 50 caracteres!!!!");
                    Thread.Sleep(2000);
                }
            } while (Nome.Length > 50);

            for (int i = Nome.Length; i <= 50; i++)
                Nome += " ";



            Console.Write("Digite sua data de nascimento: ");
            DateTime dataNasc;
            while (!DateTime.TryParse(Console.ReadLine(), out dataNasc))
            {
                Console.WriteLine("Formato de data incorreto!");
                Console.Write("Digite sua data de nascimento: ");
            }
            
            DataNascimento = dataNasc.ToShortDateString().Replace("/", "");
            if (DataNascimento == "0")
                return;

            do
            {
                Console.WriteLine("Digite seu sexo [M] Masculino / [F] Feminino / [N] Prefere não informar: ");
                Sexo = Console.ReadLine().ToLower();
                if (Sexo == "0")
                    return;
                if (Sexo != "m" && Sexo != "n" && Sexo != "f")
                {
                    Console.WriteLine("Digite um opção válida!!!");
                    Thread.Sleep(2000);
                }
            } while (Sexo != "m" && Sexo != "n" && Sexo != "f");

            UltimaCompra = DateTime.Now.ToShortDateString().Replace("/", "");

            DataCadastro = DateTime.Now.ToShortDateString().Replace("/", "");

            Situacao = "A";

            string caminho = $"C:\\Users\\wessm\\source\\repos\\ProjetoOnTheFly\\ProjetoOnTheFly\\Dados\\Passageiro.dat";
            string texto =$"{ToString()}\n";
            File.AppendAllText(caminho, texto);
            Console.WriteLine("\nCADASTRO REALIZADO COM SUCESSO!\nPressione Enter para continuar...");
            Console.ReadKey();
        }

        public override string ToString()
        {
            return $"{Cpf}{Nome}{DataNascimento}{Sexo}{UltimaCompra}{DataCadastro}{Situacao}";
        }
        private static bool ValidaCPF(string vrCPF)

        {
            string valor = vrCPF.Replace(".", "");

            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)

                if (valor[i] != valor[0])

                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)

                numeros[i] = int.Parse(

                  valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)

                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)

            {
                if (numeros[9] != 0)
                    return false;
            }

            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)

            {
                if (numeros[10] != 0)
                    return false;
            }

            else
                if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }
    }
}
