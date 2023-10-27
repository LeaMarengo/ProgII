using ModeloParcial.Entidades;
using ModeloParcial.Servicio.Implementacion;
using ModeloParcial.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModeloParcial.Servicio;

namespace ModeloParcial.Presentacion
{
    public partial class Form2 : Form
    {
        IServicio servicio = null;
        OrdenRetiro nuevo = null;
        public Form2(FabricaServicio fabrica)
        {
            InitializeComponent();
            servicio=fabrica.CrearServicio();
            servicio= new Servicio.Implementacion.Servicio();
            nuevo= new OrdenRetiro();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Today;
            txtResponsable.Text = "";
            nudCantidad.Value = 0;

            cargarMaterial();
        }

        private void cargarMaterial()
        {
            cboMaterial.DataSource= servicio.TraerMaterial();
            cboMaterial.ValueMember = "codigo";
            cboMaterial.DisplayMember = "nombre";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboMaterial.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un material", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            foreach (DataGridViewRow row in dgvOrden.Rows)
            {
                if (row.Cells["ColMaterial"].Value.ToString().Equals(cboMaterial.Text))
                {
                    MessageBox.Show("Este material ya está cargado...", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            Material m = (Material)cboMaterial.SelectedItem;
            int cant=Convert.ToInt32(nudCantidad.Value);
            
            DetalleOrden detalle=new DetalleOrden(cant,m);
            nuevo.AgregarDetalle(detalle);
            dgvOrden.Rows.Add(new object[] {m.Nombre,m.Stock,cant,"Quitar"});
        }

        private void dgvOrden_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrden.CurrentCell.ColumnIndex == 3) 
            {
                nuevo.QuitarDetalle(dgvOrden.CurrentRow.Index);
                dgvOrden.Rows.RemoveAt(dgvOrden.CurrentRow.Index);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (nudCantidad.Value<0)
            {
                MessageBox.Show("Debe ingresar un stock", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dgvOrden.Rows.Count==0)
            {
                MessageBox.Show("Debe ingresar al menos un material", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            GrabarOrdenRetiro();
        }

        private void GrabarOrdenRetiro()
        {
            nuevo.Fecha= dtpFecha.Value;
            nuevo.Responsable = txtResponsable.Text;
            if (servicio.CrearOrdenRetiro(nuevo))
            {
                MessageBox.Show("Se registró con éxito la orden", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("NO se pudo registrar la orden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
