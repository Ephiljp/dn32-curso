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
    ///teste de commitInteraction logic for formCadastroDeMarca.xaml
    /// </summary>
    public partial class formCadastroDeMarca : Window
    {
       
        public formCadastroDeMarca()
        {
            InitializeComponent();

        }

        public formCadastroDeMarca(Marca marca)
        {
            InitializeComponent();
            txtCodigo.Text = marca.Codigo.ToString();
            txtNome.Text = marca.nome;


        }


        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var codigo = txtCodigo.Text;
            var Nome = txtNome.Text;
            var repositorio = new RepositorioMarca();

            if (codigo == "")
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
                    Codigo = int.Parse(codigo),
                    nome = Nome
                };
                repositorio.Atualize(marca);   //Atualizar no banco de dados!! 
                
            }
            this.Close();

        }
    }
}
