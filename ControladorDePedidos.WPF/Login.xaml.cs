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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControladorDePedidos.WPF
{

    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var repoUsuario = new RepositorioUsuario();

            var listaUsuarios = repoUsuario.Liste();
            if (listaUsuarios.Count == 0)
            {
                var usuario = new Usuario
                {
                    Administrador = true
                };

                this.Hide();
                var formPrincipal = new MainWindow(usuario);
                formPrincipal.ShowDialog();
                this.Close();
            }
           

            cmbUsuario.DataContext = listaUsuarios;
        }


    


            private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbUsuario.SelectedItem == null)
            {
                MessageBox.Show("Selecione um Usuario");
                return;
            }

            var senha = txtPassword.Password;
            var usuario = (Usuario)cmbUsuario.SelectedItem;

            var repoUsuario = new RepositorioUsuario();

            if (repoUsuario.ValideAcesso(usuario.Codigo, senha))
            {
                var listaUsuarios =(List<Usuario>) cmbUsuario.DataContext;
                var quantidade = listaUsuarios.Where(x => x.Administrador).Count();
                    if (quantidade == 0)
                    {
                        MessageBox.Show("Não existe administrador cadastrado, logo o usuario logado terá acesso de administrador");
                    usuario.Administrador = true;
                    }
              
                    this.Hide();
                    var formPrincipal = new MainWindow(usuario);
                    formPrincipal.ShowDialog();
                    this.Close();
                
               
            }

            else
            {

                MessageBox.Show("Dados incorretos");
                return;
            }

        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;

            // your event handler here
            e.Handled = true;
            if (cmbUsuario.SelectedItem == null)
            {
                MessageBox.Show("Selecione um Usuario");
                return;
            }

            var senha = txtPassword.Password;
            var usuario = (Usuario)cmbUsuario.SelectedItem;

            var repoUsuario = new RepositorioUsuario();
            if (repoUsuario.ValideAcesso(usuario.Codigo, senha))
            {
                var listaUsuarios = (List<Usuario>)cmbUsuario.DataContext;
                var quantidade = listaUsuarios.Where(x => x.Administrador).Count();
                if (quantidade == 0)
                {
                    MessageBox.Show("Não existe administrador cadastrado, logo o usuario logado terá acesso de administrador");
                    usuario.Administrador = true;
                }

                this.Hide();
                var formPrincipal = new MainWindow(usuario);
                formPrincipal.ShowDialog();
                this.Close();
            }

            else
            {

                MessageBox.Show("Dados incorretos");
                return;
            }
        }
    }
}
