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
    /// Interaction logic for FormCadastroDeCliente.xaml
    /// </summary>
    public partial class FormCadastroDeCliente : Window
    {
        public FormCadastroDeCliente()
        {
            InitializeComponent();
            this.DataContext = new Cliente();

        }


        public FormCadastroDeCliente(Cliente cliente)
        {
            InitializeComponent();
            this.DataContext = cliente;
        }


        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var cliente = (Cliente)this.DataContext;

            var repositorio = new RepositorioCliente();

            if (cliente.Codigo == 0)
            {


                repositorio.Adicione(cliente);                //Cadastrar no banco de dados!!
            }
            else
            {
                //Editando
                repositorio.Atualize(cliente);   //Atualizar no banco de dados!! 

            }
            this.Close();

        }
    }
}
