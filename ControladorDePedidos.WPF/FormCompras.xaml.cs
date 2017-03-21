using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
using static ControladorDePedidos.WPF.Utilitarios;

namespace ControladorDePedidos.WPF
{

    public partial class FormCompras : Window
    {
        RepositorioCompra repositorio;

        public FormCompras()
        {

            repositorio = new RepositorioCompra();
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();

        }
        private void CarregueElementosDoBancoDeDados()
        {

            lstCompras.DataContext = repositorio.Liste();

        }




        private void btnMarcas_Click(object sender, RoutedEventArgs e)
        {
            var formarca = new formMarcas();
            formarca.Show();
        }


        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var formCadastroDeCompra = new FormCadastroDeCompra();
            formCadastroDeCompra.ShowDialog();
            CarregueElementosDoBancoDeDados();


        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (lstCompras.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }
            var compra = (Compra)lstCompras.SelectedItem;

            var formCadastroDeCompra = new FormCadastroDeCompra(compra);
            formCadastroDeCompra.ShowDialog();
            CarregueElementosDoBancoDeDados();
        }



        private void btnAtualziar_Click(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {

            if (lstCompras.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }

            var compra = (Compra)lstCompras.SelectedItem;
            repositorio.Excluir(compra);
            CarregueElementosDoBancoDeDados();

        }

        private void btnComprar_Click(object sender, RoutedEventArgs e)
        {
            /*
             1. Listar item da compra para enviar ao fornecedor
             2.enviar email ao fornecedor com a lista de compra
             3 atualizar o banco de dados informando que a compra foi realizada
             */
            var compra = (Compra)lstCompras.SelectedItem;
            //1
            if (lstCompras.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }

            if (compra.Status != eStatusDaCompra.NOVA)
            {
                MessageBox.Show("Essa compra ja foi efetivada");
                return;
            }

            if (compra.ItensDaCompra.Count == 0)
            {
                MessageBox.Show("Nenhum item a ser comprado nessa solicitação");
                return;
            }

            var itensDaCompra = ObterItendaCompra(compra);

            var listaAgrupada = itensDaCompra.GroupBy(x => x.Produto.Fornecedor).ToList();


            foreach (var item in listaAgrupada)
            {
                var fornecedor = item.Key;
                var itens = item.ToList();

                string listaString = "";

                foreach (var itemDaCompra in itens)
                {
                    listaString += $"{itemDaCompra.Quantidade} - {itemDaCompra.Produto.Nome} {itemDaCompra.Produto.Marca.nome} <br>";
                }
                EnviarEmail(fornecedor.Email, "Solicitação de compra",listaString);

            }

            //2 enviar email


            //3
            compra.Status = eStatusDaCompra.EFETIVADA;
            compra.DataDaEfetivacao = DateTime.Now;

            repositorio.Atualize(compra);
            CarregueElementosDoBancoDeDados();



        }


        private static List<ItemDaCompra> ObterItendaCompra(Compra compra)
        {
            var repositorioItemdaCompra = new RepositorioItemDaCompra();
            var itensDaCompra = repositorioItemdaCompra.Liste(compra.Codigo);
            return itensDaCompra;
        }

        private void btnCompraRecebida_Click(object sender, RoutedEventArgs e)
        {
            //Adicionar no estoque e 
            var compra = (Compra)lstCompras.SelectedItem;

            if (lstCompras.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }

            if (compra.Status != eStatusDaCompra.EFETIVADA)
            {
                MessageBox.Show("Essa Compra deve estar em Efetivada");
                return;
            }

            //Atualizar o estoque
            var itenDaCompra = ObterItendaCompra(compra);
            var repositorioDeProduto = new RepositorioProduto();
            foreach (var item in itenDaCompra)
            {
                var produtoDaCompra = item.Produto;
                var produtoDoBanco = repositorioDeProduto.Buscar(produtoDaCompra.Codigo);
                produtoDoBanco.QuantidadeEmEstoque += item.Quantidade;
                repositorioDeProduto.Atualize(produtoDoBanco);
            }

            //atualizar o banco de dados

            compra.Status = eStatusDaCompra.RECEBIDA;
            compra.DataDoRecebimento = DateTime.Now;
            repositorio.Atualize(compra);
            CarregueElementosDoBancoDeDados();







        }

        private void btnRelatorioDeCompra_Click(object sender, RoutedEventArgs e)
        {
            if (lstCompras.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }

            var compra = (Compra)lstCompras.SelectedItem;
            var formRelatorioDeCompra = new FormRelatorioCompra(compra);
            formRelatorioDeCompra.ShowDialog();

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
            lstCompras.DataContext = repositorio.Buscar(dtpFiltroDe.SelectedDate, dtpFiltroAte.SelectedDate);
        }

        private void dtpFiltroAte_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            dtpFiltroAte.SelectedDate = DateTime.Now;
        }
    }
}
