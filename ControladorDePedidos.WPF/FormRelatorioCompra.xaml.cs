using System.Windows;
using ControladorDePedidos.Model;
using Microsoft.Reporting.WinForms;

namespace ControladorDePedidos.WPF
{
    /// <summary>
    /// Interaction logic for RelatorioCompra.xaml
    /// </summary>
    public partial class FormRelatorioCompra : Window
    {
        public int Codigo { get; set; }

        public Compra Compra { get; set; }

        public FormRelatorioCompra()
        {
            InitializeComponent();
            
        }

       

        public FormRelatorioCompra(Compra compra)
        {


            InitializeComponent();

            Codigo = compra.Codigo;

            Compra = compra;

            


            var dadosRelatorio = compra.ItensDaCompra;
            
            
            var dataSource = new ReportDataSource("DataSetRelatorio", dadosRelatorio);

            
            ReportViewer.LocalReport.DataSources.Add(dataSource);

         
            ReportViewer.LocalReport.ReportEmbeddedResource = "ControladorDePedidos.WPF.RelatorioDeCompra.rdlc";

            ReportViewer.RefreshReport();
        }


    }
}
