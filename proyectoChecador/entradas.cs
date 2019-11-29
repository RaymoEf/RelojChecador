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
    public partial class entradas : Form
    {

        bool nuevo = false;
        public entradas()
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

        private void Limpiar()
        {
            this.textBox1.Text = string.Empty;
            this.textBox2.Text = string.Empty;
        }

        private void Habilitar(bool valor)
        {
            this.textBox1.ReadOnly = !valor;
            this.textBox2.ReadOnly = !valor;
        }

        private void Botones()
        {
            if (this.nuevo)
            {
                this.Habilitar(true);
                this.buttonnuevo.Enabled = false;
                this.buttonguardar.Enabled = true;
                this.buttoncancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.buttonnuevo.Enabled = true;
                this.buttonguardar.Enabled = false;
                this.buttoncancelar.Enabled = false;
            }
        }

        

        private void Mostrar()
        {
            this.dataListado.DataSource = nentrada.Mostrar();
            lblTolal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void vista_empleado_closing(object sender, FormClosingEventArgs e)
        {
            this.textBox1.Text = Class1.idempleado;
            Class1.idempleado = string.Empty;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            vista_empleados ve = new vista_empleados();
            ve.FormClosing += vista_empleado_closing;
            ve.ShowDialog();
        }

        private void buttonnuevo_Click(object sender, EventArgs e)
        {
            this.nuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.textBox2.Focus();
        }

        private void buttonguardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.textBox1.Text == string.Empty || this.textBox2.Text == string.Empty)
                {
                    MensajeError("Faltan Datos");
                }
                else
                {
                    if(this.nuevo){
                        rpta = nentrada.Justificar(Convert.ToInt32(this.textBox1.Text), this.dateTimePicker1.Value, this.textBox2.Text);
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.nuevo)
                        {
                            this.MensajeOk("Se inserto de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.nuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void buttoncancelar_Click(object sender, EventArgs e)
        {
            this.nuevo = false;
            this.Botones();
            this.Habilitar(false);
            this.Limpiar();
        }

        private void entradas_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }
    }
}
