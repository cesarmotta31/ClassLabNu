using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ClassLabNu
{
    public class Cliente
    {
        // atributos
        private int id;
        private string nome;
        private string cpf;
        private string email;
        private DateTime dataCad;
        private bool ativo;

        // propriedades
        public int Id { get { return id; } set { id = value; } }
        public string Nome { get { return nome; } set { nome = value; } }   
        public string Cpf { get { return cpf; }set { cpf = value; }  }
        public string Email { get { return email; }set { email = value; } }
        public DateTime DataCad { get { return dataCad; }set { dataCad = value; } }
        public bool Ativo { get { return ativo; } set { ativo = value; } }

        // construtores
        public Cliente()
        {
        
        }

        public Cliente(string nome, string cpf, string email)
        {
            Nome = this.nome;
            Cpf = cpf;
            Email = email;
            // DataCad = DateTime.Now;
            // ativo = true;
        }

        public Cliente(int id, string nome, string cpf, string email, DateTime dataCad, bool ativo)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
            DataCad = dataCad;
            Ativo = ativo;
        }

        

        // métodos da classe
        public void Inserir(Cliente cliente) 
        { 
            
        }
        public bool Alterar(int _id, string _id, string _nome, string _email)
        {
            bool resultado = false;

            try 
            {
                var cmd = banco.abrir();
                cmd.CommandType = CommandType.StoredProcedure;
                // recebe procedure
                cmd.CommandText = "sp_cliente_alterar";
                // adiciona parametros da procedure - está no SQL
                // cmd.Parameters.Add("_id", MySqlDbType.Int32).Value= _id; // linha em modo tecnico
                //cmd.Parameters.AddWithValue("_id", _id); // tabela simples, sql trabalhará
                cmd.Parameters.AddWithValue("_id",_id);
                cmd.Parameters.AddWithValue("_nome", _nome);
                cmd.Parameters.AddWithValue("_email", _email);
                cmd.ExecuteNonQuery();
                resultado = true;
                cmd.Connection.Close();
            }

            catch (Exception)
            {


            }

            return resultado;
        }
        public static Cliente ConsultarPorId(int _id) 
        { 
            Cliente cliente = new Cliente();
            var cmd = banco.abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "select * from clientes where idcli =" + _id;
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cliente.id = Convert.ToInt32(dr["id"]);
                cliente.Nome = dr ["nome"].ToString();
                cliente.cpf = dr.GetString(2); // forma mais "direta"   -- obrigatório ter conhecimento do dicionario de dados]
                cliente.email = dr.GetString(3);
                cliente.dataCad = dr.GetDateTime(4);
                cliente.ativo = dr.GetBoolean(5);



            }
            return cliente;
        }
        public static Cliente ConsultarPorCpf(string _cpf)
        {
            Cliente cliente = new Cliente();
            var cmd = banco.abrir();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "select * from clientes where cpf =" + _cpf;
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cliente.id = Convert.ToInt32(dr["id"]);
                cliente.Nome = dr["nome"].ToString();
                cliente.cpf = dr.GetString(2); // forma mais "direta"   -- obrigatório ter conhecimento do dicionario de dados]
                cliente.email = dr.GetString(3);
                cliente.dataCad = dr.GetDateTime(4);
                cliente.ativo = dr.GetBoolean(5);



            }
            return cliente;
        }
        public static List<Cliente> Listar()
        {
            List<Cliente> clientes = new List<Cliente>();
            var cmd = banco.abrir();
            cmd.CommandType= CommandType.Text;
            cmd.CommandText="select * from clientes where ativo = 1 order by nome";
            var dr = cmd.ExecuteReader();
            // cenas dos próximos episódios...
            return clientes;
        }

    }

    public void  Desativar (int _id)
    {
        var cmd= banco.abrir();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "update clientes set ativo = 0 while idcli = " + _id;
        cmd.ExecuteReader();
        cmd.Connection.Close(); 
    }
}
