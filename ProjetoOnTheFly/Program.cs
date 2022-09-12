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
                Console.WriteLine("opção 1 : menu cadastro");
                Console.WriteLine("opção 2 : menu localizar");
                Console.WriteLine("opção 3 : menu editar");
               
                Console.Write("\n\tInforme a opcao: ");
                opcao = Console.ReadLine();

                if (opcao != "0" && opcao != "1" && opcao != "3")
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
                            MostrarMenuCadastros();
                            break;

                        case "2":
                            Console.Clear();
                            MostrarMenuLocalizar();
                            break;

                        case "3":
                            Console.Clear();
                            MostrarMenuEditar();
                            break;
                    }
                }
            } while (true);
        }

        static void MostrarMenuCadastros()
        {
            string opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("°°°  MENU  CADASTRO  °°°");
                Console.WriteLine("opção 0 : sair");
                Console.WriteLine("opção 1 : cadastrar passageiro");
                Console.WriteLine("opção 2 : cadastrar companhia aerea");
                Console.WriteLine("opção 4 : cadastrar aeronave");
                Console.WriteLine("opção 5 : cadstrar bloqueados");
                Console.WriteLine("opção 6 : cadastro de voo");
                Console.WriteLine("opção 7 : cadastro de passagem");
                Console.WriteLine("opção 8 : cadastrar venda de passagem");

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
                            Aeronave aeronave = new Aeronave();
                            aeronave.CadastraAeronave();
                            break;

                        case "5":
                            Console.Clear();

                            break;

                        case "6":
                            Console.Clear();
                            Voo voo = new Voo();
                            voo.CadastrarVoo();
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

        static void MostrarMenuLocalizar()
        {
            string opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("°°°  MENU  LOCALIZAR  °°°");
                Console.WriteLine("opção 0 : sair");
                Console.WriteLine("opção 1 : localizar passaageiro");
                Console.WriteLine("opção 2 : localizar companhia aerea");
                Console.WriteLine("opção 4 : localizar aeronave");
                Console.WriteLine("opção 5 : localizar bloqueados");
                Console.WriteLine("opção 6 : localizar de voo");
                Console.WriteLine("opção 7 : localizar de passagem");
                Console.WriteLine("opção 8 : localizar venda de passagem");

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

        static void MostrarMenuEditar()
        {
                string opcao;
                do
                {
                    Console.Clear();
                    Console.WriteLine("°°°  MENU  EDITAR  °°°");
                    Console.WriteLine("opção 0 : sair");
                    Console.WriteLine("opção 1 : editar passageiro");
                    Console.WriteLine("opção 2 : editar companhia aerea");
                    Console.WriteLine("opção 3 : editar aeronave");
                    Console.WriteLine("opção 4 : editar voo");
                    Console.WriteLine("opção 5 : editar passagem");

                    Console.Write("\n\tInforme a opcao: ");
                    opcao = Console.ReadLine();

                    if (opcao != "0" && opcao != "1" && opcao != "3" && opcao != "4" && opcao != "5")
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
                            Aeronave aeronave = new Aeronave();
                            aeronave.AlteraDadoAeronave();
                            break;

                            case "4":
                                Console.Clear();

                                break;

                            case "5":
                                Console.Clear();

                                break;
                        }
                    }
                } while (true);
            }
    }
}
