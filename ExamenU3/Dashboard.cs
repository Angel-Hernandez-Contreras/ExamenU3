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
    public partial class Dashboard : Form
    {
        bool bandera = true;
        public Dashboard()
        {
            InitializeComponent();
        }

//------------------------------------------------------------------------
        private void btnHistorial_Click(object sender, EventArgs e)
        {
            FrmHistorial frmHistorial = new FrmHistorial();
            frmHistorial.Show();
            this.Hide();
        }

//------------------------------------------------------------------------
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtAgregar.Text.Length != 0 )
            {
                using (var context = new ApplicationDbContext())
                {
                    var ficha = context.Fichas.First(x => x.Id == 1);
                    ficha.Puntos = ficha.Puntos + Convert.ToInt32(txtAgregar.Text);

                    context.SaveChanges();

                    txtFichas.Text = Convert.ToString(ficha.Puntos);
                }
            }
        }

//------------------------------------------------------------------------
        private void btnCara_Click(object sender, EventArgs e)
        {
            bandera = true;
            CaraCruz();
        }

//------------------------------------------------------------------------
        private void btnCruz_Click(object sender, EventArgs e)
        {
            bandera = false;
            CaraCruz();
        }

//------------------------------------------------------------------------
        private void Dashboard_Load(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                var ficha = context.Fichas.First(x => x.Id == 1);
                txtFichas.Text = ficha.Puntos.ToString();
            }
        }

//------------------------------------------------------------------------
        public void CaraCruz()
        {
            if (txtApostar.Text.Length == 0)
            {
                lblApostar.Text = "INGRESE FICHAS!!";
            }           
            else 
            { 
            Random rnd = new Random();
            int numero = rnd.Next(1, 3);

                using (var context = new ApplicationDbContext())
                {

                    string dtp = Convert.ToString(dtpFecha.Value.Date);

                    var ficha = context.Fichas.First(x => x.Id == 1);
                    var historial = new Historial();

                    if (Convert.ToInt32(txtApostar.Text) > ficha.Puntos)
                    {
                        lblResultado.Text = "FICHAS NO VALIDAS";
                    }
                    if ((bandera == true && numero == 1) || (bandera = false && numero == 2))//if si se gana
                    {
                        lblResultado.Text = "AH GANADO";
                        lblResultado.ForeColor = Color.Lime;
                        ficha.Puntos = ficha.Puntos + Convert.ToInt32(txtApostar.Text);
                        historial.Resultado = "GANO";
                        historial.Puntos = Convert.ToInt32(txtApostar.Text);
                        historial.Fecha = dtp;
                    }
                    else //else si se pierde
                    {
                        lblResultado.Text = "AH PERDIDO";
                        lblResultado.ForeColor = Color.Red;
                        ficha.Puntos = ficha.Puntos - Convert.ToInt32(txtApostar.Text);
                        historial.Resultado = "PERDIO";
                        historial.Puntos = Convert.ToInt32(txtApostar.Text);
                        historial.Fecha = dtp;
                    }
                    context.Historial.Add(historial);
                    context.SaveChanges();

                    lblApostar.Text = "";
                    txtFichas.Text = ficha.Puntos.ToString();
                }
            }
        }

//------------------------------------------------------------------------

    }
}
