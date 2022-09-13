using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoOnTheFly
{
    internal class Restrito
    {
        public string Cpf { get; set; }

        string Caminho = $"C:\\Users\\artur\\source\\repos\\ProjetoOnTheFly\\ProjetoOnTheFly\\Dados\\Restritos.dat";
        public void GerarMenu()
        {
            int opc = 5;
            bool retorna = true;

            Console.WriteLine(" Digite a opção: \n" +
                "1 - Adicionar CPF\n" +
                "2 - Verificar CPF\n" +
                "3 - Remover CPF\n" +
                "4 - Voltar ao Menu Restritos\n" +
                "0 - Sair");

            do
            {
                try
                {
                    opc = int.Parse(Console.ReadLine());

                }
                catch (Exception)
                {
                }

                switch (opc)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        AddRestricaoCpf();
                        break;
                    case 2:
                        VerificarCpf();
                        break;
                    case 3:
                        RetirarRestricaoCpf();
                        break;
                    case 4:
                        retorna = false;
                        break;
                    default: break;
                }
            } while (retorna);
        }

        public void VerificarCpf()
        {
            Console.WriteLine(" Digite o CPF para ser verificado: ");
            Cpf = Console.ReadLine().Replace(".", "").Replace("-", "");
            string caminho = Caminho;

            foreach (string linha in File.ReadLines(caminho))
            {
                if (linha.Contains(Cpf))
                {
                    Console.WriteLine(" Este CPF ja esta restrito\n Tecle enter para continuar");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine(" Esse CPF não está restrito");
                }

            }
        }
        public void AddRestricaoCpf()
        {
            bool validar;

            do
            {
                Console.WriteLine(" Digite o CPF que sera bloqueado");
                Cpf = Console.ReadLine().Replace(".", "").Replace("-", "");
                validar = ValidarCPF(Cpf);
                if (validar)
                {

                    string caminho = Caminho;
                    string texto = $"{ToString()}\n";
                    File.AppendAllText(caminho, texto);
                    Console.WriteLine("\n CPF foi adicionado a lista de restringido");
                    Console.ReadKey();
                }
                else if (validar == false)
                {
                    Console.WriteLine(" CPF invalido");

                    Console.WriteLine(" Digite um CPF valido\n");
                }
            } while (validar == false);

        }

        public void RetirarRestricaoCpf()
        {
            Console.WriteLine(" Digite o CPF para verificar: ");
            Cpf = Console.ReadLine().Replace(".", "").Replace("-", "");
            string caminho = Caminho;
            List<string> retRest = new();

            foreach (string linha in File.ReadLines(caminho))
            {
                retRest.Add(linha);
            }
            for (int i = 0; i < retRest.Count; i++)
            {
                if (retRest[i].Contains(Cpf))
                {
                    retRest.RemoveAt(i);
                    Console.WriteLine("Retirada a restrição do CPF com sucesso");
                    Console.ReadKey();
                }
            }
            File.WriteAllLines(Caminho, retRest.ToArray());
        }


        public override string ToString()
        {
            return $"{Cpf}";
        }

        private static bool ValidarCPF(string vrCPF)

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
