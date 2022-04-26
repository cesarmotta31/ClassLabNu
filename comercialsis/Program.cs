using System;
using System.Windows.Forms;
public class ClassLabNu
{

}

namespace comercialsis

{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        /// insert clientes (nome, cpf, email, datacad, ativo) values('Zé do Pão','5416465564','paozinho@senac.corp', defacult, default);
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormPrincipal());
        }
    }
}
