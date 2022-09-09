using System;

namespace ProjetoOnTheFly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            MostrarMenuInicial();
        }
        static void MostrarMenuInicial()
        {
            string opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("°°°  MENU  INICIAL  °°°");
                Console.WriteLine("opção 0 : sair");
                Console.WriteLine("opção 1 : cadastrar passaageiro");
                Console.WriteLine("opção 2 : cadastrar companhia aerea");
                Console.WriteLine("opção 4 : cadastrar aeronave");
                Console.WriteLine("opção 5 : bloqueados");
                Console.WriteLine("opção 6 : registro de voo");
                Console.WriteLine("opção 7 : registro de passagem");
                Console.WriteLine("opção 8 : venda de passagem");

                Console.Write("\n\tInforme a opcao: ");
                opcao = Console.ReadLine();

                if (opcao != "0" && opcao != "1" && opcao != "3" && opcao != "4" && opcao != "5" && opcao != "6" && opcao != "7" && opcao != "8")
                {
                    Console.WriteLine("'" + opcao + "' é uma opcao INVALIDA! Para voltar ao MENU, pressione QUALQUER TECLA!");
                    Console.ReadKey();
                    Console.Clear();
                }

                else
                {
                    switch (opcao)
                    {
                        case "0":
                            Environment.Exit(0);
                            break;

                        case "1":
                            Console.Clear();

                            break;

                        case "2":
                            Console.Clear();

                            break;

                        case "3":
                            Console.Clear();

                            break;

                        case "4":
                            Console.Clear();

                            break;

                        case "5":
                            Console.Clear();

                            break;

                        case "6":
                            Console.Clear();

                            break;

                        case "7":
                            Console.Clear();

                            break;

                        case "8":
                            Console.Clear();

                            break;
                    }
                }
            } while (true);
        }
    }
}
