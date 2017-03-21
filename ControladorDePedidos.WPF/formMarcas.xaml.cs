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
    public partial class formMarcas : Window
    {
        RepositorioMarca repositorio;

        public formMarcas()
        {
            repositorio = new RepositorioMarca();

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();
        }

        private void CarregueElementosDoBancoDeDados()
        {

            lstMarcas.DataContext = repositorio.Liste();
            
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var formCadastroMarcas = new formCadastroDeMarca();
            formCadastroMarcas.ShowDialog();
            CarregueElementosDoBancoDeDados();

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (lstMarcas.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
              
            }
            else
            {
                var itemSelecionado = (Marca)lstMarcas.SelectedItem;
                var formCadastroMarcas = new formCadastroDeMarca(itemSelecionado);
                formCadastroMarcas.ShowDialog();
                CarregueElementosDoBancoDeDados();

            }
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            

            if (lstMarcas.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma marca.");

                return;
            }

           
                var itemSelecionado = (Marca)lstMarcas.SelectedItem;
                repositorio.Excluir(itemSelecionado);
                CarregueElementosDoBancoDeDados();
            
           
        }

       

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();

        }
    }
}
