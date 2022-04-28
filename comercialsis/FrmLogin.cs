using System;
using System.Windows.Forms;
using ClassLabNu;

namespace comercialsis
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

           

        }

        private void Cadastrar_Click(object sender, EventArgs e)
        {

        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void Entrar_Click(object sender, EventArgs e)
        {
            if (Usuario.EfetuarLogin(txtEmail.Text, txtsenha.Text))
            {
                this.Close();
            }
            else
            {
                lblMensagem.Text = txtsenha.Text = "Email ou senha incorretos!!";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

    private void FrmLogin_Load(object sender, EventArgs e)
    {


    }
        
    }
}
