using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System.Windows;

namespace ControladorDePedidos.WPF
{

    public partial class FormCadastroDeFornecedor : Window
    {
       
        public FormCadastroDeFornecedor()
        {
            InitializeComponent();

        }

        public FormCadastroDeFornecedor(Fornecedor fornecedor)
        {
            InitializeComponent();
            txtCodigo.Text = fornecedor.Codigo.ToString();
            txtNome.Text = fornecedor.Nome;
            txtEmail.Text = fornecedor.Email;


        }


        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var codigo = txtCodigo.Text;
            var nome = txtNome.Text;
            var email = txtEmail.Text;
            var repositorio = new RepositorioFornecedor();

            if (codigo == "")
            {
                //Novo cadastro
                var fornecedor = new Fornecedor
                {

                    Nome = nome,
                    Email = email,
                };

                repositorio.Adicione(fornecedor);                //Cadastrar no banco de dados!!
            }
            else
            {
                //Editando
                var fornecedor = new Fornecedor
                {
                    Codigo = int.Parse(codigo),
                    Nome = nome,
                    Email = email
                };
                repositorio.Atualize(fornecedor);   //Atualizar no banco de dados!! 
                
            }
            this.Close();

        }
    }
}
