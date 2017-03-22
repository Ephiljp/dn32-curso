using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System.Windows;

namespace ControladorDePedidos.WPF
{

    public partial class formProdutos : Window
    {
        RepositorioProduto repositorio;

        public formProdutos()
        {
            
            repositorio = new RepositorioProduto();
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();

        }
        private void CarregueElementosDoBancoDeDados()
        {

            lstProdutos.DataContext = repositorio.Liste();

        }


       

        private void btnMarcas_Click(object sender, RoutedEventArgs e)
        {
            var formarca = new formMarcas();
            formarca.Show();
        }

      
        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var formCadastroDeProduto = new FormCadastroDeProduto();
            formCadastroDeProduto.ShowDialog();
            CarregueElementosDoBancoDeDados();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (lstProdutos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }

            var produto = (Produto)lstProdutos.SelectedItem;
            var formCadastroDeProduto = new FormCadastroDeProduto(produto);
            formCadastroDeProduto.ShowDialog();
            CarregueElementosDoBancoDeDados();
        }

       

        private void btnAtualziar_Click(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {

            if (lstProdutos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }
           
            var produto = (Produto)lstProdutos.SelectedItem;
            repositorio.Excluir(produto);
            CarregueElementosDoBancoDeDados();

        }
    }
}
