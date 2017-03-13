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
    /// Interaction logic for FormCadastroDeProduto.xaml
    /// </summary>
    public partial class FormCadastroDeProduto : Window
    {
        RepositorioMarca repositorioMarca;

        RepositorioProduto repositorioProduto;

        public FormCadastroDeProduto()
        {
            repositorioMarca = new RepositorioMarca();
            repositorioProduto = new RepositorioProduto();
            InitializeComponent();
            this.DataContext = new Produto();

        }

        public FormCadastroDeProduto(Produto produto)
        {
            repositorioMarca = new RepositorioMarca();
            repositorioProduto = new RepositorioProduto();
            InitializeComponent();
            this.DataContext = produto;
            cmbMarcas.SelectedValue = produto.Marca.Codigo;
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var marcas = repositorioMarca.Liste();

            cmbMarcas.DataContext = marcas;

            

        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var produto = (Produto) this.DataContext;
            if (cmbMarcas.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma marca");
            }
            else
            {
                produto.Marca = (Marca)cmbMarcas.SelectedItem;
            }

            if (produto.Codigo == 0 )
            {
                repositorioProduto.Adicione(produto);              
                //Cadastro
            }
            else
            {
                repositorioProduto.Atualize(produto);
                //atualização
            }

            this.Close();
        }
    }
}
