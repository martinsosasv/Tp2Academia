using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Entidades;

namespace UI.Desktop
{
    public partial class Especialidades : UI.Desktop.Base
    {
        public Especialidades()
        {
            InitializeComponent();
            this.dgvBase.AutoGenerateColumns = false;
            this.GenerarColumnas();
            //this.dgvBase.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.Listar();
        }

        public void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            List<Entidades.Especialidad> listaEspecialidades = new List<Especialidad>();
            listaEspecialidades = el.GetAll();
            this.dgvBase.DataSource = listaEspecialidades;
        }

        public void GenerarColumnas()
        {
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "id_especialidades";
            colId.HeaderText = "ID";
            colId.DataPropertyName = "ID";
            this.dgvBase.Columns.Add(colId);
            
            DataGridViewTextBoxColumn colDescripcion = new DataGridViewTextBoxColumn();
            colDescripcion.Name = "descripcion_especialidades";
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.DataPropertyName = "Descripcion";
            this.dgvBase.Columns.Add(colDescripcion);
        }

        protected override void btnNuevo_Click(object sender, EventArgs e)
        {
            EspecialidadAgregar frmEspAgr = new EspecialidadAgregar();
            frmEspAgr.ShowDialog();
            this.Listar();
        }

        protected override void btnEditar_Click(object sender, EventArgs e)
        {
            if(this.dgvBase.SelectedRows.Count > 0)
            {
                EspecialidadAgregar frmEspAgr = new EspecialidadAgregar();
                frmEspAgr.Editar((Especialidad)dgvBase.SelectedRows[0].DataBoundItem);
                frmEspAgr.ShowDialog();
                this.Listar();
            }
           
        }

        protected override void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvBase.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Esta seguro que desea eliminar esta especialidad?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        EspecialidadLogic espLog = new EspecialidadLogic();
                        Especialidad especialidad = new Especialidad();
                        especialidad = (Especialidad)this.dgvBase.SelectedRows[0].DataBoundItem;
                        espLog.Delete(especialidad.ID);
                        MessageBox.Show("Se ha eliminado correctamente la especialidad", "Eliminación especialidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Listar();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
