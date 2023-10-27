using ModeloParcial.Datos;
using ModeloParcial.Entidades;
using ModeloParcial.Servicio;
using ModeloParcial.Servicio.Implementacion;
using ModeloParcial.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ModeloParcial.Presentacion
{
    public partial class FormModificarOrden : Form
    {
        IServicio servicioDatos = null;
        private OrdenRetiro oOrdenRetiro;
        
        public FormModificarOrden(FabricaServicio fabrica,int ordenNro)
        {
            InitializeComponent();
            servicioDatos=fabrica.CrearServicio();
            oOrdenRetiro = new OrdenRetiro();
            oOrdenRetiro.NroOrden = ordenNro;
            CargarMaterial();
        }

        private void CargarMaterial()
        {
            HelperDao helper = new HelperDao().ObtenerInstancia();
            DataTable tabla = helper.ConsultaSQL("SP_CONSULTAR_MATERIALES", null);
            if (tabla!=null)
            {
                cboMaterial.DataSource = tabla;
                cboMaterial.DisplayMember = "nom_material";
                cboMaterial.ValueMember = "id_material";
            }
        }

        private void FormModificarOrden_Load(object sender, EventArgs e)
        {
            
            this.Text = this.Text + oOrdenRetiro.NroOrden.ToString();
            string sp = "SP_CONSULTAR_DETALLES_ORDEN";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@id_orden", oOrdenRetiro.NroOrden));
            DataTable tabla = new HelperDao().ObtenerInstancia().ConsultaSQL(sp,lst);
            bool primero = true;
            foreach (DataRow fila in tabla.Rows)
            {
                if (primero)
                {
                    oOrdenRetiro.Fecha = Convert.ToDateTime(fila["fecha_orden"].ToString());
                    dtpFecha.Value = oOrdenRetiro.Fecha;
                    oOrdenRetiro.Responsable = fila["responsable"].ToString();
                    txtResponsable.Text = oOrdenRetiro.Responsable;
                    primero = false;
                }
                int codigo = int.Parse(fila["id_material"].ToString());
                string nom = fila["nom_material"].ToString();
                double stock = Convert.ToDouble(fila["stock_material"].ToString());

                Material oMaterial = new Material(codigo,nom,stock);
                int cantidad = int.Parse(fila["cantidad"].ToString());
                DetalleOrden detalle = new DetalleOrden(cantidad,oMaterial);
                oOrdenRetiro.AgregarDetalle(detalle);
                dgvOrden.Rows.Add(new object[]
                {
                    oMaterial.Nombre,
                    oMaterial.Stock,
                    detalle.Cantidad
                });
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtResponsable.Text))
            {
                MessageBox.Show("Debe ingresar un responsable"
                    , "Control"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Exclamation);
                return;
            }
            if (cboMaterial.SelectedIndex==-1)
            {
                MessageBox.Show("Debe ingresar un material"
                    , "Control"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Exclamation);
                return;
            }
            if (nudCantidad.Value==0)
            {
                MessageBox.Show("Debe ingresar una cantidad"
                    , "Control"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Exclamation);
                return;
            }
            foreach (DataGridViewRow fila in dgvOrden.Rows)
            {
                if (fila.Cells["ColMaterial"].Value.Equals(cboMaterial.Text))
                {
                    MessageBox.Show("Este material ya esta agregado"
                   , "Control"
                   , MessageBoxButtons.OK
                   , MessageBoxIcon.Exclamation);
                    return;
                }
            }
            DataRowView item = (DataRowView)cboMaterial.SelectedItem;

            int cod = Convert.ToInt32(item.Row.ItemArray[0]);
            string nom = item.Row.ItemArray[1].ToString();
            double fec = Convert.ToDouble(item.Row.ItemArray[2]);
            Material m = new Material(cod,nom,fec);
            int cant = Convert.ToInt32(nudCantidad.Value);

            DetalleOrden detalle = new DetalleOrden(cant, m);

            oOrdenRetiro.AgregarDetalle(detalle);
            dgvOrden.Rows.Add(new object[] { m.Nombre, m.Stock, cant });
        }

        private void dgvOrden_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrden.CurrentCell.ColumnIndex == 3)
            {
                oOrdenRetiro.QuitarDetalle(dgvOrden.CurrentRow.Index);
                dgvOrden.Rows.Remove(dgvOrden.CurrentRow);

            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvOrden.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos una orden"
                    , "Control"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Exclamation);
                return;
            }
            GrabarOrden();
        }

        private void GrabarOrden()
        {
            oOrdenRetiro.Fecha=dtpFecha.Value;
            oOrdenRetiro.Responsable=txtResponsable.Text;

            if (servicioDatos.ActualizarOrden(oOrdenRetiro))
            {
                MessageBox.Show("Se ha modificado con exito la orden", "BIEN!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Algo ha salido mal", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
