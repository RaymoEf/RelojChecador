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
    public partial class vista_horarios : Form
    {
        public vista_horarios()
        {
            InitializeComponent();
        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        private void Mostrar()
        {
            this.dataListado.DataSource = Nhorario.Mostrar();
            this.OcultarColumnas();
            lblTolal.Text = "Total de REgistros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void vista_horarios_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            Class1.idempleado = Convert.ToString(this.dataListado.CurrentRow.Cells["id_empleado"].Value);
            Class1.hora_entrada = Convert.ToString(this.dataListado.CurrentRow.Cells["hora_entrada"].Value);
            Class1.inicio_entrada = Convert.ToString(this.dataListado.CurrentRow.Cells["inicio_entrada"].Value);
            Class1.fin_entrada = Convert.ToString(this.dataListado.CurrentRow.Cells["fin_entrada"].Value);
            Class1.inicio_salida = Convert.ToString(this.dataListado.CurrentRow.Cells["inicio_salida"].Value);
            Class1.fin_salida = Convert.ToString(this.dataListado.CurrentRow.Cells["fin_salida"].Value);

            this.Close();

        }
    }
}
