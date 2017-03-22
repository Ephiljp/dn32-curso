using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System.Windows;

namespace ControladorDePedidos.WPF
{
    /// <summary>
    /// Interaction logic for FormClientes.xaml
    /// </summary>
    public partial class FormClientes : Window
    {
        RepositorioCliente repositorio;

        public FormClientes()
        {
            repositorio = new RepositorioCliente();

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();
        }

        private void CarregueElementosDoBancoDeDados()
        {

            lstClientes.DataContext = repositorio.Liste();

        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var formCadastroClientes = new FormCadastroDeCliente();
            formCadastroClientes.ShowDialog();
            CarregueElementosDoBancoDeDados();

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (lstClientes.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");

            }
            else
            {
                var itemSelecionado = (Cliente)lstClientes.SelectedItem;
                var formCadastroClientes = new FormCadastroDeCliente(itemSelecionado);
                formCadastroClientes.ShowDialog();
                CarregueElementosDoBancoDeDados();

            }
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {


            if (lstClientes.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma cliente.");

                return;
            }

            try
            {
                var itemSelecionado = (Cliente)lstClientes.SelectedItem;
                repositorio.Excluir(itemSelecionado);
                CarregueElementosDoBancoDeDados();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {


                MessageBox.Show("Cliente em uso no produto.");

            }





        }



        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();

        }
    }
}
