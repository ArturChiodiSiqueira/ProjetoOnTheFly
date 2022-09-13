using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ProjetoOnTheFly
{
    internal class Aeronave
    {
        public string Inscricao { get; set; }
        public string Capacidade { get; set; }
        public string AssentosOcupados { get; set; }
        public string UltimaVenda { get; set; }
        public string DataCadastro { get; set; }
        public string Situacao { get; set; }
        string Caminho = $"C:\\Users\\artur\\source\\repos\\ProjetoOnTheFly\\ProjetoOnTheFly\\Dados\\Aeronave.dat";
        public Aeronave()
        {
        }
        public Aeronave(string inscricao, string capacidade, string assentosOcupados, string ultimaVenda, string dataCadastro, string situacao)
        {
            Inscricao = inscricao;
            Capacidade = capacidade;
            AssentosOcupados = assentosOcupados;
            UltimaVenda = ultimaVenda;
            DataCadastro = dataCadastro;
            Situacao = situacao;
        }
        public void CadastraAeronave()
        {
            Console.WriteLine(">>> CADASTRO DE AERONAVE <<<");
            if (!CadastraIdAeronave())
                return;
            CadastraQtdPassageiros();
            AssentosOcupados = "000";
            UltimaVenda = DateTime.Now.ToString("ddMMyyyy");
            DataCadastro = DateTime.Now.ToString("ddMMyyyy");
            Situacao = "A";
            string caminho = Caminho;
            string texto = $"{ToString()}\n";
            File.AppendAllText(caminho, texto);
            Console.WriteLine("\n CADASTRO REALIZADO COM SUCESSO!\nPressione Enter para continuar...");
            Console.ReadKey();
            ImprimeAeronave(caminho, Inscricao);
            Console.ReadKey();
        }
        public bool VerificaAeronave(string caminho, string inscricao)
        {
            foreach (string line in File.ReadLines(caminho))
            {
                if (line.Substring(0, 5).Contains(inscricao))
                {
                    return true;
                }
            }
            return false;
        }
        public bool CadastraIdAeronave()
        {
            do
            {
                Console.Write("Informe o código de identificação da aeronave seguindo o padrão definido pela ANAC (XX-XXX):");
                Inscricao = Console.ReadLine().ToUpper().Trim().Replace("-", "");
            } while (Inscricao.Length != 5);
            if (VerificaAeronave(Caminho, Inscricao))
            {
                Console.WriteLine("Esta Aeronave já está cadastrada!!");
                Thread.Sleep(3000);
                return false;
            }
            return true;
        }
        public bool CadastraQtdPassageiros()
        {
            do
            {
                Console.Write("Informe a capacidade de pessoas que a aeronave comporta: ");
                Capacidade = Console.ReadLine();
            } while (int.Parse(Capacidade) < 0 || int.Parse(Capacidade) > 999);
            if (int.Parse(Capacidade) > 9 && int.Parse(Capacidade) < 100)
            {
                Capacidade = "0" + Capacidade;
            }
            if (int.Parse(Capacidade) < 10)
            {
                Capacidade = "00" + Capacidade;
            }
            return true;
        }
        public bool AlteraSituacao()
        {
            string num;
            do
            {
                Console.Write("Alterar Situação [A] Ativo / [I] Inativo / [0] Cancelar: ");
                num = Console.ReadLine().ToUpper();
                if (num != "A" && num != "I" && num != "0")
                {
                    Console.WriteLine("Digite um opção válida!!!");
                    Thread.Sleep(2000);
                }
            } while (num != "A" && num != "I" && num != "0");
            if (num.Contains("0"))
                return false;
            Situacao = num;
            return true;
        }
        public void ImprimeAeronave(string caminho, string inscricao)
        {
            foreach (string line in File.ReadLines(caminho))
            {
                if (line.Contains(inscricao))
                {
                    Console.WriteLine($"\nInscrição: {line.Substring(0, 2)}-{line.Substring(2, 3)}");
                    Console.WriteLine($"Capacidade: {line.Substring(5, 3)}");
                    Console.WriteLine($"Assentos ocupados: {line.Substring(8, 3)}");
                    Console.WriteLine($"Ultima venda: {line.Substring(11, 2)}/{line.Substring(13, 2)}/{line.Substring(15, 4)}");
                    Console.WriteLine($"Data do Cadastro: {line.Substring(19, 2)}/{line.Substring(21, 2)}/{line.Substring(23, 4)}");
                    if (line.Substring(27, 1).Contains("A"))
                        Console.WriteLine($"Situação: Ativo");
                    else
                        Console.WriteLine($"Situação: Inativo");
                }
            }
        }
        public void ImprimeAeronaves()
        {
            string[] lines = File.ReadAllLines(Caminho);
            List<string> aeronaves = new();
            for (int i = 0; i < lines.Length; i++)
            {
                //Verifica se o cadastro esta ativo
                if (lines[i].Substring(27, 1).Contains("A"))
                    aeronaves.Add(lines[i]);
            }
            //Laço para navegar nos cadastros de aeronaves
            for (int i = 0; i < aeronaves.Count; i++)
            {
                string op;
                do
                {
                    Console.Clear();
                    Console.WriteLine(">>> Cadastro Aeronaves <<<\nDigite para navegar:\n[1] Próximo Cadasatro\n[2] Cadastro Anterior" +
                        "\n[3] Último cadastro\n[4] Voltar ao Início\n[0] Sair\n");
                    Console.WriteLine($"Cadastro [{i + 1}] de [{aeronaves.Count}]");
                    //Imprimi o primeiro da lista
                    ImprimeAeronave(Caminho, aeronaves[i].Substring(0, 5));
                    Console.Write("Opção: ");
                    op = Console.ReadLine();
                    if (op != "0" && op != "1" && op != "2" && op != "3" && op != "4")
                    {
                        Console.WriteLine("Opção inválida!");
                        Thread.Sleep(2000);
                    }
                    //Sai do método
                    else if (op.Contains("0"))
                        return;
                    //Volta no Cadastro Anterior
                    else if (op.Contains("2"))
                        if (i == 0)
                            i = 0;
                        else
                            i--;
                    //Vai para o fim da lista
                    else if (op.Contains("3"))
                        i = aeronaves.Count - 1;
                    //Volta para o inicio da lista
                    else if (op.Contains("4"))
                        i = 0;
                    //Vai para o próximo da lista
                } while (op != "1");
            }
        }
        public void AlteraDadoAeronave()
        {
            string inscricao;
            string caminho = Caminho;
            Console.WriteLine(">>> ALTERAR DADOS DE AERONAVE <<<\nPara sair digite 's'.\n");
            Console.Write("Digite a inscrição da aeronave: ");
            inscricao = Console.ReadLine().ToUpper().Trim().Replace("-", "");
            if (inscricao == "s")
                return;
            if (!VerificaAeronave(Caminho, inscricao))
            {
                Console.WriteLine("Aeronave não encontrada!!");
                Thread.Sleep(3000);
                return;
            }
            string[] lines = File.ReadAllLines(Caminho);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(inscricao))
                {
                    string num;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine(">>> ALTERAR DADOS DE AERONAVE <<<");
                        Console.Write("Para alterar digite:\n\n[1] Capacidade\n[2] Situação do Cadastro\n[0] Sair\nOpção: ");
                        num = Console.ReadLine();
                        if (num != "1" && num != "2" && num != "0")
                        {
                            Console.WriteLine("Opção inválida!");
                            Thread.Sleep(3000);
                        }
                    } while (num != "1" && num != "2" && num != "0");
                    if (num.Contains("0"))
                        return;
                    switch (num)
                    {
                        case "1":
                            if (!CadastraQtdPassageiros())
                                return;
                            lines[i] = lines[i].Replace(lines[i].Substring(5, Capacidade.Length), Capacidade);
                            break;
                        case "2":
                            if (!AlteraSituacao())
                                return;
                            lines[i] = lines[i].Replace(lines[i].Substring(27, Situacao.Length), Situacao);
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
            return $"{Inscricao}{Capacidade}{AssentosOcupados}{UltimaVenda}{DataCadastro}{Situacao}";
        }
    }
}