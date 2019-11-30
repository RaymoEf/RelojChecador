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
    public partial class vista_empleados : Form
    {
        public vista_empleados()
        {
            InitializeComponent();
        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = Nempleado.Mostrar();
            this.OcultarColumnas();
            lblTolal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void vista_empleados_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            Class1.idempleado = Convert.ToString(this.dataListado.CurrentRow.Cells["id_empleado"].Value);
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }
    }
}
