using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comercialsis
{
    public partial class Form1 : Form
     {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Cliente c  = new Cliente(txtNome.Text,txtCpf.Text,txtEmail.Text);
            c.Inserir();
            txtId.Text = c.Id.ToString();    
        }
    }
}