using ModeloParcial.Presentacion;
using ModeloParcial.Servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModeloParcial
{
    public partial class Form1 : Form
    {
        FabricaServicio fabrica = null;
        public Form1(FabricaServicio fabrica)
        {
            InitializeComponent();
            this.fabrica = fabrica;
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 nuevo=new Form2(fabrica);
            nuevo.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarOrdenRetiro nuevo=new ConsultarOrdenRetiro(fabrica);
            nuevo.ShowDialog();
        }

        private void reporteStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReporte nuevo=new FrmReporte();
            nuevo.ShowDialog();
        }
    }
}
