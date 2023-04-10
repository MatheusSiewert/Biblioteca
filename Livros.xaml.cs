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
    /// Lógica interna para Livros.xaml
    /// </summary>
    public partial class Livros : Window
    {
        String Operacao;
        public Livros()
        {
            InitializeComponent();
            ListarLivros();
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
                Livro livro = ctx.Livros.Find(((Livro)DgLivros.Items[DgLivros.SelectedIndex]).Id);
                if (livro != null)
                {
                    ctx.Livros.Remove(livro);
                    ctx.SaveChanges();
                }

            }

            ListarLivros();
            AlterarBotoes(1);
            LimpaCampos();
        }

        private void BtnLocalizar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtAutor.Text))
            {
                try
                {
                    using (bibliotecaEntities ctx = new bibliotecaEntities())
                    {
                        var consulta = from c in ctx.Livros
                                       where c.Autor.Contains(TxtAutor.Text)
                                       select c;
                        DgLivros.ItemsSource = consulta.ToList();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            if (!string.IsNullOrEmpty(TxtTitulo.Text))
            {
                try
                {
                    using (bibliotecaEntities ctx = new bibliotecaEntities())
                    {
                        var consulta = from c in ctx.Livros
                                       where c.Nome.Contains(TxtTitulo.Text)
                                       select c;
                        DgLivros.ItemsSource = consulta.ToList();
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
            ListarLivros();
            AlterarBotoes(1);
        }

        private void ListarLivros()
        {
            using (bibliotecaEntities ctx = new bibliotecaEntities())
            {
                var consulta = from c in ctx.Livros
                               where c.IdUsuario == null
                               select c;
                DgLivros.ItemsSource = consulta.ToList();

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
            BtnReservar.IsEnabled = false;

            if (opcao == 1)
            {
                //Inicial
                BtnInserir.IsEnabled = true;
                BtnLocalizar.IsEnabled = true;
            }
            else if (opcao == 2)
            {
                //Inserindo registro
                BtnCancelar.IsEnabled = true;
                BtnSalvar.IsEnabled = true;
            }
            else if (opcao == 3)
            {
                //Alterando/excluindo registro com item selecionado existente
                BtnAlterar.IsEnabled = true;
                BtnExcluir.IsEnabled = true;
                BtnReservar.IsEnabled = true;
            }

        }

        private void LimpaCampos()
        {
            TxtTitulo.Clear();
            TxtAutor.Clear();
            TxtSinopse.Clear();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {

            if (Operacao == "Inserir")
            {
                Livro livro = new Livro();
                if (!string.IsNullOrEmpty(TxtTitulo.Text) &&
                    !string.IsNullOrEmpty(TxtAutor.Text) &&
                    DtpData.SelectedDate.HasValue &&
                    !string.IsNullOrEmpty(TxtSinopse.Text))
                {
                    livro.Nome = TxtTitulo.Text;
                    livro.Autor = TxtAutor.Text;
                    livro.DataLancamento = DtpData.SelectedDate.Value;
                    livro.Sinopse = TxtSinopse.Text;
                }
                else
                {
                    System.Windows.MessageBox.Show("Por favor, preencha todos os campos.");
                }
                using (bibliotecaEntities ctx = new bibliotecaEntities())
                {
                    ctx.Livros.Add(livro);
                    ctx.SaveChanges();
                }
            }
            else if (Operacao == "Alterar")
            {
                using (bibliotecaEntities ctx = new bibliotecaEntities())
                {
                    // pega o Id do usuário e utiliza para buscar o livro a ser alterado
                    Livro livro = ctx.Livros.Find(((Livro)DgLivros.Items[DgLivros.SelectedIndex]).Id);

                    if (livro != null)
                    {
                        livro.Nome = TxtTitulo.Text;
                        livro.Autor = TxtAutor.Text;
                        livro.Sinopse = TxtSinopse.Text;
                        livro.DataLancamento = DtpData.SelectedDate.Value;
                        ctx.SaveChanges();
                    }

                }
            }

            AlterarBotoes(1);
            LimpaCampos();
            ListarLivros();
        }

        private void DgLivros_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DgLivros.SelectedIndex >= 0)
            {
                var livro = (Livro)DgLivros.Items[DgLivros.SelectedIndex];
                TxtTitulo.Text = livro.Nome;
                TxtAutor.Text = livro.Autor;
                TxtSinopse.Text = livro.Sinopse;
                DtpData.SelectedDate = livro.DataLancamento;
            }
            AlterarBotoes(3);
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpaCampos();
            AlterarBotoes(1);
        }

        private void BtnReservar_Click(object sender, RoutedEventArgs e)
        {
            using (bibliotecaEntities ctx = new bibliotecaEntities())
            {
                var reserva = new Reserva();
                reserva.DataReserva = DateTime.Now;
                reserva.Usuario = ctx.Usuarios.Find(Usuarios.CurrentUser.Id);
                reserva.IdUsuario = Usuarios.CurrentUser.Id;
                reserva.IdLivro = ((Livro)DgLivros.Items[DgLivros.SelectedIndex]).Id;
                ctx.Reservas.Add(reserva);
                ctx.SaveChanges();

                var livro = ctx.Livros.Find(((Livro)DgLivros.Items[DgLivros.SelectedIndex]).Id);
                livro.IdUsuario = Usuarios.CurrentUser.Id;
                ctx.SaveChanges();
            }

            LimpaCampos();
            AlterarBotoes(1);
            ListarLivros();
        }
    }
}
