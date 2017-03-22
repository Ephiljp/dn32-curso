using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System.Windows;

namespace ControladorDePedidos.WPF
{
    /// <summary>
    ///teste de commitInteraction logic for formCadastroDeMarca.xaml
    /// </summary>
    public partial class formCadastroDeMarca : Window
    {
        public int Codigo { get; set; }
        public formCadastroDeMarca()
        {
            InitializeComponent();

        }

        public formCadastroDeMarca(Marca marca)
        {
            InitializeComponent();
            Codigo = marca.Codigo;
            txtNome.Text = marca.nome;


        }


        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var codigo = Codigo;
            var Nome = txtNome.Text;
            var repositorio = new RepositorioMarca();

            if (codigo == 0)
            {
                //Novo cadastro
                var marca = new Marca
                {

                    nome = Nome
                };

                repositorio.Adicione(marca);                //Cadastrar no banco de dados!!
            }
            else
            {
                //Editando
                var marca = new Marca
                {
                    Codigo = codigo,
                    nome = Nome
                };
                repositorio.Atualize(marca);   //Atualizar no banco de dados!! 
                
            }
            this.Close();

        }
    }
}
