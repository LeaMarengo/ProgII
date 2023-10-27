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
    public partial class NuevaCarrea : Form
    {
        DBHelper gestor;
        Carrera nuevaCarrera;
        public NuevaCarrea()
        {
            InitializeComponent();
            nuevaCarrera = new Carrera();
            gestor = new DBHelper();
        }

        private void NuevaCarrea_Load(object sender, EventArgs e)
        {
            txtTitulo.Text = " ";
            dtpAñoCursado.Text = DateTime.Now.ToShortDateString();
            rbtPrinerCuatri.Checked = false;
            rbtSegundoCuatri.Checked = false;
            CargarAsignatura();
            lblCarreraNro.Text = lblCarreraNro.Text + " " + gestor.ProximaCarrera().ToString();
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
            nuevaCarrera.AgregarDetalle(detalle);
            dgvDetalle.Rows.Add(new object[]{detalle.Asignatura.NomAsignatura,
                                detalle.AñoCursado,
                                detalle.Cuatrimestre,
                                "Quitar" });
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
            nuevaCarrera.NomCarrera = txtTitulo.Text;
            if (gestor.ConfirmarCarrera(nuevaCarrera))
            {
                MessageBox.Show("Se ha guardado con exito", "BIEN!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Algo ha salido mal", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalle.CurrentCell.ColumnIndex == 3)
            {

                nuevaCarrera.QuitarDetalle(dgvDetalle.CurrentRow.Index);
                dgvDetalle.Rows.RemoveAt(dgvDetalle.CurrentRow.Index);
            }
        }
        private void CargarAsignatura()
        {
            DataTable tabla = gestor.Consultar("sp_ConsultarAsignaturas");
            cboAsignatura.DataSource = tabla;
            cboAsignatura.ValueMember = tabla.Columns[0].ColumnName;
            cboAsignatura.DisplayMember = tabla.Columns[1].ColumnName;
        }
    }
}
