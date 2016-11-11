using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace UI.Desktop
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.dgvUsuarios.AutoGenerateColumns = false; // No genera columnas que no quiero mostrar en la data grid view como la contraseña y ademas las columnas aparecen ordenadas como quiero yo.
            this.dgvUsuarios.DataSource = ul.GetAll();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDesktop formUD = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            formUD.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Entidades.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            UsuarioDesktop formUD = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formUD.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Entidades.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            UsuarioDesktop formUD = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Baja);
            formUD.ShowDialog();
            this.Listar();
        }
    }
}
