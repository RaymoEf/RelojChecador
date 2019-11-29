using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaN;

namespace proyectoChecador
{
    public partial class Form1 : Form
    {

        private bool entrada = false;
        private bool salida = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Reloj", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Reloj", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Registro()
        {
            try
            {
                string rpta = "";
                if (this.textBox1.Text == string.Empty)
                {
                    MensajeError("Falta el id_empleado");
                }
                else
                {
                    if (this.entrada)
                    {
                        rpta = nentrada.Insertar(Convert.ToInt32(this.textBox1.Text), Convert.ToDateTime(this.lblfecha.Text), lblhora.Text);
                    }
                    else
                    {
                        rpta = Nsalida.Insertar(Convert.ToInt32(this.textBox1.Text), Convert.ToDateTime(this.lblhora.Text), this.lblhora.Text);
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.entrada)
                        {
                            MensajeOk("Enmtrada Registrada con exito");
                        }
                        else
                        {
                            MensajeOk("Salida registrada con exito");
                        }
                    }
                    else
                    {
                        MensajeError(rpta);
                    }

                    this.entrada = false;
                    this.salida = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void vista_empleado_closing(object sender, FormClosingEventArgs e)
        {
            this.textBox1.Text = Class1.idempleado;
            Class1.idempleado = string.Empty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("T");
            lblfecha.Text = DateTime.Today.ToString("d");
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void horariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            horarios hr = new horarios();
            hr.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            vista_empleados ve = new vista_empleados();
            ve.FormClosing += vista_empleado_closing;
            ve.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime uno = Convert.ToDateTime(lblhora.Text);
            uno=uno.AddMinutes(5);
            MensajeOk(uno.ToString());
        }
    }
}
