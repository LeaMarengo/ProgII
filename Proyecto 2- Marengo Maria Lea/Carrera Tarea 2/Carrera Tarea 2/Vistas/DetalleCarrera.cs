using Carrera_Tarea_2.Datos;
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
    public partial class DetalleCarrera : Form
    {
        private int carreraNro;
        public DetalleCarrera(int carreraNro)
        {
            InitializeComponent();
            this.carreraNro = carreraNro;
        }

        private void DetalleCarrera_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + carreraNro.ToString();
            string sp = "SP_CONSULTAR_DETALLE_CARRERA";
            List<Parametros> lst = new List<Parametros>();

            lst.Add(new Parametros("@idCarrera", carreraNro));

            DataTable tabla = DBHelper.ObtenerInstancia().ConsultaSQL(sp, lst);
            bool primero = true;

            foreach (DataRow fila in tabla.Rows)
            {
                if (primero)
                {
                    txtTitulo.Text = fila["Titulo"].ToString();
                    primero = false;
                }
                dgvDetalle.Rows.Add(new object[] { fila["nombre_asignatura"].ToString(),
                    fila["AnioCursado"].ToString(),
                    fila["Cuatrimestre"] });
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
