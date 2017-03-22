using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System;
using System.Windows;

namespace ControladorDePedidos.WPF
{
    /// <summary>
    /// Interaction logic for FormCadastroDeCompra.xaml
    /// </summary>
    public partial class FormCadastroDeCompra : Window
    {

        RepositorioCompra repositorio;
        RepositorioItemDaCompra repositorioItemDaCompra;
        RepositorioProduto repositorioProduto;

        public int Codigo { get; set; }

        public Compra Compra { get; set; }
       

        public FormCadastroDeCompra()
        {
            InitializeComponent();

            Inicializeoperacoes();

            var compra = new Compra
            {
                DataDeCadastro = DateTime.Now,
                Status = eStatusDaCompra.NOVA
            };
            
            repositorio.Adicione(compra);

            lstProdutos.DataContext = compra.ItensDaCompra;

            Codigo = compra.Codigo;
            Compra = compra;
            
        }
        
        public FormCadastroDeCompra(Compra compra)
        {

            InitializeComponent();
            Inicializeoperacoes();


            lstProdutos.DataContext = compra.ItensDaCompra;
            Codigo = compra.Codigo;

            Compra = compra;
        }


       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
         

        }
       

        private void btnObterRecomendacao_Click(object sender, RoutedEventArgs e)
        {
            var listaEstoqueBaixo =  repositorioProduto.ObetnhaProdutosComEstoqueBaixo();

            if (Compra.Status != eStatusDaCompra.NOVA)
            {
                MessageBox.Show("Não é possivel adicionar produtos a uma compra efetivada");
                return;
            }

            foreach (var produto in listaEstoqueBaixo)
            {
                var itemDaCompra = new ItemDaCompra
                {
                    Compra = new Compra { Codigo = this.Codigo },
                    Produto = produto,
                    Quantidade = produto.QuantidadeDesejavelEmEstoque - produto.QuantidadeEmEstoque,
                    Valor = produto.ValorDeCompra

                };
                repositorioItemDaCompra.Adicione(itemDaCompra);  
            }

            lstProdutos.DataContext = repositorioItemDaCompra.Liste(Codigo);                                           

            
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if(Compra.Status != eStatusDaCompra.NOVA)
            {
                MessageBox.Show("Não é possivel excluir produtos de uma compra efetivada");
                return;
            }

            if (lstProdutos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }

            var itemDaCompra = (ItemDaCompra)lstProdutos.SelectedItem;
            repositorioItemDaCompra.Excluir(itemDaCompra);
            lstProdutos.DataContext = repositorioItemDaCompra.Liste(Codigo);                                              

        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {

            if (Compra.Status != eStatusDaCompra.NOVA)
            {
                MessageBox.Show("Não é possivel excluir produtos de uma compra efetivada");
                return;
            }

            repositorioItemDaCompra = new RepositorioItemDaCompra();
            var formulario = new FormBuscaDeProduto();
            formulario.ShowDialog();

            if (formulario.produtoSelecionado != null)
            {
                var itemDaCompra = new ItemDaCompra
                {
                    Compra = new Compra { Codigo = this.Codigo},
                    Produto = formulario.produtoSelecionado,
                    Quantidade = formulario.Quantidade,
                    Valor = formulario.produtoSelecionado.ValorDeCompra

                };
                repositorioItemDaCompra.Adicione(itemDaCompra);  //Adicionar os produtos no banco de dados 

                lstProdutos.DataContext = repositorioItemDaCompra.Liste(Codigo);                                                //recarregar a lista de produtos na tela
            }
        }

        private void Inicializeoperacoes()
        {
            repositorio = new RepositorioCompra();
            repositorioItemDaCompra = new RepositorioItemDaCompra();
            repositorioProduto = new RepositorioProduto();
        }

        
      
    }
}
