﻿using ControladorDePedidos.Model;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Usuario Usuario { get; set; }

        public MainWindow(Usuario Usuario)
        {
            InitializeComponent();

            this.Usuario = Usuario;
        }

        private void btnProdutos_Click(object sender, RoutedEventArgs e)
        {
            if (!Usuario.Administrador && !Usuario.Produtos)
            {
                MessageBox.Show("Acesso negado");
                return;
            }
            var janelaProdutos = new formProdutos();
            janelaProdutos.Show();
        }

        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            if (!Usuario.Administrador)
            {
                MessageBox.Show("Acesso negado");
                return;
            }
            var janelaUsuarios = new formUsuarios();
            janelaUsuarios.Show();
        }

        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {
            if (!Usuario.Administrador && !Usuario.Clientes)
            {
                MessageBox.Show("Acesso negado");
                return;
            }
            var janelaClientes = new FormClientes();
            janelaClientes.Show();

        }

        private void btnCompras_Click(object sender, RoutedEventArgs e)
        {
            if (!Usuario.Administrador && !Usuario.Compras)
            {
                MessageBox.Show("Acesso negado");
                return;
            }
            var janelaCompras = new FormCompras();
            janelaCompras.Show();
        }

        private void btnVendas_Click(object sender, RoutedEventArgs e)
        {
            if (!Usuario.Administrador && !Usuario.Vendas)
            {
                MessageBox.Show("Acesso negado");
                return;
            }
            var janelaVendas = new FormVendas();
            janelaVendas.Show();
        }



        private void btnFornecedores_Click(object sender, RoutedEventArgs e)
        {
            if (!Usuario.Administrador && !Usuario.Fornecedores)
            {
                MessageBox.Show("Acesso negado");
                return;
            }
            var janelaFornecedores = new FormFornecedores();
            janelaFornecedores.Show();
        }
    }
}
