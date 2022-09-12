﻿using System;
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
        public int Capacidade { get; set; }
        public int AssentosOcupados { get; set; }
        public string UltimaVenda { get; set; }
        public string DataCadastro { get; set; }
        public char Situacao { get; set; }

        string Caminho = $"C:\\Users\\artur\\source\\repos\\ProjetoOnTheFly\\ProjetoOnTheFly\\Dados\\Aeronave.dat";

        public Aeronave()
        {

        }

        public Aeronave(string inscricao, int capacidade, int assentosOcupados, string ultimaVenda, string dataCadastro, char situacao)
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

            CadastraIdAeronave();

            if (VerificaAeronave(Caminho, Inscricao))
            {
                Console.WriteLine("Esta Aeronave já está cadastrada!!");
                Thread.Sleep(3000);
                return;
            }

            do
            {
                Console.Write("Informe a capacidade de pessoas que a aeronave comporta: ");
                Capacidade = int.Parse(Console.ReadLine());
            } while (Capacidade < 0 || Capacidade > 999);

            AssentosOcupados = 0;

            UltimaVenda = DateTime.Now.ToString("ddMMyyyy");

            DataCadastro = DateTime.Now.ToString("ddMMyyyy");

            Situacao = 'A';
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
                if (line.Contains(inscricao))
                {
                    return true;
                }
            }
            return false;
        }

        public void CadastraIdAeronave()
        {
            do
            {
                Console.Write("Informe o código de identificação da aeronave seguindo o padrão definido pela ANAC (XX-XXX):");
                Inscricao = Console.ReadLine().ToUpper().Trim().Replace("-", "");
            } while (Inscricao.Length != 5);
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
                        Console.WriteLine($"Situação: Desativado");
                }
            }
        }

        public Aeronave BuscaAeronave(string? inscricao, int? capacidade, int? assentosOcupados, string? ultimaVenda, string? dataCadastro, char? situacao)
        {
            foreach (string line in File.ReadLines(Caminho))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                Aeronave aeronave = new Aeronave();
                aeronave.Inscricao = line.Substring(0, 5);
                aeronave.Capacidade = int.Parse(line.Substring(5, 3));
                aeronave.AssentosOcupados = int.Parse(line.Substring(8, 3));
                aeronave.UltimaVenda = DateTime.ParseExact(line.Substring(11, 8), "ddMMyyyy", null).ToString();
                aeronave.DataCadastro = DateTime.ParseExact(line.Substring(19, 8), "ddMMyyyy", null).ToString();
                aeronave.Situacao = char.Parse(line.Substring(27, 1));
                if (
                    (inscricao == null || aeronave.Inscricao == inscricao) &&
                    (capacidade == null || aeronave.Capacidade == capacidade) &&
                    (assentosOcupados == null || aeronave.AssentosOcupados == assentosOcupados) &&
                    (ultimaVenda == null || aeronave.UltimaVenda == ultimaVenda) &&
                    (dataCadastro == null || aeronave.DataCadastro == dataCadastro) &&
                    (situacao == null || aeronave.Situacao == situacao)
                    )
                {
                    return aeronave;
                }
            }
            return null;
        }

        public void AlteraDadoAeronave()
        {
            string caminho = Caminho;

            Console.Write("Informe o código de identificação da aeronave: ");
            string inscricao = Console.ReadLine().ToUpper().Trim().Replace("-", "");


            string[] lines = File.ReadAllLines(caminho);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(inscricao))
                {
                    string num;
                    do
                    {
                        Console.WriteLine("Para alterar digite:\n\n[1] Capacidade\n[2] Assentos Ocupados\n[3] Ultima Venda\n[4] Data de Cadastro\n[5] Situação do Cadastro");
                        num = Console.ReadLine();

                        if (num != "1" && num != "2" && num != "3" && num != "4" && num != "5")
                            Console.WriteLine("Opção inválida!");

                    } while (num != "1" && num != "2" && num != "3" && num != "4" && num != "5");

                    switch (num)
                    {
                        case "1":
                            do
                            {
                                Console.Write("Digite a caoacidade, 3 digitos: ");
                                Capacidade = int.Parse(Console.ReadLine());
                                if (Capacidade.ToString() == "0")
                                    return;
                                if (Capacidade.ToString().Length > 3)
                                {
                                    Console.WriteLine("informe um numero de 3 digitos");
                                    Thread.Sleep(2000);
                                }
                            } while (Capacidade.ToString().Length > 3);

                            for (int j = Capacidade.ToString().Length; j <= 3; j++)
                                Capacidade += 0;

                            lines[i] = lines[i].Replace(lines[i].Substring(11, Capacidade.ToString().Length), Capacidade.ToString());

                            Console.WriteLine("Capacidade alterada com sucesso!");

                            break;
                    }
                }
            }

            File.WriteAllLines(caminho, lines);
            Console.WriteLine("gravou");
            Console.ReadKey();
        }

        public override string ToString()
        {
            return string.Format("{0}{1:000}{2:000}{3:ddMMyyyy}{4:ddMMyyyy}{5}", Inscricao, Capacidade, AssentosOcupados, UltimaVenda, DataCadastro, Situacao);
        }
    }
}
