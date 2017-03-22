using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System.Windows;
using System.Windows.Input;

namespace ControladorDePedidos.WPF
{

    public partial class FormBuscaDeProduto : Window
    {
        RepositorioProduto repositorio;
        public Produto produtoSelecionado { get; set; }

        public int Quantidade { get; set; }

        public FormBuscaDeProduto()
        {
            InitializeComponent();

            repositorio = new RepositorioProduto();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var listaTudo = repositorio.Liste();

            lstProdutos.DataContext = listaTudo;
        }

        private void txtCodigo_KeyUP(object sender, KeyEventArgs e)
        {
           var listaDeProdutos =  repositorio.Buscar(txtCodigo.Text);


            lstProdutos.DataContext = listaDeProdutos;
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (lstProdutos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item na lsita");
                return;
            }
            if (txtQuantidade.Text == "")
            {
                MessageBox.Show("Informe a quantidade");
                return;
            }
            int quantidade;
            if (int.TryParse(txtQuantidade.Text, out quantidade))
            {
                Quantidade = quantidade;
            }
            else
            {
                MessageBox.Show("Informe um valor numerico no campo quantidade");
                return;
            }

            produtoSelecionado = (Produto)lstProdutos.SelectedItem;
           
            this.Close();
        }
    }
}
