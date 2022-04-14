using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace ClassLabNu
{
    public static class banco
    {
        //propriedade de conexão  -- string

        public static string strConexao { get; set; }   

        // Metodo abrir conexão


        public static MySqlCommand abrir ()
        {
            MySqlCommand cmd = new MySqlCommand ();
            strConexao = @"server=127.0.0.1; database=comercialdb0191;user id=root;password=;port=3306";

            MySqlConnection cn = new MySqlConnection (strConexao);
            cn.Open ();
            cmd.Connection = cn;

            return cmd;
        }



    }
}
