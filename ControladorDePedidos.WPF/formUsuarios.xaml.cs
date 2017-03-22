using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System.Windows;

namespace ControladorDePedidos.WPF
{
    /// <summary>
    /// Interaction logic for FormUsuario.xaml
    /// </summary>
    public partial class formUsuarios : Window
    {
        RepositorioUsuario repositorio;

        public formUsuarios()
        {
            repositorio = new RepositorioUsuario();

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();
        }

        private void CarregueElementosDoBancoDeDados()
        {

            lstUsuarios.DataContext = repositorio.Liste();

        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var formCadastroUsuarios = new FormCadastroDeUsuario();
            formCadastroUsuarios.ShowDialog();
            CarregueElementosDoBancoDeDados();

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (lstUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Selecione um Usuario");

            }
            else
            {
                var itemSelecionado = (Usuario)lstUsuarios.SelectedItem;
                var formCadastroUsuarios = new FormCadastroDeUsuario(itemSelecionado);
                formCadastroUsuarios.ShowDialog();
                CarregueElementosDoBancoDeDados();

            }
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {


            if (lstUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma Usuario.");

                return;
            }

            try
            {
                var itemSelecionado = (Usuario)lstUsuarios.SelectedItem;
                repositorio.Excluir(itemSelecionado);
                CarregueElementosDoBancoDeDados();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {


                MessageBox.Show("Usuario em uso no produto.");

            }





        }



        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();

        }
    }
}
