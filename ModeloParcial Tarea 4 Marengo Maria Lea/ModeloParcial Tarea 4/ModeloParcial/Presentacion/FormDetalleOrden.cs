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
    public partial class FormDetalleOrden : Form
    {
        private int ordenNro;
        public FormDetalleOrden(int ordenNro)
        {
            InitializeComponent();
            this.ordenNro = ordenNro;
        }

        private void FormDetalleOrden_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + ordenNro.ToString();
            string sp = "SP_CONSULTAR_DETALLES_ORDEN";
            List<Parametro> lst = new List<Parametro>();

            lst.Add(new Parametro("@id_orden", ordenNro));

            DataTable tabla = new HelperDao().ObtenerInstancia().ConsultaSQL(sp, lst);
            bool primero = true;

            foreach (DataRow fila in tabla.Rows)
            {
                if (primero)
                {
                    txtResponsable.Text = fila["responsable"].ToString();
                    dtpDesde.Value = Convert.ToDateTime(fila["fecha_orden".ToString()]);
                    dtpHasta.Value = Convert.ToDateTime(fila["fecha_orden".ToString()]);
                    primero = false;
                }
                dgvDetalle.Rows.Add(new object[] { fila["nom_material"].ToString(),
                    fila["stock_material"].ToString(),
                    fila["cantidad"] });
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
