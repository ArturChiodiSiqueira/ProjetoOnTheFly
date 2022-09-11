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

        string caminho = "C:\\Users\\wessm\\source\\repos\\ProjetoOnTheFly\\ProjetoOnTheFly\\Dados\\Passageiro.dat";
        public Passageiro()
        {
           
        }

        public override string ToString()
        {
            return $"{Cpf}{Nome}{DataNascimento}{Sexo}{UltimaCompra}{DataCadastro}{Situacao}";
        }

        public void CadastraPassageiro()
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

            if (VerificaPassageiro(this.caminho, Cpf))
            {
                Console.WriteLine("Este CPF já está cadastrado!!");
                Thread.Sleep(3000);
                return;
            }

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



            Console.Write("Digite sua data de nascimento (Mês/Dia/Ano): ");
            DateTime dataNasc;
            while (!DateTime.TryParse(Console.ReadLine(), out dataNasc))
            {
                Console.WriteLine("Formato de data incorreto!");
                Console.Write("Digite sua data de nascimento (Mês/Dia/Ano): ");
            }

            DataNascimento = dataNasc.ToString("ddMMyyyy");
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

            UltimaCompra = DateTime.Now.ToString("ddMMyyyy");

            DataCadastro = DateTime.Now.ToString("ddMMyyyy");

            Situacao = "A";

            string caminho = $"C:\\Users\\wessm\\source\\repos\\ProjetoOnTheFly\\ProjetoOnTheFly\\Dados\\Passageiro.dat";
            string texto = $"{ToString()}\n";
            File.AppendAllText(caminho, texto);

            Console.WriteLine("\nCADASTRO REALIZADO COM SUCESSO!\nPressione Enter para continuar...");
            Console.ReadKey();
        }

        public void AlteraDadoPassageiro()
        {
            string caminho = this.caminho;

            Console.Write("Digite o CPF: ");
            string cpf = Console.ReadLine().Replace(".", "").Replace("-", "");


            string[] lines = File.ReadAllLines(caminho);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(cpf))
                {
                    string num;
                    do
                    {
                        Console.WriteLine("Para alterar digite:\n\n[1] Nome\n[2] Data de Nascimento\n[3] Sexo\n[4] Última Compra\n[5] Situação do Cadastro");
                        num = Console.ReadLine();

                        if(num != "1" && num != "2" && num != "3" && num != "4" && num != "5")
                            Console.WriteLine("Opção inválida!");

                    } while (num != "1" && num != "2" && num != "3" && num != "4" && num != "5");

                    switch (num)
                    {
                        case "1":
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

                            for (int j = Nome.Length; j <= 50; j++)
                                Nome += " ";
                            
                            lines[i] = lines[i].Replace(lines[i].Substring(11, 50), Nome);
                            
                            Console.WriteLine("Nome alterado com sucesso!");

                           
                            break;  
                    }
                }
            }
            for(int i = 0; i < lines.Length; i++)
                File.WriteAllText(caminho, lines[i]);
            Console.WriteLine("gravou");
            Console.ReadKey();  
        }

        public bool VerificaPassageiro(string caminho, string cpf)
        { 
            foreach (string line in File.ReadLines(caminho))
            {
                if (line.Contains(cpf))
                {
                    return true;
                }
            }
            return false;
        }


        public void ImprimePassageiro(string caminho, string cpf)
        {
            foreach (string line in File.ReadLines(caminho))
            {
                if (line.Contains(cpf))
                {
                    Console.WriteLine($"CPF: {line.Substring(0, 11)}");
                    Console.WriteLine($"Nome: {line.Substring(11, 50)}");
                    Console.WriteLine($"Data de Nascimento: {line.Substring(62, 2)}/{line.Substring(64, 2)}/{line.Substring(66, 4)}");
                    Console.WriteLine($"Sexo: {line.Substring(70, 1).ToUpper()}");
                    Console.WriteLine($"Ùltima compra: {line.Substring(71, 2)}/{line.Substring(73, 2)}/{line.Substring(75, 4)}");
                    Console.WriteLine($"Data do Cadastro: {line.Substring(79, 2)}/{line.Substring(81, 2)}/{line.Substring(83, 4)}");
                    if (line.Substring(87, 1).Contains("A"))
                        Console.WriteLine($"Situação: Ativo");
                    else
                        Console.WriteLine($"Situação: Desativado");

                }
            }
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
