using ControladorDePedidos.Model;
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
    /// Interaction logic for formMarcas.xaml
    /// </summary>
    public partial class formMarcas : Window
    {
        public formMarcas()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var marcas = new List<Marca>();

            var marca1 = new Marca
            {
                Codigo = 1,
                nome = "CCE"

            };
            var marca2 = new Marca
            {
                Codigo = 2,
                nome = "Dell"
            };
            marcas.Add(marca1);
            marcas.Add(marca2);
            lstMarcas.DataContext = marcas;
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var formCadastroMarcas = new formCadastroDeMarca();
            formCadastroMarcas.Show();
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
                formCadastroMarcas.Show();
            }
        }
    }
}
