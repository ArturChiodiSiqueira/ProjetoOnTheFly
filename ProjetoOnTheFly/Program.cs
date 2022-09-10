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
                Console.WriteLine(">>> AEROPORTO ON THE FLY <<<\n");
                Console.WriteLine("°°°  MENU  INICIAL  °°°");
                Console.WriteLine("\nOpção 1 : Cadastrar passageiro");
                Console.WriteLine("Opção 2 : Cadastrar companhia aerea");
                Console.WriteLine("Opção 4 : Cadastrar aeronave");
                Console.WriteLine("Opção 5 : Bloqueados");
                Console.WriteLine("Opção 6 : Registro de voo");
                Console.WriteLine("Opção 7 : Registro de passagem");
                Console.WriteLine("Opção 8 : Venda de passagem");
                Console.WriteLine("Opção 0 : Sair");

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
                            //CadastraAeronave();
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
