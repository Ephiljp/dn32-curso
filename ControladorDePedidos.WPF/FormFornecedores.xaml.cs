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
    public partial class FormFornecedores : Window
    {
        RepositorioFornecedor repositorio;

        public FormFornecedores()
        {
            repositorio = new RepositorioFornecedor();

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();
        }

        private void CarregueElementosDoBancoDeDados()
        {

            lstFornecedores.DataContext = repositorio.Liste();
            
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var FormCadastroFornecedores = new FormCadastroDeFornecedor();
            FormCadastroFornecedores.ShowDialog();
            CarregueElementosDoBancoDeDados();

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (lstFornecedores.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
              
            }
            else
            {
                var itemSelecionado = (Fornecedor)lstFornecedores.SelectedItem;
                var FormCadastroFornecedores = new FormCadastroDeFornecedor(itemSelecionado);
                FormCadastroFornecedores.ShowDialog();
                CarregueElementosDoBancoDeDados();

            }
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            

            if (lstFornecedores.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma marca.");

                return;
            }

            try
            {
                var itemSelecionado = (Fornecedor)lstFornecedores.SelectedItem;
                repositorio.Excluir(itemSelecionado);
                CarregueElementosDoBancoDeDados();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                

                MessageBox.Show("Fornecedor em uso no produto.");

            }
            
               
            
            

        }

       

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();

        }
    }
}
