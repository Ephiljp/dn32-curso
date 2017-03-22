using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System.Windows;

namespace ControladorDePedidos.WPF
{

    public partial class FormCadastroDeFornecedor : Window
    {
        public int Codigo { get; set; }
        public FormCadastroDeFornecedor()
        {
            InitializeComponent();

        }

        public FormCadastroDeFornecedor(Fornecedor fornecedor)
        {
            InitializeComponent();
            Codigo = fornecedor.Codigo;
            txtNome.Text = fornecedor.Nome;
            txtEmail.Text = fornecedor.Email;


        }


        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var codigo = Codigo;
            var nome = txtNome.Text;
            var email = txtEmail.Text;
            var repositorio = new RepositorioFornecedor();

            if (codigo == 0)
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
                    Codigo = codigo,
                    Nome = nome,
                    Email = email
                };
                repositorio.Atualize(fornecedor);   //Atualizar no banco de dados!! 
                
            }
            this.Close();

        }
    }
}
