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
    /// Interaction logic for formCadastroDeMarca.xaml
    /// </summary>
    public partial class formCadastroDeMarca : Window
    {
        public formCadastroDeMarca(Marca marca)
        {
            InitializeComponent();
            txtCodigo.Text = marca.Codigo.ToString();
            txtNome.Text = marca.nome;


        }

        public formCadastroDeMarca()
        {
            InitializeComponent();

        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var codigo = txtCodigo.Text;
            var Nome = txtNome.Text;

            if (codigo == "")
            {
                //Novo cadastro
                var marca = new Marca
                {

                    nome = Nome
                };
                //Cadastrar no banco de dados!!
            }
            else
            {
                //Editando
                var marca = new Marca
                {
                    Codigo = int.Parse(codigo),
                    nome = Nome
                };
            }

            //Atualizar no banco de dados!!
        }
    }
}
