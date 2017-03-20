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
using ControladorDePedidos.Model;
using Microsoft.Reporting.WinForms;

namespace ControladorDePedidos.WPF
{
    /// <summary>
    /// Interaction logic for RelatorioVenda.xaml
    /// </summary>
    public partial class FormRelatorioVenda : Window
    {

        public FormRelatorioVenda()
        {
            InitializeComponent();
            
        }


        public FormRelatorioVenda(Venda venda)
        {

            InitializeComponent();

            
            var dadosRelatorio = venda.ItensDaVenda;
           
           

            var dataSource = new ReportDataSource("DataSetRelatorio", dadosRelatorio);
           


            ReportViewer.LocalReport.DataSources.Add(dataSource);
            


            ReportViewer.LocalReport.ReportEmbeddedResource = "ControladorDePedidos.WPF.RelatorioDeVenda.rdlc";

            ReportViewer.RefreshReport();
        }


    }
}
