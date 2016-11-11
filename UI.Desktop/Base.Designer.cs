namespace UI.Desktop
{
    partial class Base
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
            this.tlBase = new System.Windows.Forms.TableLayoutPanel();
            this.dgvBase = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.tlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBase)).BeginInit();
            this.SuspendLayout();
            // 
            // tlBase
            // 
            this.tlBase.ColumnCount = 3;
            this.tlBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlBase.Controls.Add(this.dgvBase, 0, 0);
            this.tlBase.Controls.Add(this.btnNuevo, 0, 1);
            this.tlBase.Controls.Add(this.btnEditar, 1, 1);
            this.tlBase.Controls.Add(this.btnEliminar, 2, 1);
            this.tlBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlBase.Location = new System.Drawing.Point(0, 0);
            this.tlBase.Name = "tlBase";
            this.tlBase.RowCount = 2;
            this.tlBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlBase.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlBase.Size = new System.Drawing.Size(555, 356);
            this.tlBase.TabIndex = 0;
            // 
            // dgvBase
            // 
            this.dgvBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlBase.SetColumnSpan(this.dgvBase, 3);
            this.dgvBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBase.Location = new System.Drawing.Point(3, 3);
            this.dgvBase.Name = "dgvBase";
            this.dgvBase.Size = new System.Drawing.Size(549, 321);
            this.dgvBase.TabIndex = 0;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(3, 330);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(240, 330);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(477, 330);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // Base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 356);
            this.Controls.Add(this.tlBase);
            this.Name = "Base";
            this.Text = "Base";
            this.tlBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlBase;
        protected System.Windows.Forms.DataGridView dgvBase;
        protected System.Windows.Forms.Button btnEditar;
        protected System.Windows.Forms.Button btnEliminar;
        protected System.Windows.Forms.Button btnNuevo;
    }
}