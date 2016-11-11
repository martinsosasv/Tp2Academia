using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Base : Form
    {
        public Base()
        {
            InitializeComponent();
            this.dgvBase.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        protected virtual void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        protected virtual void btnEditar_Click(object sender, EventArgs e)
        {

        }

        protected virtual void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
