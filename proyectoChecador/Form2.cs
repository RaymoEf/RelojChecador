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
    public partial class Form2 : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public Form2()
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
            this.textBox3.Text = string.Empty;
            this.textBox4.Text = string.Empty;
            this.textBox5.Text = string.Empty;
            this.textBox6.Text = string.Empty;
            this.textBox7.Text = string.Empty;
            this.textBox8.Text = string.Empty;
            this.textBox9.Text = string.Empty;

        }

        private void Habilitar(bool valor)
        {
            this.textBox1.ReadOnly = !valor;
            this.textBox2.ReadOnly = !valor;
            this.textBox3.ReadOnly = !valor;
            this.textBox4.ReadOnly = !valor;
            this.textBox5.ReadOnly = !valor;
            this.textBox6.ReadOnly = !valor;
            this.textBox7.ReadOnly = !valor;
            this.textBox8.ReadOnly = !valor;
            this.textBox9.ReadOnly = !valor;

        }

        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) //Alt + 124
            {
                this.Habilitar(true);
                this.buttonnuevo.Enabled = false;
                this.buttonguardar.Enabled = true;
                this.buttoneditar.Enabled = false;
                this.buttoncancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.buttonnuevo.Enabled = true;
                this.buttonguardar.Enabled = false;
                this.buttoneditar.Enabled = true;
                this.buttoncancelar.Enabled = false;
            }


        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        private void Mostrar()
        {
            this.dataListado.DataSource = Nempleado.Mostrar();
            this.OcultarColumnas();
            lblTolal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = Nempleado.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }

                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.textBox1.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_empleado"].Value);
            this.textBox2.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.textBox3.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellido_paterno"].Value);
            this.textBox4.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellido_materno"].Value);
            this.textBox5.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["domicilio"].Value);
            this.textBox6.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.comboBox1.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["sexo"].Value);
            this.textBox7.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["curp"].Value);
            this.textBox8.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["rfc"].Value);
            this.textBox9.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["salario_dia"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void buttonnuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
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
                if (this.textBox2.Text == string.Empty || this.textBox3.Text == string.Empty || this.textBox4.Text == string.Empty || this.textBox5.Text == string.Empty || this.textBox6.Text == string.Empty || this.textBox7.Text == string.Empty || this.textBox8.Text == string.Empty || this.textBox9.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos");
                    
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = Nempleado.Insertar(this.textBox2.Text.Trim().ToUpper(), this.textBox3.Text.Trim().ToUpper(), this.textBox4.Text.Trim().ToUpper(), this.dateTimePicker1.Value, this.textBox5.Text, this.textBox6.Text, this.comboBox1.Text, this.textBox7.Text.Trim().ToUpper(), this.textBox8.Text.Trim().ToUpper(), Convert.ToDouble(textBox9.Text));
                    }
                    else
                    {
                        rpta = Nempleado.Editar(Convert.ToInt32(this.textBox1.Text), this.textBox2.Text.Trim().ToUpper(), this.textBox3.Text.Trim().ToUpper(), this.textBox4.Text.Trim().ToUpper(), dateTimePicker1.Value, this.textBox5.Text, textBox6.Text, comboBox1.Text, textBox7.Text.Trim().ToUpper(), textBox8.Text.Trim().ToUpper(), Convert.ToDouble(textBox9.Text));

                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
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

        private void buttoneditar_Click(object sender, EventArgs e)
        {
            if (!this.textBox1.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
        }

        private void buttoncancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Habilitar(false);
            this.Limpiar();
            this.textBox1.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
