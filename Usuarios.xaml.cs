using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Biblioteca
{
    /// <summary>
    /// Lógica interna para Usuarios.xaml
    /// </summary>
    public partial class Usuarios : Window
    {
        String Operacao;
        public static Usuario CurrentUser { get; set; }
        public Usuarios()
        {
            InitializeComponent();
        }

        private void BtnInserir_Click(object sender, RoutedEventArgs e)
        {
            Operacao = "Inserir";
            AlterarBotoes(2);
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            using (bibliotecaEntities ctx = new bibliotecaEntities())
            {
                Usuario usuario = ctx.Usuarios.Find(((Usuario)DgUsuarios.Items[DgUsuarios.SelectedIndex]).Id);
                if (usuario != null)
                {
                    ctx.Usuarios.Remove(usuario);
                    ctx.SaveChanges();
                }

            }

            ListarUsuarios();
            AlterarBotoes(1);
            LimpaCampos();
        }

        private void BtnLocalizar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtUsuario.Text))
            {
                try
                {
                    using (bibliotecaEntities ctx = new bibliotecaEntities())
                    {
                        var consulta = from c in ctx.Usuarios
                                       where c.Usuario1.Contains(TxtUsuario.Text)
                                       select c;
                        DgUsuarios.ItemsSource = consulta.ToList();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            if (!string.IsNullOrEmpty(TxtNome.Text))
            {
                try
                {
                    using (bibliotecaEntities ctx = new bibliotecaEntities())
                    {
                        var consulta = from c in ctx.Usuarios
                                       where c.Nome.Contains(TxtNome.Text)
                                       select c;
                        DgUsuarios.ItemsSource = consulta.ToList();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            Operacao = "Alterar";
            AlterarBotoes(2);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListarUsuarios();
            AlterarBotoes(1);
        }

        private void ListarUsuarios()
        {
            using (bibliotecaEntities ctx = new bibliotecaEntities())
            {
                var consulta = ctx.Usuarios;
                DgUsuarios.ItemsSource = consulta.ToList();
            }
        }

        private void AlterarBotoes(int opcao)
        {
            BtnAlterar.IsEnabled = false;
            BtnInserir.IsEnabled = false;
            BtnCancelar.IsEnabled = false;
            BtnExcluir.IsEnabled = false;
            BtnLocalizar.IsEnabled = false;
            BtnSalvar.IsEnabled = false;

            if (opcao == 1)
            {
                //Inicial
                BtnInserir.IsEnabled = true;
                BtnLocalizar.IsEnabled = true;
            }
            else if (opcao == 2)
            {
                //Inserindo registro
                BtnCancelar.IsEnabled=true;
                BtnSalvar.IsEnabled=true;
            }
            else if(opcao == 3)
            {
                //Alterando/excluindo registro com item selecionado existente
                BtnAlterar.IsEnabled =true;
                BtnExcluir.IsEnabled=true;
            }

        }

        private void LimpaCampos()
        {
            TxtNome.Clear();
            TxtSenha.Clear();
            TxtUsuario.Clear();
            TxtConfirmarSenha.Clear();             
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {

            if(Operacao == "Inserir")
            {
                if (TxtSenha.Password == TxtConfirmarSenha.Password)
                {
                    Usuario usuario = new Usuario();
                    usuario.Nome = TxtNome.Text;
                    usuario.Senha = TxtSenha.Password;
                    usuario.Usuario1 = TxtUsuario.Text;
                    using (bibliotecaEntities ctx = new bibliotecaEntities())
                    {
                        ctx.Usuarios.Add(usuario);
                        ctx.SaveChanges();
                    }
                    ListarUsuarios();
                    AlterarBotoes(1);
                    LimpaCampos();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Usuário ou senha incorretos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else if (Operacao == "Alterar")
            {
                using (bibliotecaEntities ctx = new bibliotecaEntities())
                {
                    // pega o Id do usuário e utiliza para buscar o usuario a ser alterado
                    Usuario usuario = ctx.Usuarios.Find(((Usuario)DgUsuarios.Items[DgUsuarios.SelectedIndex]).Id);

                    if (usuario != null)
                    {
                        usuario.Nome = TxtNome.Text;
                        usuario.Senha = TxtSenha.Password;
                        usuario.Usuario1 = TxtUsuario.Text;
                        ctx.SaveChanges();
                    }
                    ListarUsuarios();
                    AlterarBotoes(1);
                    LimpaCampos();
                }
            }

        }

        private void DgUsuarios_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DgUsuarios.SelectedIndex >= 0)
            {
                var usuario = (Usuario)DgUsuarios.Items[DgUsuarios.SelectedIndex];               
                TxtNome.Text = usuario.Nome;
                TxtUsuario.Text = usuario.Usuario1;
                TxtSenha.Password = usuario.Senha;
                TxtConfirmarSenha.Password = usuario.Senha;
            }
            AlterarBotoes(3);
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpaCampos();
            AlterarBotoes(1);
        }
    }
}
