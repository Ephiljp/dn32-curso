using System.Windows;
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
