using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Biblioteca
{
    /// <summary>
    /// Lógica interna para ControleLogin.xaml
    /// </summary>
    public partial class ControleLogin : Window
    {
        public ControleLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Verifica se os campos de usuário e senha não estão vazios
            if (string.IsNullOrEmpty(TxtUsuario.Text) || string.IsNullOrEmpty(TxtSenha.Password))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            try
            {
                using (bibliotecaEntities ctx = new bibliotecaEntities())
                {
                    // Obtém o usuário correspondente ao nome de usuário fornecido
                    var usuarios = from c in ctx.Usuarios
                                   where c.Usuario1.Contains(TxtUsuario.Text)
                                   select new { c.Senha, c.Id };

                    if (!usuarios.Any())
                    {
                        MessageBox.Show("Nome de usuário ou senha incorretos.");
                        return;
                    }

                    // Verifica se a senha fornecida corresponde à senha do usuário encontrado
                    foreach (var usuario in usuarios)
                    {
                        if (usuario.Senha == TxtSenha.Password)
                        {
                            // Define o usuário atual para ser usado posteriormente
                            Usuarios.CurrentUser = ctx.Usuarios.Find(usuario.Id);

                            MainWindow main = new MainWindow();
                            main.Owner = this;
                            main.ShowDialog();
                            return;
                        }
                    }

                    // Se nenhum usuário correspondente com senha correspondente for encontrado
                    MessageBox.Show("Nome de usuário ou senha incorretos.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.Owner = this;
            usuarios.ShowDialog();
        }
    }
}
