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

        }

        private void btnCompraRecebida_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
