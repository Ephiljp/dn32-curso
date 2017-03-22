using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace ControladorDePedidos.WPF
{

    public partial class FormVendas : Window
    {
        RepositorioVenda repositorio;

        public FormVendas()
        {

            repositorio = new RepositorioVenda();
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();

        }
        private void CarregueElementosDoBancoDeDados()
        {

            lstVendas.DataContext = repositorio.Liste();


        }




        private void btnMarcas_Click(object sender, RoutedEventArgs e)
        {
            var formarca = new formMarcas();
            formarca.Show();
        }


        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var formCadastroDeVenda = new FormCadastroDeVenda();
            formCadastroDeVenda.ShowDialog();
            CarregueElementosDoBancoDeDados();


        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (lstVendas.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }
            var venda = (Venda)lstVendas.SelectedItem;

            var formCadastroDeVenda = new FormCadastroDeVenda(venda);
            formCadastroDeVenda.ShowDialog();
            CarregueElementosDoBancoDeDados();
        }



        private void btnAtualziar_Click(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {

            if (lstVendas.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }

            var venda = (Venda)lstVendas.SelectedItem;
            repositorio.Excluir(venda);
            CarregueElementosDoBancoDeDados();

        }

        private void btnVender_Click(object sender, RoutedEventArgs e)
        {
            /*
             1. Listar item da venda para enviar ao fornecedor
             2.enviar email ao fornecedor com a lista de venda
             3 atualizar o banco de dados informando que a venda foi realizada
             */
            var venda = (Venda)lstVendas.SelectedItem;
            //1
            if (lstVendas.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }

            if (venda.Status != eStatusDaVenda.NOVA)
            {
                MessageBox.Show("Essa venda ja foi efetivada");
                return;
            }

            if (venda.ItensDaVenda.Count == 0)
            {
                MessageBox.Show("Nenhum item a ser vendado nessa solicitação");
                return;
            }

            var itensDaVenda = ObterItendaVenda(venda);



            //3 atualizar o banco de dados informando que a venda foi realizada
            venda.Status = eStatusDaVenda.EFETIVADA;
            venda.DataDaEfetivacao = DateTime.Now;

            repositorio.Atualize(venda);
            CarregueElementosDoBancoDeDados();



        }

        private static List<ItemDaVenda> ObterItendaVenda(Venda venda)
        {
            var repositorioItemdaVenda = new RepositorioItemDaVenda();
            var itensDaVenda = repositorioItemdaVenda.Liste(venda.Codigo);
            return itensDaVenda;
        }

        private void btnVendaRecebida_Click(object sender, RoutedEventArgs e)
        {
            //Adicionar no estoque e 
            var venda = (Venda)lstVendas.SelectedItem;

            if (lstVendas.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }

            if (venda.Status != eStatusDaVenda.EFETIVADA)
            {
                MessageBox.Show("Essa Venda deve estar em Efetivada");
                return;
            }

            //Atualizar o estoque
            var itenDaVenda = ObterItendaVenda(venda);
            var repositorioDeProduto = new RepositorioProduto();
            foreach (var item in itenDaVenda)
            {
                var produtoDaVenda = item.Produto;
                var produtoDoBanco = repositorioDeProduto.Buscar(produtoDaVenda.Codigo);
                produtoDoBanco.QuantidadeEmEstoque += item.Quantidade;
                repositorioDeProduto.Atualize(produtoDoBanco);
            }

            //atualizar o banco de dados

            venda.Status = eStatusDaVenda.EFETIVADA;
            venda.DataDaEfetivacao = DateTime.Now;
            repositorio.Atualize(venda);
            CarregueElementosDoBancoDeDados();







        }

        private void btnRelatorioDeVenda_Click(object sender, RoutedEventArgs e)
        {
            if (lstVendas.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }

            var venda = (Venda)lstVendas.SelectedItem;
            var formRelatorioDeVenda = new FormRelatorioVenda(venda);
            formRelatorioDeVenda.ShowDialog();

        }



        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {

            if (dtpFiltroDe.Text == "" || dtpFiltroAte.Text == "")
            {
                MessageBox.Show("Selecione as datas");
                return;
            }
            if (dtpFiltroAte.SelectedDate < dtpFiltroDe.SelectedDate)
            {
                MessageBox.Show("Data Futura não pode ser menor");
                return;
            }
            lstVendas.DataContext = repositorio.Buscar(dtpFiltroDe.SelectedDate, dtpFiltroAte.SelectedDate);
        }

        private void dtpFiltroAte_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            dtpFiltroAte.SelectedDate = DateTime.Now;
        }

    }  
}
