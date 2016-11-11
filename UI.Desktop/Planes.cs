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
    public partial class Planes : UI.Desktop.Base
    {
        
        public Planes()
        {
            InitializeComponent();
            this.dgvBase.AutoGenerateColumns = false;
            this.GenerarColumnas();
            //this.dgvBase.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.Listar();
        }

        public void Listar()
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> listaEspecialidades = new List<Plan>();
            listaEspecialidades = pl.GetAll();
            this.dgvBase.DataSource = listaEspecialidades;
        }

        public void GenerarColumnas()
        {
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "id_plan";
            colId.HeaderText = "ID";
            colId.DataPropertyName = "ID";
            this.dgvBase.Columns.Add(colId);

            DataGridViewTextBoxColumn colDescripcion = new DataGridViewTextBoxColumn();
            colDescripcion.Name = "descripcion_plan";
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.DataPropertyName = "Descripcion";
            this.dgvBase.Columns.Add(colDescripcion);

            DataGridViewTextBoxColumn colEspecialidad = new DataGridViewTextBoxColumn();
            colEspecialidad.Name = "descripcion_especialidad";
            colEspecialidad.HeaderText = "Descripcion especialidad";
            colEspecialidad.DataPropertyName = "DescripcionEspecialidad";
            this.dgvBase.Columns.Add(colEspecialidad);

        }

        protected override void btnNuevo_Click(object sender, EventArgs e)
        {
            PlanAgregar frmPlaAgr = new PlanAgregar();
            frmPlaAgr.ShowDialog();
            this.Listar();
        }

        protected override void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvBase.SelectedRows.Count > 0)
            {
                PlanAgregar frmPlaAgr = new PlanAgregar();
                frmPlaAgr.Editar((Plan)dgvBase.SelectedRows[0].DataBoundItem);
                frmPlaAgr.ShowDialog();
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
                        PlanLogic plaLog = new PlanLogic();
                        Plan plan = new Plan();
                        plan = (Plan)this.dgvBase.SelectedRows[0].DataBoundItem;
                        plaLog.Delete(plan);
                        MessageBox.Show("Se ha eliminado correctamente el plan", "Eliminación plan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Listar();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una fila", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
