namespace Carrera_Tarea_2.Vistas
{
    partial class ModificarCarrera
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGrabar = new System.Windows.Forms.Button();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.ColIdAsig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asignaturas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AñoCursado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuatrimestre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Acciones = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.rbtSegundoCuatri = new System.Windows.Forms.RadioButton();
            this.rbtPrinerCuatri = new System.Windows.Forms.RadioButton();
            this.dtpAñoCursado = new System.Windows.Forms.DateTimePicker();
            this.cboAsignatura = new System.Windows.Forms.ComboBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblAsignatura = new System.Windows.Forms.Label();
            this.lblAñoCursado = new System.Windows.Forms.Label();
            this.lblCuatrimestre = new System.Windows.Forms.Label();
            this.lblCarreraNro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(634, 187);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(106, 40);
            this.btnGrabar.TabIndex = 51;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColIdAsig,
            this.Asignaturas,
            this.AñoCursado,
            this.Cuatrimestre,
            this.Acciones});
            this.dgvDetalle.Location = new System.Drawing.Point(93, 241);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersWidth = 62;
            this.dgvDetalle.RowTemplate.Height = 28;
            this.dgvDetalle.Size = new System.Drawing.Size(667, 202);
            this.dgvDetalle.TabIndex = 50;
            this.dgvDetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellContentClick);
            // 
            // ColIdAsig
            // 
            this.ColIdAsig.HeaderText = "ID";
            this.ColIdAsig.MinimumWidth = 8;
            this.ColIdAsig.Name = "ColIdAsig";
            this.ColIdAsig.ReadOnly = true;
            this.ColIdAsig.Visible = false;
            this.ColIdAsig.Width = 150;
            // 
            // Asignaturas
            // 
            this.Asignaturas.HeaderText = "Asignaturas";
            this.Asignaturas.MinimumWidth = 8;
            this.Asignaturas.Name = "Asignaturas";
            this.Asignaturas.ReadOnly = true;
            this.Asignaturas.Width = 150;
            // 
            // AñoCursado
            // 
            this.AñoCursado.HeaderText = "Año de cursado";
            this.AñoCursado.MinimumWidth = 8;
            this.AñoCursado.Name = "AñoCursado";
            this.AñoCursado.ReadOnly = true;
            this.AñoCursado.Width = 150;
            // 
            // Cuatrimestre
            // 
            this.Cuatrimestre.HeaderText = "Cuatrimestre";
            this.Cuatrimestre.MinimumWidth = 8;
            this.Cuatrimestre.Name = "Cuatrimestre";
            this.Cuatrimestre.ReadOnly = true;
            this.Cuatrimestre.Width = 150;
            // 
            // Acciones
            // 
            this.Acciones.HeaderText = "Acciones";
            this.Acciones.MinimumWidth = 8;
            this.Acciones.Name = "Acciones";
            this.Acciones.ReadOnly = true;
            this.Acciones.Text = "Quitar";
            this.Acciones.Width = 150;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(634, 141);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(106, 40);
            this.btnAgregar.TabIndex = 49;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // rbtSegundoCuatri
            // 
            this.rbtSegundoCuatri.AutoSize = true;
            this.rbtSegundoCuatri.Location = new System.Drawing.Point(446, 205);
            this.rbtSegundoCuatri.Name = "rbtSegundoCuatri";
            this.rbtSegundoCuatri.Size = new System.Drawing.Size(143, 24);
            this.rbtSegundoCuatri.TabIndex = 48;
            this.rbtSegundoCuatri.TabStop = true;
            this.rbtSegundoCuatri.Text = "2° Cuatrimestre";
            this.rbtSegundoCuatri.UseVisualStyleBackColor = true;
            // 
            // rbtPrinerCuatri
            // 
            this.rbtPrinerCuatri.AutoSize = true;
            this.rbtPrinerCuatri.Location = new System.Drawing.Point(268, 205);
            this.rbtPrinerCuatri.Name = "rbtPrinerCuatri";
            this.rbtPrinerCuatri.Size = new System.Drawing.Size(143, 24);
            this.rbtPrinerCuatri.TabIndex = 47;
            this.rbtPrinerCuatri.TabStop = true;
            this.rbtPrinerCuatri.Text = "1° Cuatrimestre";
            this.rbtPrinerCuatri.UseVisualStyleBackColor = true;
            // 
            // dtpAñoCursado
            // 
            this.dtpAñoCursado.Location = new System.Drawing.Point(283, 155);
            this.dtpAñoCursado.Name = "dtpAñoCursado";
            this.dtpAñoCursado.Size = new System.Drawing.Size(321, 26);
            this.dtpAñoCursado.TabIndex = 46;
            // 
            // cboAsignatura
            // 
            this.cboAsignatura.FormattingEnabled = true;
            this.cboAsignatura.Location = new System.Drawing.Point(283, 100);
            this.cboAsignatura.Name = "cboAsignatura";
            this.cboAsignatura.Size = new System.Drawing.Size(321, 28);
            this.cboAsignatura.TabIndex = 45;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(283, 53);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(321, 26);
            this.txtTitulo.TabIndex = 44;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(129, 53);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(51, 20);
            this.lblTitulo.TabIndex = 43;
            this.lblTitulo.Text = "Titulo:";
            // 
            // lblAsignatura
            // 
            this.lblAsignatura.AutoSize = true;
            this.lblAsignatura.Location = new System.Drawing.Point(129, 100);
            this.lblAsignatura.Name = "lblAsignatura";
            this.lblAsignatura.Size = new System.Drawing.Size(90, 20);
            this.lblAsignatura.TabIndex = 42;
            this.lblAsignatura.Text = "Asignatura:";
            // 
            // lblAñoCursado
            // 
            this.lblAñoCursado.AutoSize = true;
            this.lblAñoCursado.Location = new System.Drawing.Point(129, 155);
            this.lblAñoCursado.Name = "lblAñoCursado";
            this.lblAñoCursado.Size = new System.Drawing.Size(128, 20);
            this.lblAñoCursado.TabIndex = 41;
            this.lblAñoCursado.Text = "Año de Cursado:";
            // 
            // lblCuatrimestre
            // 
            this.lblCuatrimestre.AutoSize = true;
            this.lblCuatrimestre.Location = new System.Drawing.Point(129, 205);
            this.lblCuatrimestre.Name = "lblCuatrimestre";
            this.lblCuatrimestre.Size = new System.Drawing.Size(104, 20);
            this.lblCuatrimestre.TabIndex = 40;
            this.lblCuatrimestre.Text = "Cuatrimestre:";
            // 
            // lblCarreraNro
            // 
            this.lblCarreraNro.AutoSize = true;
            this.lblCarreraNro.Location = new System.Drawing.Point(41, 7);
            this.lblCarreraNro.Name = "lblCarreraNro";
            this.lblCarreraNro.Size = new System.Drawing.Size(82, 20);
            this.lblCarreraNro.TabIndex = 39;
            this.lblCarreraNro.Text = "Carrera N°";
            // 
            // ModificarCarrera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 480);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.rbtSegundoCuatri);
            this.Controls.Add(this.rbtPrinerCuatri);
            this.Controls.Add(this.dtpAñoCursado);
            this.Controls.Add(this.cboAsignatura);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblAsignatura);
            this.Controls.Add(this.lblAñoCursado);
            this.Controls.Add(this.lblCuatrimestre);
            this.Controls.Add(this.lblCarreraNro);
            this.Name = "ModificarCarrera";
            this.Text = "ModificarCarrera";
            this.Load += new System.EventHandler(this.ModificarCarrera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIdAsig;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asignaturas;
        private System.Windows.Forms.DataGridViewTextBoxColumn AñoCursado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuatrimestre;
        private System.Windows.Forms.DataGridViewButtonColumn Acciones;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.RadioButton rbtSegundoCuatri;
        private System.Windows.Forms.RadioButton rbtPrinerCuatri;
        private System.Windows.Forms.DateTimePicker dtpAñoCursado;
        private System.Windows.Forms.ComboBox cboAsignatura;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblAsignatura;
        private System.Windows.Forms.Label lblAñoCursado;
        private System.Windows.Forms.Label lblCuatrimestre;
        private System.Windows.Forms.Label lblCarreraNro;
    }
}