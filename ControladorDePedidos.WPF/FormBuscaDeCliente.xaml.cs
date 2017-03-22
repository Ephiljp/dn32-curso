using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System.Windows;
using System.Windows.Input;

namespace ControladorDePedidos.WPF
{

    public partial class FormBuscaDeCliente : Window
    {
        RepositorioCliente repositorio;
        public Cliente ClienteSelecionado { get; set; }

        public int Quantidade { get; set; }

        public FormBuscaDeCliente()
        {
            InitializeComponent();

            repositorio = new RepositorioCliente();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var listaTudo = repositorio.Liste();

            lstClientes.DataContext = listaTudo;
        }

        private void txtCodigo_KeyUP(object sender, KeyEventArgs e)
        {
           var listaDeClientes =  repositorio.Buscar(txtCodigo.Text);


            lstClientes.DataContext = listaDeClientes;
        }

        private void btnSelecionar_Click(object sender, RoutedEventArgs e)
        {
            if (lstClientes.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item na lsita");
                return;
            }
          

            ClienteSelecionado = (Cliente)lstClientes.SelectedItem;
           
            this.Close();
        }
    }
}
