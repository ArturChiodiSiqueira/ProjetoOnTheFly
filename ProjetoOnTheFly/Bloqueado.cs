using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoOnTheFly
{
    

    internal class Bloqueado
    {
        public string Cnpj { get; set; }

        string Caminho = $"C:\\Users\\Luciano\\source\\repos\\ProjetoOnTheFly\\ProjetoOnTheFly\\Dados\\Bloqueados.dat";


        public void GerarMenu()
        {
            //BloquearCnpj();
            Console.WriteLine(" Digite a opção: \n" +
                "1 - Adicionar CNPJ\n" +
                "2 - Verificar CNPJ\n" +
                "3 - Remover CNPJ");
            int opc = int.Parse(Console.ReadLine());
            switch (opc)
            {
                case 1:
                    BloquearCnpj();
                    break;
                case 2:
                    VerificarCnpj();
                    break;
                case 3:
                    DesbloquearCnpj();
                    break;
                default:break;
            }
        }

        public void VerificarCnpj()
        {
            Console.WriteLine(" Digite o CNPJ para verificar: ");
            Cnpj = Console.ReadLine().Replace(".", "").Replace("/", "").Replace("-", "");
            string caminho = Caminho;

            foreach(string linha in File.ReadLines(caminho))
            {
                if (linha.Contains(Cnpj))
                {
                    Console.WriteLine(" Este CNPJ ja esta bloqueado\n Tecle enter para continuar");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine(" Esse CNPJ não está bloqueado");
                }
            }

        }
        public void BloquearCnpj()
        {
            bool validar;
            do
            {
                Console.WriteLine(" Digite o CNPJ a ser bloqueado");
                Cnpj = Console.ReadLine().Replace(".","").Replace("/","").Replace("-","");
                validar = ValidarCNPJ(Cnpj);
                if (validar)
                {
                    string caminho = Caminho;
                    string texto = $"{ToString()}\n";
                    File.AppendAllText(caminho, texto);
                    Console.WriteLine("\n CNPJ foi adicionado a lista de bloqueado");
                    Console.ReadKey();
                }
                else if(!validar){
                    Console.WriteLine(" CNPJ invalido");
                    Console.WriteLine(" \nDigite um CPNJ valido\n");
                }

            } while (validar == false);
        }






        public void DesbloquearCnpj()
        {
            Console.WriteLine(" Digite o CNPJ para verificar: ");
            Cnpj = Console.ReadLine().Replace(".", "").Replace("/", "").Replace("-", "");
            string caminho = Caminho;
            List<string> desbloq = new();

            foreach (string linha in File.ReadLines(caminho))
            {   
              desbloq.Add(linha);
            }
            for (int i =0; i <desbloq.Count;i++)
            {
                if (desbloq[i].Contains(Cnpj))
                {
                    desbloq.RemoveAt(i);
                    Console.WriteLine("CPNJ desbloqueado com sucesso");
                    Console.ReadKey();

                }
            }File.WriteAllLines(Caminho,desbloq.ToArray());

        }

        public override string ToString()
        {
            return $"{Cnpj}";
        }
        public static bool ValidarCNPJ(string vrCNPJ)
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
