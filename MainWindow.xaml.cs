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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Biblioteca
{

    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        Livro livroSelecionado;
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            ListarUsuarios();
        }

        private void BtnLivros_Click(object sender, RoutedEventArgs e)
        {
            Livros livros = new Livros();
            livros.Owner = this;
            livros.ShowDialog();
        }

        private void BtnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.Owner = this;
            usuarios.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListarUsuarios();
        }
        private void ListarUsuarios()
        {
            try
            {
                using (bibliotecaEntities ctx = new bibliotecaEntities())
                {
                    var consulta = from c in ctx.Livros
                                   where c.IdUsuario == Usuarios.CurrentUser.Id
                                   select c;

                    DgLivrosUsuario.ItemsSource = consulta.ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void DgLivrosUsuario_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            livroSelecionado = (Livro)DgLivrosUsuario.Items[DgLivrosUsuario.SelectedIndex];
            // verifica se o livro está com o usuário
            if (livroSelecionado.IdUsuario > 0)
            {
                BtnDevolver.IsEnabled = true;
            }
            else
            {
                BtnDevolver.IsEnabled = false;
            }
        }

        private void BtnDevolver_Click(object sender, RoutedEventArgs e)
        {
            using (bibliotecaEntities ctx = new bibliotecaEntities())
            {
                Livro livro = ctx.Livros.Find(livroSelecionado.Id);

                if (livro != null)
                {
                    livro.IdUsuario = null;
                    ctx.SaveChanges();
                }

                var reserva = (from c in ctx.Reservas
                                where (c.IdLivro == livroSelecionado.Id) && (c.IdUsuario == livroSelecionado.IdUsuario) && (c.DataEntrega.Value == null)
                               select c).FirstOrDefault();

                if (reserva != null)
                {
                    reserva.DataEntrega = DateTime.Now;

                    ctx.SaveChanges();
                }
                var diferenca = reserva.DataReserva.Subtract(reserva.DataEntrega.Value);

                if (diferenca.TotalDays > 30)
                {
                    var diasAtraso = diferenca.TotalDays;
                    var multa = diasAtraso * 2;
                    Console.WriteLine("Você está com {0} dia(s) de atraso. Sua multa é de R$ {1:F2}.", diasAtraso, multa);
                }
            }
            ListarUsuarios();
        }

        private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            ListarUsuarios();
        }

    }
}
