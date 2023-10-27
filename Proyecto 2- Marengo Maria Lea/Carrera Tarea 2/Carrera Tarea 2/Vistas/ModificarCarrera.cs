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
    public partial class ModificarCarrera : Form
    {
        private Carrera oCarrera;
        public ModificarCarrera(int carreraNro)
        {
            InitializeComponent();
            oCarrera = new Carrera();
            oCarrera.IdCarrera = carreraNro;
            CargarAsignaturas();
        }

        private void ModificarCarrera_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + oCarrera.IdCarrera.ToString();
            string sp = "SP_CONSULTAR_DETALLE_CARRERA";
            List<Parametros> lst = new List<Parametros>();
            lst.Add(new Parametros("@idCarrera", oCarrera.IdCarrera));
            DataTable dt = DBHelper.ObtenerInstancia().ConsultaSQL(sp, lst);
            bool primero = true;
            foreach (DataRow fila in dt.Rows)
            {
                if (primero)
                {
                    oCarrera.NomCarrera = fila["Titulo"].ToString();
                    txtTitulo.Text = oCarrera.NomCarrera;
                    primero = false;
                }
                int nroAsignatura = int.Parse(fila["id_asignatura"].ToString());
                string nom = fila["nombre_asignatura"].ToString();

                Asignatura oAsignatura = new Asignatura(nroAsignatura, nom);
                DateTime Año = Convert.ToDateTime(fila["AnioCursado"].ToString());
                int cuatri = int.Parse(fila["Cuatrimestre"].ToString());
                Dominio.DetalleCarrera detalle = new Dominio.DetalleCarrera(Año, cuatri, oAsignatura);
                oCarrera.AgregarDetalle(detalle);
                dgvDetalle.Rows.Add(new object[]
                {
                    oAsignatura.IdAsignatura,
                    oAsignatura.NomAsignatura,
                    detalle.AñoCursado,
                    detalle.Cuatrimestre
                });
            }
        }
        private void CargarAsignaturas()
        {
            DBHelper helper = DBHelper.ObtenerInstancia();
            DataTable tabla = helper.ConsultaSQL("sp_ConsultarAsignaturas", null);
            if (tabla != null)
            {
                cboAsignatura.DataSource = tabla;
                cboAsignatura.DisplayMember = "nombre_asignatura";
                cboAsignatura.ValueMember = "id_asignatura";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitulo.Text))
            {
                MessageBox.Show("Debe ingresar un titulo"
                    , "Control"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Exclamation);
                return;
            }
            if (cboAsignatura.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Asignatura"
                    , "Control"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Exclamation);
                return;
            }
            if (!rbtPrinerCuatri.Checked && !rbtSegundoCuatri.Checked)
            {
                MessageBox.Show("Debe ingresar un titulo"
                    , "Control"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Exclamation);
                return;
            }
            foreach (DataGridViewRow fila in dgvDetalle.Rows)
            {
                if (fila.Cells["Asignaturas"].Value.Equals(cboAsignatura.Text))
                {
                    MessageBox.Show("Esta asignatura ya esta agregada"
                   , "Control"
                   , MessageBoxButtons.OK
                   , MessageBoxIcon.Exclamation);
                    return;
                }
            }
            DataRowView item = (DataRowView)cboAsignatura.SelectedItem;

            int id = Convert.ToInt32(item.Row.ItemArray[0]);
            string nom = item.Row.ItemArray[1].ToString();
            Asignatura a = new Asignatura(id, nom);

            DateTime cursado = Convert.ToDateTime(dtpAñoCursado.Value);
            int cuatrimestre = 0;
            if (rbtPrinerCuatri.Checked == true)
            {
                cuatrimestre = 1;
            }
            else
            {
                cuatrimestre = 2;
            }

            Dominio.DetalleCarrera detalle = new Dominio.DetalleCarrera(cursado, cuatrimestre, a);
            oCarrera.AgregarDetalle(detalle);
            dgvDetalle.Rows.Add(new object[]{detalle.Asignatura.IdAsignatura,
                                detalle.Asignatura.NomAsignatura,
                                detalle.AñoCursado,
                                detalle.Cuatrimestre,
                                "Quitar" });
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalle.CurrentCell.ColumnIndex == 4)
            {
                oCarrera.QuitarDetalle(dgvDetalle.CurrentRow.Index);
                dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow);

            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos una carrera"
                    , "Control"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Exclamation);
                return;
            }
            GrabarCarrera();
        }
        private void GrabarCarrera()
        {
            oCarrera.NomCarrera = txtTitulo.Text;

            DBHelper helper = DBHelper.ObtenerInstancia();
            if (helper.ModificarCarrera(oCarrera))
            {
                MessageBox.Show("Se ha modificado con exito la carrera", "BIEN!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Algo ha salido mal", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
