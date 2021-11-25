using ExamenU3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenU3
{
    public partial class FrmHistorial : Form
    {
        public int id = 0;
        public FrmHistorial()
        {
            InitializeComponent();
        }

//------------------------------------------------------------------------
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                if (id != 0)
                {
                    //buscar con un ORM               
                    var historial = context.Historial.First(x => x.Id == id);
                    if (historial != null)
                    {                       
                        context.Remove(historial);
                        context.SaveChanges();
                    }
                }
            }
            using (var context = new ApplicationDbContext())
            {
                var historial = context.Historial.ToList();
                dgwHistorial.DataSource = historial;

            }
        }

//------------------------------------------------------------------------
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                string dtp = Convert.ToString(dtpFecha.Value.Date);

                var historial = context.Historial.Where(x => x.Fecha.Contains(dtp)).ToList();
                dgwHistorial.DataSource = historial;
            }
        }

//------------------------------------------------------------------------
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Dashboard db = new Dashboard();
            db.Show();
            this.Close();
        }

//------------------------------------------------------------------------
        private void FrmHistorial_Load(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                var historial = context.Historial.ToList();
                dgwHistorial.DataSource = historial;

            }
        }

//------------------------------------------------------------------------
        private void dgwHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dgwHistorial.CurrentRow.Cells[0].Value.ToString());
        }

//------------------------------------------------------------------------
    }
}
