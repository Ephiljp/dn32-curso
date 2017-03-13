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
    /// Interaction logic for FormCadastroDeUsuario.xaml
    /// </summary>
    public partial class FormCadastroDeUsuario : Window
    {
        public FormCadastroDeUsuario()
        {
            InitializeComponent();
            this.DataContext = new Usuario();

        }


        public FormCadastroDeUsuario(Usuario usuario)
        {
            InitializeComponent();
            this.DataContext = usuario;
        }


        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var usuario = (Usuario)this.DataContext;

            var repositorio = new RepositorioUsuario();

            if (usuario.Codigo == 0)
            {
               

                repositorio.Adicione(usuario);                //Cadastrar no banco de dados!!
            }
            else
            {
               //Editando
                repositorio.Atualize(usuario);   //Atualizar no banco de dados!! 

            }
            this.Close();

        }
    }
}
