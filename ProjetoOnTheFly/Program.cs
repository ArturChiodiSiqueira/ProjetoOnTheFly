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
            int opcao = 9;

            do
            {
                Console.Clear();
                Console.WriteLine("°°°  MENU  INICIAL  °°°");
                Console.WriteLine("opção 0 : sair");
                Console.WriteLine("opção 1 : cadastrar passageiro");
                Console.WriteLine("opção 2 : cadastrar companhia aerea");
                Console.WriteLine("opção 4 : cadastrar aeronave");
                Console.WriteLine("opção 5 : bloqueados");
                Console.WriteLine("opção 6 : Menu Restritos");
                Console.WriteLine("opção 7 : Menu Bloqueados");
                Console.WriteLine("opção 8 : Menu de PAssagem");

                Console.Write("\n\tInforme a opcao: ");
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {

                    // throw;
                }

              
                switch (opcao)
                {
                    case 0:
                        Environment.Exit(0);
                        break;

                    case 1:
                        Console.Clear();

                        break;

                    case 2:
                        Console.Clear();

                        break;

                    case 3:
                        Console.Clear();

                        break;

                    case 4:
                        Console.Clear();

                        break;

                    case 5:
                        Console.Clear();

                        break;

                    case 6:
                        Console.Clear();
                        Restrito rest = new();
                        rest.GerarMenu();
                        break;

                    case 7:
                       Console.Clear();
                        Bloqueado bloq = new();
                        bloq.GerarMenu();
                        break;

                    case 8:
                        Console.Clear();
                        PassagemVoo pass = new ();
                        pass.GerarMenu();
                       // pass.PassagemVoo();

                        break;
                    default:
                        Console.WriteLine(" Opção INVALIDA! Para voltar ao MENU, pressione QUALQUER TECLA!");
                        Console.ReadKey();
                       
                        break;
                }

            } while (opcao>8);
        }


    }
}
