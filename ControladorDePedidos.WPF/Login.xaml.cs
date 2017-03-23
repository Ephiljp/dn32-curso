using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

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

            BackgroundWorker worker = new BackgroundWorker();
            //this is where the long running process should go
            worker.DoWork += (o, ea) =>
            {
                var repoUsuario = new RepositorioUsuario();

                var listaUsuarios = repoUsuario.Liste();

                //no direct interaction with the UI is allowed from this method
                for (int i = 0; i < 2; i++)
                {
                    System.Threading.Thread.Sleep(50);
                }
            };
            worker.RunWorkerCompleted += (o, ea) =>
            {
                //work has completed. you can now interact with the UI
                ProgressIndicator.IsBusy = false;

                
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

            };
            //set the IsBusy before you start the thread
            ProgressIndicator.IsBusy = true;
            worker.RunWorkerAsync();


        
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
