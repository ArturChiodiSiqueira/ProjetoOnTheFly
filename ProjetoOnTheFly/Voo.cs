using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoOnTheFly
{
    internal class Voo
    {
        public string Id { get; set; }
        public string Destino { get; set; }
        public string IdAeronave { get; set; }
        public string DataVoo { get; set; }
        public string DataCadastro { get; set; }
        public string Situacao { get; set; }

        string Caminho = $"C:\\Users\\artur\\source\\repos\\ProjetoOnTheFly\\ProjetoOnTheFly\\Dados\\Voo.dat";
        string CaminhoIata = $"C:\\Users\\artur\\source\\repos\\ProjetoOnTheFly\\ProjetoOnTheFly\\Dados\\ListaIatas.dat";
        string CaminhoAeronave = $"C:\\Users\\artur\\source\\repos\\ProjetoOnTheFly\\ProjetoOnTheFly\\Dados\\Aeronave.dat";

        public Voo()
        {

        }

        public Voo(string id, string destino, string idAeronave, string dataVoo, string dataCadastro, string situacao)
        {
            Id = id;
            Destino = destino;
            IdAeronave = idAeronave;
            DataVoo = dataVoo;
            DataCadastro = dataCadastro;
            Situacao = situacao;
        }

        public bool BuscarIata(string iata)
        {
            string caminho = CaminhoIata;
            foreach (string line in File.ReadLines(caminho))
            {
                if (line.ToUpper().Contains(iata))
                {
                    Console.WriteLine("Aeroporto encontrado!");
                    Thread.Sleep(2000);
                    return true;
                }
            }
            Console.WriteLine("Aeroporto não encontrado!");
            Thread.Sleep(2000);
            return false;
        }

        public bool BuscarAeronave(string inscricaoInformada)
        {
            string caminho = CaminhoAeronave;
            foreach (string line in File.ReadLines(caminho))
            {
                if (line.Contains(inscricaoInformada))
                {
                    Console.WriteLine("Aeronave encontrada!");
                    IdAeronave = line.Substring(0, 5);
                    Thread.Sleep(2000);
                    return true;
                }
            }
            Console.WriteLine("Aeronave não encontrada!");
            Thread.Sleep(2000);
            return false;
        }

        public bool ColetaDestino()
        {
            Console.Write("Informe a IATA do aeroporto de destino (XXX): ");
            string iata = Console.ReadLine().ToUpper();
            Destino = iata;
            if (!BuscarIata(iata))
            {
                return false;
            }
            return true;
        }

        public bool ColetaAeronave()
        {
            string inscricaoInformada;
            do
            {
                Console.WriteLine("Informe a inscrição da aeronave que irá realizar o voo: ");
                inscricaoInformada = Console.ReadLine().ToUpper().Trim().Replace("-", "");
            } while (!BuscarAeronave(inscricaoInformada));
            IdAeronave = inscricaoInformada;
            return true;
        }

        public void CadastrarVoo()
        {
            Console.WriteLine(">>> CADASTRO DE VOO <<<");

            ColetaDestino();

            ColetaAeronave();

            if (!GerarIdVoo())
                return;
            
            Console.Write("Informe a data de partida do voo: ");
            DateTime dataVoo;
            while (!DateTime.TryParse(Console.ReadLine(), out dataVoo))
            {
                Console.Write("Informe a data de partida do voo: ");
            }

            Console.Write("Informe a hora de partida do voo: ");
            DateTime horaVoo;
            while (!DateTime.TryParse(Console.ReadLine(), out horaVoo))
            {
                Console.Write("Informe a hora de partida do voo: ");
            }

            DataVoo = dataVoo.ToString("ddMMyyyy") + horaVoo.ToString("HHmm");

            DataCadastro = DateTime.Now.ToString("ddMMyyyy");

            Situacao = "A";

            PassagemVoo passagemVoo = new();
            //passagemVoo.GerarPassagem();//capacidade e id voo

            string caminho = Caminho;
            string texto = $"{ToString()}\n";
            File.AppendAllText(caminho, texto);

            Console.WriteLine("\n CADASTRO REALIZADO COM SUCESSO!\nPressione Enter para continuar...");
            Console.ReadKey();

            ImprimeVoo(caminho, Id);
            Console.ReadKey();
        }

        public bool GerarIdVoo()
        {
            Random random = new Random();
            Id = "V" + random.Next(0001, 9999).ToString();

            string caminho = Caminho;
            foreach (string linha in File.ReadLines(caminho))
            {
                if (linha.Contains("Voo") & linha.Contains(Id))
                {
                    Console.WriteLine(linha);
                }
            }
            if (VerificaVoo(Caminho, Id))
            {
                Console.WriteLine("Este voo já está cadastrado!!");
                Thread.Sleep(3000);
                return false;
            }
            return true;
        }

        public bool VerificaVoo(string caminho, string id)
        {
            foreach (string line in File.ReadLines(caminho))
            {
                if (line.Substring(0, 5).Contains(id))
                {
                    return true;
                }
            }
            return false;
        }

        public bool AlteraSituacao()
        {
            string num;
            do
            {
                Console.Write("Alterar Situação [A] Ativo / [C] Inativo / [0] Cancelar: ");
                num = Console.ReadLine().ToUpper();
                if (num != "A" && num != "C" && num != "0")
                {
                    Console.WriteLine("Digite um opção válida!!!");
                    Thread.Sleep(2000);
                }
            } while (num != "A" && num != "C" && num != "0");

            if (num.Contains("0"))
                return false;
            Situacao = num;
            return true;
        }

        public void ImprimeVoo(string caminho, string id)
        {
            foreach (string line in File.ReadLines(caminho))
            {
                if (line.Contains(id))
                {
                    Console.WriteLine($"\nId: {line.Substring(0, 5)}");
                    Console.WriteLine($"Destino: {line.Substring(5, 3)}");
                    Console.WriteLine($"Inscrição da aeronave: {line.Substring(8, 2)}-{line.Substring(10, 3)}");
                    Console.WriteLine($"Data e hora do voo: {line.Substring(13, 2)}/{line.Substring(15, 2)}/{line.Substring(17, 4)} às {line.Substring(21, 2)}:{line.Substring(23, 2)}");
                    Console.WriteLine($"Data do Cadastro: {line.Substring(25, 2)}/{line.Substring(27, 2)}/{line.Substring(29, 4)}");
                    if (line.Substring(33, 1).Contains("A"))
                        Console.WriteLine($"Situação: Ativo");
                    else
                        Console.WriteLine($"Situação: Cancelado");
                }
            }
        }

        public void ImprimeVoos()
        {
            string[] lines = File.ReadAllLines(Caminho);
            List<string> voos = new();

            for (int i = 1; i < lines.Length; i++)
            {
                if (lines[i].Substring(33, 1).Contains("A"))
                    voos.Add(lines[i]);
            }

            for (int i = 0; i < voos.Count; i++)
            {
                string op;
                do
                {
                    Console.Clear();
                    Console.WriteLine(">>> Cadastro Voos <<<\nDigite para navegar:\n[1] Próximo Cadasatro\n[2] Cadastro Anterior" +
                        "\n[3] Último cadastro\n[4] Voltar ao Início\n[0] Sair\n");

                    Console.WriteLine($"Cadastro [{i + 1}] de [{voos.Count}]");

                    ImprimeVoo(Caminho, voos[i].Substring(0, 5));

                    Console.Write("Opção: ");
                    op = Console.ReadLine();

                    if (op != "0" && op != "1" && op != "2" && op != "3" && op != "4")
                    {
                        Console.WriteLine("Opção inválida!");
                        Thread.Sleep(2000);
                    }

                    else if (op.Contains("0"))
                        return;

                    else if (op.Contains("2"))
                        if (i == 0)
                            i = 0;
                        else
                            i--;

                    else if (op.Contains("3"))
                        i = voos.Count - 1;

                    else if (op.Contains("4"))
                        i = 0;

                } while (op != "1");
                i = 0;
            }
        }

        public void AlteraDadoVoo()
        {
            string id;

            string caminho = Caminho;
            Console.WriteLine(">>> ALTERAR DADOS DE VOO <<<\nPara sair digite 'S'.\n");
            Console.Write("Digite o ID do voo: ");
            id = Console.ReadLine().ToUpper().Trim();
            if (id == "S")
                return;

            if (!VerificaVoo(Caminho, id))
            {
                Console.WriteLine("Voo não encontrado!!");
                Thread.Sleep(3000);
                return;
            }

            string[] lines = File.ReadAllLines(Caminho);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(id))
                {
                    string num;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine(">>> ALTERAR DADOS DE VOO <<<");
                        Console.Write("Para alterar digite:\n\n[1] Destino\n[2] Aeronave\n[3] Situação do Cadastro\n[0] Sair\nOpção: ");
                        num = Console.ReadLine();

                        if (num != "1" && num != "2" && num != "3" && num != "0")
                        {
                            Console.WriteLine("Opção inválida!");
                            Thread.Sleep(3000);
                        }

                    } while (num != "1" && num != "2" && num != "3" && num != "0");

                    if (num.Contains("0"))
                        return;

                    switch (num)
                    {
                        case "1":
                            if (!ColetaDestino())
                                return;
                            lines[i] = lines[i].Replace(lines[i].Substring(5, Destino.Length), Destino);
                            break;

                        case "2":
                            if (!ColetaAeronave())
                                return;
                            lines[i] = lines[i].Replace(lines[i].Substring(8, IdAeronave.Length), IdAeronave);
                            break;

                        case "3":
                            if (!AlteraSituacao())
                                return;
                            lines[i] = lines[i].Replace(lines[i].Substring(33, Situacao.Length), Situacao);
                            break;
                    }
                    Console.WriteLine("Cadastro alterado com sucesso!");
                    Thread.Sleep(3000);
                }
            }
            File.WriteAllLines(Caminho, lines);
        }

        public override string ToString()
        {
            return $"{Id}{Destino}{IdAeronave}{DataVoo}{DataCadastro}{Situacao}";
        }
    }
}
