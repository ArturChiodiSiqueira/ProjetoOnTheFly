using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoOnTheFly
{
    internal class ConexaoBanco
    {

        private static string Conexao = "Data Source=localhost;Initial Catalog=Aeroporto;User id=sa;Password=eXPERT.87;";

        private static SqlConnection Conexaosql = new SqlConnection(Conexao);
       

        public ConexaoBanco()
        {

        }
        public string Caminho()
        {
            return Conexao;
        }
        public void Insert(string query)
        {
            try
            {
                Conexaosql.Open();
                SqlCommand cmd = new SqlCommand(query,Conexaosql);
                cmd.ExecuteNonQuery();
                Conexaosql.Close();
               
            }
            catch (Exception ex)
            {

                Console.WriteLine(" Erro ao se comunicar com o banco\n" + ex.Message);
              

                Console.WriteLine("\nPressione ENTER para continuar");
                Console.ReadKey();
                Console.Clear();
                Conexaosql.Close();
            }
           
        }
        public bool Select(string query,int opc)
        {
            bool retorna = false;
            try
            {
                Conexaosql.Open();
                SqlCommand cmd = new SqlCommand(query, Conexaosql);
                cmd.ExecuteNonQuery();

                switch (opc)
                {
                    case 1:
                        using (SqlDataReader leitor = cmd.ExecuteReader())
                        {
                          
                            while (leitor.Read())
                            {
                                Console.WriteLine("\nCADASTRO ENCONTRADO COM SUCESSO!\n");

                                Console.Write(" CPF: {0}", leitor.GetString(0));
                                Console.Write("\n Nome: {0} ", leitor.GetString(1));
                                Console.Write("\n Data de Nascimento: {0} ", leitor.GetDateTime(2).ToString("dd/MM/yyyy"));
                                Console.Write("\n Sexo:{0} ", leitor.GetString(3));
                                Console.Write("\n Ultima compra: {0} ", leitor.GetDateTime(4).ToString("dd/MM/yyyy"));
                                Console.Write("\n Data de cadastro: {0} ", leitor.GetDateTime(5).ToString("dd/MM/yyyy"));
                                Console.Write("\n Situação: {0} ", leitor.GetString(6));

                                
                            }
                            Console.WriteLine("\nPressione Enter para continuar...");

                            retorna = true;
                            Console.ReadKey();
                            Console.Clear();
                        }
                       
                        break;

                        case 2:
                        using (SqlDataReader leitor = cmd.ExecuteReader())
                        {
                            

                            while (leitor.Read())
                            {
                                

                                Console.Write(" CPF: {0}", leitor.GetString(0));
                             

                            }
                            Console.WriteLine("\n\nPressione Enter para continuar...");

                            retorna = true;
                            Console.ReadKey();
                            Console.Clear();
                        } 

                        break;

                    case 0:
                        using (SqlDataReader leitor = cmd.ExecuteReader())
                        {


                            if (leitor.Read())
                            {
                                Console.WriteLine(" {0} ja existe em nosso banco de dados ", leitor.GetString(0));
                            }
                            Console.WriteLine("\n\nPressione Enter para continuar...");

                            retorna = true;
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                        default:
                        break;
                        
                       
                }
                cmd.ExecuteNonQuery();
                Conexaosql.Close();
                return retorna;

            }
            catch (Exception ex)
            {

                Console.WriteLine(" Erro ao se comunicar com o banco\n" + ex.Message);
                Conexaosql.Close();
               
                Console.WriteLine("\nPressione ENTER para continuar");
                Console.ReadKey();
                Console.Clear();
                return false;
            }
        }
        public void Update(string query)
        {
            try
            {
                Conexaosql.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.ExecuteNonQuery();
                Conexaosql.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(" Erro ao se comunicar com o banco\n" + ex.Message);
                Conexaosql.Close();

                Console.WriteLine("\nPressione ENTER para continuar");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void Delete(string query)
        {
            try
            {
                Conexaosql.Open();
                SqlCommand cmd = new SqlCommand(query, Conexaosql);
                cmd.ExecuteNonQuery();
                Conexaosql.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(" Erro ao se comunicar com o banco\n" + ex.Message);
                Conexaosql.Close();

                Console.WriteLine("\nPressione ENTER para continuar");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //public void Verifica()
        //{
        //    try
        //    {
        //        Conexaosql.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.ExecuteNonQuery();
        //        Conexaosql.Close();
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine(" Erro ao se comunicar com o banco\n"+ex.Message);
        //        Conexaosql.Close();

        //        Console.WriteLine("\nPressione ENTER para continuar");
        //        Console.ReadKey();
        //        Console.Clear();
        //    }
        //}
             

    }
}
