using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ABMCarrera
{
    public partial class FrmNuevaCarrera : Form
    {
        DBHelper gestor;
        Carrera nuevaCarrera;
        public FrmNuevaCarrera()
        {
            InitializeComponent();
            nuevaCarrera = new Carrera();
            gestor= new DBHelper();
        }

        private void FrmNuevaCarrera_Load(object sender, EventArgs e)
        {
            //txtTitulo.Text = " ";
            //dtpAñoCursado.Text=DateTime.Now.ToString();
            //rbtPrinerCuatri.Checked = false;
            //rbtSegundoCuatri.Checked = false;
            CargarAsignatura();
            lblCarreraNro.Text =lblCarreraNro.Text+" "+gestor.ProximaCarrera().ToString(); ;
            
        }

        private void CargarAsignatura()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = "Data Source=DESKTOP-KQDVDBG\\MYSQLSERVER19;Initial Catalog=Carrera1;Integrated Security=True";
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType= CommandType.StoredProcedure;
            comando.CommandText = "sp_ConsultarAsignaturas";
            DataTable tabla=new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();

            cboAsignatura.DataSource= tabla;
            cboAsignatura.ValueMember = tabla.Columns[0].ColumnName;
            cboAsignatura.DisplayMember= tabla.Columns[1].ColumnName;
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
            DetalleCarrera detalle = new DetalleCarrera(cursado, cuatrimestre,a);
            nuevaCarrera.AgregarDetalle(detalle);
            dgvDetalle.Rows.Add(
                                detalle.Asignatura.NomAsignatura,
                                detalle.AñoCursado,
                                detalle.Cuatrimestre,
                                "Quitar");


        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalle.CurrentCell.ColumnIndex==3)
            {
                nuevaCarrera.QuitarDetalle(dgvDetalle.CurrentRow.Index);
                dgvDetalle.Rows.RemoveAt(dgvDetalle.CurrentRow.Index);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            nuevaCarrera.NomCarrera = txtTitulo.ToString();
            if (gestor.ConfirmarCarrera(nuevaCarrera))
            {
                MessageBox.Show("Se ha guardado cone xito", "BIEN!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Algo ha salido mal...", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
