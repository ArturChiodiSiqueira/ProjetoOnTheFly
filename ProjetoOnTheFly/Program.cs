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
                Console.WriteLine("opção 8 : Menu de Restrição (CPF/CNPJ");

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
                        PassagemVoo pass = new();
                       // pass.PassagemVoo();

                        break;
                    default:
                        Console.WriteLine(" Opção INVALIDA! Para voltar ao MENU, pressione QUALQUER TECLA!");
                        Console.ReadKey();
                       
                        break;
                }

            } while (opcao>8);
        }


        /*
              var result = opcao switch
              {
                  0 => Environment.Exit(0),
                  1 => Console.WriteLine(" Acessando cadastro de passagerios"),
                  2 => Console.WriteLine(" Acessar cadastro de campanhias aereas"),
                  3 => Console.WriteLine(" Cadastrar aeronave"),
                  4 => Console.WriteLine(" Bloqueados"),
                  5 => Console.WriteLine(" Registro de voo"),
                  6 => Console.WriteLine(" Registro de passagem"),
                  7 => Console.WriteLine(" Venda de passagem");
                  => "No case availabe"

              };
        */

        /*
        static void MenuPassagemVoo()
        {
            Console.WriteLine(" Menu Passagem voo \n" +
                " 1 - Localizar");
                 }
        static void MenuRestricao()
        {
            Restrito rest = new Restrito();
            Bloqueado bloq = new Bloqueado();
            int opcao = 0;
            Console.WriteLine(" Menu de restrições \n" +
                " 1 - Verificar CPF\n" +
                " 2 - Verificar CNPJ\n" +
                " 3 - Cadastrar  CPF para ser restringido\n" +
                " 4 - Cadastrar CNPJ para ser restrigido\n" +
                " 5 - Localizar CPF restringido\n" +
                " 6 - Retirar restrição de CPF\n" +
                " 5 - Retirar restrição de CNPJ");
            do
            {
                Console.Write(" Informe a opcao: ");
           
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {


                }
                switch (opcao)
                {
                    case 1:
                        rest.VerificarCpf();
                        break;
                    case 2:
                     //   rest.VerificarCnpj();
                     
                        break;
                    case 3:
                     //   rest.AddRestricaoCnpj();
                        break;
                    case 4:
                        bloq.GerarMenu();
                        break;
                    case 5:
                      //  rest.LocalizarCpf();
                        break;
                    case 6:
                     //   rest.LocalizarCnpj();
                        break;
                    case 7:
                        string idVoo = "0001";
                       PassagemVoo passVoo = new (idVoo);
                        break;
                    case 8:
                    //    rest.RetRestricaoCnpj();
                        break;
                    default:
                        Console.WriteLine(" Opção invalida!!!");
                        break;


                }
            } while (opcao > 5);
        }*/
    }
}
