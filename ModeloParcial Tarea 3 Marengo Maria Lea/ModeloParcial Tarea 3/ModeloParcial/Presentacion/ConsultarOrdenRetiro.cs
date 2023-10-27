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
    public partial class ConsultarOrdenRetiro : Form
    {
        public ConsultarOrdenRetiro()
        {
            InitializeComponent();
        }

        private void ConsultarOrdenRetiro_Load(object sender, EventArgs e)
        {
                
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string sp = "SP_CONSULTAR_ORDEN";
            List<Parametro> lst= new List<Parametro>();
            lst.Add(new Parametro("@fecha_desde",dtpDesde.Value));
            lst.Add(new Parametro("@fecha_hasta", dtpHasta.Value));
            lst.Add(new Parametro("@responsable", txtResponsable.Text));

            dgvConsultarOrdenRetiro.Rows.Clear();
            DataTable tabla = new HelperDao().ObtenerInstancia().ConsultaSQL(sp,lst);
            foreach (DataRow fila in tabla.Rows)
            {
                dgvConsultarOrdenRetiro.Rows.Add(new object[] {
                    fila["id_orden"].ToString(),
                    fila["fecha_orden"].ToString(),
                    fila["fecha_baja"].ToString(),
                    fila["responsable"].ToString(),
                    "Ver Detalle"});
            }

        }

        private void dgvConsultarOrdenRetiro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvConsultarOrdenRetiro.CurrentCell.ColumnIndex == 4)
            {
                int nro = int.Parse(dgvConsultarOrdenRetiro.CurrentRow.Cells["ColOrdenNro"].Value.ToString());
                new FormDetalleOrden(nro).ShowDialog();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea quitar la orden seleccionada?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dgvConsultarOrdenRetiro.CurrentRow != null)
                {
                    int nro = int.Parse(dgvConsultarOrdenRetiro.CurrentRow.Cells["ColOrdenNro"].Value.ToString());
                    List<Parametro> lst = new List<Parametro>();
                    lst.Add(new Parametro("@id_orden", nro));

                    int afectadas = new HelperDao().ObtenerInstancia().EjecutarSQL("SP_BORRAR_ORDEN", lst);
                    if (afectadas == 1)
                    {
                        MessageBox.Show("La orden se quitó exitosamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.btnConsultar_Click(sender,e);
                    }
                    else
                    {
                        MessageBox.Show("La orden NO se quitó exitosamente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int nro = int.Parse(dgvConsultarOrdenRetiro.CurrentRow.Cells["ColOrdenNro"].Value.ToString());
            new FormModificarOrden(nro).ShowDialog();
            this.btnConsultar_Click(null, null);
        }
    }
}
