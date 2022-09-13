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
            int opcao = 5;
            Console.Clear();
            Console.WriteLine(" °°°  MENU  INICIAL  °°°");
            Console.WriteLine(" Opção 1 : Menu cadastro");
            Console.WriteLine(" Opção 2 : Menu localizar");
            Console.WriteLine(" Opção 3 : Menu editar");
            Console.WriteLine(" Opção 4 : Menu bloqueados e restritos");
            Console.WriteLine(" Opção 0 : Sair");

            Console.Write("\n Informe a opção: ");

            do
            {
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                }

                switch (opcao)
                {
                    case 0:
                        Environment.Exit(0);
                        break;

                    case 1:
                        Console.Clear();
                        MostrarMenuCadastrar();
                        break;

                    case 2:
                        Console.Clear();
                        MostrarMenuLocalizar();
                        break;

                    case 3:
                        Console.Clear();
                        MostrarMenuEditar();
                        break;

                    case 4:
                        Console.Clear();
                        MenuBloqueadosRestritos();
                        break;

                    default:
                        Console.Write("\n Opcao Inválida!\n Digite novamente: ");
                        break;
                }
            } while (true);
        }

        static void MostrarMenuCadastrar()
        {
            int opcao = 8;
                Console.WriteLine(" °°°  MENU  CADASTRO  °°°");
                Console.WriteLine(" Opção 1 : Cadastrar passageiro");
                Console.WriteLine(" Opção 2 : Cadastrar companhia aerea");
                Console.WriteLine(" Opção 3 : Cadastrar aeronave");
                Console.WriteLine(" Opção 4 : Cadastro de voo");
                Console.WriteLine(" Opção 5 : Cadastro de passagem");
                Console.WriteLine(" Opção 6 : Cadastrar venda de passagem");
                Console.WriteLine(" Opção 7 : Voltar ao Menu Iniciar");
                Console.WriteLine(" Opção 0 : Sair");

                Console.Write("\n Informe a opção: ");

            do
            {
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                }
                switch (opcao)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        Console.WriteLine(" Cadastrar passageiro");
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine(" Cadastrar companhia aerea");
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine(" Cadastrar aeronave");
                        Console.Clear();
                        break;
                    
                    case 4:
                        Console.WriteLine(" Cadastro de voo");
                        Console.Clear();
                        break;
                    case 5:
                        Console.WriteLine(" Cadastro de passagem");
                        Console.Clear();
                        break;
                    case 6:
                        Console.WriteLine(" Cadastrar venda de passagem");
                        Console.Clear();
                        break;
                    case 7:
                        Console.WriteLine(" Menu Inicial");
                        MostrarMenuInicial();
                        break;
                    default:
                        Console.Write("\n Opção invalida\n Digite novamente:");
                        break;
                }
            } while (true);
        }

        static void MostrarMenuLocalizar()
        {
            int opcao = 8;
            Console.WriteLine(" °°°  MENU  LOCALIZAR  °°°");
            Console.WriteLine(" Opção 1 : Localizar passaageiro");
            Console.WriteLine(" Opção 2 : Localizar companhia aerea");
            Console.WriteLine(" Opção 3 : Localizar aeronave");
            Console.WriteLine(" Opção 4 : Localizar de voo");
            Console.WriteLine(" Opção 5 : Localizar de passagem");
            Console.WriteLine(" Opção 6 : Localizar venda de passagem");
            Console.WriteLine(" Opção 7 : Voltar ao Menu Iniciar");
            Console.WriteLine(" Opção 0 : Sair");

            Console.Write("\n Informe a opção: ");

            do
            {
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                }

                switch (opcao)
                {
                    case 0:
                        Environment.Exit(0);
                        break;

                    case 1:
                        Console.WriteLine("Localizar passaageiro");
                        Console.Clear();

                        break;

                    case 2:
                        Console.WriteLine("Localizar companhia aerea");
                        Console.Clear();

                        break;

                    case 3:
                        Console.WriteLine("Localizar aeronave");
                        Console.Clear();

                        break;

                    case 4:
                        Console.WriteLine("Localizar de voo");
                        Console.Clear();

                        break;

                    case 5:
                        Console.WriteLine("Localizar de passagem");
                        Console.Clear();

                        break;

                    case 6:
                        Console.WriteLine("Localizar venda de passagem");
                        Console.Clear();

                        break;

                    case 7:
                        Console.Clear();
                        MostrarMenuInicial();
                        break;

                    default:
                        Console.Write("\n Opcao Inválida!\n Digite novamente: ");
                        break;
                }

            } while (true);
        }

        static void MostrarMenuEditar()
        {
            int opcao = 7;
                Console.WriteLine(" °°°  MENU  EDITAR  °°°");
                Console.WriteLine(" Opção 1 : Editar passageiro");
                Console.WriteLine(" Opção 2 : Editar companhia aerea");
                Console.WriteLine(" Opção 3 : Editar aeronave");
                Console.WriteLine(" Opção 4 : Editar voo");
                Console.WriteLine(" Opção 5 : Editar passagem");
                Console.WriteLine(" Opção 6 : Voltar ao Menu Iniciar");
                Console.WriteLine(" Opção 0 : Sair");

            Console.Write("\n Informe a opção: ");
            do
            {
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                }

                switch (opcao)
                {
                    case 0:
                        Environment.Exit(0);
                        break;

                    case 1:
                        Console.WriteLine("Editar passageiro");
                        Console.Clear();

                        break;

                    case 2:
                        Console.WriteLine("Editar companhia aerea");
                        Console.Clear();

                        break;

                    case 3:
                        Console.WriteLine("Editar aeronave");
                        Console.Clear();
                        
                        break;

                    case 4:
                        Console.WriteLine("Editar voo");
                        Console.Clear();
                        
                        break;

                    case 5:
                        Console.WriteLine("Editar passagem");
                        Console.Clear();

                        break;

                    case 6:
                        Console.Clear();
                        MostrarMenuInicial();
                        break;
                }

            } while (true);
        }

        static void MenuBloqueadosRestritos()
        {
            int opcao = 8;
            Console.WriteLine(" °°°  MENU  BLOQUEADOS E RESTRITOS  °°°");
            Console.WriteLine(" Opção 1 : Restringir CPF");
            Console.WriteLine(" Opção 2 : Bloquear CNPJ");
            Console.WriteLine(" Opção 3 : Verificar restrição CPF");
            Console.WriteLine(" Opção 4 : Verificar bloqueio CNPJ");
            Console.WriteLine(" Opção 5 : Retirar restrição CPF");
            Console.WriteLine(" Opção 6 : Desbloquear CNPJ");
            Console.WriteLine(" Opção 7 : Voltar ao Menu Iniciar");
            Console.WriteLine(" Opção 0 : Sair");

            Console.Write("\n Informe a opção: ");
            do
            {
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                }

                switch (opcao)
                {
                    case 0:
                        Environment.Exit(0);
                        break;

                    case 1:
                        Console.WriteLine("Restringir CPF");
                        Console.Clear();

                        break;

                    case 2:
                        Console.WriteLine("Bloquear CNPJ");
                        Console.Clear();

                        break;

                    case 3:
                        Console.WriteLine("Verificar restrição CPF");
                        Console.Clear();

                        break;

                    case 4:
                        Console.WriteLine("Verificar bloqueio CNPJ");
                        Console.Clear();

                        break;

                    case 5:
                        Console.WriteLine("Retirar restrição CPF");
                        Console.Clear();

                        break;

                    case 6:
                        Console.WriteLine("Desbloquear CNPJ");
                        Console.Clear();

                        break;

                    case 7:
                        Console.Clear();
                        MostrarMenuInicial();
                        break;
                }

            } while (true);
        }
    }
}
