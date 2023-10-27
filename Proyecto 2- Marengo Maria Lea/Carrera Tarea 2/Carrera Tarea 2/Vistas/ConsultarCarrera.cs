using Carrera_Tarea_2.Datos;
using Carrera_Tarea_2.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carrera_Tarea_2.Vistas
{
    public partial class ConsultarCarrera : Form
    {
        public ConsultarCarrera()
        {
            InitializeComponent();
        }

        private void ConsultarCarrera_Load(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string sp = "sp_ConsultarCarrera";
            List<Parametros> lst = new List<Parametros>();
            lst.Add(new Parametros("@titulo", txtCarrera.Text));

            dgvConsultarCarrera.Rows.Clear();
            DataTable tabla = DBHelper.ObtenerInstancia().ConsultaSQL(sp, lst);
            foreach (DataRow fila in tabla.Rows)
            {
                dgvConsultarCarrera.Rows.Add(new object[] {
                    fila["id_Carrera"].ToString(),
                    fila["Titulo"].ToString(),
                    "Ver Detalle"});
            }
        }

        private void dgvConsultarCarrera_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvConsultarCarrera.CurrentCell.ColumnIndex == 2)
            {
                int nro = int.Parse(dgvConsultarCarrera.CurrentRow.Cells["ColCarreraNro"].Value.ToString());
                new DetalleCarrera(nro).ShowDialog();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea quitar la carrera seleccionada?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dgvConsultarCarrera.CurrentRow != null)
                {
                    int nro = int.Parse(dgvConsultarCarrera.CurrentRow.Cells["ColCarreraNro"].Value.ToString());
                    List<Parametros> lst = new List<Parametros>();
                    lst.Add(new Parametros("@idCarrera", nro));

                    int afectadas = DBHelper.ObtenerInstancia().EjecutarSQL("SP_ELIMINAR_CARRERA", lst);
                    if (afectadas == 1)
                    {
                        MessageBox.Show("La carrera se quitó exitosamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.btnConsultar_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("La carrera NO se quitó exitosamente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            int nro = int.Parse(dgvConsultarCarrera.CurrentRow.Cells["ColCarreraNro"].Value.ToString());
            new ModificarCarrera(nro).ShowDialog();
            this.btnConsultar_Click(null, null);
        }
    }
}
