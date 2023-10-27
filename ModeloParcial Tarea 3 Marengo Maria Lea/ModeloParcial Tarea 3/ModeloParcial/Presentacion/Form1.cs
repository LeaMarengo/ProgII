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
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 nuevo=new Form2();
            nuevo.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarOrdenRetiro nuevo=new ConsultarOrdenRetiro();
            nuevo.ShowDialog();
        }

        private void reporteStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReporte nuevo=new FrmReporte();
            nuevo.ShowDialog();
        }
    }
}
