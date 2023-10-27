using Microsoft.Reporting.WinForms;
using ModeloParcial.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModeloParcial.Presentacion
{
    public partial class FrmReporte : Form
    {
        public FrmReporte()
        {
            InitializeComponent();
        }

        private void FrmReporte_Load(object sender, EventArgs e)
        {
            dtpFechaDesde.Value = DateTime.Now.AddDays(-30);
            dtpFechaHasta.Value = DateTime.Now;
            this.reportViewer1.RefreshReport();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            List<Parametro> lista = new List<Parametro>();
            lista.Add(new Parametro("@fecha_desde", dtpFechaDesde.Value));
            lista.Add(new Parametro("@fecha_hasta", dtpFechaHasta.Value));

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", new HelperDao().ObtenerInstancia().ConsultaSQL("SP_REPORTE_STOCK", lista)));

            this.reportViewer1.RefreshReport();
        }
    }
}
