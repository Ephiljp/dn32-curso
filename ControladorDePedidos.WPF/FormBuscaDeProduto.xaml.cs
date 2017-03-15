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
    
    public partial class FormBuscaDeProduto : Window
    {
        RepositorioProduto repositorio;
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
            this.Close();
        }
    }
}
