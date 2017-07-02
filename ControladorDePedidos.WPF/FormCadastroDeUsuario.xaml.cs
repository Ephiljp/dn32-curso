using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System.Windows;

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
                if (txtSenha.Password != txtConfSenha.Password)
                {
                    MessageBox.Show("As senhas devem ser iguais");
                    return;
                }

                if (string.IsNullOrEmpty(txtSenha.Password) || string.IsNullOrEmpty(txtConfSenha.Password))
                {
                    MessageBox.Show("A senha deve ser informada");
                    return;
                }
                usuario.Senha = txtSenha.Password;

            }

           
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
