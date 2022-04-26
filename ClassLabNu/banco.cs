using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace ClassLabNu
{
    public static class Banco
    {
        //propriedade de conexão  -- string

        public static string StrConexao { get; set; }   

        // Metodo abrir conexão


        public static MySqlCommand abrir ()
        {
            MySqlCommand cmd = new MySqlCommand ();
            StrConexao = @"server=127.0.0.1; database=Procedures_comercialdb0191;user id=root;password=;port=3306";

            MySqlConnection cn = new MySqlConnection (StrConexao);
            try
            {
                cn.Open();
            }
            catch (Exception)
            {
                throw;
            }

            cmd.Connection = cn;
            return cmd;
        }



    }
}
