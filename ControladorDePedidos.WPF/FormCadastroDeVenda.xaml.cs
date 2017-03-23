using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
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

namespace ControladorDePedidos.WPF
{
    /// <summary>
    /// Interaction logic for FormCadastroDeVenda.xaml
    /// </summary>
    public partial class FormCadastroDeVenda : Window
    {

        RepositorioVenda repositorio;
        RepositorioItemDaVenda repositorioItemDaVenda;
        RepositorioProduto repositorioProduto;

        public int Codigo { get; set; }

        public Venda Venda { get; set; }
       

        public FormCadastroDeVenda()
        {
            InitializeComponent();

            Inicializeoperacoes();

            var venda = new Venda
            {
                DataDeCadastro = DateTime.Now,
                Status = eStatusDaVenda.NOVA
            };
            
            repositorio.Adicione(venda);

            lstProdutos.DataContext = venda.ItensDaVenda;

            Codigo = venda.Codigo;
            Venda = venda;
            
        }
        
        public FormCadastroDeVenda(Venda venda)
        {

            InitializeComponent();
            Inicializeoperacoes();

            
            lstProdutos.DataContext = venda.ItensDaVenda;
            Codigo = venda.Codigo;

            Venda = venda;

            if (Venda.Cliente != null)
            {
                txtCliente.Text = Venda.Cliente.Nome;
            }
        }


       
       


        private void Inicializeoperacoes()
        {
            repositorio = new RepositorioVenda();
            repositorioItemDaVenda = new RepositorioItemDaVenda();
            repositorioProduto = new RepositorioProduto();
        }

        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {
            if (Venda.Status != eStatusDaVenda.NOVA)
            {
                MessageBox.Show("Não é possivel Alterar o cliente de uma venda efetivada");
                return;
            }

            var buscaDeCliente = new FormBuscaDeCliente();
            buscaDeCliente.ShowDialog();
            Venda.Cliente = buscaDeCliente.ClienteSelecionado;
            if (Venda.Cliente != null)
            {
                txtCliente.Text = Venda.Cliente.Nome;
            }
            repositorio.Atualize(Venda);

        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if(Venda.Status != eStatusDaVenda.NOVA)
            {
                MessageBox.Show("Não é possivel excluir produtos de uma venda efetivada");
                return;
            }

            if (lstProdutos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }

            var itemDaVenda = (ItemDaVenda)lstProdutos.SelectedItem;
            repositorioItemDaVenda.Excluir(itemDaVenda);
            lstProdutos.DataContext = repositorioItemDaVenda.Liste(Codigo);                                              

        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {

            if (Venda.Status != eStatusDaVenda.NOVA)
            {
                MessageBox.Show("Não é possivel excluir produtos de uma venda efetivada");
                return;
            }

            repositorioItemDaVenda = new RepositorioItemDaVenda();
            var formulario = new FormBuscaDeProduto();
            formulario.ShowDialog();

            if (formulario.produtoSelecionado != null)
            {
                var itemDaVenda = new ItemDaVenda
                {
                    Venda = new Venda { Codigo = this.Codigo},
                    Produto = formulario.produtoSelecionado,
                    Quantidade = formulario.Quantidade,
                    Valor = formulario.produtoSelecionado.ValorDeVenda

                };
                repositorioItemDaVenda.Adicione(itemDaVenda);  //Adicionar os produtos no banco de dados 

                lstProdutos.DataContext = repositorioItemDaVenda.Liste(Codigo);                                                //recarregar a lista de produtos na tela
            }
        }

     

     
    }
}
